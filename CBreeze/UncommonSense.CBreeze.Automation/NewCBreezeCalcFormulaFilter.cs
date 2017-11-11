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
    [Alias("CalcFormulaFilter", "Add-CBreezeCalcFormulaFilter")]
    public class NewCBreezeCalcFormulaFilter : NewItemCmdlet<CalcFormulaTableFilterLine, CalcFormula>
    {
        protected override void AddItemToInputObject(CalcFormulaTableFilterLine item, CalcFormula calcFormula)
        {
            calcFormula.TableFilter.Add(item);
        }

        protected override IEnumerable<CalcFormulaTableFilterLine> CreateItems()
        {
            yield return new CalcFormulaTableFilterLine(FieldName, Type, Value)
            {
                OnlyMaxLimit = OnlyMaxLimit,
                ValueIsFilter = ValueIsFilter
            };
        }

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
    }
}