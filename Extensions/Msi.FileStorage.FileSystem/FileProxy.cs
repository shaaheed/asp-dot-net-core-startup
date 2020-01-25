using System;
using System.IO;
using System.Security;
using System.Threading.Tasks;
using Msi.FileStorage.Abstractions;

namespace Msi.FileStorage.FileSystem
{

    public class FileProxy : IFileProxy
  {
    private readonly string rootPath;
    private readonly string filepath;


    public string RelativePath { get; private set; }
    public string Filename { get; private set; }

    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public FileProxy(string rootPath, string relativePath, string filename)
    {
      if (filename == string.Empty)
        throw new ArgumentException($"Value can't be empty. Parameter name: filename.");

      if (filename == null)
        throw new ArgumentNullException($"Value can't be null. Parameter name: filename.", default(Exception));

      this.rootPath = rootPath;
      RelativePath = relativePath;
      Filename = filename;
      filepath = AbsolutePath.Combine(this.rootPath, this.RelativePath, this.Filename);
    }

    public async Task<bool> ExistsAsync()
    {
      return await Task<bool>.Factory.StartNew(() => File.Exists(this.filepath));
    }

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task<Stream> ReadStreamAsync()
    {
      return await Task<Stream>.Factory.StartNew(() =>
      {
        try
        {
          return File.Open(filepath, FileMode.Open);
        }

        catch (UnauthorizedAccessException e)
        {
          throw new AccessDeniedException($"Access denied: \"{filepath}\". See inner exception for details.", e);
        }

        catch (System.IO.DirectoryNotFoundException e)
        {
          throw new DirectoryNotFoundException($"Directory not found: \"{filepath}\". See inner exception for details.", e);
        }

        catch (System.IO.FileNotFoundException e)
        {
          throw new FileNotFoundException($"File not found: \"{filepath}\". See inner exception for details.", e);
        }

        catch (System.IO.PathTooLongException e)
        {
          throw new PathTooLongException($"Path too long: \"{filepath}\". See inner exception for details.", e);
        }

        catch (Exception e)
        {
          throw new FileStorageException($"Generic file storage exception: \"{filepath}\". See inner exception for details.", e);
        }
      });
    }

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task<byte[]> ReadBytesAsync()
    {
      return await Task<byte[]>.Factory.StartNew(() =>
      {
        try
        {
          return File.ReadAllBytes(filepath);
        }

        catch (UnauthorizedAccessException e)
        {
          throw new AccessDeniedException($"Access denied: \"{filepath}\". See inner exception for details.", e);
        }

        catch (SecurityException e)
        {
          throw new AccessDeniedException($"Access denied: \"{filepath}\". See inner exception for details.", e);
        }

        catch (System.IO.DirectoryNotFoundException e)
        {
          throw new DirectoryNotFoundException($"Directory not found: \"{filepath}\". See inner exception for details.", e);
        }

        catch (System.IO.FileNotFoundException e)
        {
          throw new FileNotFoundException($"File not found: \"{filepath}\". See inner exception for details.", e);
        }

        catch (System.IO.PathTooLongException e)
        {
          throw new PathTooLongException($"Path too long: \"{filepath}\". See inner exception for details.", e);
        }

        catch (Exception e)
        {
          throw new FileStorageException($"Generic file storage exception: \"{filepath}\". See inner exception for details.", e);
        }
      });
    }

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task<string> ReadTextAsync()
    {
      return await Task<string>.Factory.StartNew(() =>
      {
        try
        {
          return File.ReadAllText(filepath);
        }

        catch (UnauthorizedAccessException e)
        {
          throw new AccessDeniedException($"Access denied: \"{filepath}\". See inner exception for details.", e);
        }

        catch (SecurityException e)
        {
          throw new AccessDeniedException($"Access denied: \"{filepath}\". See inner exception for details.", e);
        }

        catch (System.IO.DirectoryNotFoundException e)
        {
          throw new DirectoryNotFoundException($"Directory not found: \"{filepath}\". See inner exception for details.", e);
        }

        catch (System.IO.FileNotFoundException e)
        {
          throw new FileNotFoundException($"File not found: \"{filepath}\". See inner exception for details.", e);
        }

        catch (System.IO.PathTooLongException e)
        {
          throw new PathTooLongException($"Path too long: \"{filepath}\". See inner exception for details.", e);
        }

        catch (Exception e)
        {
          throw new FileStorageException($"Generic file storage exception: \"{filepath}\". See inner exception for details.", e);
        }
      });
    }

    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task WriteStreamAsync(Stream inputStream)
    {
      if (inputStream == null)
        throw new ArgumentNullException($"Value can't be null. Parameter name: inputStream.", default(Exception));

      await Task.Factory.StartNew(() =>
      {
        try
        {
          using (Stream outputStream = File.Create(filepath))
            inputStream.CopyTo(outputStream);
        }

        catch (UnauthorizedAccessException e)
        {
          throw new AccessDeniedException($"Access denied: \"{filepath}\". See inner exception for details.", e);
        }

        catch (System.IO.DirectoryNotFoundException e)
        {
          throw new DirectoryNotFoundException($"Directory not found: \"{filepath}\". See inner exception for details.", e);
        }

        catch (System.IO.PathTooLongException e)
        {
          throw new PathTooLongException($"Path too long: \"{filepath}\". See inner exception for details.", e);
        }

        catch (Exception e)
        {
          throw new FileStorageException($"Generic file storage exception: \"{filepath}\". See inner exception for details.", e);
        }
      });
    }

    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task WriteBytesAsync(byte[] bytes)
    {
      if (bytes == null)
        throw new ArgumentNullException($"Value can't be null. Parameter name: bytes.", default(Exception));

      await Task.Factory.StartNew(() =>
      {
        try
        {
          File.WriteAllBytes(filepath, bytes);
        }

        catch (UnauthorizedAccessException e)
        {
          throw new AccessDeniedException($"Access denied: \"{filepath}\". See inner exception for details.", e);
        }

        catch (SecurityException e)
        {
          throw new AccessDeniedException($"Access denied: \"{filepath}\". See inner exception for details.", e);
        }

        catch (System.IO.DirectoryNotFoundException e)
        {
          throw new DirectoryNotFoundException($"Directory not found: \"{filepath}\". See inner exception for details.", e);
        }

        catch (System.IO.PathTooLongException e)
        {
          throw new PathTooLongException($"Path too long: \"{filepath}\". See inner exception for details.", e);
        }

        catch (Exception e)
        {
          throw new FileStorageException($"Generic file storage exception: \"{filepath}\". See inner exception for details.", e);
        }
      });
    }

    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task WriteTextAsync(string text)
    {
      if (text == null)
        throw new ArgumentNullException($"Value can't be null. Parameter name: text.", default(Exception));

      await Task.Factory.StartNew(() =>
      {
        try
        {
          File.WriteAllText(filepath, text);
        }

        catch (UnauthorizedAccessException e)
        {
          throw new AccessDeniedException($"Access denied: \"{filepath}\". See inner exception for details.", e);
        }

        catch (SecurityException e)
        {
          throw new AccessDeniedException($"Access denied: \"{filepath}\". See inner exception for details.", e);
        }

        catch (System.IO.DirectoryNotFoundException e)
        {
          throw new DirectoryNotFoundException($"Directory not found: \"{filepath}\". See inner exception for details.", e);
        }

        catch (System.IO.PathTooLongException e)
        {
          throw new PathTooLongException($"Path too long: \"{filepath}\". See inner exception for details.", e);
        }

        catch (Exception e)
        {
          throw new FileStorageException($"Generic file storage exception: \"{filepath}\". See inner exception for details.", e);
        }
      });
    }

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task DeleteAsync()
    {
      await Task.Factory.StartNew(() =>
      {
        if (!File.Exists(filepath))
          throw new FileNotFoundException($"File not found: \"{filepath}\".", null);

        try
        {
          File.Delete(filepath);
        }

        catch (UnauthorizedAccessException e)
        {
          throw new AccessDeniedException($"Access denied: \"{filepath}\". See inner exception for details.", e);
        }

        catch (System.IO.DirectoryNotFoundException e)
        {
          throw new DirectoryNotFoundException($"Directory not found: \"{filepath}\". See inner exception for details.", e);
        }

        catch (System.IO.PathTooLongException e)
        {
          throw new PathTooLongException($"Path too long: \"{filepath}\". See inner exception for details.", e);
        }

        catch (Exception e)
        {
          throw new FileStorageException($"Generic file storage exception: \"{filepath}\". See inner exception for details.", e);
        }
      });
    }
  }
}