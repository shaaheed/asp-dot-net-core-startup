using System;
using System.Collections.Generic;

namespace Msi.Data.Entity
{
    public class CsvPropertyAttribute : Attribute
    {

        public List<string> ImportTitles { get; private set; }
        public string ExportTitle { get; private set; }

        CsvPropertyAttribute(List<string> importTitles, string exportTitle)
        {
            ImportTitles = importTitles;
            ExportTitle = exportTitle;
        }

    }
}
