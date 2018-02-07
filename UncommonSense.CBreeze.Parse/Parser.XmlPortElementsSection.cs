using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseXmlPortElementsSection(Lines lines)
        {
            foreach (var chunk in lines.Chunks(Patterns.XmlPortElement))
            {
                ParseXmlPortElement(chunk);
            }
        }
    }
}
