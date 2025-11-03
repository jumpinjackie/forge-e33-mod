#!/bin/sh
# POSIX-compatible replacement for build.bat
# On Linux, "%APPDATA%\Forge" is mapped to "$HOME/forge"

set -eu

# Root of the repo (current working directory when script is run)
ROOT="$(pwd)"

# Directory to use instead of %APPDATA%\Forge on Windows
FORGE_DIR="${HOME}/.forge"

echo "ROOT: $ROOT"
echo "FORGE_DIR: $FORGE_DIR"

# Run CardProcess to regenerate design files
if [ -d "$ROOT/tools/CardProcess" ]; then
  echo "Running CardProcess..."
  cd "$ROOT/tools/CardProcess"
  # run the dotnet tool from the project directory (like pushd/popd + dotnet run in the batch file)
  dotnet run -- genall --base-directory "$ROOT/custom" --output-dir "$ROOT/design"
  cd "$ROOT"
else
  echo "Warning: $ROOT/tools/CardProcess not found; skipping CardProcess step." >&2
fi

# Ensure base Forge directories
mkdir -p "$FORGE_DIR"
mkdir -p "$FORGE_DIR/custom"

# Remove old custom subfolders (cards, editions, tokens)
echo "Cleaning existing custom subfolders..."
rm -rf "$FORGE_DIR/custom/cards" || true
rm -rf "$FORGE_DIR/custom/editions" || true
rm -rf "$FORGE_DIR/custom/tokens" || true

# Recreate them
mkdir -p "$FORGE_DIR/custom/cards"
mkdir -p "$FORGE_DIR/custom/editions"
mkdir -p "$FORGE_DIR/custom/tokens"

# Copy local custom files to the Forge user directory
echo "Copying custom files to $FORGE_DIR/custom/ ..."
if [ -d "$ROOT/custom" ]; then
  # Prefer cp -a (preserve attributes). Fallback to cp -r if -a isn't supported.
  if cp -a "$ROOT/custom/." "$FORGE_DIR/custom/" 2>/dev/null; then
    :
  else
    # fallback: copy non-hidden files and directories
    cp -r "$ROOT/custom/"* "$FORGE_DIR/custom/" 2>/dev/null || true
    # also copy hidden files (.*) if any
    set +e
    for f in "$ROOT/custom"/.[!.]* "$ROOT/custom"/..?*; do
      [ -e "$f" ] || continue
      cp -r "$f" "$FORGE_DIR/custom/" || true
    done
    set -e
  fi
else
  echo "No local custom directory found at $ROOT/custom; nothing to copy." >&2
fi

echo "Done."
