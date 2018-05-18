using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class DataItemQueryElementProperties : Properties
    {
        private QueryDataItemLinkProperty dataItemLink = new QueryDataItemLinkProperty("DataItemLink");
        private DataItemLinkTypeProperty dataItemLinkType = new DataItemLinkTypeProperty("DataItemLinkType");
        private TableReferenceProperty dataItemTable = new TableReferenceProperty("DataItemTable");
        private DataItemQueryElementTableFilterProperty dataItemTableFilter = new DataItemQueryElementTableFilterProperty("DataItemTableFilter");
        private StringProperty description = new StringProperty("Description");
        private SqlJoinTypeProperty sQLJoinType = new SqlJoinTypeProperty("SQLJoinType");

        internal DataItemQueryElementProperties(DataItemQueryElement dataItemQueryElement)
        {
            DataItemQueryElement = dataItemQueryElement;

            innerList.Add(dataItemTable);
            innerList.Add(description);
            innerList.Add(dataItemTableFilter);
            innerList.Add(dataItemLink);
            innerList.Add(dataItemLinkType);
            innerList.Add(sQLJoinType);
        }

        public QueryDataItemLink DataItemLink
        {
            get
            {
                return this.dataItemLink.Value;
            }
        }

        public DataItemLinkType? DataItemLinkType
        {
            get
            {
                return this.dataItemLinkType.Value;
            }
            set
            {
                this.dataItemLinkType.Value = value;
            }
        }

        public DataItemQueryElement DataItemQueryElement { get; protected set; }

        public int? DataItemTable
        {
            get
            {
                return this.dataItemTable.Value;
            }
            set
            {
                this.dataItemTable.Value = value;
            }
        }

        public TableFilter DataItemTableFilter
        {
            get
            {
                return this.dataItemTableFilter.Value;
            }
        }

        public string Description
        {
            get
            {
                return this.description.Value;
            }
            set
            {
                this.description.Value = value;
            }
        }

        public override INode ParentNode => DataItemQueryElement;

        public SqlJoinType? SQLJoinType
        {
            get
            {
                return this.sQLJoinType.Value;
            }
            set
            {
                this.sQLJoinType.Value = value;
            }
        }
    }
}