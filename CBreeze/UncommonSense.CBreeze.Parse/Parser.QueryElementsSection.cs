using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseQueryElementsSection(Lines lines)
        {
            foreach (var chunk in lines.Chunks(Patterns.QueryElement))
            {
                ParseQueryElement(chunk);
            }
        }
    }
}
