#!/bin/sh
# POSIX-compatible replacement for build.bat
# On Linux, "%APPDATA%\Forge" is mapped to "$HOME/forge"

set -eu

# Root of the repo (directory containing this script)
ROOT="$(cd "$(dirname "$0")" && pwd)"

IMG_BASE_URL="https://jumpinjackie.github.io/e33-reference-art/images/spoilers/beta"

# Directory to use instead of %APPDATA%\Forge on Windows
FORGE_DIR="${HOME}/.forge"
PICS_DIR="${HOME}/.cache/forge/pics"

echo "ROOT: $ROOT"
echo "FORGE_DIR: $FORGE_DIR"
echo "PICS_DIR: $PICS_DIR"

# Run CardProcess to regenerate design files
if [ -d "$ROOT/tools/CardProcess" ]; then
  echo "Running CardProcess..."
  cd "$ROOT/tools/CardProcess"
  # run the dotnet tool from the project directory (like pushd/popd + dotnet run in the batch file)
  dotnet run -- genall --base-directory "$ROOT/custom" --output-dir "$ROOT/design" --linkify-captions --image-base-url "$IMG_BASE_URL"
  cd "$ROOT"
else
  echo "Warning: $ROOT/tools/CardProcess not found; skipping CardProcess step." >&2
fi

# Ensure base Forge directories
mkdir -p "$FORGE_DIR"
mkdir -p "$FORGE_DIR/custom"
mkdir -p "$PICS_DIR/cards/E33"
mkdir -p "$PICS_DIR/tokens/E33"

# Remove old custom subfolders (cards, editions, tokens)
echo "Cleaning existing custom subfolders..."
rm -rf "$FORGE_DIR/custom/cards" || true
rm -rf "$FORGE_DIR/custom/editions" || true
rm -rf "$FORGE_DIR/custom/tokens" || true
rm -rf "$PICS_DIR/cards/E33" || true
rm -rf  "$PICS_DIR/tokens/E33" || true

# Recreate them
mkdir -p "$FORGE_DIR/custom/cards"
mkdir -p "$FORGE_DIR/custom/editions"
mkdir -p "$FORGE_DIR/custom/tokens"
mkdir -p "$PICS_DIR/cards/E33"
mkdir -p "$PICS_DIR/tokens/E33"

# Copy specific custom subdirectories to the Forge user directory
echo "Copying custom subdirectories to $FORGE_DIR/custom/ ..."
if [ -d "$ROOT/custom" ]; then
  for dir in cards editions tokens; do
    if [ -d "$ROOT/custom/$dir" ]; then
      echo "Copying $dir..."
      if cp -a "$ROOT/custom/$dir" "$FORGE_DIR/custom/" 2>/dev/null; then
        :
      else
        cp -r "$ROOT/custom/$dir" "$FORGE_DIR/custom/" || true
      fi
    else
      echo "Warning: $ROOT/custom/$dir not found" >&2
    fi
  done
else
  echo "No local custom directory found at $ROOT/custom; nothing to copy." >&2
fi

# Copy custom subdirectories to custom/dist/forge
echo "Copying custom subdirectories to $ROOT/custom/dist/forge/custom/ ..."
mkdir -p "$ROOT/custom/dist/forge/custom"
if [ -d "$ROOT/custom" ]; then
  for dir in cards editions tokens; do
    if [ -d "$ROOT/custom/$dir" ]; then
      echo "Copying $dir to dist/forge..."
      if cp -a "$ROOT/custom/$dir" "$ROOT/custom/dist/forge/custom/" 2>/dev/null; then
        :
      else
        cp -r "$ROOT/custom/$dir" "$ROOT/custom/dist/forge/custom/" || true
      fi
    else
      echo "Warning: $ROOT/custom/$dir not found" >&2
    fi
  done
else
  echo "No local custom directory found at $ROOT/custom; nothing to copy." >&2
fi

if [ -d "$ROOT/custom/pics" ]; then
  echo "Copying card and token pictures to $PICS_DIR..."
  # Copy cards
  if [ -d "$ROOT/custom/pics/cards" ]; then
    echo "Copying card pictures..."
    if cp -a "$ROOT/custom/pics/cards/." "$PICS_DIR/cards/" 2>/dev/null; then
      :
    else
      cp -r "$ROOT/custom/pics/cards/." "$PICS_DIR/cards/" || true
    fi
  else
    echo "Warning: No card pictures found in $ROOT/custom/pics/cards" >&2
  fi
  
  # Copy tokens
  if [ -d "$ROOT/custom/pics/tokens" ]; then
    echo "Copying token pictures..."
    if cp -a "$ROOT/custom/pics/tokens/." "$PICS_DIR/tokens/" 2>/dev/null; then
      :
    else
      cp -r "$ROOT/custom/pics/tokens/." "$PICS_DIR/tokens/" || true
    fi
  else
    echo "Warning: No token pictures found in $ROOT/custom/pics/tokens" >&2
  fi
fi

# Copy pictures to custom/dist/forge
echo "Copying card and token pictures to $ROOT/custom/dist/forge/pics/..."
mkdir -p "$ROOT/custom/dist/forge/pics/cards"
mkdir -p "$ROOT/custom/dist/forge/pics/tokens"
if [ -d "$ROOT/custom/pics" ]; then
  # Copy cards
  if [ -d "$ROOT/custom/pics/cards" ]; then
    echo "Copying card pictures to dist/forge..."
    if cp -a "$ROOT/custom/pics/cards/." "$ROOT/custom/dist/forge/pics/cards/" 2>/dev/null; then
      :
    else
      cp -r "$ROOT/custom/pics/cards/." "$ROOT/custom/dist/forge/pics/cards/" || true
    fi
  else
    echo "Warning: No card pictures found in $ROOT/custom/pics/cards" >&2
  fi
  
  # Copy tokens
  if [ -d "$ROOT/custom/pics/tokens" ]; then
    echo "Copying token pictures to dist/forge..."
    if cp -a "$ROOT/custom/pics/tokens/." "$ROOT/custom/dist/forge/pics/tokens/" 2>/dev/null; then
      :
    else
      cp -r "$ROOT/custom/pics/tokens/." "$ROOT/custom/dist/forge/pics/tokens/" || true
    fi
  else
    echo "Warning: No token pictures found in $ROOT/custom/pics/tokens" >&2
  fi
fi

# Copy images for Cockatrice, changing .full.jpg to .jpg
echo "Copying images for Cockatrice..."
mkdir -p "$ROOT/custom/dist/cockatrice/pics"
for set in E33 E3C; do
  if [ -d "$ROOT/custom/pics/cards/$set" ]; then
    echo "Copying $set images..."
    for file in "$ROOT/custom/pics/cards/$set"/*.full.jpg; do
      if [ -f "$file" ]; then
        base=$(basename "$file" .full.jpg)
        cp "$file" "$ROOT/custom/dist/cockatrice/pics/$base.jpg"
      fi
    done
  else
    echo "Warning: No images found for $set in $ROOT/custom/pics/cards/$set" >&2
  fi
done

# Copy token images for Cockatrice
if [ -d "$ROOT/custom/tokens" ] && [ -d "$ROOT/custom/pics/tokens" ]; then
  echo "Copying token images..."
  for txt in "$ROOT/custom/tokens"/*.txt; do
    if [ -f "$txt" ]; then
      name=$(grep '^Name:' "$txt" | sed 's/^Name://' | sed 's/^[[:space:]]*//' | sed 's/[[:space:]]*$//')
      if [ -n "$name" ]; then
        base=$(basename "$txt" .txt)
        src="$ROOT/custom/pics/tokens/E33/$base.jpg"
        if [ -f "$src" ]; then
          cp "$src" "$ROOT/custom/dist/cockatrice/pics/$name.jpg"
        else
          echo "Warning: Image not found for token $base at $src" >&2
        fi
      else
        echo "Warning: No Name found in $txt" >&2
      fi
    fi
  done
else
  echo "Warning: Token directories not found" >&2
fi

echo "Done."
