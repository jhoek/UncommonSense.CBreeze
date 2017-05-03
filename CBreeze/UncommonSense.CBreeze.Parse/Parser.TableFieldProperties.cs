using System;
using System.Linq;

namespace UncommonSense.CBreeze.Parse
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

