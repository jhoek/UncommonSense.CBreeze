﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "ColumnQueryElement", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(QueryElement))]
    [Alias("QueryColumn", "Add-ColumnQueryElement")]
    public class NewCBreezeColumnQueryElement : NewCBreezeQueryElement<DataItemQueryElement>
    {
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ParameterSetNames.AddWithoutID)]
        public String DataSource { get; set; }

        [Parameter()]
        public String Description { get; set; }

        [Parameter()]
        [ValidateSet("Day", "Month", "Year", "Sum", "Count", "Average", "Min", "Max")]
        public string Method { get; set; }

        [Parameter()]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(ParameterSetName = ParameterSetNames.AddWithoutID)]
        public Position? Position { get; set; }

        [Parameter()]
        public SwitchParameter ReverseSign { get; set; }

        protected override void AddItemToInputObject(QueryElement item, DataItemQueryElement InputObject)
        {
            InputObject.AddChildNode(item, Position.GetValueOrDefault(Core.Position.LastWithinContainer));
        }

        protected override IEnumerable<QueryElement> CreateItems()
        {
            var columnQueryElement = new ColumnQueryElement(DataSource, ID, Name, GetIndentation());

            columnQueryElement.Properties.Description = Description;
            columnQueryElement.Properties.ReverseSign = NullableBooleanFromSwitch(nameof(ReverseSign));
            columnQueryElement.Properties.DateMethod = GetDateMethod();
            columnQueryElement.Properties.TotalsMethod = GetTotalsMethod();
            columnQueryElement.Properties.MethodType = GetMethodType(columnQueryElement.Properties.DateMethod, columnQueryElement.Properties.TotalsMethod);

            yield return columnQueryElement;
        }

        protected DateMethod? GetDateMethod()
        {
            switch (Method)
            {
                case "Day":
                    return DateMethod.Day;

                case "Month":
                    return DateMethod.Month;

                case "Year":
                    return DateMethod.Year;

                default:
                    return null;
            }
        }

        protected override int GetIndentationFromInputObject() => InputObject.IndentationLevel.GetValueOrDefault(0) + 1;

        protected MethodType? GetMethodType(DateMethod? dateMethod, TotalsMethod? totalsMethod)
        {
            if (dateMethod.HasValue)
                return MethodType.Date;
            if (totalsMethod.HasValue)
                return MethodType.Totals;
            return null;
        }

        protected TotalsMethod? GetTotalsMethod()
        {
            switch (Method)
            {
                case "Average":
                    return TotalsMethod.Average;

                case "Count":
                    return TotalsMethod.Count;

                case "Min":
                    return TotalsMethod.Min;

                case "Max":
                    return TotalsMethod.Max;

                case "Sum":
                    return TotalsMethod.Sum;

                default:
                    return null;
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "DataItemQueryElement", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(QueryElement))]
    [Alias("QueryDataItem", "Add-DataItemQueryElement")]
    public class NewCBreezeDataItemQueryElement : NewCBreezeQueryElement<PSObject>
    {
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.AddWithoutID)]
        public ScriptBlock ChildElements { get; set; }

        [Parameter()]
        public DataItemLinkType? DataItemLinkType { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [ValidateRange(1, int.MaxValue)]
        public int DataItemTable { get; set; }

        [Parameter()]
        public String Description { get; set; }

        [Parameter()]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(ParameterSetName = ParameterSetNames.AddWithoutID)]
        public Position? Position { get; set; }

        [Parameter()]
        public SqlJoinType? SQLJoinType { get; set; }

        protected override void AddItemToInputObject(QueryElement item, PSObject InputObject)
        {
            switch (InputObject.BaseObject)
            {
                case Query q when Position.GetValueOrDefault(Core.Position.LastWithinContainer) == Core.Position.LastWithinContainer:
                    q.Elements.Add(item);
                    break;

                case Query q when Position.GetValueOrDefault(Core.Position.LastWithinContainer) == Core.Position.FirstWithinContainer:
                    q.Elements.Insert(0, item);
                    break;

                case DataItemQueryElement d:
                    d.AddChildNode(item, Position.GetValueOrDefault(Core.Position.LastWithinContainer));
                    break;

                default:
                    base.AddItemToInputObject(item, InputObject);
                    break;
            }
        }

        protected override IEnumerable<QueryElement> CreateItems()
        {
            var indentation = GetIndentation();

            var dataItemQueryElement = new DataItemQueryElement(DataItemTable, ID, Name, indentation);
            dataItemQueryElement.Properties.DataItemLinkType = DataItemLinkType;
            dataItemQueryElement.Properties.Description = Description;
            dataItemQueryElement.Properties.SQLJoinType = SQLJoinType;
            yield return dataItemQueryElement;

            var variables = new List<PSVariable>() { new PSVariable("ElementIndentation", indentation + 1) };
            var childElements = ChildElements?.InvokeWithContext(null, variables).Select(o => o.BaseObject);

            dataItemQueryElement.Properties.DataItemTableFilter.AddRange(childElements.OfType<TableFilterLine>());

            foreach (var childElement in childElements.OfType<QueryElement>())
            {
                yield return childElement;
            }
        }

        protected override int GetIndentationFromInputObject()
        {
            switch (InputObject.BaseObject)
            {
                case Query q:
                    return 0;

                case DataItemQueryElement e:
                    return e.IndentationLevel.GetValueOrDefault(0) + 1;

                default:
                    return 0;
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "FilterQueryElement", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(QueryElement))]
    [Alias("QueryFilter", "Add-FilterQueryElement")]
    public class NewCBreezeFilterQueryElement : NewCBreezeQueryElement<DataItemQueryElement>
    {
        [Parameter()]
        public String DataSource { get; set; }

        [Parameter()]
        public String Description { get; set; }

        [Parameter()]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(ParameterSetName = ParameterSetNames.AddWithoutID)]
        public Position? Position { get; set; }

        protected override void AddItemToInputObject(QueryElement item, DataItemQueryElement InputObject)
        {
            InputObject.AddChildNode(item, Position.GetValueOrDefault(Core.Position.LastWithinContainer));
        }

        protected override IEnumerable<QueryElement> CreateItems()
        {
            var filterQueryElement = new FilterQueryElement(DataSource, ID, Name, GetIndentation());
            filterQueryElement.Properties.Description = Description;
            yield return filterQueryElement;
        }

        protected override int GetIndentationFromInputObject() => InputObject.IndentationLevel.GetValueOrDefault(0) + 1;
    }

    public abstract class NewCBreezeQueryElement<TInputObject> : NewItemWithIDCmdlet<QueryElement, int, TInputObject>
    {
        protected int GetIndentation() => ParameterSetNames.IsNew(ParameterSetName) ? GetIndentationFromVariable() : GetIndentationFromInputObject();

        protected abstract int GetIndentationFromInputObject();

        protected int GetIndentationFromVariable() => (int)GetVariableValue("ElementIndentation", 0);
    }
}