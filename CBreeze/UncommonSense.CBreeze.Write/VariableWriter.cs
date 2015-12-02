using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using System.Globalization;

namespace UncommonSense.CBreeze.Write
{
    public static class VariableWriter
    {
        public static void Write(this Variable variable, CSideWriter writer)
        {
            TypeSwitch.Do(
                variable,
                TypeSwitch.Case<ActionVariable>(p => DoWrite(p.Name, p.ID, "Action", p.Dimensions, writer)),
                TypeSwitch.Case<AutomationVariable>(p => DoWrite(p.Name, p.ID, string.Format("Automation \"{0}\"", p.SubType), p.Dimensions, false, false, p.WithEvents.GetValueOrDefault(false), false, null, writer)),
                TypeSwitch.Case<BigIntegerVariable>(p => DoWrite(p.Name, p.ID, "BigInteger", p.Dimensions, writer)),
                TypeSwitch.Case<BigTextVariable>(p => DoWrite(p.Name, p.ID, "BigText", p.Dimensions, writer)),
                TypeSwitch.Case<BinaryVariable>(p => DoWrite(p.Name, p.ID, string.Format("Binary[{0}]", p.DataLength), p.Dimensions, writer)),
                TypeSwitch.Case<BooleanVariable>(p => DoWrite(p.Name, p.ID, "Boolean", p.Dimensions, false, p.IncludeInDataset.GetValueOrDefault(false), false, false, null, writer)),
                TypeSwitch.Case<ByteVariable>(p => DoWrite(p.Name, p.ID, "Byte", p.Dimensions, writer)),
                TypeSwitch.Case<CharVariable>(p => DoWrite(p.Name, p.ID, "Char", p.Dimensions, writer)),
                TypeSwitch.Case<CodeunitVariable>(p => DoWrite(p.Name, p.ID, string.Format("Codeunit {0}", p.SubType), p.Dimensions, writer)),
                TypeSwitch.Case<CodeVariable>(p => DoWrite(p.Name, p.ID, p.DataLength.HasValue ? string.Format("Code[{0}]", p.DataLength) : "Code", p.Dimensions, false, p.IncludeInDataset.GetValueOrDefault(false), false, false, null, writer)),
                TypeSwitch.Case<DateFormulaVariable>(p => DoWrite(p.Name, p.ID, "DateFormula", p.Dimensions, writer)),
                TypeSwitch.Case<DateTimeVariable>(p => DoWrite(p.Name, p.ID, "DateTime", p.Dimensions, writer)),
                TypeSwitch.Case<DateVariable>(p => DoWrite(p.Name, p.ID, "Date", p.Dimensions, writer)),
                TypeSwitch.Case<DecimalVariable>(p => DoWrite(p.Name, p.ID, "Decimal", p.Dimensions, writer)),
                TypeSwitch.Case<DialogVariable>(p => DoWrite(p.Name, p.ID, "Dialog", p.Dimensions, writer)),
                TypeSwitch.Case<DotNetVariable>(p => DoWrite(p.Name, p.ID, string.Format("DotNet \"{0}\"", p.SubType), p.Dimensions, false, false, p.WithEvents.GetValueOrDefault(false), p.RunOnClient.GetValueOrDefault(false), null, writer)),
                TypeSwitch.Case<DurationVariable>(p => DoWrite(p.Name, p.ID, "Duration", p.Dimensions, writer)),
                TypeSwitch.Case<ExecutionModeVariable>(p => DoWrite(p.Name, p.ID, "ExecutionMode", p.Dimensions, writer)),
                TypeSwitch.Case<FieldRefVariable>(p => DoWrite(p.Name, p.ID, "FieldRef", p.Dimensions, writer)),
                TypeSwitch.Case<FileVariable>(p => DoWrite(p.Name, p.ID, "File", p.Dimensions, writer)),
                TypeSwitch.Case<GuidVariable>(p => DoWrite(p.Name, p.ID, "GUID", p.Dimensions, writer)),
                TypeSwitch.Case<InStreamVariable>(p => DoWrite(p.Name, p.ID, "InStream", p.Dimensions, writer)),
                TypeSwitch.Case<IntegerVariable>(p => DoWrite(p.Name, p.ID, "Integer", p.Dimensions, false, p.IncludeInDataset.GetValueOrDefault(false), false, false, null, writer)),
                TypeSwitch.Case<KeyRefVariable>(p => DoWrite(p.Name, p.ID, "KeyRef", p.Dimensions, writer)),
                TypeSwitch.Case<OcxVariable>(p => DoWrite(p.Name, p.ID, string.Format("OCX \"{0}\"", p.SubType), p.Dimensions, writer)),
                TypeSwitch.Case<OptionVariable>(p => DoWrite(p.Name, p.ID, string.IsNullOrEmpty(p.OptionString) ? "Option" : string.Format("'{0}'", p.OptionString), p.Dimensions, writer)),
                TypeSwitch.Case<OutStreamVariable>(p => DoWrite(p.Name, p.ID, "OutStream", p.Dimensions, writer)),
                TypeSwitch.Case<PageVariable>(p => DoWrite(p.Name, p.ID, string.Format("Page {0}", p.SubType), p.Dimensions, writer)),
                TypeSwitch.Case<QueryVariable>(p => DoWrite(p.Name, p.ID, string.Format("Query {0}", p.SubType), p.Dimensions, false, false, false, false, p.SecurityFiltering.HasValue ? p.SecurityFiltering.Value.ToString() : null, writer)),
                TypeSwitch.Case<RecordVariable>(p => DoWrite(p.Name, p.ID, string.Format("Record {0}", p.SubType), p.Dimensions, p.Temporary.GetValueOrDefault(false), false, false, false, p.SecurityFiltering.HasValue ? p.SecurityFiltering.Value.ToString() : null, writer)),
                TypeSwitch.Case<RecordIDVariable>(p => DoWrite(p.Name, p.ID, "RecordID", p.Dimensions, writer)),
                TypeSwitch.Case<RecordRefVariable>(p => DoWrite(p.Name, p.ID, "RecordRef", p.Dimensions, false, false, false, false, p.SecurityFiltering.HasValue ? p.SecurityFiltering.Value.ToString() : null, writer)),
                TypeSwitch.Case<ReportVariable>(p => DoWrite(p.Name, p.ID, string.Format("Report {0}", p.SubType), p.Dimensions, writer)),
                TypeSwitch.Case<TestPageVariable>(p => DoWrite(p.Name, p.ID, string.Format("TestPage {0}", p.SubType), p.Dimensions, writer)),
                TypeSwitch.Case<TextConstant>(p => WriteTextConstant(p, writer)),
                TypeSwitch.Case<TextVariable>(p => DoWrite(p.Name, p.ID, p.DataLength.HasValue ? string.Format("Text[{0}]", p.DataLength) : "Text", p.Dimensions, false, p.IncludeInDataset.GetValueOrDefault(false), false, false, null, writer)),
                TypeSwitch.Case<TimeVariable>(p => DoWrite(p.Name, p.ID, "Time", p.Dimensions, writer)),
                TypeSwitch.Case<TransactionTypeVariable>(p => DoWrite(p.Name, p.ID, "TransactionType", p.Dimensions, writer)),
                TypeSwitch.Case<VariantVariable>(p => DoWrite(p.Name, p.ID, "Variant", p.Dimensions, writer)),
                TypeSwitch.Case<XmlPortVariable>(p => DoWrite(p.Name, p.ID, string.Format("XMLport {0}", p.SubType), p.Dimensions, writer))
                );
        }

        private static void DoWrite(string name, int id, string type, string dimensions, CSideWriter writer)
        {
            DoWrite(name, id, type, dimensions, false, false, false, false, null, writer);
        }

        private static void DoWrite(string name, int id, string type, string dimensions, bool temporary, bool includeInDataset, bool withEvents, bool runOnClient, string securityFiltering, CSideWriter writer)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("{0}@{1} : ", name, id);

            if (!string.IsNullOrEmpty(dimensions))
                stringBuilder.AppendFormat("ARRAY [{0}] OF ", dimensions.Replace(';', ','));

            if (temporary)
                stringBuilder.Append("TEMPORARY ");

            stringBuilder.Append(type);

            if (runOnClient)
                stringBuilder.Append(" RUNONCLIENT");

            if (withEvents)
                stringBuilder.Append(" WITHEVENTS");

            if (includeInDataset)
                stringBuilder.Append(" INDATASET");

            if (!string.IsNullOrEmpty(securityFiltering))
                stringBuilder.AppendFormat(" SECURITYFILTERING({0})", securityFiltering);

            stringBuilder.Append(";");

            writer.WriteLine(stringBuilder.ToString());
        }

        private static void WriteTextConstant(TextConstant textConstant, CSideWriter writer)
        {
            if (IsMultiLineTextConstant(textConstant))
            {
                WriteMultiLineTextConstant(textConstant, writer);
            }
            else
            {
                WriteSingleLineTextConstant(textConstant, writer);
            }
        }

        private static bool IsMultiLineTextConstant(TextConstant textConstant)
        {
            return textConstant.Values.Sum(v => v.QuotedValue.Length) >= 1002; 
        }

        private static void WriteSingleLineTextConstant(TextConstant textConstant, CSideWriter writer)
        {
            DoWrite(
                textConstant.Name,
                textConstant.ID,
                string.Format(
                    "TextConst '{0}'",
                    string.Join(
                        ";",
                        textConstant.Values.OrderBy(t => t.LanguageID.GetLCIDFromLanguageCode()).Select(v => string.Format("{0}={1}", v.LanguageID, v.Value.TextConstantValue(v.LanguageID == "@@@", textConstant.Values.Count()))))),
                "", writer);
        }

        private static void WriteMultiLineTextConstant(TextConstant textConstant, CSideWriter writer)
        {
            var sortedValues = textConstant.Values.OrderBy(v => v.LanguageID.GetLCIDFromLanguageCode());

            writer.InnerWriter.WriteLine();
            writer.WriteLine("{0}@{1} : TextConst", textConstant.Name, textConstant.ID);
            writer.Indent();

            foreach (var value in sortedValues)
            {
                var isLastValue = (value.LanguageID == sortedValues.Last().LanguageID);
                writer.WriteLine("'{0}={1}'{2}", value.LanguageID, value.QuotedValue, isLastValue ? ";" : ",");
            }

            writer.Unindent();
        }
    }
}
