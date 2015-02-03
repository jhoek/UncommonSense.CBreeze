using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.Nav.Parser
{
    public partial class Parser
    {
        internal void ParseRequestPageSection(Lines lines, ObjectType objectType)
        {
            Listener.OnBeginRequestPage();

            foreach (var chunk in lines.Chunks(Patterns.SectionSignature))
            {
                ParseSection(chunk, objectType);
            }

            Listener.OnEndRequestPage();
        }
    }
}
