using System.Configuration;
using System.IO;

namespace Sinbin.FileUpload
{
    public class LocalFileStorage : IFileStorage
    {
        string server = ConfigurationManager.AppSettings["Server"];
        string local = ConfigurationManager.AppSettings["Local"];

        public string Write(string name, byte[] file)
        {
            var serverPath = string.Concat(server, name);
            var localPath = string.Concat(local, serverPath);
            File.WriteAllBytes(localPath, file);
            return serverPath;
        }
    }
}
