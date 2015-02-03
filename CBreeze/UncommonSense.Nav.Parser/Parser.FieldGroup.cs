using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.Nav.Parser
{
    public partial class Parser
    {
        internal void ParseFieldGroup(Lines lines)
        {
            var match = lines.FirstLineMustMatch(Patterns.FieldGroup);
            var fieldGroupID = match.Groups[1].Value.Trim().ToInteger();
            var fieldGroupName = match.Groups[2].Value.TrimEnd();
            var fieldGroupFields = match.Groups[3].Value.TrimEnd().Split(",".ToCharArray());
            var separator = match.Groups[4].Value;

            Listener.OnBeginTableFieldGroup(fieldGroupID, fieldGroupName, fieldGroupFields);

            if (separator == ";")
            {
                lines.Unindent(Math.Min(match.Length, 69));
                ParseFieldGroupProperties(lines);
            }

            Listener.OnEndTableFieldGroup();
        }
    }
}
