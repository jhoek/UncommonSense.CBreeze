using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class DataItemReportElement : ReportElement
    {
        private DataItemReportElementProperties properties = new DataItemReportElementProperties();

        internal DataItemReportElement(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
        }

        public override ReportElementType Type
        {
            get
            {
                return ReportElementType.DataItem;
            }
        }

        public DataItemReportElementProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
