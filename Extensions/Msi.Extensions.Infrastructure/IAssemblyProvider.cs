using System.Collections.Generic;
using System.Reflection;

namespace Msi.Extensions.Infrastructure
{
    public interface IAssemblyProvider
    {
        IEnumerable<Assembly> GetAssemblies(string path, bool includingSubpaths);
    }
}
