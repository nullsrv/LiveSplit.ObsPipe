using System;
using ObsPipeProto = global::ObsPipe.Proto;

namespace LiveSplit.ObsPipe
{
    public enum ImageFormat
    {
        Raw  = 0,
        Bmp  = 1,
        Jpeg = 2,
        Png  = 3,
        Tiff = 5,
    }

    public enum PixelFormat
    {
        Rgba = 0,
        Bgra = 1,
    }

    public enum Compression
    {
        None = 0,
        Zlib = 1,
    }

    public class ObsPipeHelpers
    {
        public static ImageFormat ImageFormatFromProto(ObsPipeProto.ImageFormat format)
        {
            switch (format)
            {
                case ObsPipeProto.ImageFormat.Raw:  return ImageFormat.Raw;
                case ObsPipeProto.ImageFormat.Bmp:  return ImageFormat.Bmp;
                case ObsPipeProto.ImageFormat.Jpeg: return ImageFormat.Jpeg;
                case ObsPipeProto.ImageFormat.Png:  return ImageFormat.Png;
                case ObsPipeProto.ImageFormat.Tiff: return ImageFormat.Tiff;
            }

            throw new ArgumentException("Invalid image format");
        }

        public static ObsPipeProto.ImageFormat ImageFormatToProto(ImageFormat format)
        {
            switch (format)
            {
                case ImageFormat.Raw:  return ObsPipeProto.ImageFormat.Raw;
                case ImageFormat.Bmp:  return ObsPipeProto.ImageFormat.Bmp;
                case ImageFormat.Jpeg: return ObsPipeProto.ImageFormat.Jpeg;
                case ImageFormat.Png:  return ObsPipeProto.ImageFormat.Png;
                case ImageFormat.Tiff: return ObsPipeProto.ImageFormat.Tiff;
            }

            throw new ArgumentException("Invalid image format");
        }

        public static ImageFormat ImageFormatFromSystem(System.Drawing.Imaging.ImageFormat format)
        {
            if (format == System.Drawing.Imaging.ImageFormat.Bmp)  return ImageFormat.Bmp;
            if (format == System.Drawing.Imaging.ImageFormat.Png)  return ImageFormat.Png;
            if (format == System.Drawing.Imaging.ImageFormat.Jpeg) return ImageFormat.Jpeg;
            if (format == System.Drawing.Imaging.ImageFormat.Tiff) return ImageFormat.Tiff;

            throw new ArgumentException("Unsupported image format");
        }

        public static System.Drawing.Imaging.ImageFormat ImageFormatToSystem(ImageFormat format)
        {
            switch (format)
            {
                case ImageFormat.Bmp:  return System.Drawing.Imaging.ImageFormat.Bmp;
                case ImageFormat.Jpeg: return System.Drawing.Imaging.ImageFormat.Jpeg;
                case ImageFormat.Png:  return System.Drawing.Imaging.ImageFormat.Png;
                case ImageFormat.Tiff: return System.Drawing.Imaging.ImageFormat.Tiff;
            }

            throw new ArgumentException("Unsupported image format");
        }

        public static PixelFormat PixelFormatFromProto(ObsPipeProto.PixelFormat format)
        {
            switch (format) 
            {
                case ObsPipeProto.PixelFormat.Bgra: return PixelFormat.Bgra;
                case ObsPipeProto.PixelFormat.Rgba: return PixelFormat.Rgba;
            }

            throw new ArgumentException("Invalid pixel format");
        }

        public static ObsPipeProto.PixelFormat PixelFormatToProto(PixelFormat format)
        {
            switch (format)
            {
                case PixelFormat.Bgra: return ObsPipeProto.PixelFormat.Bgra;
                case PixelFormat.Rgba: return ObsPipeProto.PixelFormat.Rgba;
            }

            throw new ArgumentException("Invalid pixel format");
        }

        public static PixelFormat PixelFormatFromSystem(System.Drawing.Imaging.PixelFormat format)
        {
            if (format == System.Drawing.Imaging.PixelFormat.Format32bppArgb) return PixelFormat.Bgra; // ??

            throw new ArgumentException("Invalid pixel format");
        }

        public static Compression CompressionFromProto(ObsPipeProto.Compression compression)
        {
            switch (compression)
            {
                case ObsPipeProto.Compression.None: return Compression.None;
                case ObsPipeProto.Compression.Zlib: return Compression.Zlib;
            }

            throw new ArgumentException("Invalid compression");
        }

        public static Google.Protobuf.WellKnownTypes.Timestamp ToGoogleTimestamp(DateTime timestamp)
        {
            return Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(timestamp);
        }
    }
}
