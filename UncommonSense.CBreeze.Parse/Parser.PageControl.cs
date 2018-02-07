using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParsePageControl(Lines lines)
        {
            var match = lines.FirstLineMustMatch(Patterns.PageControl);
            var controlID = match.Groups[1].Value.ToInteger();
            var controlIndentation = match.Groups[2].Value.ToNullableInteger();
            var controlType = match.Groups[3].Value.ToEnum<PageControlType>();
            var controlSeparator = match.Groups[4].Value;

            Listener.OnBeginPageControl(controlID, controlIndentation, controlType);

            if (controlSeparator == ";")
            {
                var indentation = lines.First().Length - lines.First().TrimStart().Length;
                lines.Unindent(indentation);
                ParsePageControlProperties(lines);
            }

            Listener.OnEndPageControl();
        }
    }
}
