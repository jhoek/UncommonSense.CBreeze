using System;
using System.Collections.Generic;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    // FIXME: Combine methods into one property

    [Cmdlet(VerbsCommon.New, "ColumnQueryElement")]
    [OutputType(typeof(QueryElement))]
    [Alias("Column")]
    public class NewCBreezeColumnQueryElement : NewItemWithIDCmdlet<QueryElement, int, PSObject>
    {
        protected override void AddItemToInputObject(QueryElement item, PSObject InputObject)
        {
            // FIXME
        }

        protected override IEnumerable<QueryElement> CreateItems()
        {
            var columnQueryElement = new ColumnQueryElement();

            return columnQueryElement;
        }

        [Parameter()]
        public String DataSource { get; set; }

        [Parameter()]
        public String Description { get; set; }

        [Parameter()]
        [ValidateSet("Day", "Month", "Year", "Sum", "Count", "Average", "Min", "Max")]
        public string Method { get; set; }

        [Parameter()]
        public string Name { get; set; }

        [Parameter()]
        public Nullable<Boolean> ReverseSign { get; set; }
    }

    [Cmdlet(VerbsCommon.New, "DataItemQueryElement")]
    [OutputType(typeof(QueryElement))]
    [Alias("DataItem")]
    public class NewCBreezeDataItemQueryElement : NewItemWithIDCmdlet<QueryElement, int, PSObject>
    {
        protected override void AddItemToInputObject(QueryElement item, PSObject InputObject)
        {
            // FIXME
        }

        protected override IEnumerable<QueryElement> CreateItems()
        {
            var dataItemQueryElement = new DataItemQueryElement();

            return dataItemQueryElement;
        }

        [Parameter()]
        public Nullable<DataItemLinkType> DataItemLinkType { get; set; }

        [Parameter(Mandatory = true)]
        public Nullable<Int32> DataItemTable { get; set; }

        [Parameter()]
        public DataItemQueryElementTableFilter DataItemTableFilter { get; set; }

        [Parameter()]
        public String Description { get; set; }

        [Parameter()]
        public string Name { get; set; }

        [Parameter()]
        public Nullable<SqlJoinType> SQLJoinType { get; set; }
    }

    [Cmdlet(VerbsCommon.New, "FilterQueryElement")]
    [OutputType(typeof(QueryElement))]
    [Alias("Filter")]
    public class NewCBreezeFilterQueryElement : NewItemWithIDCmdlet<QueryElement, int, PSObject>
    {
        protected override void AddItemToInputObject(QueryElement item, PSObject InputObject)
        {
            // FIXME
        }

        protected override IEnumerable<QueryElement> CreateItems()
        {
            var filterQueryElement = new FilterQueryElement();

            return filterQueryElement;
        }

        [Parameter()]
        public String DataSource { get; set; }

        [Parameter()]
        public String Description { get; set; }

        [Parameter()]
        public string Name { get; set; }
    }
}