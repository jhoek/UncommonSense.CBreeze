using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.Nav.Parser
{
    public partial class Parser
    {
        internal void ParseCodeSection(Lines lines)
        {           
            ParseGlobals(lines);
            ParseProcedures(lines);                     
        }
    }
}
