using System;

namespace UncommonSense.CBreeze.Parse
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

