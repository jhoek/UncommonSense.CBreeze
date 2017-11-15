using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
	public partial class Parser
	{
		internal void ParsePageAction(Lines lines)
		{
			var match = lines.FirstLineMustMatch(Patterns.PageAction);
			var actionID = match.Groups [1].Value.ToInteger();
			var actionIndentation = match.Groups [2].Value.ToNullableInteger();
			var actionType = match.Groups [3].Value.ToEnum<PageActionType>();
			var actionSeparator = match.Groups [4].Value;

			Listener.OnBeginPageAction(actionID, actionIndentation, actionType);

			if (actionSeparator == ";")
			{
				lines.Unindent(16);
				ParsePageActionProperties(lines);
			}

			Listener.OnEndPageAction();
		}
	}
}
