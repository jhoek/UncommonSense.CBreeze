using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script
{
    public static partial class ToInvocationMethod
    {
        internal static string GetExternalDataFileParameterValue(IEnumerable<string> data, string fileName)
        {
            if (data.Any())
            {
                // WriteAllLines will append a trailing line break that we don't want in our RDL!
                File.WriteAllText(fileName, string.Join(Environment.NewLine, data));
                return $"(Get-Content -Path {fileName} -Raw)";
            }

            return null;
        }

        public static Invocation ToInvocation(this Report report, string directory)
        {
            IEnumerable<ParameterBase> signature = new[] {
                new SimpleParameter("ID", report.ID),
                new SimpleParameter("Name", report.Name)
            };

            IEnumerable<ParameterBase> objectProperties = report
                .ObjectProperties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            IEnumerable<ParameterBase> properties = report
                .Properties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            IEnumerable<ParameterBase> requestPageProperties = report
                .RequestPage
                .Properties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters("RequestPage"));

            var rdlData =
                new LiteralParameter(
                    "RdlData",
                    GetExternalDataFileParameterValue(report.RdlData.CodeLines, Path.Combine(directory, $"rep{report.ID}.rdl.txt")));
#if NAV2015
            var wordLayout =
                new LiteralParameter(
                    "WordLayout",
                    GetExternalDataFileParameterValue(report.WordLayout.CodeLines, Path.Combine(directory, $"rep{report.ID}.word.txt")));
#endif

            IEnumerable<ParameterBase> subObjects = new[] {
                new ScriptBlockParameter(
                    "SubObjects",
                        report.Elements.ToInvocations().Cast<Statement>()
                            .Concat(report.Labels.ToInvocations().Cast<Statement>())
                            .Concat(report.Code.Variables.ToInvocations().Cast<Statement>())
                            .Concat(report.Code.Functions.ToInvocations().Cast<Statement>())
                            .Concat(report.Code.Events.ToInvocations().Cast<Statement>())
                            .Concat(report.Code.Documentation.CodeLines.ToInvocation().Cast<Statement>())
                )
            };

            IEnumerable<ParameterBase> requestPageSubObjects = new[] {
                new ScriptBlockParameter(
                    "RequestPageSubObjects",
                        report.RequestPage.Controls.ToInvocations().Cast<Statement>()
                            .Concat(report.RequestPage.Actions.ToInvocations().Cast<Statement>())
                )
            };

            return new Invocation(
                "New-CBreezeReport",
                signature
                    .Concat(objectProperties)
                    .Concat(properties)
                    .Concat(requestPageProperties)
                    .Concat(requestPageSubObjects)
                    .Concat(subObjects)
                    .Concat(rdlData.ToEnumerable())
#if NAV2015
                    .Concat(wordLayout.ToEnumerable())
#endif
            );
        }

        public static IEnumerable<Invocation> ToInvocations(this ReportElements reportElements) =>
            reportElements.Where(e => e.IndentationLevel.GetValueOrDefault(0) == 0).Select(e => e.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this ReportLabels reportLabels) => reportLabels.Select(l => l.ToInvocation());

        public static Invocation ToInvocation(this ReportLabel reportLabel) => new Invocation("New-CBreezeReportLabel", reportLabel.ToParameters());

        public static Invocation ToInvocation(this ReportElement reportElement)
        {
            switch (reportElement)
            {
                case DataItemReportElement dataItemReportElement: return dataItemReportElement.ToInvocation();
                case ColumnReportElement columnReportElement: return columnReportElement.ToInvocation();
                default: throw new ArgumentOutOfRangeException("reportElement");
            }
        }

        public static Invocation ToInvocation(this DataItemReportElement dataItemReportElement)
        {
            return new Invocation("New-CBreezeDataItemReportElement", dataItemReportElement.ToParameters());
        }

        public static Invocation ToInvocation(this ColumnReportElement columnReportElement)
        {
            return new Invocation("New-CBreezeColumnReportElement", columnReportElement.ToParameters());
        }

        public static Invocation ToInvocation(this ReportDataItemLinkLine reportDataItemLinkLine) => new Invocation("New-CBreezeReportLink", reportDataItemLinkLine.ToParameters());
    }
}