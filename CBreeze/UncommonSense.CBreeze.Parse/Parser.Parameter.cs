using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseParameter(string parameter)
        {
            var match = Patterns.ProcedureParameter.Match(parameter);
            var parameterVar = match.Groups[1].Value == "VAR ";
            var parameterName = match.Groups[2].Value;
            var parameterID = match.Groups[3].Value.ToInteger();
            var parameterType = match.Groups[4].Value;
            var parameterSuppressDispose = ParseSuppressDispose(ref parameterType);
            var parameterRunOnClient = ParseRunOnClient(ref parameterType);
            var parameterSecurityFiltering = ParseSecurityFiltering(ref parameterType);
            var parameterDimensions = ParseDimensions(ref parameterType);
            var parameterTemporary = ParseTemporary(ref parameterType);
            var parameterSubType = ParseVariableSubType(ref parameterType);
            var parameterLength = ParseVariableLength(ref parameterType);
            var parameterOptionString = ParseOptionString(ref parameterType);

            Listener.OnParameter(parameterVar, parameterID, parameterName, parameterType.ToEnum<ParameterType>(),  parameterSubType, parameterLength, parameterOptionString, parameterTemporary, parameterDimensions, parameterRunOnClient, parameterSecurityFiltering, parameterSuppressDispose);
        }

        internal bool ParseSuppressDispose(ref string parameterType)
        {
            var match = Patterns.ParameterSuppressDispose.Match(parameterType);

            if (match.Success)
            {
                parameterType = match.Groups[1].Value;
                return true;
            }

            return false;
        }

    }
}
