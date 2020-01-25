using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;
using Msi.FileStorage.Abstractions;

namespace Msi.FileStorage.Dropbox
{
    public class DirectoryProxy : IDirectoryProxy
  {
    private readonly string accessToken;
    private readonly string rootPath;
    private readonly string path;

    public string RelativePath { get; private set; }

    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public DirectoryProxy(string accessToken, string rootPath, string relativePath)
    {
      if (accessToken == string.Empty)
        throw new ArgumentException($"Value can't be empty. Parameter name: accessToken.");

      if (accessToken == null)
        throw new ArgumentNullException($"Value can't be null. Parameter name: accessToken.", default(Exception));

      this.accessToken = accessToken;
      this.rootPath = RelativeUrl.Combine(rootPath);
      RelativePath = RelativeUrl.Combine(relativePath);
      path = RelativeUrl.Combine(this.rootPath, RelativePath);

      if (string.Equals(path, "/"))
        path = string.Empty;
    }

    public async Task<bool> ExistsAsync()
    {
      try
      {
        using (DropboxClient dropboxClient = new DropboxClient(this.accessToken))
        {
          Metadata metadata = await dropboxClient.Files.GetMetadataAsync(this.path);

          return metadata.IsFolder;
        }
      }

      catch { return false; }
    }

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task CreateAsync()
    {
      try
      {
        using (DropboxClient dropboxClient = new DropboxClient(accessToken))
          await dropboxClient.Files.CreateFolderV2Async(path);
      }

      catch (Exception e)
      {
        throw new FileStorageException($"Generic file storage exception: \"{path}\". See inner exception for details.", e);
      }
    }

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

      try
      {
        using (DropboxClient dropboxClient = new DropboxClient(accessToken))
          await dropboxClient.Files.MoveV2Async(path, RelativeUrl.Combine(rootPath, destinationRelativePath));
      }

      catch (ApiException<RelocationError> e)
      {
        if (e.ErrorResponse.IsFromLookup)
          throw new DirectoryNotFoundException($"Directory not found: \"{path}\". See inner exception for details.", e);

        throw new FileStorageException($"Generic file storage exception: \"{path}\". See inner exception for details.", e);
      }

      catch (Exception e)
      {
        throw new FileStorageException($"Generic file storage exception: \"{path}\". See inner exception for details.", e);
      }
    }

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task DeleteAsync(bool recursive)
    {
      try
      {
        using (DropboxClient dropboxClient = new DropboxClient(accessToken))
          await dropboxClient.Files.DeleteV2Async(path);
      }

      catch (ApiException<DeleteError> e)
      {
        if (e.ErrorResponse.IsPathLookup)
          throw new DirectoryNotFoundException($"Directory not found: \"{path}\". See inner exception for details.", e);

        throw new FileStorageException($"Generic file storage exception: \"{path}\". See inner exception for details.", e);
      }

      catch (Exception e)
      {
        throw new FileStorageException($"Generic file storage exception: \"{path}\". See inner exception for details.", e);
      }
    }

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task<IEnumerable<IDirectoryProxy>> GetDirectoryProxiesAsync()
    {
      using (DropboxClient dropboxClient = new DropboxClient(accessToken))
      {
        IList<IDirectoryProxy> directoryProxies = new List<IDirectoryProxy>();

        try
        {
          foreach (Metadata metadata in (await dropboxClient.Files.ListFolderAsync(path)).Entries.Where(m => m.IsFolder))
            directoryProxies.Add(new DirectoryProxy(accessToken, rootPath, metadata.PathDisplay.Substring(this.rootPath.Length)));
        }

        catch (ApiException<ListFolderError> e)
        {
          if (e.ErrorResponse.IsPath)
            throw new DirectoryNotFoundException($"Directory not found: \"{path}\". See inner exception for details.", e);

          throw new FileStorageException($"Generic file storage exception: \"{path}\". See inner exception for details.", e);
        }

        catch (Exception e)
        {
          throw new FileStorageException($"Generic file storage exception: \"{path}\". See inner exception for details.", e);
        }

        return directoryProxies;
      }
    }

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task<IEnumerable<IFileProxy>> GetFileProxiesAsync()
    {
      using (DropboxClient dropboxClient = new DropboxClient(accessToken))
      {
        IList<IFileProxy> fileProxies = new List<IFileProxy>();

        try
        {
          foreach (Metadata metadata in (await dropboxClient.Files.ListFolderAsync(path)).Entries.Where(m => m.IsFile))
          {
            string relativePath = metadata.PathDisplay;

            relativePath = relativePath.Substring(rootPath.Length);

            if (relativePath.Contains("/"))
              relativePath = relativePath.Remove(relativePath.LastIndexOf("/"));

            fileProxies.Add(new FileProxy(accessToken, rootPath, relativePath, metadata.Name));
          }
        }

        catch (ApiException<ListFolderError> e)
        {
          if (e.ErrorResponse.IsPath)
            throw new DirectoryNotFoundException($"Directory not found: \"{path}\". See inner exception for details.", e);

          throw new FileStorageException($"Generic file storage exception: \"{path}\". See inner exception for details.", e);
        }

        catch (Exception e)
        {
          throw new FileStorageException($"Generic file storage exception: \"{path}\". See inner exception for details.", e);
        }

        return fileProxies;
      }
    }
  }
}