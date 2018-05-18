using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
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