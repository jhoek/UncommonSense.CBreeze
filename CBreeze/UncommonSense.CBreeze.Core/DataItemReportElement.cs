using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class DataItemReportElement : ReportElement
    {
        public DataItemReportElement(int? dataitemTable, int id = 0, int? indentationLevel = null)
            : base(id, indentationLevel)
        {
            Properties = new DataItemReportElementProperties(this);
            Properties.DataItemTable = dataitemTable;
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

        public DataItemReportElementProperties Properties
        {
            get;
            protected set;
        }

        public override ReportElementType Type
        {
            get
            {
                return ReportElementType.DataItem;
            }
        }
    }
}