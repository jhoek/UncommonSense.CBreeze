using System;

namespace UncommonSense.CBreeze.Parse
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

