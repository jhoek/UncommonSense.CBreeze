using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UncommonSense.Nav.Parser
{
    public partial class Parser
    {
        internal bool ParseEvent(Lines lines)
        {
            Match match;

            if (!lines.FirstLineTryMatch(Patterns.EventSignature, out match))
                return false;

            var variableName = match.Groups[1].Value;
            var variableID = match.Groups[2].Value.ToInteger();
            var eventName = match.Groups[3].Value;
            var eventID = match.Groups[4].Value.ToInteger();

            Listener.OnBeginEvent(variableID, variableName, eventID, eventName);

            ParseParameters(lines);
            lines.FirstLineMustMatch(Patterns.ProcedureNoReturnValue);

            if (lines.FirstLineTryMatch(Patterns.Variables))
                ParseLocals(lines);
            else
                lines.FirstLineMustMatch(Patterns.BeginCodeBlock);

            while (!lines.FirstLineTryMatch(Patterns.EndCodeBlock))
            {
                Listener.OnCodeLine(lines.FirstLineMustMatch(Patterns.Any).Value.UnIndent(2));
            }

            Listener.OnEndEvent();

            lines.FirstLineTryMatch(Patterns.BlankLine);
            return true;
        }
    }
}
