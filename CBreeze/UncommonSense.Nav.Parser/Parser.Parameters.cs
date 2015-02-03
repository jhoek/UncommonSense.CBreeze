using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.Nav.Parser
{
    public partial class Parser
    {
        internal void ParseParameters(Lines lines)
        {
            var match = lines.FirstLineMustMatch(Patterns.ProcedureParameters);
            var parameters = match.Groups[1].Value;

            if (string.IsNullOrEmpty(parameters))
                return;

            foreach (var parameter in parameters.Split(";".ToCharArray()))
            {
                ParseParameter(parameter);
            }
        }
    }
}
