using System;
using System.IO;
using System.Linq;

namespace Msi.FileStorage.FileSystem
{
  public static class AbsolutePath
  {
    public static string Combine(params string[] segments)
    {
      return string.Join(
        Path.DirectorySeparatorChar.ToString(),
        segments.Where(s => !string.IsNullOrEmpty(s)).Select(
          s => string.Join(Path.DirectorySeparatorChar.ToString(), s.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries))
        ).Where(s => !string.IsNullOrEmpty(s))
      );
    }
  }
}