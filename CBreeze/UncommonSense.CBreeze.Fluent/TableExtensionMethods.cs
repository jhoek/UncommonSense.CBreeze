using System;
using System.Linq;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Fluent
{
    public static class TableExtensionMethods
    {
        public static Table AutoCaption(this Table table)
        {
            if (!table.Properties.CaptionML.Any(e => e.LanguageID == "ENU"))
                table.Properties.CaptionML.Add("ENU", table.Name);

            return table;
        }

        public static Table SetCaptionML(this Table table, string languageID, string value)
        {
            if (table.Properties.CaptionML.Any(e => e.LanguageID == languageID))
                table.Properties.CaptionML.Remove(languageID);

            table.Properties.CaptionML.Add(languageID, value);

            return table;
        }
    }
}

