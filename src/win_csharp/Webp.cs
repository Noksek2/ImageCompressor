
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace ImageCompressor
{
    static public class WebP
    {
        public static Bitmap ResizeBitmap(Bitmap original, int newWidth, int newHeight)
        {
            Bitmap resized = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(original, 0, 0, newWidth, newHeight);
            }
            original.Dispose();
            return resized;
        }
        [DllImport("libwebp.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr WebPDecodeRGBA(byte[] data, int dataSize, out int width, out int height);

        [DllImport("libwebp.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int WebPEncodeBGR(IntPtr ptrIn, int width, int height, int stride, float quality, out IntPtr ptrOut);

        [DllImport("libwebp.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int WebPEncodeLosslessBGR(IntPtr ptrIn, int width, int height, int stride, out IntPtr ptrOut);

        [DllImport("libwebp.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int WebPFree(IntPtr ptr);
        public static Bitmap DecodeWebPToBitmap(string filePath)
        {
            byte[] webpData = File.ReadAllBytes(filePath);

            int width, height;
            IntPtr rawData = WebPDecodeRGBA(webpData, webpData.Length, out width, out height);

            if (rawData == IntPtr.Zero)
                throw new Exception("WebP 디코딩 실패");

            // 비트맵 생성
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            // 메모리 복사
            var bmpData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            int byteCount = width * height * 4;
            unsafe
            {
                Buffer.MemoryCopy((void*)rawData, (void*)bmpData.Scan0, byteCount, byteCount);
            }
            bmp.UnlockBits(bmpData);
            WebPFree(rawData);
            // 네이티브 메모리 해제 필요 없음 (WebPDecodeRGBA 내부에서 관리)
            return bmp;
        }
        public static void SaveLossy(Bitmap bmp, string path, int quality)
        {
            byte[] arrayWebP = null;

            EncodeLossy(bmp, out arrayWebP, quality);

            File.WriteAllBytes(path, arrayWebP);
        }

        private static void EncodeLossy(Bitmap bmp, out byte[] arrayWebP, int quality)
        {
            IntPtr unmanagedPtr;
            BitmapData dataBitmap = null;

            dataBitmap = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            int size = WebPEncodeBGR(dataBitmap.Scan0, bmp.Width, bmp.Height, dataBitmap.Stride, quality, out unmanagedPtr);

            arrayWebP = new byte[size];
            Marshal.Copy(unmanagedPtr, arrayWebP, 0, size);

            bmp.UnlockBits(dataBitmap);

            WebPFree(unmanagedPtr);
        }

        public static void SaveLossless(Bitmap bmp, string path)
        {
            byte[] arrayWebP = null;

            EncodeLossless(bmp, out arrayWebP);

            File.WriteAllBytes(path, arrayWebP);
        }

        private static void EncodeLossless(Bitmap bmp, out byte[] arrayWebP)
        {
            IntPtr unmanagedPtr;
            BitmapData dataBitmap = null;

            dataBitmap = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            int size = WebPEncodeLosslessBGR(dataBitmap.Scan0, bmp.Width, bmp.Height, dataBitmap.Stride, out unmanagedPtr);

            arrayWebP = new byte[size];
            Marshal.Copy(unmanagedPtr, arrayWebP, 0, size);

            bmp.UnlockBits(dataBitmap);

            WebPFree(unmanagedPtr);
        }
    }
}