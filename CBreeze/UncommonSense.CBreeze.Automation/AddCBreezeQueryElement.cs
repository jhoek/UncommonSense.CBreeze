using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeQueryElement")]
    public class AddCBreezeQueryElement : CmdletWithDynamicParams
    {
        private const string DataItemParameterSet = "DataItem";
        private const string ColumnParameterSetNoMethod = "ColumnWithNoMethod";
        private const string ColumnParameterSetDateMethod = "ColumnWithDateMethod";
        private const string ColumnParameterSetTotalsMethod = "ColumnWithTotalsMethod";
        private const string FilterParameterSet = "Filter";

        protected DynamicParameter<PSObject> InputObjectForDataItems = new DynamicParameter<PSObject>("InputObject", true, true, parameterSetNames: new string[] { DataItemParameterSet });
        protected DynamicParameter<DataItemQueryElement> InputObjectForColumnsOrFilters = new DynamicParameter<DataItemQueryElement>("InputObject", true, true, parameterSetNames: new string[] { ColumnParameterSetNoMethod, ColumnParameterSetDateMethod, ColumnParameterSetTotalsMethod, FilterParameterSet });

        [Parameter(Mandatory = true, ParameterSetName = DataItemParameterSet)]
        public SwitchParameter DataItem
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = ColumnParameterSetNoMethod)]
        [Parameter(Mandatory = true, ParameterSetName = ColumnParameterSetDateMethod)]
        [Parameter(Mandatory = true, ParameterSetName = ColumnParameterSetTotalsMethod)]
        public SwitchParameter Column
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = FilterParameterSet)]
        public SwitchParameter Filter
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        public PSObject ID
        {
            get;
            set;
        }

        [Parameter()]
        public string Name
        {
            get;
            set;
        }

        [Parameter()]
        public Position? Position
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = DataItemParameterSet)]
        public DataItemLinkType? DataItemLinkType
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = DataItemParameterSet)]
        public int DataItemTable
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = ColumnParameterSetNoMethod)]
        [Parameter(ParameterSetName = ColumnParameterSetDateMethod)]
        [Parameter(ParameterSetName = ColumnParameterSetTotalsMethod)]
        [Parameter(ParameterSetName = FilterParameterSet)]
        public string DataSource
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = ColumnParameterSetDateMethod)]
        public DateMethod? DateMethod
        {
            get;
            set;
        }

        [Parameter()]
        public string Description
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = ColumnParameterSetNoMethod)]
        [Parameter(ParameterSetName = ColumnParameterSetDateMethod)]
        [Parameter(ParameterSetName = ColumnParameterSetTotalsMethod)]
        public bool? ReverseSign
        {
            get;
            set;
        }

        [Parameter(ParameterSetName=DataItemParameterSet)]
        public SqlJoinType? SqlJoinType
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = ColumnParameterSetTotalsMethod)]
        public TotalsMethod? TotalsMethod
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter PassThru
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            var element = CreateElement();

            if (DataItem)
            {
                if (InputObjectForDataItems.Value.BaseObject is DataItemQueryElement)
                {
                    (InputObjectForDataItems.Value.BaseObject as DataItemQueryElement).AddChildNode(element, Position.GetValueOrDefault(Utils.Position.LastWithinContainer));
                }
                else
                {
                    switch (Position.GetValueOrDefault(Utils.Position.LastWithinContainer))
                    {
                        case Utils.Position.FirstWithinContainer:
                            GetQuery().Elements.Insert(0, element);
                            break;
                        case Utils.Position.LastWithinContainer:
                            GetQuery().Elements.Add(element);
                            break;
                    }
                }
            }
            else
            {
                InputObjectForColumnsOrFilters.Value.AddChildNode(element, Position.GetValueOrDefault(Utils.Position.LastWithinContainer));
            }

            if (PassThru)
                WriteObject(element);
        }

        protected QueryElement CreateElement()
        {
            if (DataItem)
            {
                var dataItem = new DataItemQueryElement(GetElementID(), Name, GetIndentationLevel());

                dataItem.Properties.DataItemLinkType = DataItemLinkType;
                dataItem.Properties.DataItemTable = DataItemTable;
                dataItem.Properties.Description = Description;
                dataItem.Properties.SQLJoinType = SqlJoinType;

                return dataItem;
            }
            else if (Column)
            {
                var column = new ColumnQueryElement(GetElementID(), Name, GetIndentationLevel());

                column.Properties.DataSource = DataSource;
                column.Properties.Description = Description;
                column.Properties.ReverseSign = ReverseSign;

                if (DateMethod.HasValue)
                {
                    column.Properties.MethodType = MethodType.Date;
                    column.Properties.DateMethod = DateMethod.Value;
                }
                else if (TotalsMethod.HasValue)
                {
                    column.Properties.MethodType = MethodType.Totals;
                    column.Properties.TotalsMethod = TotalsMethod.Value;
                }

                return column;
            }
            else if (Filter)
            {
                var filter = new FilterQueryElement(GetElementID(), Name, GetIndentationLevel());

                filter.Properties.DataSource = DataSource;
                filter.Properties.Description = Description;

                return filter;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Don't know how to create an element of this type.");
            }
        }

        protected int GetElementID()
        {
            if (ID.BaseObject is int)
            {
                return (int)ID.BaseObject;
            }
            else if (ID.BaseObject is IEnumerable<int>)
            {
                var range = ID.BaseObject as IEnumerable<int>;

                if (range.Contains(GetQuery().ID))
                    range = 1.To(int.MaxValue);

                return range.Except(GetElementIDs()).First();
            }

            throw new ArgumentOutOfRangeException("Cannot determine ID.");
        }

        protected Query GetQuery()
        {
            if (DataItem)
            {
                if (InputObjectForDataItems.Value.BaseObject is Query)
                    return (InputObjectForDataItems.Value.BaseObject as Query);
                else if (InputObjectForDataItems.Value.BaseObject is QueryElements)
                    return (InputObjectForDataItems.Value.BaseObject as QueryElements).Query;
                else if (InputObjectForDataItems.Value.BaseObject is DataItemQueryElement)
                    return (InputObjectForDataItems.Value.BaseObject as DataItemQueryElement).Container.Query;
                else
                    throw new ArgumentOutOfRangeException("Cannot determine query object for this InputObject.");
            }
            else
            {
                return InputObjectForColumnsOrFilters.Value.Container.Query;
            }
        }

        protected IEnumerable<int> GetElementIDs()
        {
            return GetQuery().Elements.Select(e => e.ID);
        }

        protected int? GetIndentationLevel()
        {
            if (DataItem)
            {
                if (InputObjectForDataItems.Value.BaseObject is DataItemQueryElement)
                    return (InputObjectForDataItems.Value.BaseObject as DataItemQueryElement).IndentationLevel.GetValueOrDefault(0) + 1;
                else
                    return null;
            }
            else
            {
                return InputObjectForColumnsOrFilters.Value.IndentationLevel.GetValueOrDefault(0) + 1;
            }
        }

        public override IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get
            {
                if (DataItem)
                {
                    yield return InputObjectForDataItems.RuntimeDefinedParameter;
                }
                else if (Column)
                {
                    yield return InputObjectForColumnsOrFilters.RuntimeDefinedParameter;
                }
                else if (Filter)
                {
                    yield return InputObjectForColumnsOrFilters.RuntimeDefinedParameter;
                }
            }
        }
    }
}
