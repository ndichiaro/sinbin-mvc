using System.Configuration;
using System.IO;
using Amazon.S3;
using Amazon.S3.Model;

namespace Sinbin.FileUpload
{
    public class AmazonFileStorage : IFileStorage
    {
        private readonly IAmazonS3 _client;
        private string _bucket;
        private const string Host = "s3.amazonaws.com";
        public AmazonFileStorage()
        {
            _client = new AmazonS3Client();
            _bucket = ConfigurationManager.AppSettings["bucket"];
        }

        public string Write(string name, byte[] file)
        {
            var request = new PutObjectRequest
            {
                BucketName = _bucket,
                Key = name
            };

            using (var stream = new MemoryStream(file))
            {
                request.InputStream = stream;
                _client.PutObject(request);
            }
            return string.Concat("https://", Host, "/", _bucket, "/", name);
        }
    }
}
