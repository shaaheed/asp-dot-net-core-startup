using System;

namespace Msi.FileStorage
{
  public class FileNotFoundException : FileStorageException
  {
    public FileNotFoundException() : base() { }
    public FileNotFoundException(string message) : base(message) { }
    public FileNotFoundException(string message, Exception innerException) : base(message, innerException) { }
  }
}