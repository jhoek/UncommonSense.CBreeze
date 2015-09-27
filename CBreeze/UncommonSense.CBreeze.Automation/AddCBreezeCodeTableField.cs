using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeCodeTableField")]
    public class AddCBreezeCodeTableField : AddCBreezeTableField
    {
        public AddCBreezeCodeTableField()
        {
            DataLength = 10;
        }

        [Parameter()]
        [ValidateRange(1, 250)]
        public int DataLength
        {
            get;
            set;
        }

        [Parameter()]
        public string AltSearchField
        {
            get;
            set;
        }

        [Parameter()]
        public string AutoFormatExpr
        {
            get;
            set;
        }

        [Parameter()]
        public AutoFormatType? AutoFormatType
        {
            get;
            set;
        }

        [Parameter()]
        public string CalcFormulaFieldName
        {
            get;
            set;
        }

        [Parameter()]
        public CalcFormulaMethod? CalcFormulaMethod
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter CalcFormulaReverseSign
        {
            get;
            set;
        }

        [Parameter()]
        public string CalcFormulaTableName
        {
            get;
            set;
        }

        [Parameter()]
        public bool? NotBlank
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            foreach (var table in Table)
            {
                var field = table.Fields.Add(new CodeTableField(GetNo(), Name, DataLength));
                field.Properties.AltSearchField = AltSearchField;
                field.Properties.AutoFormatExpr = AutoFormatExpr;
                field.Properties.AutoFormatType = AutoFormatType;
                field.Properties.CalcFormula.FieldName = CalcFormulaFieldName;
                field.Properties.CalcFormula.Method = CalcFormulaMethod;
                field.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign;
                field.Properties.CalcFormula.TableName = CalcFormulaTableName;
                // FIXME: field.Properties.CalcFormula.T

                field.Properties.NotBlank = NotBlank;

                if (AutoCaption)
                    field.AutoCaption();

                if (PassThru)
                    WriteObject(field);
            }
        }
    }
}
