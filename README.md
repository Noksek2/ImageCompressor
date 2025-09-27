**Documentation is a work in progress.**

# ImageCompressor 0.1.0-beta
## README 
- KOREAN : [ImageCompressor (by noksek2) 한국어판 문서](./README_KR.md)

## Why I Made This
- I needed to compress and convert the format of numerous image files.

- I'm a computer science major but had nothing to show for it.

- Because it's fun.

# How to Use ImageCompressor

A simple tool for image conversion and compression.

## Basic Usage

1.  **Set Options**: First, configure all necessary conversion options (e.g., format, quality, size, save path).
2.  **Execute**: Click the `Open & Convert` button.
3.  **Select Files**: When the file dialog opens, select one or more image files you wish to convert.
4.  **Check Results**: The conversion starts automatically upon selection. You can monitor the progress and see the results in the message log at the bottom.

## Feature Guide

### Image Option

-   **Format**: Select the target image format (e.g., JPG, BMP) (*PNG,WEBP: experimental)
-   **Quality**: Adjust the compression quality of the image. (Higher numbers mean better quality).
-   **Rotation & Flip**: Rotate(90, 180, 270) or flip the image horizontally/vertically. 

### Image Size

-   **Ratio**: Resizes the image based on a percentage of its original size. (Default: 100%).
-   **Set owner size (Custom Size)**: Manually enter a specific width (W) and height (H).

### Path Option

-   **Path mode**: The default 'Auto' mode saves the converted files to the same folder as the original files.
-   **Create /res folder**: If checked, this creates a subfolder named '/res' in the original directory and saves the output there.
-   **Delete origin files**: Deletes the original files after conversion is complete. **(Caution: This action may be irreversible.)**

### Other

-   **Message option**: Choose the type of messages to display in the log. (Show all, Only error, None).
-   **Clear message**: Clears all messages from the log.


## Details

- JPG and BMP are supported (Experimentally: WEBP, PNG).
This is a beta version and feature support is still incomplete, as I personally use JPG files most of the time. Currently, the only conversion confirmed to be stable is: JPG, BMP <-> JPG, BMP

- Quality adjustment (stable only for JPG/JPEG, BMP).
- Image resizing (by ratio or custom dimensions).

## Known Issues 🐛
There are bugs with WebP <-> JPG conversions.

These issues are scheduled to be fixed.

## Usage Notes ⚠️
-By default, the Quality setting cannot be set higher than 95.

-If you attempt an unsupported conversion, an error message will appear. Please read the message carefully.

-Also, even if I receive bug reports, I might not fix them because I'm lazy.

(Translated by Gemini)
