using System.IO;
using System.Web;

namespace Sinbin.Web.Helpers
{
    public static class FileHelpers
    {
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
            return data;
        }

        public static string ConvertEmailToFileName(string email, string fileName)
        {
            // split the file name by . and take 
            // the last as the file extension
            var arr = fileName.Split('.');
            var extension = arr[arr.Length - 1];
            var name = email.Split('@')[0];
            return string.Concat(name, ".", extension);
        }
    }
}