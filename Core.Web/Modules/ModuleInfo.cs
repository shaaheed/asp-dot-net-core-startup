using System;
using System.Collections.Generic;
using System.Reflection;

namespace Core.Web.Modules
{
    public class ModuleInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Version Version { get; set; }
        public Assembly Assembly { get; set; }
        public IModuleInitializer ModuleInitializer { get; set; }
        public ICollection<Assembly> DependentAssemblies { get; set; } = new HashSet<Assembly>();
    }
}
