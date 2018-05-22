using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Query
{
        public class QueryProperties : Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private TriggerProperty onBeforeOpen = new TriggerProperty("OnBeforeOpen");
        private QueryOrderByLinesProperty orderBy = new QueryOrderByLinesProperty("OrderBy");
        private PermissionsProperty permissions = new PermissionsProperty("Permissions");
        private ReadStateProperty readState = new ReadStateProperty("ReadState");
        private NullableIntegerProperty topNumberOfRows = new NullableIntegerProperty("TopNumberOfRows");

        internal QueryProperties(Query query)
        {
            Query =query;

            innerList.Add(permissions);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(topNumberOfRows);
            innerList.Add(readState);
            innerList.Add(orderBy);
            innerList.Add(onBeforeOpen);
        }

        public Query Query { get; protected set; }

        public override INode ParentNode => Query;

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
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

        public Trigger OnBeforeOpen
        {
            get
            {
                return this.onBeforeOpen.Value;
            }
        }

        public QueryOrderByLines OrderBy
        {
            get
            {
                return this.orderBy.Value;
            }
        }

        public Permissions Permissions
        {
            get
            {
                return this.permissions.Value;
            }
        }

        public ReadState? ReadState
        {
            get
            {
                return this.readState.Value;
            }
            set
            {
                this.readState.Value = value;
            }
        }

      public int? TopNumberOfRows
        {
            get
            {
                return this.topNumberOfRows.Value;
            }
            set
            {
                this.topNumberOfRows.Value = value;
            }
        }
    }
}
