#!/usr/bin/env bash
# Regenerate custom/design/patch_order.txt from git history.
#
# Lists the canonical card names whose images under custom/src_pics/cards were
# added or modified between a given commit and HEAD. Deleted images are ignored,
# as are tokens (custom/src_pics/tokens) and the card back (__CARD_BACK__.jpg).
#
# The filename -> card name mapping mirrors card_process.cs:
#   - image filename = canonical name with diacritics stripped
#     (Unicode NFD -> drop combining marks -> NFC), see NormalizeQuery()
#   - split cards use the two halves joined with " // " removed, see GetImageNames()
#
# Canonical names are sourced from:
#   - E33:  custom/cards/<letter>/*.txt  (every Name: line; AlternateMode:Split
#           yields an additional combined "Left // Right" entry)
#   - E3C:  custom/editions/Clair Obscur Expedition 33 Commander.txt
#           (flavorName wins over the reprint name)
#
# Requires: git, python3

set -euo pipefail

ROOT="$(cd "$(dirname "$0")" && pwd)"

usage() {
    cat <<EOF
Usage: $(basename "$0") <commit>

Regenerate custom/design/patch_order.txt with the canonical card names whose
images under custom/src_pics/cards were added or modified between <commit> and
HEAD.

Arguments:
  <commit>   The base git commit (any revision git understands, e.g. a SHA,
             branch, tag, or HEAD~N).

Examples:
  $(basename "$0") HEAD~1
  $(basename "$0") 97a585bfd39ffd71f382487af64a5f93c0c00557
EOF
}

if [ "${1:-}" = "-h" ] || [ "${1:-}" = "--help" ]; then
    usage
    exit 0
fi

if [ "$#" -lt 1 ]; then
    usage >&2
    exit 1
fi

COMMIT="$1"

for cmd in git python3; do
    if ! command -v "$cmd" >/dev/null 2>&1; then
        echo "Error: $cmd not found in PATH." >&2
        exit 1
    fi
done

if [ "$(git -C "$ROOT" cat-file -t "$COMMIT" 2>/dev/null)" != "commit" ]; then
    echo "Error: '$COMMIT' is not a commit in this repository." >&2
    exit 1
fi

TMP="$(mktemp)"
trap 'rm -f "$TMP"' EXIT

git -C "$ROOT" diff --name-status "$COMMIT" HEAD -- custom/src_pics/cards > "$TMP"

python3 - "$ROOT" "$TMP" <<'PY'
import os, re, sys, unicodedata

repo = sys.argv[1]
diff_file = sys.argv[2]


def strip_diacritics(s):
    nfd = unicodedata.normalize('NFD', s)
    return unicodedata.normalize('NFC', ''.join(c for c in nfd if not unicodedata.combining(c)))


slug2name = {}

# E33 card scripts: every Name: line is a face name; splits get a combined entry.
cards_dir = os.path.join(repo, 'custom', 'cards')
for root, _dirs, files in os.walk(cards_dir):
    for fn in files:
        if not fn.endswith('.txt'):
            continue
        with open(os.path.join(root, fn), encoding='utf-8') as f:
            text = f.read()
        names = [m.strip() for m in re.findall(r'^Name:(.+)$', text, flags=re.M)]
        if not names:
            continue
        mode = ''
        mm = re.search(r'^AlternateMode:(.+)$', text, flags=re.M)
        if mm:
            mode = mm.group(1).strip()
        for n in names:
            slug2name[strip_diacritics(n)] = n
        if mode == 'Split' and len(names) >= 2:
            slug2name[strip_diacritics(names[0]) + strip_diacritics(names[1])] = (
                names[0] + ' // ' + names[1]
            )

# E3C commander reprints: flavorName wins over the reprint name.
ed = os.path.join(repo, 'custom', 'editions', 'Clair Obscur Expedition 33 Commander.txt')
with open(ed, encoding='utf-8') as f:
    for line in f:
        line = line.rstrip('\n')
        if not line or line.startswith('['):
            continue
        m = re.match(r'^\S+\s+\S+\s+(.+?)\s+@', line)
        if not m:
            continue
        fm = re.search(r'\$\{"flavorName"\s*:\s*"([^"]*)"\}', line)
        name = fm.group(1) if fm else m.group(1).strip()
        slug2name[strip_diacritics(name)] = name

with open(diff_file, encoding='utf-8') as f:
    diff_lines = f.read().splitlines()

by_slug = {}
orphans = []
for line in diff_lines:
    parts = line.split('\t')
    if len(parts) < 2:
        continue
    status, path = parts[0], parts[-1]
    if status not in ('A', 'M'):
        continue
    if not path.endswith('.full.jpg'):
        continue
    slug = os.path.basename(path)[:-len('.full.jpg')]
    name = slug2name.get(slug)
    if name is None:
        orphans.append((status, path))
    else:
        by_slug[slug] = name

if orphans:
    print('Error: could not map these changed images to a card name:', file=sys.stderr)
    for status, path in orphans:
        print('  %s\t%s' % (status, path), file=sys.stderr)
    sys.exit(1)

names = sorted(by_slug.values(), key=lambda x: (strip_diacritics(x).lower(), x))

# Round-trip check: every name must correspond to an existing .full.jpg.
missing_img = []
for n in names:
    slug = strip_diacritics(n.replace(' // ', ''))
    ok = (
        os.path.isfile(os.path.join(repo, 'custom/src_pics/cards/E33', slug + '.full.jpg'))
        or os.path.isfile(os.path.join(repo, 'custom/src_pics/cards/E3C', slug + '.full.jpg'))
    )
    if not ok:
        missing_img.append(n)

if missing_img:
    print('Error: these card names have no matching image file:', file=sys.stderr)
    for n in missing_img:
        print('  ' + n, file=sys.stderr)
    sys.exit(1)

content = '\n'.join(names) + '\n'
target = os.path.join(repo, 'custom', 'design', 'patch_order.txt')
with open(target, 'w', encoding='utf-8') as f:
    f.write(content)

for n in names:
    print(n)
print('Wrote %d card name(s) to custom/design/patch_order.txt' % len(names), file=sys.stderr)
PY
