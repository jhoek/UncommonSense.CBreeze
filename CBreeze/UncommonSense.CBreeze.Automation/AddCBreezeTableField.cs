using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTableField", DefaultParameterSetName="Range")]
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
            CalcFormulaReverseSign = new DynamicParameter<bool?>("CalcFormulaReverseSign", false);
            CalcFormulaTableName = new DynamicParameter<string>("CalcFormulaTableName", false);
            CaptionClass = new DynamicParameter<string>("CaptionClass", false);
            CharAllowed = new DynamicParameter<string>("CharAllowed", false);
            ClosingDates = new DynamicParameter<bool?>("ClosingDates", false);
            Compressed = new DynamicParameter<bool?>("Compressed", false);
            DateFormula = new DynamicParameter<bool?>("DateFormula", false);
            DataLength = new DynamicParameter<int?>("DataLength", false, 1, 250);
            DecimalPlacesAtLeast = new DynamicParameter<int?>("DecimalPlacesAtLeast", false);
            DecimalPlacesAtMost = new DynamicParameter<int?>("DecimalPlacesAtMost", false);
            Editable = new DynamicParameter<bool?>("Editable", false);
            Enabled = new DynamicParameter<bool?>("Enabled", false);
            ExtendedDataType = new DynamicParameter<Core.ExtendedDataType?>("ExtendedDataType", false);
            FieldClass = new DynamicParameter<FieldClass?>("FieldClass", false);
            BigIntegerInitValue = new DynamicParameter<long?>("InitValue", false);
            BooleanInitValue = new DynamicParameter<bool?>("InitValue", false);
            DateTimeInitValue = new DynamicParameter<DateTime?>("InitValue", false);
            DecimalInitValue = new DynamicParameter<decimal?>("InitValue", false);
            TextualInitValue = new DynamicParameter<string>("InitValue", false);
            BigIntegerMaxValue = new DynamicParameter<long?>("MaxValue", false);
            BooleanMaxValue = new DynamicParameter<bool?>("MaxValue", false);
            DateTimeMaxValue = new DynamicParameter<DateTime?>("MaxValue", false);
            DecimalMaxValue = new DynamicParameter<decimal?>("MaxValue", false);
            BigIntegerMinValue = new DynamicParameter<long?>("MinValue", false);
            BooleanMinValue = new DynamicParameter<bool?>("MinValue", false);
            DateTimeMinValue = new DynamicParameter<DateTime?>("MinValue", false);
            DecimalMinValue = new DynamicParameter<decimal?>("MinValue", false);
            NotBlank = new DynamicParameter<bool?>("NotBlank", false);
            Numeric = new DynamicParameter<bool?>("Numeric", false);
            Owner = new DynamicParameter<string>("Owner", false);
            SignDisplacement = new DynamicParameter<int?>("SignDisplacement", false);
            SqlDataType = new DynamicParameter<Core.SqlDataType?>("SqlDataType", false);
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

        protected DynamicParameter<bool?> Enabled
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

        protected DynamicParameter<bool?> CalcFormulaReverseSign
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

        protected DynamicParameter<string> CharAllowed
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> ClosingDates
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> Compressed
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> DateFormula
        {
            get;
            set;
        }

        protected DynamicParameter<int?> DataLength
        {
            get;
            set;
        }

        protected DynamicParameter<int?> DecimalPlacesAtLeast
        {
            get;
            set;
        }

        protected DynamicParameter<int?> DecimalPlacesAtMost
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

        protected DynamicParameter<bool?> BooleanInitValue
        {
            get;
            set;
        }

        protected DynamicParameter<DateTime?> DateTimeInitValue
        {
            get;
            set;
        }

        protected DynamicParameter<Decimal?> DecimalInitValue
        {
            get;
            set;
        }

        protected DynamicParameter<string> TextualInitValue
        {
            get;
            set;
        }

        protected DynamicParameter<long?> BigIntegerMaxValue
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> BooleanMaxValue
        {
            get;
            set;
        }

        protected DynamicParameter<DateTime?> DateTimeMaxValue
        {
            get;
            set;
        }

        protected DynamicParameter<decimal?> DecimalMaxValue
        {
            get;
            set;
        }

        protected DynamicParameter<long?> BigIntegerMinValue
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> BooleanMinValue
        {
            get;
            set;
        }

        protected DynamicParameter<DateTime?> DateTimeMinValue
        {
            get;
            set;
        }

        protected DynamicParameter<decimal?> DecimalMinValue
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> NotBlank
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> Numeric
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

        protected DynamicParameter<SqlDataType?> SqlDataType
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
            tableField.Enabled = Enabled.Value;

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
                    bigIntegerTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value ?? false;
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
                    var binaryTableField = new BinaryTableField(GetTableFieldNo(), Name, DataLength.Value ?? 4);
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

                #region Boolean
                case TableFieldType.Boolean:
                    var booleanTableField = new BooleanTableField(GetTableFieldNo(), Name);
                    booleanTableField.Properties.AltSearchField = AltSearchField.Value;
                    booleanTableField.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    booleanTableField.Properties.AutoFormatType = AutoFormatType.Value;
                    booleanTableField.Properties.BlankNumbers = BlankNumbers.Value;
                    booleanTableField.Properties.BlankZero = BlankZero.Value;
                    booleanTableField.Properties.CalcFormula.FieldName = CalcFormulaFieldName.Value;
                    booleanTableField.Properties.CalcFormula.Method = CalcFormulaMethod.Value;
                    booleanTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value ?? false;
                    booleanTableField.Properties.CalcFormula.TableName = CalcFormulaTableName.Value;
                    booleanTableField.Properties.CaptionClass = CaptionClass.Value;
                    booleanTableField.Properties.Description = Description;
                    booleanTableField.Properties.Editable = Editable.Value;
                    booleanTableField.Properties.ExtendedDatatype = ExtendedDataType.Value;
                    booleanTableField.Properties.FieldClass = FieldClass.Value;
                    booleanTableField.Properties.InitValue = BooleanInitValue.Value;
                    booleanTableField.Properties.MaxValue = BooleanMaxValue.Value;
                    booleanTableField.Properties.MinValue = BooleanMinValue.Value;
                    booleanTableField.Properties.NotBlank = NotBlank.Value;
                    booleanTableField.Properties.SignDisplacement = SignDisplacement.Value;
                    booleanTableField.Properties.TestTableRelation = TestTableRelation.Value;
                    booleanTableField.Properties.ValidateTableRelation = ValidateTableRelation.Value;
                    booleanTableField.Properties.ValuesAllowed = ValuesAllowed.Value;

                    if (AutoCaption)
                        booleanTableField.AutoCaption();

                    return booleanTableField;
                #endregion

                #region Code
                case TableFieldType.Code:
                    var codeTableField = new CodeTableField(GetTableFieldNo(), Name, DataLength.Value ?? 10);
                    codeTableField.Properties.AltSearchField = AltSearchField.Value;
                    codeTableField.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    codeTableField.Properties.AutoFormatType = AutoFormatType.Value;
                    codeTableField.Properties.CalcFormula.FieldName = CalcFormulaFieldName.Value;
                    codeTableField.Properties.CalcFormula.Method = CalcFormulaMethod.Value;
                    codeTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value ?? false;
                    codeTableField.Properties.CalcFormula.TableName = CalcFormulaTableName.Value;
                    codeTableField.Properties.CaptionClass = CaptionClass.Value;
                    codeTableField.Properties.CharAllowed = CharAllowed.Value;
                    codeTableField.Properties.DateFormula = DateFormula.Value;
                    codeTableField.Properties.Description = Description;
                    codeTableField.Properties.Editable = Editable.Value;
                    codeTableField.Properties.ExtendedDatatype = ExtendedDataType.Value;
                    codeTableField.Properties.FieldClass = FieldClass.Value;
                    codeTableField.Properties.InitValue = TextualInitValue.Value;
                    codeTableField.Properties.NotBlank = NotBlank.Value;
                    codeTableField.Properties.Numeric = Numeric.Value;
                    codeTableField.Properties.SQLDataType = SqlDataType.Value;
                    codeTableField.Properties.TestTableRelation = TestTableRelation.Value;
                    codeTableField.Properties.ValidateTableRelation = ValidateTableRelation.Value;
                    codeTableField.Properties.ValuesAllowed = ValuesAllowed.Value;
                    codeTableField.Properties.Width = Width.Value;

                    if (AutoCaption)
                        codeTableField.AutoCaption();

                    return codeTableField;
                #endregion

                #region Date
                case TableFieldType.Date:
                    var dateTableField = new DateTableField(GetTableFieldNo(), Name);
                    dateTableField.Properties.AltSearchField = AltSearchField.Value;
                    dateTableField.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    dateTableField.Properties.AutoFormatType = AutoFormatType.Value;
                    dateTableField.Properties.BlankNumbers = BlankNumbers.Value;
                    dateTableField.Properties.CalcFormula.FieldName = CalcFormulaFieldName.Value;
                    dateTableField.Properties.CalcFormula.Method = CalcFormulaMethod.Value;
                    dateTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value ?? false;
                    dateTableField.Properties.CalcFormula.TableName = CalcFormulaTableName.Value;
                    dateTableField.Properties.CaptionClass = CaptionClass.Value;
                    dateTableField.Properties.ClosingDates = ClosingDates.Value;
                    dateTableField.Properties.Description = Description;
                    dateTableField.Properties.Editable = Editable.Value;
                    dateTableField.Properties.ExtendedDatatype = ExtendedDataType.Value;
                    dateTableField.Properties.FieldClass = FieldClass.Value;
                    dateTableField.Properties.InitValue = DateTimeInitValue.Value;
                    dateTableField.Properties.MaxValue = DateTimeMaxValue.Value;
                    dateTableField.Properties.MinValue = DateTimeMinValue.Value;
                    dateTableField.Properties.NotBlank = NotBlank.Value;
                    dateTableField.Properties.SignDisplacement = SignDisplacement.Value;
                    dateTableField.Properties.TestTableRelation = TestTableRelation.Value;
                    dateTableField.Properties.ValidateTableRelation = ValidateTableRelation.Value;
                    dateTableField.Properties.ValuesAllowed = ValuesAllowed.Value;

                    if (AutoCaption)
                        dateTableField.AutoCaption();

                    return dateTableField;
                #endregion

                #region DateFormula
                case TableFieldType.DateFormula:
                    var dateFormulaTableField = new DateFormulaTableField(GetTableFieldNo(), Name);
                    dateFormulaTableField.Properties.AltSearchField = AltSearchField.Value;
                    dateFormulaTableField.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    dateFormulaTableField.Properties.AutoFormatType = AutoFormatType.Value;
                    dateFormulaTableField.Properties.CalcFormula.FieldName = CalcFormulaFieldName.Value;
                    dateFormulaTableField.Properties.CalcFormula.Method = CalcFormulaMethod.Value;
                    dateFormulaTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value ?? false;
                    dateFormulaTableField.Properties.CalcFormula.TableName = CalcFormulaTableName.Value;
                    dateFormulaTableField.Properties.CaptionClass = CaptionClass.Value;
                    dateFormulaTableField.Properties.Description = Description;
                    dateFormulaTableField.Properties.Editable = Editable.Value;
                    dateFormulaTableField.Properties.ExtendedDatatype = ExtendedDataType.Value;
                    dateFormulaTableField.Properties.FieldClass = FieldClass.Value;
                    dateFormulaTableField.Properties.InitValue = TextualInitValue.Value;
                    dateFormulaTableField.Properties.NotBlank = NotBlank.Value;
                    dateFormulaTableField.Properties.TestTableRelation = TestTableRelation.Value;
                    dateFormulaTableField.Properties.ValidateTableRelation = ValidateTableRelation.Value;
                    dateFormulaTableField.Properties.ValuesAllowed = ValuesAllowed.Value;

                    if (AutoCaption)
                        dateFormulaTableField.AutoCaption();

                    return dateFormulaTableField;
                #endregion

                #region DateTime
                case TableFieldType.DateTime:
                    var dateTimeTableField = new DateTimeTableField(GetTableFieldNo(), Name);
                    dateTimeTableField.Properties.AltSearchField = AltSearchField.Value;
                    dateTimeTableField.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    dateTimeTableField.Properties.AutoFormatType = AutoFormatType.Value;
                    dateTimeTableField.Properties.BlankNumbers = BlankNumbers.Value;
                    dateTimeTableField.Properties.CalcFormula.FieldName = CalcFormulaFieldName.Value;
                    dateTimeTableField.Properties.CalcFormula.Method = CalcFormulaMethod.Value;
                    dateTimeTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value ?? false;
                    dateTimeTableField.Properties.CalcFormula.TableName = CalcFormulaTableName.Value;
                    dateTimeTableField.Properties.CaptionClass = CaptionClass.Value;
                    dateTimeTableField.Properties.Description = Description;
                    dateTimeTableField.Properties.Editable = Editable.Value;
                    dateTimeTableField.Properties.ExtendedDatatype = ExtendedDataType.Value;
                    dateTimeTableField.Properties.FieldClass = FieldClass.Value;
                    dateTimeTableField.Properties.InitValue = DateTimeInitValue.Value;
                    dateTimeTableField.Properties.MinValue = DateTimeMinValue.Value;
                    dateTimeTableField.Properties.MaxValue = DateTimeMaxValue.Value;
                    dateTimeTableField.Properties.NotBlank = NotBlank.Value;
                    dateTimeTableField.Properties.SignDisplacement = SignDisplacement.Value;
                    dateTimeTableField.Properties.TestTableRelation = TestTableRelation.Value;
                    dateTimeTableField.Properties.ValidateTableRelation = ValidateTableRelation.Value;
                    dateTimeTableField.Properties.ValuesAllowed = ValuesAllowed.Value;
                    dateTimeTableField.Properties.Volatile = Volatile.Value;

                    if (AutoCaption)
                        dateTimeTableField.AutoCaption();

                    return dateTimeTableField;
                #endregion

                #region Decimal
                case TableFieldType.Decimal:
                    var decimalTableField = new DecimalTableField(GetTableFieldNo(), Name);
                    decimalTableField.Properties.AltSearchField = AltSearchField.Value;
                    decimalTableField.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    decimalTableField.Properties.AutoFormatType = AutoFormatType.Value;
                    decimalTableField.Properties.BlankNumbers = BlankNumbers.Value;
                    decimalTableField.Properties.BlankZero = BlankZero.Value;
                    decimalTableField.Properties.CalcFormula.FieldName = CalcFormulaFieldName.Value;
                    decimalTableField.Properties.CalcFormula.Method = CalcFormulaMethod.Value;
                    decimalTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value ?? false;
                    decimalTableField.Properties.CalcFormula.TableName = CalcFormulaTableName.Value;
                    decimalTableField.Properties.CaptionClass = CaptionClass.Value;
                    decimalTableField.Properties.DecimalPlaces.AtLeast = DecimalPlacesAtLeast.Value;
                    decimalTableField.Properties.DecimalPlaces.AtMost = DecimalPlacesAtMost.Value;
                    decimalTableField.Properties.Description = Description;
                    decimalTableField.Properties.Editable = Editable.Value;
                    decimalTableField.Properties.ExtendedDatatype = ExtendedDataType.Value;
                    decimalTableField.Properties.FieldClass = FieldClass.Value;
                    decimalTableField.Properties.InitValue = DecimalInitValue.Value;
                    decimalTableField.Properties.MinValue = DecimalMinValue.Value;
                    decimalTableField.Properties.MaxValue = DecimalMaxValue.Value;
                    decimalTableField.Properties.NotBlank = NotBlank.Value;
                    decimalTableField.Properties.SignDisplacement = SignDisplacement.Value;
                    decimalTableField.Properties.TestTableRelation = TestTableRelation.Value;
                    decimalTableField.Properties.ValidateTableRelation = ValidateTableRelation.Value;
                    decimalTableField.Properties.ValuesAllowed = ValuesAllowed.Value;
                    decimalTableField.Properties.Width = Width.Value;

                    if (AutoCaption)
                        decimalTableField.AutoCaption();

                    return decimalTableField;
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
                    timeTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value ?? false;
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
                yield return Enabled.RuntimeDefinedParameter;

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

                    #region Boolean
                    case TableFieldType.Boolean:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
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
                        yield return BooleanInitValue.RuntimeDefinedParameter;
                        yield return BooleanMaxValue.RuntimeDefinedParameter;
                        yield return BooleanMinValue.RuntimeDefinedParameter;
                        yield return NotBlank.RuntimeDefinedParameter;
                        yield return SignDisplacement.RuntimeDefinedParameter;
                        yield return TestTableRelation.RuntimeDefinedParameter;
                        yield return ValidateTableRelation.RuntimeDefinedParameter;
                        yield return ValuesAllowed.RuntimeDefinedParameter;
                        break;
                    #endregion

                    #region Code
                    case TableFieldType.Code:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return CalcFormulaFieldName.RuntimeDefinedParameter;
                        yield return CalcFormulaMethod.RuntimeDefinedParameter;
                        yield return CalcFormulaReverseSign.RuntimeDefinedParameter;
                        yield return CalcFormulaTableName.RuntimeDefinedParameter;
                        yield return CaptionClass.RuntimeDefinedParameter;
                        yield return CharAllowed.RuntimeDefinedParameter;
                        yield return DataLength.RuntimeDefinedParameter;
                        yield return DateFormula.RuntimeDefinedParameter;
                        yield return ExtendedDataType.RuntimeDefinedParameter;
                        yield return Editable.RuntimeDefinedParameter;
                        yield return FieldClass.RuntimeDefinedParameter;
                        yield return TextualInitValue.RuntimeDefinedParameter;
                        yield return NotBlank.RuntimeDefinedParameter;
                        yield return Numeric.RuntimeDefinedParameter;
                        yield return SqlDataType.RuntimeDefinedParameter;
                        yield return TestTableRelation.RuntimeDefinedParameter;
                        yield return ValidateTableRelation.RuntimeDefinedParameter;
                        yield return ValuesAllowed.RuntimeDefinedParameter;
                        yield return Width.RuntimeDefinedParameter;
                        break;
                    #endregion

                    #region Date
                    case TableFieldType.Date:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return BlankNumbers.RuntimeDefinedParameter;
                        yield return CalcFormulaFieldName.RuntimeDefinedParameter;
                        yield return CalcFormulaMethod.RuntimeDefinedParameter;
                        yield return CalcFormulaReverseSign.RuntimeDefinedParameter;
                        yield return CalcFormulaTableName.RuntimeDefinedParameter;
                        yield return CaptionClass.RuntimeDefinedParameter;
                        yield return ClosingDates.RuntimeDefinedParameter;
                        yield return Editable.RuntimeDefinedParameter;
                        yield return ExtendedDataType.RuntimeDefinedParameter;
                        yield return FieldClass.RuntimeDefinedParameter;
                        yield return DateTimeInitValue.RuntimeDefinedParameter;
                        yield return DateTimeMaxValue.RuntimeDefinedParameter;
                        yield return DateTimeMinValue.RuntimeDefinedParameter;
                        yield return NotBlank.RuntimeDefinedParameter;
                        yield return SignDisplacement.RuntimeDefinedParameter;
                        yield return TestTableRelation.RuntimeDefinedParameter;
                        yield return ValidateTableRelation.RuntimeDefinedParameter;
                        yield return ValuesAllowed.RuntimeDefinedParameter;
                        break;
                    #endregion

                    #region DateFormula
                    case TableFieldType.DateFormula:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return CalcFormulaFieldName.RuntimeDefinedParameter;
                        yield return CalcFormulaMethod.RuntimeDefinedParameter;
                        yield return CalcFormulaReverseSign.RuntimeDefinedParameter;
                        yield return CalcFormulaTableName.RuntimeDefinedParameter;
                        yield return CaptionClass.RuntimeDefinedParameter;
                        yield return Editable.RuntimeDefinedParameter;
                        yield return ExtendedDataType.RuntimeDefinedParameter;
                        yield return FieldClass.RuntimeDefinedParameter;
                        yield return TextualInitValue.RuntimeDefinedParameter;
                        yield return NotBlank.RuntimeDefinedParameter;
                        yield return TestTableRelation.RuntimeDefinedParameter;
                        yield return ValidateTableRelation.RuntimeDefinedParameter;
                        yield return ValuesAllowed.RuntimeDefinedParameter;
                        break;
                    #endregion

                    #region DateTime
                    case TableFieldType.DateTime:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return BlankNumbers.RuntimeDefinedParameter;
                        yield return CalcFormulaFieldName.RuntimeDefinedParameter;
                        yield return CalcFormulaMethod.RuntimeDefinedParameter;
                        yield return CalcFormulaReverseSign.RuntimeDefinedParameter;
                        yield return CalcFormulaTableName.RuntimeDefinedParameter;
                        yield return CaptionClass.RuntimeDefinedParameter;
                        yield return Editable.RuntimeDefinedParameter;
                        yield return ExtendedDataType.RuntimeDefinedParameter;
                        yield return FieldClass.RuntimeDefinedParameter;
                        yield return DateTimeInitValue.RuntimeDefinedParameter;
                        yield return DateTimeMaxValue.RuntimeDefinedParameter;
                        yield return DateTimeMinValue.RuntimeDefinedParameter;
                        yield return NotBlank.RuntimeDefinedParameter;
                        yield return SignDisplacement.RuntimeDefinedParameter;
                        yield return TestTableRelation.RuntimeDefinedParameter;
                        yield return ValidateTableRelation.RuntimeDefinedParameter;
                        yield return ValuesAllowed.RuntimeDefinedParameter;
                        yield return Volatile.RuntimeDefinedParameter;
                        break;
                    #endregion

                    #region Decimal
                    case TableFieldType.Decimal:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return BlankNumbers.RuntimeDefinedParameter;
                        yield return BlankZero.RuntimeDefinedParameter;
                        yield return CalcFormulaFieldName.RuntimeDefinedParameter;
                        yield return CalcFormulaMethod.RuntimeDefinedParameter;
                        yield return CalcFormulaReverseSign.RuntimeDefinedParameter;
                        yield return CalcFormulaTableName.RuntimeDefinedParameter;
                        yield return CaptionClass.RuntimeDefinedParameter;
                        yield return DecimalPlacesAtLeast.RuntimeDefinedParameter;
                        yield return DecimalPlacesAtMost.RuntimeDefinedParameter;
                        yield return Editable.RuntimeDefinedParameter;
                        yield return ExtendedDataType.RuntimeDefinedParameter;
                        yield return FieldClass.RuntimeDefinedParameter;
                        yield return DecimalInitValue.RuntimeDefinedParameter;
                        yield return DecimalMaxValue.RuntimeDefinedParameter;
                        yield return DecimalMinValue.RuntimeDefinedParameter;
                        yield return NotBlank.RuntimeDefinedParameter;
                        yield return SignDisplacement.RuntimeDefinedParameter;
                        yield return TestTableRelation.RuntimeDefinedParameter;
                        yield return ValidateTableRelation.RuntimeDefinedParameter;
                        yield return ValuesAllowed.RuntimeDefinedParameter;
                        yield return Width.RuntimeDefinedParameter;
                        break;
                    #endregion

                    #region Time
                    case TableFieldType.Time:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        break;
                    #endregion
                }
            }
        }
    }
}
