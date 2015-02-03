using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace UncommonSense.Nav.Parser
{
    public partial class Parser
    {
        internal void ParseActionList(Lines lines)
        {
            foreach (var chunk in lines.Chunks(Patterns.PageAction))
            {
                ParsePageAction(chunk);
            }
        }
    }
}
