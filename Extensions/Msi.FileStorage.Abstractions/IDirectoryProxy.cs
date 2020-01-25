using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Msi.FileStorage.Abstractions
{
  public interface IDirectoryProxy
  {
    string RelativePath { get; }

    Task<bool> ExistsAsync();

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    Task CreateAsync();

    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    Task MoveAsync(string destinationRelativePath);

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    Task DeleteAsync(bool recursive);

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    Task<IEnumerable<IDirectoryProxy>> GetDirectoryProxiesAsync();

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    Task<IEnumerable<IFileProxy>> GetFileProxiesAsync();
  }
}