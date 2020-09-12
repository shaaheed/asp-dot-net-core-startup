using System;

namespace Msi.FileStorage
{
  public class AccessDeniedException : FileStorageException
  {
    public AccessDeniedException() : base() { }
    public AccessDeniedException(string message) : base(message) { }
    public AccessDeniedException(string message, Exception innerException) : base(message, innerException) { }
  }
}