using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class ColumnReportElement : ReportElement
    {
        private ColumnReportElementProperties properties = new ColumnReportElementProperties();

        internal ColumnReportElement(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
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
            get
            {
                return this.properties;
            }
        }

    }
}
