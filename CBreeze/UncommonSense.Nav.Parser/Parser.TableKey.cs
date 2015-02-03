using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.Nav.Parser
{
    public partial class Parser
    {
        internal void ParseTableKey(Lines lines)
        {
            var match = lines.FirstLineMustMatch(Patterns.TableKey);
            var keyEnabled = match.Groups[1].Value.ToNullableBoolean();
            var keyFields = match.Groups[2].Value.TrimEnd().Split(",".ToCharArray());
            var separator = match.Groups[3].Value;

            Listener.OnBeginTableKey(keyEnabled, keyFields);

            if (separator == ";")
            {
                lines.Unindent(Math.Min(match.Length, 47));
                ParseTableKeyProperties(lines);
            }           

            Listener.OnEndTableKey();
        }
    }
}
