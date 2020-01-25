using Msi.FileStorage.Abstractions;

namespace Msi.FileStorage.FileSystem
{
    public class FileStorage : IFileStorage
  {
    private readonly string rootPath;

    public FileStorage(FileStorageOptions options)
    {
      rootPath = options.RootPath;
    }

    public IDirectoryProxy CreateDirectoryProxy(string relativePath)
    {
      return new DirectoryProxy(rootPath, relativePath);
    }

    public IFileProxy CreateFileProxy(string relativePath, string filename)
    {
      return new FileProxy(rootPath, relativePath, filename);
    }
  }
}