using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using System.Text.RegularExpressions;

namespace UncommonSense.CBreeze.Write
{
    public static class ReportElementExtensionMethods
    {
        public static ColumnReportElement AutoName(this ColumnReportElement element)
        {
            if (!string.IsNullOrEmpty(element.Properties.SourceExpr))
            {
                element.Name = Regex.Replace(element.Properties.SourceExpr.TrimStart("\"".ToCharArray()), @"\W", @"_");
            }

            return element;
        }
    }
}
