using System;
using System.Text.RegularExpressions;

namespace UncommonSense.CBreeze.Parse
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

