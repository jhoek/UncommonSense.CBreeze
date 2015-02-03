using System;
using System.Linq;

namespace UncommonSense.Nav.Parser
{
	public partial class Parser
	{
		internal void ParseTableFieldProperties(Lines lines)
		{
			lines.LastLineMustMatch(Patterns.EndTableField);

			foreach (var chunk in lines.Chunks(Patterns.PropertySignature))
			{
				ParseProperty(chunk, true);
			}
		}
	}
}

