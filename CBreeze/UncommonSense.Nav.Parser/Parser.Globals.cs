using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.Nav.Parser
{
    public partial class Parser
    {
        internal void ParseGlobals(Lines lines)
        {
            if (lines.FirstLineTryMatch(Patterns.BlankLine))
                return;

            lines.FirstLineMustMatch(Patterns.Variables);

            while (!lines.FirstLineTryMatch(Patterns.BlankLine))
            {
                ParseVariable(lines);
            }
        }
    }
}
