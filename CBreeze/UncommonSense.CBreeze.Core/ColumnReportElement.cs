using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class ColumnReportElement : ReportElement, IHasOptionString
    {
        public ColumnReportElement(int id, int? indentationLevel)
            : base(id, indentationLevel)
        {
            Properties = new ColumnReportElementProperties(this);
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public override ReportElementType Type
        {
            get
            {
                return ReportElementType.Column;
            }
        }

        public ColumnReportElementProperties Properties
        {
            get;
            protected set;
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public string GetOptionString()
        {
            return Properties.OptionString;
        }
    }
}
