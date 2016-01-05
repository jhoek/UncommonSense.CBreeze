using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class FunctionWriter
    {
        public static void Write(this Function function, CSideWriter writer)
        {
            writer.InnerWriter.WriteLine();
#if NAV2016
            writer.WriteLineIf(function.TryFunction.GetValueOrDefault(false), "[TryFunction]");
            WriteEventingAttributes(function, writer);
#endif
#if NAV2015
            writer.WriteLineIf(function.UpgradeFunctionType.HasValue, "[{0}]", function.UpgradeFunctionType);
#endif
            writer.WriteLineIf(function.TestFunctionType.HasValue, "[{0}]", function.TestFunctionType);
            writer.WriteLineIf(function.HandlerFunctions != null, "[HandlerFunctions({0})]", function.HandlerFunctions);
            writer.WriteLineIf(function.TransactionModel.HasValue, "[TransactionModel({0})]", function.TransactionModel);

            writer.Write("{2}PROCEDURE {0}@{1}(", function.Name, function.ID, function.Local.GetValueOrDefault(false) ? "LOCAL " : "");
            FunctionParametersWriter.Write(function.Parameters, writer);
            writer.Write(")");
            FunctionReturnValueWriter.Write(function.ReturnValue, writer);
            writer.WriteLine(";");
            function.Variables.Write(writer);
            writer.WriteLine("BEGIN");
            writer.Indent();
            function.CodeLines.Write(writer);
            writer.Unindent();
            writer.WriteLine("END;");
        }

#if NAV2016
        public static void WriteEventingAttributes(Function function, CSideWriter writer)
        {
            switch (function.Event.GetValueOrDefault(EventPublisherSubscriber.No))
            {
                case EventPublisherSubscriber.Publisher:
                    WritePublisherAttributes(function, writer);
                    break;
                case EventPublisherSubscriber.Subscriber:
                    WriteSubscriberAttributes(function, writer);
                    break;
            }
        }

        public static void WritePublisherAttributes(Function function, CSideWriter writer)
        {
            switch (function.EventType)
            {
                case EventType.Business:
                    WriteBusinessEventAttributes(function, writer);
                    break;
                case EventType.Integration:
                    WriteIntegrationEventAttributes(function, writer);
                    break;
            }
        }

        public static void WriteSubscriberAttributes(Function function, CSideWriter writer)
        {
            if (function.EventPublisherObject.Type == null)
                return;
            if (function.EventPublisherObject.ID == null)
                return;
            if (string.IsNullOrEmpty(function.EventFunction))
                return;

            writer.Write(
                "[EventSubscriber({0},{1},{2}", 
                function.EventPublisherObject.Type, 
                function.EventPublisherObject.ID, 
                function.EventFunction);

            var parameters = 
                string.Format(
                    ",{0},{1}",
                    function.OnMissingLicense.HasValue? function.OnMissingLicense.ToString() : "DEFAULT",
                    function.OnMissingPermission.HasValue ? function.OnMissingPermission.ToString() : "DEFAULT");
            var eventPublisherElement = string.IsNullOrEmpty(function.eventPublisherElement) ? ",\"\"" : string.Format(",{0}", function.eventPublisherElement);

            // Handle exceptional cases
            parameters = parameters == ",DEFAULT,DEFAULT" ? "" : parameters;
            parameters = parameters == ",Skip,DEFAULT" ? ",Skip" : parameters;
            parameters = parameters == ",Error,DEFAULT" ? ",Error" : parameters;
            eventPublisherElement = parameters == "" && eventPublisherElement == ",\"\"" ? "" : eventPublisherElement;

            writer.WriteLine("{0}{1})]", eventPublisherElement, parameters);
        }

        public static void WriteBusinessEventAttributes(Function function, CSideWriter writer)
        {
            switch (function.IncludeSender)
            {
                case null:
                    writer.WriteLine("[Business]");
                    break;
                case true:
                    writer.WriteLine("[Business(TRUE)]");
                    break;
                case false:
                    writer.WriteLine("[Business(FALSE)]");
                    break;
            }
        }

        public static void WriteIntegrationEventAttributes(Function function, CSideWriter writer)
        {
            var parameters =
                string.Format(
                    "({0},{1})",
                    function.IncludeSender.HasValue ? function.IncludeSender.ToString().ToUpperInvariant() : "DEFAULT",
                    function.GlobalVarAccess.HasValue ? function.GlobalVarAccess.ToString().ToUpperInvariant() : "DEFAULT");

            // Handle exceptional cases
            parameters = parameters == "(DEFAULT,DEFAULT)" ? "" : parameters;
            parameters = parameters == "(FALSE,DEFAULT)" ? "(FALSE)" : parameters;
            parameters = parameters == "(TRUE,DEFAULT)" ? "(TRUE)" : parameters;

            writer.WriteLine("[Integration{0}]", parameters);
        }
#endif
    }
}
