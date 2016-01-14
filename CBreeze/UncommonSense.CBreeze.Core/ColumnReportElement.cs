using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ColumnReportElement : ReportElement, IHasOptionString
    {
        public ColumnReportElement(int id, int? indentationLevel)
            : base(id, indentationLevel)
        {
            Properties = new ColumnReportElementProperties();
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
