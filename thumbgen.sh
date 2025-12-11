#!/bin/sh
set -euo pipefail

resize_images() {
	local src_dir="$1"
	local dst_dir="$2"
	local width="$3"

	if [ ! -d "$src_dir" ]; then
		echo "Source directory not found: $src_dir" >&2
		return 1
	fi

	if ! command -v magick >/dev/null 2>&1; then
		echo "ImageMagick 'magick' not found in PATH. Install ImageMagick 7+." >&2
		return 1
	fi

	echo "Resizing images from $src_dir -> $dst_dir (width ${width}px)"

	# Find JPG/JPEG files (case-insensitive), handle filenames with spaces
	find "$src_dir" -type f \( -iname '*.jpg' -o -iname '*.jpeg' \) -print0 |
	while IFS= read -r -d '' src; do
		rel="${src#$src_dir/}"
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

# Run the resizing function
resize_images "custom/pics/cards/E33" "custom/thumbs/cards/E33" "$WIDTH"
resize_images "custom/pics/cards/E3C" "custom/thumbs/cards/E3C" "$WIDTH"
resize_images "custom/pics/tokens/E33" "custom/thumbs/tokens/E33" "$WIDTH"
