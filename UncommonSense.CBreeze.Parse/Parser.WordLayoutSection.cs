using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseWordLayoutSection(Lines lines)
        {
            lines.LastLineMustMatch(Patterns.EndWordLayoutSection);

            foreach (var line in lines)
            {
                Listener.OnCodeLine(line);
            }
        }
    }
}
