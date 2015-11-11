using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseTableKeyProperties(Lines lines)
        {
            lines.LastLineMustMatch(Patterns.EndTableField);

            foreach (var chunk in lines.Chunks(Patterns.PropertySignature))
            {
                ParseProperty(chunk, false);
            }
        }
    }
}
