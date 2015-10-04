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

        protected override void ProcessRecord()
        {
            WriteVerbose(InputObject.BaseObject.GetType().FullName);

            if (InputObject.BaseObject is CalcFormula)
            {
                (InputObject.BaseObject as CalcFormula).TableFilter.Add(new CalcFormulaTableFilterLine(FieldName, ExtendedTableFilterType, Value));
                return;
            }

            throw new ArgumentOutOfRangeException("InputObject"); // FIXME
        }

        public bool SupportsFieldFilters
        {
            get
            {
                if (InputObject == null)
                    return false;

                if (InputObject.BaseObject is CalcFormula)
                    return true;

                if (InputObject.BaseObject is TableRelationLines)
                    return true;

                return false;
            }
        }

        protected ExtendedTableFilterType ExtendedTableFilterType
        {
            get
            {
                if (Const.IsPresent)
                    return Core.ExtendedTableFilterType.Const;
                if (Filter.IsPresent)
                    return Core.ExtendedTableFilterType.Filter;
                if (Field.IsPresent)
                    return Core.ExtendedTableFilterType.Field;

                throw new ArgumentOutOfRangeException("ExtendedTableFilterType");
            }
        }
    }
}
