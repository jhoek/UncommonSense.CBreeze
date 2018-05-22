using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.Report
{
    public class ColumnReportElement : ReportElement, IHasOptionString
    {
        public ColumnReportElement(string name, string sourceExpr = null, int id = 0, int? indentationLevel = null)
            : base(id, indentationLevel)
        {
            Name = name;

            Properties = new ColumnReportElementProperties(this);
            Properties.SourceExpr = sourceExpr;
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public ColumnReportElementProperties Properties
        {
            get;
            protected set;
        }

        public override ReportElementType Type
        {
            get
            {
                return ReportElementType.Column;
            }
        }

        public string GetOptionString()
        {
            return Properties.OptionString;
        }
    }
}