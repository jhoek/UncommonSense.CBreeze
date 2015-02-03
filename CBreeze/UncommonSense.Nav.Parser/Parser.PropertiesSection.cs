using System;

namespace UncommonSense.Nav.Parser
{
	public partial class Parser
	{
		internal void ParsePropertiesSection(Lines lines)
		{
			foreach (var chunk in lines.Chunks(Patterns.PropertySignature))
			{
				ParseProperty(chunk, true);
			}
		}
	}
}

