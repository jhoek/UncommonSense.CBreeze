using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTableField")]
    public class AddCBreezeTableField : CmdletWithDynamicParams
    {
        public AddCBreezeTableField()
        {
            AltSearchField = new DynamicParameter<string>("AltSearchField", false);
            AutoFormatExpr = new DynamicParameter<string>("AutoFormatExpr", false);
            AutoFormatType = new DynamicParameter<AutoFormatType?>("AutoFormatType", false);
            AutoIncrement = new DynamicParameter<bool?>("AutoIncrement", false);
            BlankNumbers = new DynamicParameter<BlankNumbers?>("BlankNumbers", false);
            BlankZero = new DynamicParameter<bool?>("BlankZero", false);
            CalcFormulaFieldName = new DynamicParameter<string>("CalcFormulaFieldName", false);
            CalcFormulaMethod = new DynamicParameter<Core.CalcFormulaMethod?>("CalcFormulaMethod", false);
            CalcFormulaReverseSign = new DynamicParameter<bool>("CalcFormulaReverseSign", false);
            CalcFormulaTableName = new DynamicParameter<string>("CalcFormulaTableName", false);
            CaptionClass = new DynamicParameter<string>("CaptionClass", false);
            Editable = new DynamicParameter<bool?>("Editable", false);
            ExtendedDataType = new DynamicParameter<Core.ExtendedDataType?>("ExtendedDataType", false);
            // FIXME
            FieldClass = new DynamicParameter<FieldClass?>("FieldClass", false);
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Table Table
        {
            get;
            set;
        }

        [Parameter()]
        public TableFieldType? Type
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "Range")]
        public IEnumerable<int> Range
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "No")]
        [ValidateRange(1, int.MaxValue)]
        public int No
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0)]
        public string Name
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter AutoCaption
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

        [Parameter()]
        public SwitchParameter PrimaryKeyFieldNoRange
        {
            get;
            set;
        }

        [Parameter()]
        public bool? Enabled
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

        protected DynamicParameter<string> AltSearchField
        {
            get;
            set;
        }

        protected DynamicParameter<string> AutoFormatExpr
        {
            get;
            set;
        }

        protected DynamicParameter<AutoFormatType?> AutoFormatType
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> AutoIncrement
        {
            get;
            set;
        }

        protected DynamicParameter<BlankNumbers?> BlankNumbers
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> BlankZero
        {
            get;
            set;
        }

        protected DynamicParameter<CalcFormulaMethod?> CalcFormulaMethod
        {
            get;
            set;
        }

        protected DynamicParameter<string> CalcFormulaFieldName
        {
            get;
            set;
        }

        protected DynamicParameter<bool> CalcFormulaReverseSign
        {
            get;
            set;
        }

        protected DynamicParameter<string> CalcFormulaTableName
        {
            get;
            set;
        }

        protected DynamicParameter<string> CaptionClass
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> Editable
        {
            get;
            set;
        }

        protected DynamicParameter<ExtendedDataType?> ExtendedDataType
        {
            get;
            set;
        }

        protected DynamicParameter<FieldClass?> FieldClass
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            var tableField = Table.Fields.Add(CreateTableField());
            tableField.Enabled = Enabled;

            if (PassThru)
                WriteObject(tableField);
        }

        protected TableField CreateTableField()
        {
            switch (Type)
            {
                case TableFieldType.BigInteger:
                    var bigIntegerTableField = new BigIntegerTableField(GetTableFieldNo(), Name);
                    bigIntegerTableField.Properties.AltSearchField = AltSearchField.Value;
                    bigIntegerTableField.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    bigIntegerTableField.Properties.AutoFormatType = AutoFormatType.Value;
                    bigIntegerTableField.Properties.AutoIncrement = AutoIncrement.Value;
                    bigIntegerTableField.Properties.BlankNumbers = BlankNumbers.Value;
                    bigIntegerTableField.Properties.BlankZero = BlankZero.Value;
                    bigIntegerTableField.Properties.CalcFormula.FieldName = CalcFormulaFieldName.Value;
                    bigIntegerTableField.Properties.CalcFormula.Method = CalcFormulaMethod.Value;
                    //FIXME bigIntegerTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value;
                    bigIntegerTableField.Properties.CalcFormula.TableName = CalcFormulaTableName.Value;
                    bigIntegerTableField.Properties.CaptionClass = CaptionClass.Value;
                    bigIntegerTableField.Properties.Editable = Editable.Value;
                    bigIntegerTableField.Properties.ExtendedDatatype = ExtendedDataType.Value;
                    bigIntegerTableField.Properties.FieldClass = FieldClass.Value;
                    // FIXME
                    return bigIntegerTableField;

                case TableFieldType.Time:
                    var timeTableField = new TimeTableField(GetTableFieldNo(), Name);
                    timeTableField.Properties.AltSearchField = AltSearchField.Value;
                    timeTableField.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    timeTableField.Properties.AutoFormatType = AutoFormatType.Value;
                    timeTableField.Properties.BlankNumbers = BlankNumbers.Value;
                    timeTableField.Properties.CalcFormula.Method = CalcFormulaMethod.Value;
                    timeTableField.Properties.CalcFormula.FieldName = CalcFormulaFieldName.Value;
                    timeTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value;
                    return timeTableField;

                default:
                    throw new ArgumentOutOfRangeException("Unknown field type.");
            }
        }

        protected int GetTableFieldNo()
        {
            if (No != 0)
                return No;

            var range = Range;

            if (Range.Contains(Table.ID))
            {
                switch (PrimaryKeyFieldNoRange.IsPresent)
                {
                    case true:
                        range = 1.To(int.MaxValue);
                        break;
                    case false:
                        range = 10.To(int.MaxValue);
                        break;
                }
            }

            return range.Except(Table.Fields.Select(f => f.ID)).First();
        }

        public override IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get
            {
                switch (Type)
                {
                    case TableFieldType.BigInteger:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return AutoIncrement.RuntimeDefinedParameter;
                        yield return BlankNumbers.RuntimeDefinedParameter;
                        yield return BlankZero.RuntimeDefinedParameter;
                        // FIXME
                        yield return CalcFormulaFieldName.RuntimeDefinedParameter;
                        yield return CalcFormulaMethod.RuntimeDefinedParameter;
                        yield return CalcFormulaReverseSign.RuntimeDefinedParameter;
                        yield return CalcFormulaTableName.RuntimeDefinedParameter;
                        yield return CaptionClass.RuntimeDefinedParameter;
                        yield return Editable.RuntimeDefinedParameter;
                        yield return ExtendedDataType.RuntimeDefinedParameter;
                        // FIXME
                        yield return FieldClass.RuntimeDefinedParameter;

                        break;
                    case TableFieldType.Time:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        break;
                }
            }
        }
    }
}
