using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.Nav.Parser
{
    public partial class Parser
    {
        internal void ParseDocumentation(Lines lines)
        {
            lines.FirstLineMustMatch(Patterns.BeginDocumentation);
            lines.LastLineMustMatch(Patterns.EndDocumentation);

            if (lines.FirstLineTryMatch(Patterns.BeginSection))
                lines.LastLineMustMatch(Patterns.EndSection);

            lines.Unindent(2);

            while (lines.Any())
                Listener.OnCodeLine(lines.FirstLineMustMatch(Patterns.Any).Value);
        }
    }
}
