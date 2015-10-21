using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeFilter", DefaultParameterSetName = "Const")]
    public class AddCBreezeFilter : Cmdlet
    {
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

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "Const")]
        public SwitchParameter Const
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "Filter")]
        public SwitchParameter Filter
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "Field")]
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
        public SwitchParameter PassThru
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            if (InputObject.BaseObject is CalcFormula)
            {
                (InputObject.BaseObject as CalcFormula).TableFilter.Add(new CalcFormulaTableFilterLine(FieldName, TableFilterType, Value));
                PassThruInputObject(InputObject.BaseObject as CalcFormula);
                return;
            }

            if (InputObject.BaseObject is CalcFormulaTableFilter)
            {
                (InputObject.BaseObject as CalcFormulaTableFilter).Add(new CalcFormulaTableFilterLine(FieldName, TableFilterType, Value));
                PassThruInputObject(InputObject.BaseObject as CalcFormulaTableFilter);
                return;
            }

            if (InputObject.BaseObject is PartPageControl)
            {
                (InputObject.BaseObject as PartPageControl).Properties.SubPageView.TableFilter.Add(FieldName, SimpleTableFilterType, Value);
                PassThruInputObject(InputObject.BaseObject as PartPageControl);
                return;
            }

            if (InputObject.BaseObject is TableView)
            {
                (InputObject.BaseObject as TableView).TableFilter.Add(FieldName, SimpleTableFilterType, Value);
                PassThruInputObject(InputObject.BaseObject as TableView);
                return;
            }

            if (InputObject.BaseObject is TableFilter)
            {
                (InputObject.BaseObject as TableFilter).Add(FieldName, SimpleTableFilterType, Value);
                PassThruInputObject(InputObject.BaseObject as TableFilter);
                return;
            }

            if (InputObject.BaseObject is TableRelationTableFilter)
            {
                (InputObject.BaseObject as TableRelationTableFilter).Add(FieldName, TableFilterType, Value);
                PassThruInputObject(InputObject.BaseObject as TableRelationTableFilter);
                return;
            }

            if (InputObject.BaseObject is TableRelationLine)
            {
                (InputObject.BaseObject as TableRelationLine).TableFilter.Add(FieldName, TableFilterType, Value);
                PassThruInputObject(InputObject.BaseObject as TableRelationLine);
                return;
            }

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
