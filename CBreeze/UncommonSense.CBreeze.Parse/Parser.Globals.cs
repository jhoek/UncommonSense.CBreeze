using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseGlobals(Lines lines)
        {
            if (lines.FirstLineTryMatch(Patterns.BlankLine))
                return;

            lines.FirstLineMustMatch(Patterns.Variables);

            while (true)
            {
                if (!lines.FirstLineTryMatch(Patterns.BlankLine))
                    if (!ParseVariable(lines))
                        if (!ParseMultiLineTextConstant(lines))
                            break;
            }
        }
    }
}
