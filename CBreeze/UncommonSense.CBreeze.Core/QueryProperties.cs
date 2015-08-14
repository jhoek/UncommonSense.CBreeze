using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class QueryProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private TriggerProperty onBeforeOpen = new TriggerProperty("OnBeforeOpen");
        private QueryOrderByLinesProperty orderBy = new QueryOrderByLinesProperty("OrderBy");
        private PermissionsProperty permissions = new PermissionsProperty("Permissions");
        private ReadStateProperty readState = new ReadStateProperty("ReadState");
        private NullableIntegerProperty topNumberOfRows = new NullableIntegerProperty("TopNumberOfRows");

        internal QueryProperties()
        {
            innerList.Add(permissions);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(topNumberOfRows);
            innerList.Add(readState);
            innerList.Add(orderBy);
            innerList.Add(onBeforeOpen);
        }

        public Property this[string name]
        {
            get
            {
                return innerList.FirstOrDefault(p => p.Name == name);
            }
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
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

      public System.Int32? TopNumberOfRows
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
