using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Core.Web.Modules
{
    public static class ServiceCollectionExtentions
    {

        public static readonly string ModulesFilename = "modules.json";

        public static IServiceCollection AddModules(this IServiceCollection services, string contentRootPath)
        {
            var modulesPath = Path.Combine(contentRootPath, ModulesFilename);
            using (var reader = new StreamReader(modulesPath))
            {
                string content = reader.ReadToEnd();
                List<ModuleData> modulesData = JsonConvert.DeserializeObject<List<ModuleData>>(content);
                foreach (ModuleData module in modulesData)
                {
                    // var moduleFolder = new DirectoryInfo(Path.Combine(contentRootPath, module.Id));
                    // var moduleManifestPath = Path.Combine(moduleFolder.FullName, ModulesFilename);
                    ModuleInfo moduleInfo = new ModuleInfo
                    {
                        Id = module.Id,
                        Version = Version.Parse(module.Version)
                    };
                    // TryLoadModuleAssembly(moduleFolder.FullName, moduleInfo);
                    if(moduleInfo.Assembly == null)
                    {
                        moduleInfo.Assembly = Assembly.Load(new AssemblyName(module.Id));
                    }

                    var moduleInitializerType = moduleInfo.Assembly.GetTypes().FirstOrDefault(t => typeof(IModuleInitializer).IsAssignableFrom(t));
                    if ((moduleInitializerType != null) && (moduleInitializerType != typeof(IModuleInitializer)))
                    {
                        var moduleInitializer = (IModuleInitializer)Activator.CreateInstance(moduleInitializerType);
                        moduleInfo.ModuleInitializer = moduleInitializer;
                        services.AddSingleton(typeof(IModuleInitializer), moduleInitializer);
                        moduleInitializer.ConfigureServices(services, moduleInfo);
                    }
                    ModuleManager.Modules.Add(moduleInfo);
                }
            }
            return services;
        }

        public static IApplicationBuilder UseModules(this IApplicationBuilder app)
        {
            var moduleInitializers = app.ApplicationServices.GetServices<IModuleInitializer>();
            var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
            foreach (var moduleInitializer in moduleInitializers)
            {
                moduleInitializer.Configure(app, env);
            }
            return app;
        }

        private static void TryLoadModuleAssembly(string moduleFolderPath, ModuleInfo module)
        {
            const string binariesFolderName = "bin";
            var binariesFolderPath = Path.Combine(moduleFolderPath, binariesFolderName);
            var binariesFolder = new DirectoryInfo(binariesFolderPath);

            if (Directory.Exists(binariesFolderPath))
            {
                foreach (var file in binariesFolder.GetFileSystemInfos("*.dll", SearchOption.AllDirectories))
                {
                    Assembly assembly;
                    try
                    {
                        assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file.FullName);
                    }
                    catch (FileLoadException)
                    {
                        // Get loaded assembly. This assembly might be loaded
                        assembly = Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(file.Name)));

                        if (assembly == null)
                        {
                            throw;
                        }

                        string loadedAssemblyVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
                        string tryToLoadAssemblyVersion = FileVersionInfo.GetVersionInfo(file.FullName).FileVersion;

                        // Or log the exception somewhere and don't add the module to list so that it will not be initialized
                        if (tryToLoadAssemblyVersion != loadedAssemblyVersion)
                        {
                            throw new Exception($"Cannot load {file.FullName} {tryToLoadAssemblyVersion} because {assembly.Location} {loadedAssemblyVersion} has been loaded");
                        }
                    }

                    if (Path.GetFileNameWithoutExtension(assembly.ManifestModule.Name) == module.Id)
                    {
                        module.Assembly = assembly;
                    }
                }
            }
        }

        internal class ModuleData
        {
            public string Id { get; set; }
            public string Version { get; set; }
        }
    }
}
