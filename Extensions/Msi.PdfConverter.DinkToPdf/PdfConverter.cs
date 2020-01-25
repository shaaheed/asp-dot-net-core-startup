using DinkToPdf;
using DinkToPdf.Contracts;
using Msi.Converter.Abstractions;

namespace Msi.PdfConverter.DinkToPdf
{
    public class PdfConverter : IDocumentConverter
    {
        private IConverter _converter;

        public PdfConverter(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] ConvertAsync(string content, IConverterOptions options = null)
        {
            PdfConverterOptions opts = options as PdfConverterOptions;
            if (options == null)
            {
                opts = new PdfConverterOptions();
            }

            opts.ObjectSettings.HtmlContent = content;

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = opts.GlobalSettings,
                Objects = {
                    opts.ObjectSettings
                }
            };

            byte[] pdf = _converter.Convert(doc);
            return pdf;
        }
    }
}
