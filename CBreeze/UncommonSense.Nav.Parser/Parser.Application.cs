using System;

namespace UncommonSense.Nav.Parser
{
	public partial class Parser
	{
		internal void ParseApplication(Lines lines)
		{
			foreach (var chunk in lines.Chunks(Patterns.ObjectSignature))
			{
				ParseObject(chunk);
			}
		}
	}
}

