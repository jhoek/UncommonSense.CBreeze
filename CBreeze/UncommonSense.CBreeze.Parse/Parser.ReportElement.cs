using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser 
    {
        internal void ParseReportElement(Lines lines)
        {
            var match = lines.FirstLineMustMatch(Patterns.ReportElement);
            var elementID = match.Groups[1].Value.ToInteger();
            var elementIndentation = match.Groups[2].Value.ToNullableInteger();
            var elementType = match.Groups[3].Value.ToEnum<ReportElementType>();
            var elementName = match.Groups[4].Value.Trim();
            var elementSeparator = match.Groups[5].Value;

            Listener.OnBeginReportElement(elementID, elementIndentation, elementName, elementType);

            if (elementSeparator == ";")
            {
                lines.Unindent(11);
                ParseReportElementProperties(lines);
            }

            Listener.OnEndReportElement();
        }
    }
}
