using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.Nav.Parser
{
    public partial class Parser
    {
        internal void ParseReportLabelProperties(Lines lines)
        {
            lines.LastLineMustMatch(Patterns.EndReportLabel);

            foreach (var chunk in lines.Chunks(Patterns.PropertySignature))
            {
                ParseProperty(chunk, true);
            }
        }
    }
}
