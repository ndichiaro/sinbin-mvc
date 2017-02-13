using System;
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
            var serverPath = String.Concat(server, name);
            var localPath = String.Concat(local, serverPath);
            File.WriteAllBytes(localPath, file);
            return serverPath;
        }
    }
}
