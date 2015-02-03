using System;

namespace UncommonSense.Nav.Parser
{
	public partial class Parser
	{
		internal void ParsePageActionProperties(Lines lines)
		{
			lines.LastLineMustMatch(Patterns.EndPageAction);

			foreach (var chunk in lines.Chunks(Patterns.PropertySignature))
			{
				ParseProperty(chunk, true);
			}
		}
	}
}

