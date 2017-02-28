using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class DataItemReportElement : ReportElement
    {
        public DataItemReportElement(int id, int? indentationLevel)
            : base(id, indentationLevel)
        {
            Properties = new DataItemReportElementProperties(this);
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
