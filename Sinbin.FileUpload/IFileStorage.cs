namespace Sinbin.FileUpload
{
    public interface IFileStorage
    {
        string Write(string name, byte[] file);
    }
}
