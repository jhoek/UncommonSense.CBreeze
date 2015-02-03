using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.Nav.Parser
{
	public partial class Parser
	{
		internal void ParseObjectPropertiesSection(Lines lines)
		{
            foreach (var chunk in lines.Chunks(Patterns.PropertySignature))
            {
                ParseObjectProperty(chunk);
            }
		}
	}
}
