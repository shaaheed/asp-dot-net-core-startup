using Msi.FileStorage.Abstractions;

namespace Msi.FileStorage.Dropbox
{

    public class FileStorage : IFileStorage
  {
    private readonly string secret;
    private readonly string rootPath;

    public FileStorage(FileStorageOptions options)
    {
      secret = options.Secret;
      rootPath = options.RootPath;
    }

    public IDirectoryProxy CreateDirectoryProxy(string relativePath)
    {
      return new DirectoryProxy(secret, rootPath, relativePath);
    }

    public IFileProxy CreateFileProxy(string relativePath, string filename)
    {
      return new FileProxy(secret, rootPath, relativePath, filename);
    }
  }
}