using System;
using System.Collections.Generic;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "ColumnQueryElement")]
    [OutputType(typeof(QueryElement))]
    [Alias("Column")]
    public class NewCBreezeColumnQueryElement : NewItemWithIDCmdlet<QueryElement, int, PSObject>
    {
        protected override void AddItemToInputObject(QueryElement item, PSObject InputObject)
        {
            switch (InputObject)
            {
            }
        }

        protected override IEnumerable<QueryElement> CreateItems()
        {
            var columnQueryElement = new ColumnQueryElement(DataSource, ID, Name, GetIndentation());
            columnQueryElement.Properties.Description = Description;
            columnQueryElement.Properties.ReverseSign = ReverseSign;
            columnQueryElement.Properties.DateMethod = GetDateMethod();
            columnQueryElement.Properties.TotalsMethod = GetTotalsMethod();
            columnQueryElement.Properties.MethodType = GetMethodType(columnQueryElement.Properties.DateMethod, columnQueryElement.Properties.TotalsMethod);
            yield return columnQueryElement;
        }

        protected DateMethod? GetDateMethod()
        {
            switch (Method)
            {
                case "Day": return DateMethod.Day;
                case "Month": return DateMethod.Month;
                case "Year": return DateMethod.Year;
                default: return null;
            }
        }

        protected int GetIndentation() => ParameterSetNames.IsNew(ParameterSetName) ? GetIndentationFromVariable() : GetIndentationFromInputObject();

        protected int GetIndentationFromInputObject() => 42;

        protected int GetIndentationFromVariable() => (int)GetVariableValue("Indentation", 0);

        protected MethodType? GetMethodType(DateMethod? dateMethod, TotalsMethod? totalsMethod)
        {
            if (dateMethod.HasValue) return MethodType.Date;
            if (totalsMethod.HasValue) return MethodType.Totals;
            return MethodType.None;
        }

        protected TotalsMethod? GetTotalsMethod()
        {
            switch (Method)
            {
                case "Average": return TotalsMethod.Average;
                case "Count": return TotalsMethod.Count;
                case "Min": return TotalsMethod.Min;
                case "Max": return TotalsMethod.Max;
                case "Sum": return TotalsMethod.Sum;
                default: return null;
            }
        }

        // FIXME
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
            var dataItemQueryElement = new DataItemQueryElement(0); // FIXME

            yield return dataItemQueryElement;
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
            var filterQueryElement = new FilterQueryElement(DataSource, ID, Name, GetIndentationLevel());

            yield return filterQueryElement;
        }

        [Parameter()]
        public String DataSource { get; set; }

        [Parameter()]
        public String Description { get; set; }

        [Parameter()]
        public string Name { get; set; }
    }

    public abstract class NewCBreezeQueryElement : NewItemWithIDCmdlet<QueryElement, int, PSObject>
    {
    }
}