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
            Compressed = new DynamicParameter<bool?>("Compressed", false);
            DataLength = new DynamicParameter<int>("DataLength", true, 1, 250);
            Editable = new DynamicParameter<bool?>("Editable", false);
            ExtendedDataType = new DynamicParameter<Core.ExtendedDataType?>("ExtendedDataType", false);
            FieldClass = new DynamicParameter<FieldClass?>("FieldClass", false);
            BigIntegerInitValue = new DynamicParameter<long?>("InitValue", false);
            BigIntegerMaxValue = new DynamicParameter<long?>("MaxValue", false);
            BigIntegerMinValue = new DynamicParameter<long?>("MinValue", false);
            NotBlank = new DynamicParameter<bool?>("NotBlank", false);
            Owner = new DynamicParameter<string>("Owner", false);
            SignDisplacement = new DynamicParameter<int?>("SignDisplacement", false);
            SubType = new DynamicParameter<BlobSubType?>("SubType", false);
            TestTableRelation = new DynamicParameter<bool?>("TestTableRelation", false);
            ValidateTableRelation = new DynamicParameter<bool?>("ValidateTableRelation", false);
            ValuesAllowed = new DynamicParameter<string>("ValuesAllowed", false);
            Volatile = new DynamicParameter<bool?>("Volatile", false);
            Width = new DynamicParameter<int?>("Width", false);
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

        protected DynamicParameter<bool?> Compressed
        {
            get;
            set;
        }

        protected DynamicParameter<int> DataLength
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

        protected DynamicParameter<long?> BigIntegerInitValue
        {
            get;
            set;
        }

        protected DynamicParameter<long?> BigIntegerMaxValue
        {
            get;
            set;
        }

        protected DynamicParameter<long?> BigIntegerMinValue
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> NotBlank
        {
            get;
            set;
        }

        protected DynamicParameter<string> Owner
        {
            get;
            set;
        }

        protected DynamicParameter<int?> SignDisplacement
        {
            get;
            set;
        }

        protected DynamicParameter<BlobSubType?> SubType
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> TestTableRelation
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> ValidateTableRelation
        {
            get;
            set;
        }

        protected DynamicParameter<string> ValuesAllowed
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> Volatile
        {
            get;
            set;
        }

        protected DynamicParameter<int?> Width
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
                #region BigInteger
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
                    // FIXME: bigIntegerTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value;
                    bigIntegerTableField.Properties.CalcFormula.TableName = CalcFormulaTableName.Value;
                    bigIntegerTableField.Properties.CaptionClass = CaptionClass.Value;
                    bigIntegerTableField.Properties.Description = Description;
                    bigIntegerTableField.Properties.Editable = Editable.Value;
                    bigIntegerTableField.Properties.ExtendedDatatype = ExtendedDataType.Value;
                    bigIntegerTableField.Properties.FieldClass = FieldClass.Value;
                    bigIntegerTableField.Properties.InitValue = BigIntegerInitValue.Value;
                    bigIntegerTableField.Properties.MaxValue = BigIntegerMaxValue.Value;
                    bigIntegerTableField.Properties.MinValue = BigIntegerMinValue.Value;
                    bigIntegerTableField.Properties.NotBlank = NotBlank.Value;
                    bigIntegerTableField.Properties.SignDisplacement = SignDisplacement.Value;
                    bigIntegerTableField.Properties.TestTableRelation = TestTableRelation.Value;
                    bigIntegerTableField.Properties.ValidateTableRelation = ValidateTableRelation.Value;
                    bigIntegerTableField.Properties.ValuesAllowed = ValuesAllowed.Value;
                    bigIntegerTableField.Properties.Volatile = Volatile.Value;
                    bigIntegerTableField.Properties.Width = Width.Value;

                    if (AutoCaption)
                        bigIntegerTableField.AutoCaption();

                    return bigIntegerTableField;
                #endregion

                #region Binary
                case TableFieldType.Binary:
                    var binaryTableField = new BinaryTableField(GetTableFieldNo(), Name, DataLength.Value);
                    binaryTableField.Properties.Description = Description;

                    if (AutoCaption)
                        binaryTableField.AutoCaption();

                    return binaryTableField;
                #endregion

                #region Blob
                case TableFieldType.Blob:
                    var blobTableField = new BlobTableField(GetTableFieldNo(), Name);
                    blobTableField.Properties.Compressed = Compressed.Value;
                    blobTableField.Properties.Description = Description;
                    blobTableField.Properties.Owner = Owner.Value;
                    blobTableField.Properties.SubType = SubType.Value;
                    blobTableField.Properties.Volatile = Volatile.Value;

                    if (AutoCaption)
                        blobTableField.AutoCaption();

                    return blobTableField;
                #endregion

                #region Time
                case TableFieldType.Time:
                    var timeTableField = new TimeTableField(GetTableFieldNo(), Name);
                    timeTableField.Properties.AltSearchField = AltSearchField.Value;
                    timeTableField.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    timeTableField.Properties.AutoFormatType = AutoFormatType.Value;
                    timeTableField.Properties.BlankNumbers = BlankNumbers.Value;
                    timeTableField.Properties.CalcFormula.Method = CalcFormulaMethod.Value;
                    timeTableField.Properties.CalcFormula.FieldName = CalcFormulaFieldName.Value;
                    timeTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value;
                    timeTableField.Properties.Description = Description;

                    if (AutoCaption)
                        timeTableField.AutoCaption();

                    return timeTableField;
                #endregion

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
                    #region BigInteger
                    case TableFieldType.BigInteger:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return AutoIncrement.RuntimeDefinedParameter;
                        yield return BlankNumbers.RuntimeDefinedParameter;
                        yield return BlankZero.RuntimeDefinedParameter;
                        yield return CalcFormulaFieldName.RuntimeDefinedParameter;
                        yield return CalcFormulaMethod.RuntimeDefinedParameter;
                        yield return CalcFormulaReverseSign.RuntimeDefinedParameter;
                        yield return CalcFormulaTableName.RuntimeDefinedParameter;
                        yield return CaptionClass.RuntimeDefinedParameter;
                        yield return Editable.RuntimeDefinedParameter;
                        yield return ExtendedDataType.RuntimeDefinedParameter;
                        yield return FieldClass.RuntimeDefinedParameter;
                        yield return BigIntegerInitValue.RuntimeDefinedParameter;
                        yield return BigIntegerMaxValue.RuntimeDefinedParameter;
                        yield return BigIntegerMinValue.RuntimeDefinedParameter;
                        yield return NotBlank.RuntimeDefinedParameter;
                        yield return SignDisplacement.RuntimeDefinedParameter;
                        yield return TestTableRelation.RuntimeDefinedParameter;
                        yield return ValidateTableRelation.RuntimeDefinedParameter;
                        yield return ValuesAllowed.RuntimeDefinedParameter;
                        yield return Volatile.RuntimeDefinedParameter;
                        yield return Width.RuntimeDefinedParameter;

                        break;
                    #endregion

                    #region Binary
                    case TableFieldType.Binary:
                        yield return DataLength.RuntimeDefinedParameter;
                        break;
                    #endregion

                    #region Blob
                    case TableFieldType.Blob:
                        yield return Compressed.RuntimeDefinedParameter;
                        yield return Owner.RuntimeDefinedParameter;
                        yield return SubType.RuntimeDefinedParameter;
                        yield return Volatile.RuntimeDefinedParameter;
                        break;
                    #endregion

                    #region Time
                    case TableFieldType.Time:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        break;
                    #endregion

                    default:
                        throw new ArgumentOutOfRangeException("Unknown field type.");
                }
            }
        }
    }
}
