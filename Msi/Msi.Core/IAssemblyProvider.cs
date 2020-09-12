using System.Collections.Generic;
using System.Reflection;

namespace Msi.Core
{
    public interface IAssemblyProvider
    {
        IEnumerable<Assembly> GetAssemblies(string path, bool includingSubpaths);
    }
}
