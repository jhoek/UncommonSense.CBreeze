using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script
{
    public static partial class ToInvocationMethod
    {
        public static Invocation ToInvocation(this Report report)
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

            IEnumerable<ParameterBase> subObjects = new[] {
                new ScriptBlockParameter(
                    "SubObjects",
                        report.Elements.ToInvocation().Cast<Statement>()


                    //report.Code
                    //report.Elements
                    //report.Labels
                    //report.ObjectProperties
                    //report.Properties
                    //report.RdlData
                    //report.RequestPage
                    //report.WordLayout

                    //report.Fields.ToInvocation().Cast<Statement>()
                        

                    //    .Concat(report.FieldGroups.ToInvocation().Cast<Statement>())
                    //    .Concat(report.Keys.ToInvocation().Cast<Statement>())
                    //    .Concat(report.Code.Variables.ToInvocation().Cast<Statement>())
                    //    .Concat(report.Code.Functions.ToInvocation().Cast<Statement>())
                    //    .Concat(report.Code.Events.ToInvocation().Cast<Statement>())
                    //    .Concat(report.Code.Documentation.CodeLines.ToInvocation().Cast<Statement>())
                )
            };

            return new Invocation(
                "New-CBreezeReport",
                signature
                    .Concat(objectProperties)
                    .Concat(properties)
                    .Concat(subObjects));
        }

        public static IEnumerable<Invocation> ToInvocation(this ReportElements reportElements) => reportElements.Select(e => e.ToInvocation());

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
    }
}
