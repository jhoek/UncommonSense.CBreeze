using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class QueryProperties : Properties
    {
#if NAV2018
        private StringProperty apiVersion = new StringProperty("APIVersion");
#endif
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
#if NAV2018
        private StringProperty entityName = new StringProperty("EntityName");
        private StringProperty entitySetName = new StringProperty("EntitySetName");
#endif
        private TriggerProperty onBeforeOpen = new TriggerProperty("OnBeforeOpen");
        private QueryOrderByLinesProperty orderBy = new QueryOrderByLinesProperty("OrderBy");
        private PermissionsProperty permissions = new PermissionsProperty("Permissions");
#if NAV2018
        private QueryTypeProperty queryType = new QueryTypeProperty("QueryType");
#endif
        private ReadStateProperty readState = new ReadStateProperty("ReadState");
        private NullableIntegerProperty topNumberOfRows = new NullableIntegerProperty("TopNumberOfRows");

        internal QueryProperties(Query query)
        {
            Query = query;

            innerList.Add(permissions);
            innerList.Add(captionML);
            innerList.Add(description);
#if NAV2018
            innerList.Add(entitySetName);
            innerList.Add(entityName);
            innerList.Add(apiVersion);
#endif
            innerList.Add(topNumberOfRows);
            innerList.Add(readState);
#if NAV2018
            innerList.Add(queryType);
#endif
            innerList.Add(orderBy);
            innerList.Add(onBeforeOpen);
        }

        public Query Query { get; protected set; }

        public override INode ParentNode => Query;

        public string APIVersion
        {
            get => apiVersion.Value;
            set => apiVersion.Value = value;
        }

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

        public string EntitySetName
        {
            get => entitySetName.Value;
            set => entitySetName.Value = value;
        }

        public string EntityName
        {
            get => entityName.Value;
            set => entityName.Value = value;
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

        public QueryType? QueryType
        {
            get => queryType.Value;
            set => queryType.Value = value;
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