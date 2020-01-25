using System;

namespace Msi.FileStorage
{
  public class FileStorageException : Exception
  {
    public FileStorageException() : base() { }
    public FileStorageException(string message) : base(message) { }
    public FileStorageException(string message, Exception innerException) : base(message, innerException) { }
  }
}