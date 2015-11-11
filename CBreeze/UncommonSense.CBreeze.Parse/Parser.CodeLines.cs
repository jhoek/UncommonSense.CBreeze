using System;
using System.Linq;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseCodeLines(Lines lines)
        {
            lines.LastLineTryMatch(Patterns.BlankLine);
            lines.FirstLineTryMatch(Patterns.BeginCodeBlock);
            lines.LastLineMustMatch(Patterns.EndCodeBlock);

            lines.Unindent(2);

            foreach (var line in lines)
            {
                Listener.OnCodeLine(line);
            }
        }
    }
}

