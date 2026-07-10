![License](https://img.shields.io/badge/license-MIT-green)

# ImageCompressor 0.2.2

<img width="500" height="550" alt="image" src="./thumb.jpg" />

## README ❗
- KOREAN : [ImageCompressor (by noksek2) 한국어판 문서](./README_KR.md)

## Platform
- Windows 🪟 : C# Winform 


## What's this for?  🤔
- Batch compression and format conversion of image files
- Just for practice

## How to Use (Basic) 🔧

1. **Set Options**: First, configure all the options you need (format, quality, size, save path, etc.).
2. **Execute**: Click the `Open & Convert` button.
3. **Select Files**: When the file dialog opens, select one or more image files you want to convert.
4. **Check Results**: The conversion starts automatically right after selection. You can check the progress and results in the message log at the bottom. 

For more details, check the wiki separately.

## Feature Guide

### Image Option ⚙️
- **Format**: Select the target image format (JPG, PNG, etc.).
- **Quality**: Adjust the compression quality.  (Higher number = better quality.  85~90 recommended. 95 or higher is disabled)
- **Rotation & Flip**: Rotate the image in 90-degree increments or flip it horizontally/vertically. 

### Image Size 🌄
- **Ratio**: Resize based on the percentage of the original image size. (Default: 100%)
- **Custom size**:  Manually enter the width (W) and height (H) you want.  (Caution: )

### Path Option 📂
- **Path mode**: The default 'Auto' mode saves the converted files in the same folder as the original files. 
- **Output folder**: If checked, creates a '/res' subfolder in the original directory and saves the results there.
- **Delete origin files**: Deletes the original files after conversion is complete. **(Caution: May be difficult to recover.)**

### Other
- **Message option**: Choose what kind of messages to display in the log (Show all, Only errors, None).
- **Clear message**: Clears all messages from the log.

## Usage Notes ⚠️
- By default, Quality cannot be set higher than 98.
- If you try an unsupported conversion, you'll get an error.  Please read the messages carefully.
- Development may be discontinued due to lack of users.
- This is still a beta version, and feature support is incomplete.

## Bugs 🐛
**v0.1.0**
- WebP conversion has bugs. File size gets too large or conversion results are weird.  Seems to be due to color differences between libwebp and GDI+. Fixed in v0.2.0

## Cross-platform support (planned for 3.0)
- Linux (Debian/Ubuntu) 🐧 : C GTK3.0


## Third-party Libraries (`./CREDITS`)
This software uses the following open-source libraries:

*  **libwebp** - [BSD 3-Clause License](https://github.com/webmproject/libwebp/blob/main/COPYING)
    Copyright (c) 2010, Google Inc. All rights reserved.
	