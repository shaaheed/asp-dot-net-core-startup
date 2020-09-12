using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;
using Dropbox.Api.Stone;
using Msi.FileStorage.Abstractions;

namespace Msi.FileStorage.Dropbox
{

    public class FileProxy : IFileProxy
  {
    private readonly string accessToken;
    private readonly string rootPath;
    private readonly string filepath;


    public string RelativePath { get; private set; }

    public string Filename { get; private set; }

    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public FileProxy(string accessToken, string rootPath, string relativePath, string filename)
    {
      if (accessToken == string.Empty)
        throw new ArgumentException($"Value can't be empty. Parameter name: accessToken.");

      if (accessToken == null)
        throw new ArgumentNullException($"Value can't be null. Parameter name: accessToken.", default(Exception));

      if (filename == string.Empty)
        throw new ArgumentException($"Value can't be empty. Parameter name: filename.");

      if (filename == null)
        throw new ArgumentNullException($"Value can't be null. Parameter name: filename.", default(Exception));

      this.accessToken = accessToken;
      this.rootPath = rootPath;
      RelativePath = relativePath;
      Filename = filename;
      filepath = RelativeUrl.Combine(this.rootPath, RelativePath, Filename);
    }

    public async Task<bool> ExistsAsync()
    {
      try
      {
        using (DropboxClient dropboxClient = new DropboxClient(accessToken))
        {
          Metadata metadata = await dropboxClient.Files.GetMetadataAsync(filepath);
          return metadata.IsFile;
        }
      }

      catch { return false; }
    }

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task<Stream> ReadStreamAsync()
    {
      try
      {
        using (DropboxClient dropboxClient = new DropboxClient(accessToken))
        using (IDownloadResponse<FileMetadata> response = await dropboxClient.Files.DownloadAsync(filepath))
          return await response.GetContentAsStreamAsync();
      }

      catch (ApiException<DownloadError> e)
      {
        if (e.ErrorResponse.IsPath)
          throw new DirectoryNotFoundException($"Directory not found: \"{filepath}\". See inner exception for details.", e);

        throw new FileStorageException($"Generic file storage exception: \"{filepath}\". See inner exception for details.", e);
      }

      catch (Exception e)
      {
        throw new FileStorageException($"Generic file storage exception: \"{filepath}\". See inner exception for details.", e);
      }
    }

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task<byte[]> ReadBytesAsync()
    {
      try
      {
        using (DropboxClient dropboxClient = new DropboxClient(accessToken))
        using (IDownloadResponse<FileMetadata> response = await dropboxClient.Files.DownloadAsync(filepath))
          return await response.GetContentAsByteArrayAsync();
      }

      catch (ApiException<DownloadError> e)
      {
        if (e.ErrorResponse.IsPath)
          throw new DirectoryNotFoundException($"Directory not found: \"{filepath}\". See inner exception for details.", e);

        throw new FileStorageException($"Generic file storage exception: \"{filepath}\". See inner exception for details.", e);
      }

      catch (Exception e)
      {
        throw new FileStorageException($"Generic file storage exception: \"{filepath}\". See inner exception for details.", e);
      }
    }

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task<string> ReadTextAsync()
    {
      try
      {
        using (DropboxClient dropboxClient = new DropboxClient(accessToken))
        using (IDownloadResponse<FileMetadata> response = await dropboxClient.Files.DownloadAsync(filepath))
          return await response.GetContentAsStringAsync();
      }

      catch (ApiException<DownloadError> e)
      {
        if (e.ErrorResponse.IsPath)
          throw new DirectoryNotFoundException($"Directory not found: \"{filepath}\". See inner exception for details.", e);

        throw new FileStorageException($"Generic file storage exception: \"{filepath}\". See inner exception for details.", e);
      }

      catch (Exception e)
      {
        throw new FileStorageException($"Generic file storage exception: \"{filepath}\". See inner exception for details.", e);
      }
    }

    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task WriteStreamAsync(Stream inputStream)
    {
      try
      {
        using (DropboxClient dropboxClient = new DropboxClient(accessToken))
          await dropboxClient.Files.UploadAsync(filepath, WriteMode.Overwrite.Instance, body: inputStream);
      }

      catch (Exception e)
      {
        throw new FileStorageException($"Generic file storage exception: \"{filepath}\". See inner exception for details.", e);
      }
    }

    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task WriteBytesAsync(byte[] bytes)
    {
      try
      {
        using (MemoryStream inputStream = new MemoryStream(bytes))
          await this.WriteStreamAsync(inputStream);
      }

      catch (Exception e)
      {
        throw new FileStorageException($"Generic file storage exception: \"{filepath}\". See inner exception for details.", e);
      }
    }

    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task WriteTextAsync(string text)
    {
      try
      {
        await WriteBytesAsync(Encoding.UTF8.GetBytes(text));
      }

      catch (Exception e)
      {
        throw new FileStorageException($"Generic file storage exception: \"{filepath}\". See inner exception for details.", e);
      }
    }

    /// <exception cref="AccessDeniedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="PathTooLongException"></exception>
    /// <exception cref="FileStorageException"></exception>
    public async Task DeleteAsync()
    {
      try
      {
        using (DropboxClient dropboxClient = new DropboxClient(accessToken))
          await dropboxClient.Files.DeleteV2Async(filepath);
      }

      catch (ApiException<ListFolderError> e)
      {
        if (e.ErrorResponse.IsPath)
          throw new DirectoryNotFoundException($"Directory not found: \"{filepath}\". See inner exception for details.", e);

        throw new FileStorageException($"Generic file storage exception: \"{filepath}\". See inner exception for details.", e);
      }

      catch (Exception e)
      {
        throw new FileStorageException($"Generic file storage exception: \"{filepath}\". See inner exception for details.", e);
      }
    }
  }
}