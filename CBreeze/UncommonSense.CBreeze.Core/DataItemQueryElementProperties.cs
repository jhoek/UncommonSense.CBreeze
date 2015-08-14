using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class DataItemQueryElementProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private QueryDataItemLinkProperty dataItemLink = new QueryDataItemLinkProperty("DataItemLink");
        private DataItemLinkTypeProperty dataItemLinkType = new DataItemLinkTypeProperty("DataItemLinkType");
        private TableReferenceProperty dataItemTable = new TableReferenceProperty("DataItemTable");
        private DataItemQueryElementTableFilterProperty dataItemTableFilter = new DataItemQueryElementTableFilterProperty("DataItemTableFilter");
        private StringProperty description = new StringProperty("Description");
        private SqlJoinTypeProperty sQLJoinType = new SqlJoinTypeProperty("SQLJoinType");

        internal DataItemQueryElementProperties()
        {
            innerList.Add(dataItemTable);
            innerList.Add(description);
            innerList.Add(dataItemTableFilter);
            innerList.Add(dataItemLink);
            innerList.Add(dataItemLinkType);
            innerList.Add(sQLJoinType);
        }

        public Property this[string name]
        {
            get
            {
                return innerList.FirstOrDefault(p => p.Name == name);
            }
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

      public System.Int32? DataItemTable
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

        public DataItemQueryElementTableFilter DataItemTableFilter
        {
            get
            {
                return this.dataItemTableFilter.Value;
            }
        }

      public System.String Description
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }
}
