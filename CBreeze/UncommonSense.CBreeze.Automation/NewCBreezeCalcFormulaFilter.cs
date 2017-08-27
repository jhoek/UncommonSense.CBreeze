using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeCalcFormulaFilter", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(CalcFormulaTableFilterLine))]
    [Alias("CalcFormulaFilter")]
    public class NewCBreezeCalcFormulaFilter : NewItemCmdlet<CalcFormulaTableFilterLine, PSObject>
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string FieldName { get; set; }

        [Parameter()]
        public SwitchParameter OnlyMaxLimit { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        public TableFilterType Type { get; set; }

        [Parameter(Mandatory = true, Position = 3)]
        [AllowEmptyString]
        public string Value { get; set; }

        [Parameter()]
        public SwitchParameter ValueIsFilter { get; set; }

        protected override void AddItemToInputObject(CalcFormulaTableFilterLine item, PSObject inputObject)
        {
            switch (InputObject.BaseObject)
            {
                case CalcFormula c: c.TableFilter.Add(item); break;
                case CalcFormulaTableFilter f: f.Add(item); break;
                default: throw new ArgumentOutOfRangeException("Cannot add a CalcFormula filter to this object.");
            }
        }

        protected override IEnumerable<CalcFormulaTableFilterLine> CreateItems()
        {
            yield return new CalcFormulaTableFilterLine(FieldName, Type, Value) { OnlyMaxLimit = OnlyMaxLimit, ValueIsFilter = ValueIsFilter };
        }
    }
}