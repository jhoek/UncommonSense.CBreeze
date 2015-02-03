using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UncommonSense.Nav.Parser
{
    public partial class Parser
    {
        internal bool ParseProcedure(Lines lines)
        {
            Match match;

            if (!lines.FirstLineTryMatch(Patterns.ProcedureSignature, out match))
                return false;

            var procedureLocal = match.Groups[1].Value == "LOCAL ";
            var procedureName = match.Groups[2].Value;
            var procedureID = match.Groups[3].Value.ToInteger();

            Listener.OnBeginFunction(procedureID, procedureName, procedureLocal);

            ParseParameters(lines);
            ParseReturnValue(lines);

            if (lines.FirstLineTryMatch(Patterns.Variables))
                ParseLocals(lines);
            else
                lines.FirstLineMustMatch(Patterns.BeginCodeBlock);

            while (!lines.FirstLineTryMatch(Patterns.EndCodeBlock))
            {
                Listener.OnCodeLine(lines.FirstLineMustMatch(Patterns.Any).Value.UnIndent(2));
            }

            Listener.OnEndFunction();

            lines.FirstLineTryMatch(Patterns.BlankLine);
            return true;
        }
    }
}
