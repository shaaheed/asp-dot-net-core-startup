using System;

namespace Msi.FileStorage
{
  public class DirectoryNotFoundException : FileStorageException
  {
    public DirectoryNotFoundException() : base() { }
    public DirectoryNotFoundException(string message) : base(message) { }
    public DirectoryNotFoundException(string message, Exception innerException) : base(message, innerException) { }
  }
}