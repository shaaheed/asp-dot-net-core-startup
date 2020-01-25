using System;

namespace Msi.FileStorage
{
  public class PathTooLongException : FileStorageException
  {
    public PathTooLongException() : base() { }
    public PathTooLongException(string message) : base(message) { }
    public PathTooLongException(string message, Exception innerException) : base(message, innerException) { }
  }
}