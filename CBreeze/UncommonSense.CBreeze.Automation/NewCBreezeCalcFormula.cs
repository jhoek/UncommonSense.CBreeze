using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeCalcFormula")]
    public class NewCBreezeCalcFormula : Cmdlet
    {
        protected override void EndProcessing()
        {
            var calcFormula = new CalcFormula();

            calcFormula.Method =
                Average.IsPresent ? CalcFormulaMethod.Average :
                Exist.IsPresent ? CalcFormulaMethod.Exist :
                Count.IsPresent ? CalcFormulaMethod.Count :
                Min.IsPresent ? CalcFormulaMethod.Min :
                Max.IsPresent ? CalcFormulaMethod.Max :
                Lookup.IsPresent ? CalcFormulaMethod.Lookup :
                CalcFormulaMethod.Sum;

            calcFormula.TableName = TableName;
            calcFormula.FieldName = FieldName;
            calcFormula.ReverseSign = ReverseSign.IsPresent;

            WriteObject(calcFormula);
        }

        [Parameter(Mandatory = true, ParameterSetName = "Sum")]
        public SwitchParameter Sum
        {
            get; set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "Average")]
        public SwitchParameter Average
        {
            get; set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "Exist")]
        public SwitchParameter Exist
        {
            get; set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "Count")]
        public SwitchParameter Count
        {
            get; set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "Min")]
        public SwitchParameter Min
        {
            get; set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "Max")]
        public SwitchParameter Max
        {
            get; set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "Lookup")]
        public SwitchParameter Lookup
        {
            get; set;
        }

        [Parameter(Mandatory = true, Position = 0)]
        public string TableName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "Sum", Position = 1)]
        [Parameter(Mandatory = true, ParameterSetName = "Average", Position = 1)]
        [Parameter(Mandatory = true, ParameterSetName = "Min", Position = 1)]
        [Parameter(Mandatory = true, ParameterSetName = "Max", Position = 1)]
        [Parameter(Mandatory = true, ParameterSetName = "Lookup", Position = 1)]
        public string FieldName
        {
            get; set;
        }

        [Parameter(ParameterSetName = "Sum")]
        [Parameter(ParameterSetName = "Average")]
        [Parameter(ParameterSetName = "Exist")]
        public SwitchParameter ReverseSign
        {
            get; set;
        }
    }
}
