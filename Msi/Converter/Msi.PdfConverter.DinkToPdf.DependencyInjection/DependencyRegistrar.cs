using Microsoft.Extensions.DependencyInjection;
using Msi.Extensions.DependencyInjection;
using Msi.Extensions.DependencyInjection.Abstractions;
using Msi.PdfConverter.DinkToPdf.DependencyInjection.Extensions;
using System;

namespace Msi.PdfConverter.DinkToPdf.DependencyInjection
{
    public class DependencyRegistrar : DependencyRegistrarBase
    {
        public DependencyRegistrar(IServiceCollection services, IServiceProvider provider) : base(services, provider)
        {
            //
        }

        public override void Register()
        {
            Services.AddDinkToPdfConverter();
        }
    }
}
