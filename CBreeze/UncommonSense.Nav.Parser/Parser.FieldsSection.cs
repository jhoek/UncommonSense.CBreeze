using System;

namespace UncommonSense.Nav.Parser
{
	public partial class Parser
	{
		internal void ParseFieldsSection(Lines lines)
		{
			foreach (var chunk in lines.Chunks(Patterns.TableField))
			{
				ParseTableField(chunk);
			}
		}
	}
}

