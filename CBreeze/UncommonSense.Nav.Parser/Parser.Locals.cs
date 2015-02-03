using System;
using System.Text.RegularExpressions;

namespace UncommonSense.Nav.Parser
{
    public partial class Parser
    {
        internal void ParseLocals(Lines lines)
        {
            // Note: assumes the "VAR" keyword has already been consumed

            while (!lines.FirstLineTryMatch(Patterns.BeginCodeBlock))
            {
                ParseVariable(lines);
            }
        }

    }
}

