using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class DataItemReportElement : ReportElement
    {
        public DataItemReportElement(int id, int? indentationLevel)
            : base(id, indentationLevel)
        {
            Properties = new DataItemReportElementProperties();
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
    }
}
