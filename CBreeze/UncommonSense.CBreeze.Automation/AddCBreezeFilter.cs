using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeFilter", DefaultParameterSetName = ConstParameterSetName)]
    public class AddCBreezeFilter : Cmdlet
    {
        private const string ConstParameterSetName = "Const";
        private const string FilterParameterSetName = "Filter";
        private const string FieldParameterSetName = "Field";

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0)]
        public string FieldName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ConstParameterSetName)]
        public SwitchParameter Const
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = FilterParameterSetName)]
        public SwitchParameter Filter
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = FieldParameterSetName)]
        public SwitchParameter Field
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 2)]
        [AllowEmptyString]
        public string Value
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter OnlyMaxLimit
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter ValueIsFilter
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
            TypeSwitch.Do(
                InputObject.BaseObject,
                TypeSwitch.Case<CalcFormula>(i => i.TableFilter.Add(
                    new CalcFormulaTableFilterLine(FieldName, TableFilterType, Value)
                    {
                        OnlyMaxLimit = OnlyMaxLimit ,
                        ValueIsFilter = ValueIsFilter 
                    })),
                TypeSwitch.Case<CalcFormulaTableFilter>(i => i.Add(new CalcFormulaTableFilterLine(FieldName, TableFilterType, Value)
                {
                    OnlyMaxLimit = OnlyMaxLimit ,
                    ValueIsFilter = ValueIsFilter 
                }
                )),
                TypeSwitch.Case<PartPageControl>(i => i.Properties.SubPageView.TableFilter.Add(new TableFilterLine(FieldName, SimpleTableFilterType, Value))),
                TypeSwitch.Case<TableView>(i => i.TableFilter.Add(new TableFilterLine(FieldName, SimpleTableFilterType, Value))),
                TypeSwitch.Case<TableFilter>(i => i.Add(new TableFilterLine(FieldName, SimpleTableFilterType, Value))),
                TypeSwitch.Case<TableRelationTableFilter>(i => i.Add(new TableRelationTableFilterLine(FieldName, TableFilterType, Value))),
                TypeSwitch.Case<TableRelationLine>(i => i.TableFilter.Add(new TableRelationTableFilterLine(FieldName, TableFilterType, Value))),
                TypeSwitch.Case<DataItemQueryElement>(i => i.Properties.DataItemTableFilter.Add(new DataItemQueryElementTableFilterLine(FieldName, SimpleTableFilterType, Value))),
                TypeSwitch.Case<DataItemQueryElementTableFilter>(i => i.Add(new DataItemQueryElementTableFilterLine(FieldName, SimpleTableFilterType, Value))),
                TypeSwitch.Case<ColumnQueryElement>(i => i.Properties.ColumnFilter.Add(new ColumnFilterLine(FieldName, SimpleTableFilterType, Value))),
                TypeSwitch.Case<ColumnFilter>(i => i.Add(new ColumnFilterLine(FieldName, SimpleTableFilterType, Value))),
                TypeSwitch.Case<FilterQueryElement>(i => i.Properties.ColumnFilter.Add(new ColumnFilterLine(FieldName, SimpleTableFilterType, Value))),
                TypeSwitch.Default(() => InvalidInputObject())
                );

            PassThruInputObject(InputObject);
        }

        protected void InvalidInputObject()
        {
            throw new ArgumentOutOfRangeException("Cannot add a filter to this object.");
        }

        protected void PassThruInputObject(object inputObject)
        {
            if (PassThru)
                WriteObject(inputObject);
        }

        protected TableFilterType TableFilterType
        {
            get
            {
                if (Const.IsPresent)
                    return Core.TableFilterType.Const;
                if (Filter.IsPresent)
                    return Core.TableFilterType.Filter;
                if (Field.IsPresent)
                    return Core.TableFilterType.Field;

                throw new ArgumentOutOfRangeException("ExtendedTableFilterType");
            }
        }

        protected SimpleTableFilterType SimpleTableFilterType
        {
            get
            {
                if (Const.IsPresent)
                    return SimpleTableFilterType.Const;
                if (Filter.IsPresent)
                    return Core.SimpleTableFilterType.Filter;

                throw new ArgumentOutOfRangeException("SimpleTableFilterType");
            }
        }
    }
}
