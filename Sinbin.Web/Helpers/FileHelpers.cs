using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Sinbin.Web.Helpers
{
    public static class FileHelpers
    {
        #region Static Methods
        public static byte[] GetPostedFileBytes(HttpPostedFileBase file)
        {
            byte[] data;
            using (var inputStream = file.InputStream)
            {
                var memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
            }
            return RotateImageByExifOrientationData(data);
        }

        public static string ConvertEmailToFileName(string email, string fileName)
        {
            // split the file name by . and take 
            // the last as the file extension
            var arr = fileName.Split('.');
            var extension = arr[arr.Length - 1];
            var emailArr = email.Split('@');
            var name = emailArr[0];
            var host = emailArr[1].Split('.')[0];
            return string.Concat(name, host, ".", extension);
        }

        /// <summary>
        /// Rotate the given image byte stream according to Exif Orientation data
        /// </summary>
        /// <param name="source">byte array of source file</param>
        /// <param name="updateExifData">set it to TRUE to update image Exif data after rotation (default is TRUE)</param>
        /// <returns>The RotateFlipType value corresponding to the applied rotation. If no rotation occurred, RotateFlipType.RotateNoneFlipNone will be returned.</returns>
        public static byte[] RotateImageByExifOrientationData(byte[] source, bool updateExifData = true)
        {
            // Rotate the image according to EXIF data
            Bitmap bmp;
            using (var ms = new MemoryStream(source))
            {
                bmp = new Bitmap(ms);
                RotateFlipType fType = RotateImageByExifOrientationData(bmp, updateExifData);
                return ImageToByte(bmp);
            }
        }

        /// <summary>
        /// Rotate the given bitmap according to Exif Orientation data
        /// </summary>
        /// <param name="img">source image</param>
        /// <param name="updateExifData">set it to TRUE to update image Exif data after rotation (default is TRUE)</param>
        /// <returns>The RotateFlipType value corresponding to the applied rotation. If no rotation occurred, RotateFlipType.RotateNoneFlipNone will be returned.</returns>
        public static RotateFlipType RotateImageByExifOrientationData(Image img, bool updateExifData = true)
        {
            int orientationId = 0x0112;
            var fType = RotateFlipType.RotateNoneFlipNone;
            if (img.PropertyIdList.Contains(orientationId))
            {
                var pItem = img.GetPropertyItem(orientationId);
                fType = GetRotateFlipTypeByExifOrientationData(pItem.Value[0]);
                if (fType != RotateFlipType.RotateNoneFlipNone)
                {
                    img.RotateFlip(fType);
                    if (updateExifData) img.RemovePropertyItem(orientationId); // Remove Exif orientation tag
                }
            }
            return fType;
        }

        /// <summary>
        /// Return the proper System.Drawing.RotateFlipType according to given orientation EXIF metadata
        /// </summary>
        /// <param name="orientation">Exif "Orientation"</param>
        /// <returns>the corresponding System.Drawing.RotateFlipType enum value</returns>
        public static RotateFlipType GetRotateFlipTypeByExifOrientationData(int orientation)
        {
            switch (orientation)
            {
                case 1:
                default:
                    return RotateFlipType.RotateNoneFlipNone;
                case 2:
                    return RotateFlipType.RotateNoneFlipX;
                case 3:
                    return RotateFlipType.Rotate180FlipNone;
                case 4:
                    return RotateFlipType.Rotate180FlipX;
                case 5:
                    return RotateFlipType.Rotate90FlipX;
                case 6:
                    return RotateFlipType.Rotate90FlipNone;
                case 7:
                    return RotateFlipType.Rotate270FlipX;
                case 8:
                    return RotateFlipType.Rotate270FlipNone;
            }
        }

        /// <summary>
        /// Converts an image to a byte array
        /// </summary>
        /// <param name="img">Source Image</param>
        /// <returns></returns>
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        #endregion
    }
}