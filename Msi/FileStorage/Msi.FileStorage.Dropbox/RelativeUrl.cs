using System;
using System.Linq;

namespace Msi.FileStorage.Dropbox
{
  public static class RelativeUrl
  {
    public static string Combine(params string[] segments)
    {
      return "/" + string.Join(
        "/",
        segments.Where(s => !string.IsNullOrEmpty(s)).Select(
          s => string.Join("/", s.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries))
        ).Where(s => !string.IsNullOrEmpty(s))
      );
    }
  }
}