using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Table.Field.Properties;

namespace UncommonSense.CBreeze.Core.Report
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