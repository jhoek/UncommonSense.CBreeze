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

            writer.WriteLineIf(function.Properties.TestFunctionType.HasValue, "[{0}]", function.Properties.TestFunctionType);
            writer.WriteLineIf(function.Properties.HandlerFunctions != null, "[HandlerFunctions({0})]", function.Properties.HandlerFunctions);
            writer.WriteLineIf(function.Properties.TransactionModel.HasValue, "[TransactionModel({0})]", function.Properties.TransactionModel);

            writer.Write("{2}PROCEDURE {0}@{1}(", function.Name, function.ID, function.Properties.Local.GetValueOrDefault(false) ? "LOCAL " : "");
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
    }
}
