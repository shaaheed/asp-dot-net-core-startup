namespace Msi.FileStorage
{

  public class FileStorageOptions
  {
    /// <summary>
    /// The origin that is used to connect to the file storage. Might be used to provide an API base URL.
    /// </summary>
    public string Origin { get; set; }

    /// <summary>
    /// The identifier that is used to connect to the file storage. Might be used to provide a username or an application identifier.
    /// </summary>
    public string Identifier { get; set; }

    /// <summary>
    /// The secret that is used to connect to the file storage. Might be used to provide a password, an application secret, or an API key.
    /// </summary>
    public string Secret { get; set; }

    /// <summary>
    /// The root path that is used by the file storage.
    /// </summary>
    public string RootPath { get; set; }
  }
}