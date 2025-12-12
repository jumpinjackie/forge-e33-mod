#!/bin/sh
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"

resize_images() {
	local src_dir="$1"
	local dst_dir="$2"
	local width="$3"
	local only_modified="${4:-false}"

	if [ ! -d "$src_dir" ]; then
		echo "Source directory not found: $src_dir" >&2
		return 1
	fi

	if ! command -v magick >/dev/null 2>&1; then
		echo "ImageMagick 'magick' not found in PATH. Install ImageMagick 7+." >&2
		return 1
	fi

	if [ "$only_modified" = true ] && ! command -v git >/dev/null 2>&1; then
		echo "Git not found in PATH. Cannot check modified status." >&2
		return 1
	fi

	echo "Resizing images from $src_dir -> $dst_dir (width ${width}px)"

	# Find JPG/JPEG files (case-insensitive), handle filenames with spaces
	find "$src_dir" -type f \( -iname '*.jpg' -o -iname '*.jpeg' \) -print0 |
	while IFS= read -r -d '' src; do
		rel="${src#$src_dir/}"
		if [ "$only_modified" = true ]; then
			if git ls-files --error-unmatch -- "$src_dir/$rel" >/dev/null 2>&1; then
				# tracked, check if modified
				if git diff --quiet "$src"; then
					continue
				fi
			fi
			# if untracked, continue to process
		fi
		dest="$dst_dir/$rel"
		destdir=$(dirname "$dest")
		mkdir -p "$destdir"

		# Perform resize: set width, keep aspect ratio, strip metadata, set reasonable quality
		magick "$src" -resize "${width}x" -strip -quality 85 "$dest"
		echo "Wrote: $dest"
	done

	echo "Done."
}

# Bulk-resize JPG images from custom/pics/cards/E33 -> custom/thumbs/cards/E33
# Resize width to 672px, keep aspect ratio. Requires ImageMagick (`magick`).
WIDTH=672

# Parse command-line options
only_modified=false
while getopts "m" opt; do
    case $opt in
        m) only_modified=true ;;
        *) echo "Usage: $0 [-m]" >&2; exit 1 ;;
    esac
done

# Run the resizing function
resize_images "$SCRIPT_DIR/custom/pics/cards/E33" "$SCRIPT_DIR/custom/thumbs/cards/E33" "$WIDTH" "$only_modified"
resize_images "$SCRIPT_DIR/custom/pics/cards/E3C" "$SCRIPT_DIR/custom/thumbs/cards/E3C" "$WIDTH" "$only_modified"
resize_images "$SCRIPT_DIR/custom/pics/tokens/E33" "$SCRIPT_DIR/custom/thumbs/tokens/E33" "$WIDTH" "$only_modified"
