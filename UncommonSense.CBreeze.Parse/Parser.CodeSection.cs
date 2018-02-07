using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Parse
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
