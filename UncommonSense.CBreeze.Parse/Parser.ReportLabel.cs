using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseReportLabel(Lines lines)
        {
            var match = lines.FirstLineMustMatch(Patterns.ReportLabel);
            var labelID = match.Groups[1].Value.ToInteger();
            var labelName = match.Groups[2].Value.Trim();
            var labelSeparator = match.Groups[3].Value;

            Listener.OnBeginReportLabel(labelID, labelName);

            if (labelSeparator == ";")
            {
                lines.Unindent(28);
                ParseReportLabelProperties(lines);
            }

            Listener.OnEndReportLabel();
        }
    }
}
