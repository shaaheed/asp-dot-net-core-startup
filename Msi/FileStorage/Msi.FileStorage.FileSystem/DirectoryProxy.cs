using Msi.FileStorage.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Msi.FileStorage.FileSystem
{
    public class DirectoryProxy : IDirectoryProxy
  {
    private readonly string rootPath;
    private readonly string path;

    public string RelativePath { get; private set; }

    public DirectoryProxy(string rootPath, string relativePath)
    {
      this.rootPath = AbsolutePath.Combine(rootPath);
      RelativePath = AbsolutePath.Combine(relativePath);
      path = AbsolutePath.Combine(this.rootPath, RelativePath);
    }

    public async Task<bool> ExistsAsync()
    {
      return await Task<bool>.Factory.StartNew(() => Directory.Exists(path));
    }

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task CreateAsync()
    {
      await Task.Factory.StartNew(() =>
      {
        try
        {
          Directory.CreateDirectory(path);
        }

        catch (UnauthorizedAccessException e)
        {
          throw new AccessDeniedException($"Access denied: \"{path}\". See inner exception for details.", e);
        }

        catch (System.IO.DirectoryNotFoundException e)
        {
          throw new DirectoryNotFoundException($"Directory not found: \"{path}\". See inner exception for details.", e);
        }

        catch (System.IO.PathTooLongException e)
        {
          throw new PathTooLongException($"Path too long: \"{path}\". See inner exception for details.", e);
        }

        catch (Exception e)
        {
          throw new FileStorageException($"Generic file storage exception: \"{path}\". See inner exception for details.", e);
        }
      });
    }

    /// <param name="destinationRelativePath"></param>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task MoveAsync(string destinationRelativePath)
    {
      if (destinationRelativePath == string.Empty)
        throw new ArgumentException($"Value can't be empty. Parameter name: destinationRelativePath.");

      if (destinationRelativePath == null)
        throw new ArgumentNullException($"Value can't be null. Parameter name: destinationRelativePath.", default(Exception));

      await Task.Factory.StartNew(() =>
      {
        try
        {
          Directory.Move(path, rootPath + destinationRelativePath);
        }

        catch (UnauthorizedAccessException e)
        {
          throw new AccessDeniedException($"Access denied: \"{path}\". See inner exception for details.", e);
        }

        catch (System.IO.DirectoryNotFoundException e)
        {
          throw new DirectoryNotFoundException($"Directory not found: \"{path}\". See inner exception for details.", e);
        }

        catch (System.IO.PathTooLongException e)
        {
          throw new PathTooLongException($"Path too long: \"{path}\". See inner exception for details.", e);
        }

        catch (Exception e)
        {
          throw new FileStorageException($"Generic file storage exception: \"{path}\". See inner exception for details.", e);
        }
      });
    }

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task DeleteAsync(bool recursive)
    {
      await Task.Factory.StartNew(() =>
      {
        try
        {
          Directory.Delete(path, recursive);
        }

        catch (UnauthorizedAccessException e)
        {
          throw new AccessDeniedException($"Access denied: \"{path}\". See inner exception for details.", e);
        }

        catch (System.IO.DirectoryNotFoundException e)
        {
          throw new DirectoryNotFoundException($"Directory not found: \"{path}\". See inner exception for details.", e);
        }

        catch (System.IO.PathTooLongException e)
        {
          throw new PathTooLongException($"Path too long: \"{path}\". See inner exception for details.", e);
        }

        catch (Exception e)
        {
          throw new FileStorageException($"Generic file storage exception: \"{path}\". See inner exception for details.", e);
        }
      });
    }

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task<IEnumerable<IDirectoryProxy>> GetDirectoryProxiesAsync()
    {
      return await Task<IEnumerable<IDirectoryProxy>>.Factory.StartNew(
        () =>
        {
          try
          {
            return Directory.GetDirectories(path).Select(
              d => new DirectoryProxy(rootPath, d.Substring(rootPath.Length))
            );
          }

          catch (UnauthorizedAccessException e)
          {
            throw new AccessDeniedException($"Access denied: \"{path}\". See inner exception for details.", e);
          }

          catch (System.IO.DirectoryNotFoundException e)
          {
            throw new DirectoryNotFoundException($"Directory not found: \"{path}\". See inner exception for details.", e);
          }

          catch (System.IO.PathTooLongException e)
          {
            throw new PathTooLongException($"Path too long: \"{path}\". See inner exception for details.", e);
          }

          catch (Exception e)
          {
            throw new FileStorageException($"Generic file storage exception: \"{path}\". See inner exception for details.", e);
          }
        }
      );
    }

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task<IEnumerable<IFileProxy>> GetFileProxiesAsync()
    {
      return await Task<IEnumerable<IFileProxy>>.Factory.StartNew(
        () =>
        {
          try
          {
            return Directory.GetFiles(path).Select(
              f =>
              {
                string relativePath = f;

                relativePath = relativePath.Substring(rootPath.Length);
                relativePath = relativePath.Remove(relativePath.LastIndexOf(Path.DirectorySeparatorChar));
                return new FileProxy(rootPath, relativePath, f.Substring(f.LastIndexOf(Path.DirectorySeparatorChar) + 1));
              }
            );
          }

          catch (UnauthorizedAccessException e)
          {
            throw new AccessDeniedException($"Access denied: \"{path}\". See inner exception for details.", e);
          }

          catch (System.IO.DirectoryNotFoundException e)
          {
            throw new DirectoryNotFoundException($"Directory not found: \"{path}\". See inner exception for details.", e);
          }

          catch (System.IO.PathTooLongException e)
          {
            throw new PathTooLongException($"Path too long: \"{path}\". See inner exception for details.", e);
          }

          catch (Exception e)
          {
            throw new FileStorageException($"Generic file storage exception: \"{path}\". See inner exception for details.", e);
          }
        }
      );
    }
  }
}