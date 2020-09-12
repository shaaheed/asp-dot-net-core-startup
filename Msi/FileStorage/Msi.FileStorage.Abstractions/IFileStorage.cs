namespace Msi.FileStorage.Abstractions
{
  public interface IFileStorage
  {
    IDirectoryProxy CreateDirectoryProxy(string relativePath);

    IFileProxy CreateFileProxy(string relativePath, string filename);
  }
}