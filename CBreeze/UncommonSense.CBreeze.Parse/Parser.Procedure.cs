﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal bool ParseProcedure(Lines lines)
        {
#if NAV2016
            Match tryFunctionMatch = null;
            Match businessEventPublisherMatch = null;
            Match integrationEventPublisherMatch = null;
            Match eventSubscriberMatch = null;
#endif
            Match functionTypeMatch = null;
            Match handlerFunctionsMatch = null;
            Match transactionModelMatch = null;
            Match procedureSignatureMatch = null;
#if NAV2017
            Match testPermissionsMatch = null;
#endif

#if NAV2016
            lines.FirstLineTryMatch(Patterns.TryFunctionAttribute, out tryFunctionMatch);

            if (!lines.FirstLineTryMatch(Patterns.BusinessEventPublisherAttribute, out businessEventPublisherMatch))
                if (!lines.FirstLineTryMatch(Patterns.IntegrationEventPublisherAttribute, out integrationEventPublisherMatch))
                    if (!lines.FirstLineTryMatch(Patterns.EventSubscriberAttribute, out eventSubscriberMatch))
#endif
                        lines.FirstLineTryMatch(Patterns.FunctionTypeAttribute, out functionTypeMatch);

            lines.FirstLineTryMatch(Patterns.HandlerFunctionsAttribute, out handlerFunctionsMatch);
            lines.FirstLineTryMatch(Patterns.TransactionModelAttribute, out transactionModelMatch);
#if NAV2017
            lines.FirstLineTryMatch(Patterns.TestPermissionsAttribute, out testPermissionsMatch);
#endif
#if NAV2018
            lines.FirstLineTryMatch(Patterns.FunctionVisibilityAttribute, out Match functionVisibilityMatch);
#endif

            if (!lines.FirstLineTryMatch(Patterns.ProcedureSignature, out procedureSignatureMatch))
            {
                return false;
            }

            var procedureLocal = procedureSignatureMatch.Groups[1].Value == "LOCAL ";
            var procedureName = procedureSignatureMatch.Groups[2].Value;
            var procedureID = procedureSignatureMatch.Groups[3].Value.ToInteger();

            Listener.OnBeginFunction(procedureID, procedureName, procedureLocal);

#if NAV2016
            if (businessEventPublisherMatch.Success)
            {
                Listener.OnFunctionAttribute("Business", businessEventPublisherMatch.Groups[2].Value);
            }
            else if (integrationEventPublisherMatch.Success)
            {
                Listener.OnFunctionAttribute("Integration", integrationEventPublisherMatch.Groups[2].Value, integrationEventPublisherMatch.Groups[4].Value);
            }
            else if (eventSubscriberMatch.Success)
            {
                Listener.OnFunctionAttribute(
                    "EventSubscriber",
                    eventSubscriberMatch.Groups["ObjectType"].Value,
                    eventSubscriberMatch.Groups["ObjectID"].Value,
                    eventSubscriberMatch.Groups["Function"].Value,
                    eventSubscriberMatch.Groups["Element"].Value,
                    eventSubscriberMatch.Groups["OnMissingLicense"].Value,
                    eventSubscriberMatch.Groups["OnMissingPermission"].Value);
            }
            else
#endif
                if (functionTypeMatch.Success)
            {
                Listener.OnFunctionAttribute(functionTypeMatch.Groups[1].Value);
            }

#if NAV2016
            if (tryFunctionMatch.Success)
            {
                Listener.OnFunctionAttribute("TryFunction");
            }
#endif

            if (handlerFunctionsMatch.Success)
            {
                Listener.OnFunctionAttribute("HandlerFunctions", handlerFunctionsMatch.Groups[1].Value);
            }

            if (transactionModelMatch.Success)
            {
                Listener.OnFunctionAttribute("TransactionModel", transactionModelMatch.Groups[1].Value);
            }

#if NAV2017
            if (testPermissionsMatch.Success)
            {
                Listener.OnFunctionAttribute("TestPermissions", testPermissionsMatch.Groups[1].Value);
            }
#endif

#if NAV2018
            if (functionVisibilityMatch.Success)
            {
                Listener.OnFunctionAttribute("FunctionVisibility", functionVisibilityMatch.Groups[1].Value);
            }
#endif

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