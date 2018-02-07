using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseProcedures(Lines lines)
        {
            while (lines.Any())
            {
                if (!ParseProcedure(lines))
                    if (!ParseEvent(lines))
                        ParseDocumentation(lines);
            }
        }
    }
}
