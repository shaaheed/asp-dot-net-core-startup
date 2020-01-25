using DinkToPdf;
using Msi.Converter.Abstractions;

namespace Msi.PdfConverter.DinkToPdf
{
    public class PdfConverterOptions : IConverterOptions
    {

        public GlobalSettings GlobalSettings { get; private set; }
        public ObjectSettings ObjectSettings { get; private set; }

        public PdfConverterOptions()
        {
            GlobalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4
            };
            ObjectSettings = new ObjectSettings
            {
                WebSettings = { DefaultEncoding = "utf-8" }
            };
        }

        public PdfConverterOptions(GlobalSettings globalSettings, ObjectSettings objectSettings)
        {
            GlobalSettings = globalSettings;
            ObjectSettings = objectSettings;
        }
    }
}
