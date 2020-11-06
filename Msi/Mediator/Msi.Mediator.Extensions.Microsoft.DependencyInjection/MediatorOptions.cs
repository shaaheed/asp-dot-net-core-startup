using System.Collections.Generic;
using System.Reflection;

namespace Msi.Mediator.Extensions.Microsoft.DependencyInjection
{
    public class MediatorOptions
    {
        public List<Assembly> Assemblies { get; set; } = new List<Assembly>();
    }
}
