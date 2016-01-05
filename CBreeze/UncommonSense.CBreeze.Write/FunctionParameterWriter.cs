using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class ParameterWriter
    {
        public static void Write(this Parameter parameter, CSideWriter writer)
        {
            TypeSwitch.Do(
                parameter,
                TypeSwitch.Case<ActionParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "Action", p.Dimensions, writer)),
                TypeSwitch.Case<AutomationParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, string.Format("Automation \"{0}\"", p.SubType), p.Dimensions, writer)),
                TypeSwitch.Case<BigIntegerParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "BigInteger", p.Dimensions, writer)),
                TypeSwitch.Case<BigTextParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "BigText", p.Dimensions, writer)),
                TypeSwitch.Case<BinaryParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, string.Format("Binary[{0}]", p.DataLength), p.Dimensions, writer)),
                TypeSwitch.Case<BooleanParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "Boolean", p.Dimensions, writer)),
                TypeSwitch.Case<ByteParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "Byte", p.Dimensions, writer)),
                TypeSwitch.Case<CharParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "Char", p.Dimensions, writer)),
                TypeSwitch.Case<CodeParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, string.Format("Code[{0}]", p.DataLength), p.Dimensions, writer)),
                TypeSwitch.Case<CodeunitParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, string.Format("Codeunit {0}", p.SubType), p.Dimensions, writer)),
                TypeSwitch.Case<DateFormulaParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "DateFormula", p.Dimensions, writer)),
                TypeSwitch.Case<DateParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "Date", p.Dimensions, writer)),
                TypeSwitch.Case<DateTimeParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "DateTime", p.Dimensions, writer)),
                TypeSwitch.Case<DecimalParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "Decimal", p.Dimensions, writer)),
                TypeSwitch.Case<DialogParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "Dialog", p.Dimensions, writer)),
                TypeSwitch.Case<DotNetParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, string.Format("DotNet \"{0}\"{1}{2}", p.SubType, p.RunOnClient.GetValueOrDefault() ? " RUNONCLIENT" : "", p.SuppressDispose.GetValueOrDefault() ? " SUPPRESSDISPOSE" : ""), p.Dimensions, writer)),
                TypeSwitch.Case<DurationParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "Duration", p.Dimensions, writer)),
                TypeSwitch.Case<ExecutionModeParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "ExecutionMode", p.Dimensions, writer)),
                TypeSwitch.Case<FieldRefParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "FieldRef", p.Dimensions, writer)),
                TypeSwitch.Case<FileParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "File", p.Dimensions, writer)),
#if NAV2016
                TypeSwitch.Case<FilterPageBuilderParameter>(p=>DoWrite(p.Var, p.Name, p.ID, false, "FilterPageBuilder", p.Dimensions, writer)),
#endif
                TypeSwitch.Case<GuidParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "GUID", p.Dimensions, writer)),
                TypeSwitch.Case<InStreamParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "InStream", p.Dimensions, writer)),
                TypeSwitch.Case<IntegerParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "Integer", p.Dimensions, writer)),
                TypeSwitch.Case<KeyRefParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "KeyRef", p.Dimensions, writer)),
                TypeSwitch.Case<OcxParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, string.Format("OCX \"{0}\"", p.SubType), p.Dimensions, writer)),
                TypeSwitch.Case<OptionParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, string.IsNullOrEmpty(p.OptionString) ? "Option" : string.Format("'{0}'", p.OptionString), p.Dimensions, writer)),
                TypeSwitch.Case<OutStreamParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "OutStream", p.Dimensions, writer)),
                TypeSwitch.Case<PageParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, string.Format("Page {0}", p.SubType), p.Dimensions, writer)),
                TypeSwitch.Case<QueryParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, string.Format("Query {0}{1}", p.SubType, p.SecurityFiltering.HasValue ? string.Format(" SECURITYFILTERING({0})", p.SecurityFiltering.GetValueOrDefault(), "") : ""), p.Dimensions, writer)),
                TypeSwitch.Case<RecordParameter>(p => DoWrite(p.Var, p.Name, p.ID, p.Temporary.HasValue ? p.Temporary.Value : false, string.Format("Record {0}{1}", p.SubType, p.SecurityFiltering.HasValue ? string.Format(" SECURITYFILTERING({0})", p.SecurityFiltering.GetValueOrDefault(), "") : ""), p.Dimensions, writer)),
                TypeSwitch.Case<RecordIDParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "RecordID", p.Dimensions, writer)),
                TypeSwitch.Case<RecordRefParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, string.Format("RecordRef{0}", p.SecurityFiltering.HasValue ? string.Format(" SECURITYFILTERING({0})", p.SecurityFiltering.GetValueOrDefault(), "") : ""), p.Dimensions, writer)),
                TypeSwitch.Case<ReportParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, string.Format("Report {0}", p.SubType), p.Dimensions, writer)),
                TypeSwitch.Case<TestPageParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, string.Format("TestPage {0}", p.SubType), p.Dimensions, writer)),
                TypeSwitch.Case<TestRequestPageParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, string.Format("TestRequestPage {0}", p.SubType), p.Dimensions, writer)),
                TypeSwitch.Case<TextParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, string.Format("Text{0}", p.DataLength.HasValue ? string.Format("[{0}]", p.DataLength.Value) : string.Empty), p.Dimensions, writer)),
                TypeSwitch.Case<TimeParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "Time", p.Dimensions, writer)),
                TypeSwitch.Case<TransactionTypeParameter>(p => DoWrite(p.Var, p.Name, p.ID, false, "TransactionType", p.Dimensions, writer)),
                TypeSwitch.Case<VariantParameter> (p=> DoWrite(p.Var, p.Name, p.ID, false, "Variant", p.Dimensions, writer)),
                TypeSwitch.Case<XmlPortParameter>(p=> DoWrite(p.Var, p.Name, p.ID, false, string.Format("XMLport {0}", p.SubType), p.Dimensions, writer)));
        }

        private static void DoWrite(bool var, string name, int uid, bool temporary, string typeName, string dimensions, CSideWriter writer)
        {
            if (var)
                writer.Write("VAR ");

            writer.Write("{0}@{1} : ", name, uid);

            if (!string.IsNullOrEmpty(dimensions))
                writer.Write("ARRAY [{0}] OF ", dimensions.Replace(';', ','));

            if (temporary)
                writer.Write("TEMPORARY ");

            writer.Write(typeName);
        }
    }
}
