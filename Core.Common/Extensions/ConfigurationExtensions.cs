using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Core.Common.Extensions
{
    public class ConfigurationExtensions
    {

        public static IConfigurationRoot BuildConfiguration(ConfigParams parameters = default)
        {
            var basePath = string.IsNullOrEmpty(parameters?.BasePath) ? Directory.GetCurrentDirectory() : parameters.BasePath;
            basePath = basePath.Replace("\\bin\\Debug\\netcoreapp2.0", "");
            var environment = string.IsNullOrEmpty(parameters?.EnvironmentName) ? Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") : parameters?.EnvironmentName;
            var fileName = string.IsNullOrEmpty(parameters?.FileName) ? "appsettings" : parameters.FileName;

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile($"{fileName}.json")
                .AddJsonFile($"{fileName}.{environment}.json", optional: true, reloadOnChange: true)
                .Build();

            return configuration;
        }

        public class ConfigParams
        {
            public string FileName { get; set; }
            public string BasePath { get; set; }
            public string EnvironmentName { get; set; }
        }

    }
}
