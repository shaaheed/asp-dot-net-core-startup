using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Msi.Converter.Abstractions;
using System;

namespace Msi.PdfConverter.DinkToPdf.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDinkToPdfConverter(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddTransient<IDocumentConverter, PdfConverter>();
            services.AddTransient<Func<string, IDocumentConverterFactory>>(f => {
                return x => {
                    return null;
                };
            });
            return services;
        }
    }
}
