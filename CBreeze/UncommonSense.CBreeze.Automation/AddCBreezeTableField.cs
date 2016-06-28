using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTableField")]
    public class AddCBreezeTableField : CmdletWithDynamicParams
    {
        public AddCBreezeTableField()
        {
            AltSearchField = new DynamicParameter<string>("AltSearchField");
            AutoFormatExpr = new DynamicParameter<string>("AutoFormatExpr");
            AutoFormatType = new DynamicParameter<AutoFormatType?>("AutoFormatType");
            AutoIncrement = new DynamicParameter<bool?>("AutoIncrement");
            AutoOptionCaption = new DynamicParameter<SwitchParameter>("AutoOptionCaption");
            BlankNumbers = new DynamicParameter<BlankNumbers?>("BlankNumbers");
            BlankZero = new DynamicParameter<bool?>("BlankZero");
            CalcFormulaFieldName = new DynamicParameter<string>("CalcFormulaFieldName");
            CalcFormulaMethod = new DynamicParameter<Core.CalcFormulaMethod?>("CalcFormulaMethod");
            CalcFormulaReverseSign = new DynamicParameter<bool?>("CalcFormulaReverseSign");
            CalcFormulaTableName = new DynamicParameter<string>("CalcFormulaTableName");
            CaptionClass = new DynamicParameter<string>("CaptionClass");
            CharAllowed = new DynamicParameter<string>("CharAllowed");
            ClosingDates = new DynamicParameter<bool?>("ClosingDates");
            Compressed = new DynamicParameter<bool?>("Compressed");
            DateFormula = new DynamicParameter<bool?>("DateFormula");
            DataLength = new DynamicParameter<int?>("DataLength", minRange: 1, maxRange: 250);
            DecimalPlacesAtLeast = new DynamicParameter<int?>("DecimalPlacesAtLeast");
            DecimalPlacesAtMost = new DynamicParameter<int?>("DecimalPlacesAtMost");
            Editable = new DynamicParameter<bool?>("Editable");
            Enabled = new DynamicParameter<bool?>("Enabled");
            ExtendedDataType = new DynamicParameter<Core.ExtendedDataType?>("ExtendedDataType");
#if NAV2016
            ExternalAccess = new DynamicParameter<ExternalAccess?>("ExternalAccess");
            ExternalName = new DynamicParameter<string>("ExternalName");
            ExternalType = new DynamicParameter<string>("ExternalType");
#endif
            FieldClass = new DynamicParameter<FieldClass?>("FieldClass");
            BigIntegerInitValue = new DynamicParameter<long?>("InitValue");
            BooleanInitValue = new DynamicParameter<bool?>("InitValue");
            DateTimeInitValue = new DynamicParameter<DateTime?>("InitValue");
            DecimalInitValue = new DynamicParameter<decimal?>("InitValue");
            GuidInitValue = new DynamicParameter<Guid?>("InitValue");
            IntegerInitValue = new DynamicParameter<int?>("InitValue");
            TextualInitValue = new DynamicParameter<string>("InitValue");
            TimeSpanInitValue = new DynamicParameter<TimeSpan?>("InitValue");
            BigIntegerMaxValue = new DynamicParameter<long?>("MaxValue");
            BooleanMaxValue = new DynamicParameter<bool?>("MaxValue");
            DateTimeMaxValue = new DynamicParameter<DateTime?>("MaxValue");
            DecimalMaxValue = new DynamicParameter<decimal?>("MaxValue");
            IntegerMaxValue = new DynamicParameter<int?>("MaxValue");
            TextualMaxValue = new DynamicParameter<string>("MaxValue");
            TimeSpanMaxValue = new DynamicParameter<TimeSpan?>("MaxValue");
            BigIntegerMinValue = new DynamicParameter<long?>("MinValue");
            BooleanMinValue = new DynamicParameter<bool?>("MinValue");
            DateTimeMinValue = new DynamicParameter<DateTime?>("MinValue");
            DecimalMinValue = new DynamicParameter<decimal?>("MinValue");
            IntegerMinValue = new DynamicParameter<int?>("MinValue");
            TextualMinValue = new DynamicParameter<string>("MinValue");
            TimeSpanMinValue = new DynamicParameter<TimeSpan?>("MinValue");
            NotBlank = new DynamicParameter<bool?>("NotBlank");
            Numeric = new DynamicParameter<bool?>("Numeric");
            OptionString = new DynamicParameter<string>("OptionString");
#if NAV2016
            OptionOrdinalValues = new DynamicParameter<string>("OptionOrdinalValues");
#endif
            Owner = new DynamicParameter<string>("Owner");
            SignDisplacement = new DynamicParameter<int?>("SignDisplacement");
            SqlDataType = new DynamicParameter<Core.SqlDataType?>("SqlDataType");
            StandardDayTimeUnit = new DynamicParameter<Core.StandardDayTimeUnit?>("StandardDayTimeUnit");
            SubType = new DynamicParameter<BlobSubType?>("SubType");
            TableIDExpr = new DynamicParameter<string>("TableIDExpr");
            TestTableRelation = new DynamicParameter<bool?>("TestTableRelation");
            ValidateTableRelation = new DynamicParameter<bool?>("ValidateTableRelation");
            ValuesAllowed = new DynamicParameter<string>("ValuesAllowed");
            Volatile = new DynamicParameter<bool?>("Volatile");
            Width = new DynamicParameter<int?>("Width");
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Table Table
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position=2)]
        public TableFieldType? Type
        {
            get;
            set;
        }

        [Parameter(Mandatory=true, Position=0)]
        [Alias("Range")]
        public PSObject ID
        {
            get;set;
        }

        [Parameter(Mandatory = true, Position = 1)]
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

        protected DynamicParameter<SwitchParameter> AutoOptionCaption
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

        protected DynamicParameter<bool?> Enabled
        {
            get;
            set;
        }

        protected DynamicParameter<ExtendedDataType?> ExtendedDataType
        {
            get;
            set;
        }

#if NAV2016
        protected DynamicParameter<ExternalAccess?> ExternalAccess
        {
            get;
            set;
        }

        protected DynamicParameter<string> ExternalName
        {
            get;
            set;
        }

        protected DynamicParameter<string> ExternalType
        {
            get;
            set;
        }
#endif

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

        protected DynamicParameter<Guid?> GuidInitValue
        {
            get;
            set;
        }

        protected DynamicParameter<int?> IntegerInitValue
        {
            get;
            set;
        }

        protected DynamicParameter<string> TextualInitValue
        {
            get;
            set;
        }

        protected DynamicParameter<TimeSpan?> TimeSpanInitValue
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

        protected DynamicParameter<int?> IntegerMaxValue
        {
            get;
            set;
        }

        protected DynamicParameter<string> TextualMaxValue
        {
            get;
            set;
        }

        protected DynamicParameter<TimeSpan?> TimeSpanMaxValue
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

        protected DynamicParameter<int?> IntegerMinValue
        {
            get;
            set;
        }

        protected DynamicParameter<string> TextualMinValue
        {
            get;
            set;
        }

        protected DynamicParameter<TimeSpan?> TimeSpanMinValue
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

        protected DynamicParameter<string> OptionString
        {
            get;
            set;
        }

        protected DynamicParameter<string> OptionOrdinalValues
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

        protected DynamicParameter<StandardDayTimeUnit?> StandardDayTimeUnit
        {
            get;
            set;
        }

        protected DynamicParameter<BlobSubType?> SubType
        {
            get;
            set;
        }

        protected DynamicParameter<string> TableIDExpr
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
#if NAV2016
                    bigIntegerTableField.Properties.ExternalAccess = ExternalAccess.Value;
                    bigIntegerTableField.Properties.ExternalName = ExternalName.Value;
                    bigIntegerTableField.Properties.ExternalType = ExternalType.Value;
#endif
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
                case TableFieldType.BLOB:
                    var blobTableField = new BlobTableField(GetTableFieldNo(), Name);
                    blobTableField.Properties.Compressed = Compressed.Value;
                    blobTableField.Properties.Description = Description;
#if NAV2016
                    blobTableField.Properties.ExternalAccess = ExternalAccess.Value;
                    blobTableField.Properties.ExternalName = ExternalName.Value;
                    blobTableField.Properties.ExternalType = ExternalType.Value;
#endif
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
#if NAV2016
                    booleanTableField.Properties.ExternalAccess = ExternalAccess.Value;
                    booleanTableField.Properties.ExternalName = ExternalName.Value;
                    booleanTableField.Properties.ExternalType = ExternalType.Value;
#endif
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
#if NAV2016
                    codeTableField.Properties.ExternalAccess = ExternalAccess.Value;
                    codeTableField.Properties.ExternalName = ExternalName.Value;
                    codeTableField.Properties.ExternalType = ExternalType.Value;
#endif
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
#if NAV2016
                    dateTableField.Properties.ExternalAccess = ExternalAccess.Value;
                    dateTableField.Properties.ExternalName = ExternalName.Value;
                    dateTableField.Properties.ExternalType = ExternalType.Value;
#endif
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
#if NAV2016
                    dateFormulaTableField.Properties.ExternalAccess = ExternalAccess.Value;
                    dateFormulaTableField.Properties.ExternalName = ExternalName.Value;
                    dateFormulaTableField.Properties.ExternalType = ExternalType.Value;
#endif
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
#if NAV2016
                    dateTimeTableField.Properties.ExternalAccess = ExternalAccess.Value;
                    dateTimeTableField.Properties.ExternalName = ExternalName.Value;
                    dateTimeTableField.Properties.ExternalType = ExternalType.Value;
#endif
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
#if NAV2016
                    decimalTableField.Properties.ExternalAccess = ExternalAccess.Value;
                    decimalTableField.Properties.ExternalName = ExternalName.Value;
                    decimalTableField.Properties.ExternalType = ExternalType.Value;
#endif
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

                #region Duration
                case TableFieldType.Duration:
                    var durationTableField = new DurationTableField(GetTableFieldNo(), Name);
                    durationTableField.Properties.AltSearchField = AltSearchField.Value;
                    durationTableField.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    durationTableField.Properties.AutoFormatType = AutoFormatType.Value;
                    durationTableField.Properties.BlankNumbers = BlankNumbers.Value;
                    durationTableField.Properties.BlankZero = BlankZero.Value;
                    durationTableField.Properties.CalcFormula.FieldName = CalcFormulaFieldName.Value;
                    durationTableField.Properties.CalcFormula.Method = CalcFormulaMethod.Value;
                    durationTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value ?? false;
                    durationTableField.Properties.CalcFormula.TableName = CalcFormulaTableName.Value;
                    durationTableField.Properties.CaptionClass = CaptionClass.Value;
                    durationTableField.Properties.Description = Description;
                    durationTableField.Properties.Editable = Editable.Value;
                    durationTableField.Properties.ExtendedDatatype = ExtendedDataType.Value;
#if NAV2016
                    durationTableField.Properties.ExternalAccess = ExternalAccess.Value;
                    durationTableField.Properties.ExternalName = ExternalName.Value;
                    durationTableField.Properties.ExternalType = ExternalType.Value;
#endif
                    durationTableField.Properties.FieldClass = FieldClass.Value;
                    durationTableField.Properties.InitValue = TimeSpanInitValue.Value;
                    durationTableField.Properties.MinValue = TimeSpanMinValue.Value;
                    durationTableField.Properties.MaxValue = TimeSpanMaxValue.Value;
                    durationTableField.Properties.NotBlank = NotBlank.Value;
                    durationTableField.Properties.SignDisplacement = SignDisplacement.Value;
                    durationTableField.Properties.StandardDayTimeUnit = StandardDayTimeUnit.Value;
                    durationTableField.Properties.TestTableRelation = TestTableRelation.Value;
                    durationTableField.Properties.ValidateTableRelation = ValidateTableRelation.Value;
                    durationTableField.Properties.ValuesAllowed = ValuesAllowed.Value;

                    if (AutoCaption)
                        durationTableField.AutoCaption();

                    return durationTableField;
                #endregion

                #region Guid
                case TableFieldType.Guid:
                    var guidTableField = new GuidTableField(GetTableFieldNo(), Name);
                    guidTableField.Properties.AltSearchField = AltSearchField.Value;
                    guidTableField.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    guidTableField.Properties.AutoFormatType = AutoFormatType.Value;
                    guidTableField.Properties.CalcFormula.FieldName = CalcFormulaFieldName.Value;
                    guidTableField.Properties.CalcFormula.Method = CalcFormulaMethod.Value;
                    guidTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value ?? false;
                    guidTableField.Properties.CalcFormula.TableName = CalcFormulaTableName.Value;
                    guidTableField.Properties.CaptionClass = CaptionClass.Value;
                    guidTableField.Properties.Description = Description;
                    guidTableField.Properties.Editable = Editable.Value;
                    guidTableField.Properties.ExtendedDatatype = ExtendedDataType.Value;
#if NAV2016
                    guidTableField.Properties.ExternalAccess = ExternalAccess.Value;
                    guidTableField.Properties.ExternalName = ExternalName.Value;
                    guidTableField.Properties.ExternalType = ExternalType.Value;
#endif
                    guidTableField.Properties.FieldClass = FieldClass.Value;
                    guidTableField.Properties.InitValue = GuidInitValue.Value;
                    guidTableField.Properties.NotBlank = NotBlank.Value;
                    guidTableField.Properties.TestTableRelation = TestTableRelation.Value;
                    guidTableField.Properties.ValidateTableRelation = ValidateTableRelation.Value;
                    guidTableField.Properties.ValuesAllowed = ValuesAllowed.Value;

                    if (AutoCaption)
                        guidTableField.AutoCaption();

                    return guidTableField;
                #endregion

                #region Integer
                case TableFieldType.Integer:
                    var integerTableField = new IntegerTableField(GetTableFieldNo(), Name);
                    integerTableField.Properties.AltSearchField = AltSearchField.Value;
                    integerTableField.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    integerTableField.Properties.AutoFormatType = AutoFormatType.Value;
                    integerTableField.Properties.AutoIncrement = AutoIncrement.Value;
                    integerTableField.Properties.BlankNumbers = BlankNumbers.Value;
                    integerTableField.Properties.BlankZero = BlankZero.Value;
                    integerTableField.Properties.CalcFormula.FieldName = CalcFormulaFieldName.Value;
                    integerTableField.Properties.CalcFormula.Method = CalcFormulaMethod.Value;
                    integerTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value ?? false;
                    integerTableField.Properties.CalcFormula.TableName = CalcFormulaTableName.Value;
                    integerTableField.Properties.CaptionClass = CaptionClass.Value;
                    integerTableField.Properties.Description = Description;
                    integerTableField.Properties.Editable = Editable.Value;
                    integerTableField.Properties.ExtendedDatatype = ExtendedDataType.Value;
#if NAV2016
                    integerTableField.Properties.ExternalAccess = ExternalAccess.Value;
                    integerTableField.Properties.ExternalName = ExternalName.Value;
                    integerTableField.Properties.ExternalType = ExternalType.Value;
#endif
                    integerTableField.Properties.FieldClass = FieldClass.Value;
                    integerTableField.Properties.InitValue = IntegerInitValue.Value;
                    integerTableField.Properties.MaxValue = IntegerMaxValue.Value;
                    integerTableField.Properties.MinValue = IntegerMinValue.Value;
                    integerTableField.Properties.NotBlank = NotBlank.Value;
                    integerTableField.Properties.SignDisplacement = SignDisplacement.Value;
                    integerTableField.Properties.TestTableRelation = TestTableRelation.Value;
                    integerTableField.Properties.ValidateTableRelation = ValidateTableRelation.Value;
                    integerTableField.Properties.ValuesAllowed = ValuesAllowed.Value;
                    integerTableField.Properties.Volatile = Volatile.Value;
                    integerTableField.Properties.Width = Width.Value;

                    if (AutoCaption)
                        integerTableField.AutoCaption();

                    return integerTableField;
                #endregion

                #region Option
                case TableFieldType.Option:
                    var optionTableField = new OptionTableField(GetTableFieldNo(), Name);
                    optionTableField.Properties.AltSearchField = AltSearchField.Value;
                    optionTableField.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    optionTableField.Properties.AutoFormatType = AutoFormatType.Value;
                    optionTableField.Properties.BlankNumbers = BlankNumbers.Value;
                    optionTableField.Properties.BlankZero = BlankZero.Value;
                    optionTableField.Properties.CalcFormula.FieldName = CalcFormulaFieldName.Value;
                    optionTableField.Properties.CalcFormula.Method = CalcFormulaMethod.Value;
                    optionTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value ?? false;
                    optionTableField.Properties.CalcFormula.TableName = CalcFormulaTableName.Value;
                    optionTableField.Properties.CaptionClass = CaptionClass.Value;
                    optionTableField.Properties.Description = Description;
                    optionTableField.Properties.Editable = Editable.Value;
                    optionTableField.Properties.ExtendedDatatype = ExtendedDataType.Value;
#if NAV2016
                    optionTableField.Properties.ExternalAccess = ExternalAccess.Value;
                    optionTableField.Properties.ExternalName = ExternalName.Value;
                    optionTableField.Properties.ExternalType = ExternalType.Value;
#endif
                    optionTableField.Properties.FieldClass = FieldClass.Value;
                    optionTableField.Properties.InitValue = TextualInitValue.Value;
                    optionTableField.Properties.MaxValue = TextualMaxValue.Value;
                    optionTableField.Properties.MinValue = TextualMinValue.Value;
                    optionTableField.Properties.NotBlank = NotBlank.Value;
                    optionTableField.Properties.OptionString = OptionString.Value;
#if NAV2016
                    optionTableField.Properties.OptionOrdinalValue = OptionOrdinalValues.Value;
#endif
                    optionTableField.Properties.SignDisplacement = SignDisplacement.Value;
                    optionTableField.Properties.TestTableRelation = TestTableRelation.Value;
                    optionTableField.Properties.ValidateTableRelation = ValidateTableRelation.Value;
                    optionTableField.Properties.ValuesAllowed = ValuesAllowed.Value;

                    if (AutoCaption)
                        optionTableField.AutoCaption();

                    if (AutoOptionCaption.Value != null)
                        if (AutoOptionCaption.Value.IsPresent)
                            optionTableField.AutoOptionCaption();

                    return optionTableField;
                #endregion

                #region RecordID
                case TableFieldType.RecordID:
                    var recordIDTableField = new RecordIDTableField(GetTableFieldNo(), Name);
                    recordIDTableField.Properties.AltSearchField = AltSearchField.Value;
                    recordIDTableField.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    recordIDTableField.Properties.AutoFormatType = AutoFormatType.Value;
                    recordIDTableField.Properties.CalcFormula.FieldName = CalcFormulaFieldName.Value;
                    recordIDTableField.Properties.CalcFormula.Method = CalcFormulaMethod.Value;
                    recordIDTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value ?? false;
                    recordIDTableField.Properties.CalcFormula.TableName = CalcFormulaTableName.Value;
                    recordIDTableField.Properties.CaptionClass = CaptionClass.Value;
                    recordIDTableField.Properties.Description = Description;
                    recordIDTableField.Properties.Editable = Editable.Value;
                    recordIDTableField.Properties.ExtendedDatatype = ExtendedDataType.Value;
#if NAV2016
                    recordIDTableField.Properties.ExternalAccess = ExternalAccess.Value;
                    recordIDTableField.Properties.ExternalName = ExternalName.Value;
                    recordIDTableField.Properties.ExternalType = ExternalType.Value;
#endif
                    recordIDTableField.Properties.FieldClass = FieldClass.Value;
                    recordIDTableField.Properties.InitValue = TextualInitValue.Value;
                    recordIDTableField.Properties.NotBlank = NotBlank.Value;
                    recordIDTableField.Properties.TestTableRelation = TestTableRelation.Value;
                    recordIDTableField.Properties.ValidateTableRelation = ValidateTableRelation.Value;
                    recordIDTableField.Properties.ValuesAllowed = ValuesAllowed.Value;

                    if (AutoCaption)
                        recordIDTableField.AutoCaption();

                    return recordIDTableField;
                #endregion

                #region TableFilter
                case TableFieldType.TableFilter:
                    var tableFilterTableField = new TableFilterTableField(GetTableFieldNo(), Name);
                    tableFilterTableField.Properties.Description = Description;
                    tableFilterTableField.Properties.TableIDExpr = TableIDExpr.Value;

                    if (AutoCaption)
                        tableFilterTableField.AutoCaption();

                    return tableFilterTableField;
                #endregion

                #region Text
                case TableFieldType.Text:
                    var textTableField = new TextTableField(GetTableFieldNo(), Name, DataLength.Value ?? 30);
                    textTableField.Properties.AltSearchField = AltSearchField.Value;
                    textTableField.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    textTableField.Properties.AutoFormatType = AutoFormatType.Value;
                    textTableField.Properties.CalcFormula.FieldName = CalcFormulaFieldName.Value;
                    textTableField.Properties.CalcFormula.Method = CalcFormulaMethod.Value;
                    textTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value ?? false;
                    textTableField.Properties.CalcFormula.TableName = CalcFormulaTableName.Value;
                    textTableField.Properties.CaptionClass = CaptionClass.Value;
                    textTableField.Properties.CharAllowed = CharAllowed.Value;
                    textTableField.Properties.DateFormula = DateFormula.Value;
                    textTableField.Properties.Description = Description;
                    textTableField.Properties.Editable = Editable.Value;
                    textTableField.Properties.ExtendedDatatype = ExtendedDataType.Value;
#if NAV2016
                    textTableField.Properties.ExternalAccess = ExternalAccess.Value;
                    textTableField.Properties.ExternalName = ExternalName.Value;
                    textTableField.Properties.ExternalType = ExternalType.Value;
#endif
                    textTableField.Properties.FieldClass = FieldClass.Value;
                    textTableField.Properties.InitValue = TextualInitValue.Value;
                    textTableField.Properties.NotBlank = NotBlank.Value;
                    textTableField.Properties.Numeric = Numeric.Value;
                    textTableField.Properties.TestTableRelation = TestTableRelation.Value;
                    textTableField.Properties.ValidateTableRelation = ValidateTableRelation.Value;
                    textTableField.Properties.ValuesAllowed = ValuesAllowed.Value;
                    textTableField.Properties.Width = Width.Value;

                    if (AutoCaption)
                        textTableField.AutoCaption();

                    return textTableField;
                #endregion

                #region Time
                case TableFieldType.Time:
                    var timeTableField = new TimeTableField(GetTableFieldNo(), Name);
                    timeTableField.Properties.AltSearchField = AltSearchField.Value;
                    timeTableField.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    timeTableField.Properties.AutoFormatType = AutoFormatType.Value;
                    timeTableField.Properties.BlankNumbers = BlankNumbers.Value;
                    timeTableField.Properties.CalcFormula.FieldName = CalcFormulaFieldName.Value;
                    timeTableField.Properties.CalcFormula.Method = CalcFormulaMethod.Value;
                    timeTableField.Properties.CalcFormula.ReverseSign = CalcFormulaReverseSign.Value ?? false;
                    timeTableField.Properties.CalcFormula.TableName = CalcFormulaTableName.Value;
                    timeTableField.Properties.CaptionClass = CaptionClass.Value;
                    timeTableField.Properties.Description = Description;
                    timeTableField.Properties.Editable = Editable.Value;
                    timeTableField.Properties.ExtendedDatatype = ExtendedDataType.Value;
#if NAV2016
                    timeTableField.Properties.ExternalAccess = ExternalAccess.Value;
                    timeTableField.Properties.ExternalName = ExternalName.Value;
                    timeTableField.Properties.ExternalType = ExternalType.Value;
#endif
                    timeTableField.Properties.FieldClass = FieldClass.Value;
                    timeTableField.Properties.InitValue = TimeSpanInitValue.Value;
                    timeTableField.Properties.NotBlank = NotBlank.Value;
                    timeTableField.Properties.SignDisplacement = SignDisplacement.Value;
                    timeTableField.Properties.TestTableRelation = TestTableRelation.Value;
                    timeTableField.Properties.ValidateTableRelation = ValidateTableRelation.Value;
                    timeTableField.Properties.ValuesAllowed = ValuesAllowed.Value;

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
            return ID.GetID(
                idsInUse: Table.Fields.Select(f => f.ID),
                containingID: Table.ID,
                alternativeRange: PrimaryKeyFieldNoRange ? 1.To(int.MaxValue) : 10.To(int.MaxValue));
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
#if NAV2016
                        yield return ExternalAccess.RuntimeDefinedParameter;
                        yield return ExternalName.RuntimeDefinedParameter;
                        yield return ExternalType.RuntimeDefinedParameter;
#endif
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
                    case TableFieldType.BLOB:
                        yield return Compressed.RuntimeDefinedParameter;
#if NAV2016
                        yield return ExternalAccess.RuntimeDefinedParameter;
                        yield return ExternalName.RuntimeDefinedParameter;
                        yield return ExternalType.RuntimeDefinedParameter;
#endif
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
#if NAV2016
                        yield return ExternalAccess.RuntimeDefinedParameter;
                        yield return ExternalName.RuntimeDefinedParameter;
                        yield return ExternalType.RuntimeDefinedParameter;
#endif
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
#if NAV2016
                        yield return ExternalAccess.RuntimeDefinedParameter;
                        yield return ExternalName.RuntimeDefinedParameter;
                        yield return ExternalType.RuntimeDefinedParameter;
#endif
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
#if NAV2016
                        yield return ExternalAccess.RuntimeDefinedParameter;
                        yield return ExternalName.RuntimeDefinedParameter;
                        yield return ExternalType.RuntimeDefinedParameter;
#endif
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
#if NAV2016
                        yield return ExternalAccess.RuntimeDefinedParameter;
                        yield return ExternalName.RuntimeDefinedParameter;
                        yield return ExternalType.RuntimeDefinedParameter;
#endif
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
#if NAV2016
                        yield return ExternalAccess.RuntimeDefinedParameter;
                        yield return ExternalName.RuntimeDefinedParameter;
                        yield return ExternalType.RuntimeDefinedParameter;
#endif
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
#if NAV2016
                        yield return ExternalAccess.RuntimeDefinedParameter;
                        yield return ExternalName.RuntimeDefinedParameter;
                        yield return ExternalType.RuntimeDefinedParameter;
#endif
                        yield return NotBlank.RuntimeDefinedParameter;
                        yield return SignDisplacement.RuntimeDefinedParameter;
                        yield return TestTableRelation.RuntimeDefinedParameter;
                        yield return ValidateTableRelation.RuntimeDefinedParameter;
                        yield return ValuesAllowed.RuntimeDefinedParameter;
                        yield return Width.RuntimeDefinedParameter;
                        break;
                    #endregion

                    #region Duration
                    case TableFieldType.Duration:
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
#if NAV2016
                        yield return ExternalAccess.RuntimeDefinedParameter;
                        yield return ExternalName.RuntimeDefinedParameter;
                        yield return ExternalType.RuntimeDefinedParameter;
#endif
                        yield return FieldClass.RuntimeDefinedParameter;
                        yield return TimeSpanInitValue.RuntimeDefinedParameter;
                        yield return TimeSpanMaxValue.RuntimeDefinedParameter;
                        yield return TimeSpanMinValue.RuntimeDefinedParameter;
                        yield return NotBlank.RuntimeDefinedParameter;
                        yield return SignDisplacement.RuntimeDefinedParameter;
                        yield return StandardDayTimeUnit.RuntimeDefinedParameter;
                        yield return TestTableRelation.RuntimeDefinedParameter;
                        yield return ValidateTableRelation.RuntimeDefinedParameter;
                        yield return ValuesAllowed.RuntimeDefinedParameter;
                        break;
                    #endregion

                    #region Guid
                    case TableFieldType.Guid:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return CalcFormulaFieldName.RuntimeDefinedParameter;
                        yield return CalcFormulaMethod.RuntimeDefinedParameter;
                        yield return CalcFormulaReverseSign.RuntimeDefinedParameter;
                        yield return CalcFormulaTableName.RuntimeDefinedParameter;
                        yield return CaptionClass.RuntimeDefinedParameter;
                        yield return Editable.RuntimeDefinedParameter;
                        yield return Enabled.RuntimeDefinedParameter;
                        yield return ExtendedDataType.RuntimeDefinedParameter;
#if NAV2016
                        yield return ExternalAccess.RuntimeDefinedParameter;
                        yield return ExternalName.RuntimeDefinedParameter;
                        yield return ExternalType.RuntimeDefinedParameter;
#endif
                        yield return FieldClass.RuntimeDefinedParameter;
                        yield return GuidInitValue.RuntimeDefinedParameter;
                        yield return NotBlank.RuntimeDefinedParameter;
                        yield return TestTableRelation.RuntimeDefinedParameter;
                        yield return ValidateTableRelation.RuntimeDefinedParameter;
                        yield return ValuesAllowed.RuntimeDefinedParameter;
                        break;
                    #endregion

                    #region Integer
                    case TableFieldType.Integer:
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
#if NAV2016
                        yield return ExternalAccess.RuntimeDefinedParameter;
                        yield return ExternalName.RuntimeDefinedParameter;
                        yield return ExternalType.RuntimeDefinedParameter;
#endif
                        yield return FieldClass.RuntimeDefinedParameter;
                        yield return IntegerInitValue.RuntimeDefinedParameter;
                        yield return IntegerMinValue.RuntimeDefinedParameter;
                        yield return IntegerMaxValue.RuntimeDefinedParameter;
                        yield return NotBlank.RuntimeDefinedParameter;
                        yield return SignDisplacement.RuntimeDefinedParameter;
                        yield return TestTableRelation.RuntimeDefinedParameter;
                        yield return ValidateTableRelation.RuntimeDefinedParameter;
                        yield return ValuesAllowed.RuntimeDefinedParameter;
                        yield return Volatile.RuntimeDefinedParameter;
                        yield return Width.RuntimeDefinedParameter;
                        break;
                    #endregion

                    #region Option
                    case TableFieldType.Option:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return AutoOptionCaption.RuntimeDefinedParameter;
                        yield return BlankNumbers.RuntimeDefinedParameter;
                        yield return BlankZero.RuntimeDefinedParameter;
                        yield return CalcFormulaFieldName.RuntimeDefinedParameter;
                        yield return CalcFormulaMethod.RuntimeDefinedParameter;
                        yield return CalcFormulaReverseSign.RuntimeDefinedParameter;
                        yield return CalcFormulaTableName.RuntimeDefinedParameter;
                        yield return CaptionClass.RuntimeDefinedParameter;
                        yield return Editable.RuntimeDefinedParameter;
                        yield return ExtendedDataType.RuntimeDefinedParameter;
#if NAV2016
                        yield return ExternalAccess.RuntimeDefinedParameter;
                        yield return ExternalName.RuntimeDefinedParameter;
                        yield return ExternalType.RuntimeDefinedParameter;
#endif
                        yield return FieldClass.RuntimeDefinedParameter;
                        yield return TextualInitValue.RuntimeDefinedParameter;
                        yield return TextualMinValue.RuntimeDefinedParameter;
                        yield return TextualMaxValue.RuntimeDefinedParameter;
                        yield return NotBlank.RuntimeDefinedParameter;
                        yield return OptionString.RuntimeDefinedParameter;
#if NAV2016
                        yield return OptionOrdinalValues.RuntimeDefinedParameter;
#endif
                        yield return SignDisplacement.RuntimeDefinedParameter;
                        yield return TestTableRelation.RuntimeDefinedParameter;
                        yield return ValidateTableRelation.RuntimeDefinedParameter;
                        yield return ValuesAllowed.RuntimeDefinedParameter;
                        break;
                    #endregion

                    #region RecordID
                    case TableFieldType.RecordID:
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
#if NAV2016
                        yield return ExternalAccess.RuntimeDefinedParameter;
                        yield return ExternalName.RuntimeDefinedParameter;
                        yield return ExternalType.RuntimeDefinedParameter;
#endif
                        yield return FieldClass.RuntimeDefinedParameter;
                        yield return TextualInitValue.RuntimeDefinedParameter;
                        yield return NotBlank.RuntimeDefinedParameter;
                        yield return TestTableRelation.RuntimeDefinedParameter;
                        yield return ValidateTableRelation.RuntimeDefinedParameter;
                        yield return ValuesAllowed.RuntimeDefinedParameter;
                        break;
                    #endregion

                    #region TableFilter
                    case TableFieldType.TableFilter:
                        yield return TableIDExpr.RuntimeDefinedParameter;
                        break;
                    #endregion

                    #region Text
                    case TableFieldType.Text:
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
                        yield return Editable.RuntimeDefinedParameter;
                        yield return ExtendedDataType.RuntimeDefinedParameter;
#if NAV2016
                        yield return ExternalAccess.RuntimeDefinedParameter;
                        yield return ExternalName.RuntimeDefinedParameter;
                        yield return ExternalType.RuntimeDefinedParameter;
#endif
                        yield return FieldClass.RuntimeDefinedParameter;
                        yield return TextualInitValue.RuntimeDefinedParameter;
                        yield return NotBlank.RuntimeDefinedParameter;
                        yield return Numeric.RuntimeDefinedParameter;
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
                        yield return CalcFormulaFieldName.RuntimeDefinedParameter;
                        yield return CalcFormulaMethod.RuntimeDefinedParameter;
                        yield return CalcFormulaReverseSign.RuntimeDefinedParameter;
                        yield return CalcFormulaTableName.RuntimeDefinedParameter;
                        yield return CaptionClass.RuntimeDefinedParameter;
                        yield return Editable.RuntimeDefinedParameter;
                        yield return ExtendedDataType.RuntimeDefinedParameter;
#if NAV2016
                        yield return ExternalAccess.RuntimeDefinedParameter;
                        yield return ExternalName.RuntimeDefinedParameter;
                        yield return ExternalType.RuntimeDefinedParameter;
#endif
                        yield return FieldClass.RuntimeDefinedParameter;
                        yield return TimeSpanInitValue.RuntimeDefinedParameter;
                        yield return TimeSpanMaxValue.RuntimeDefinedParameter;
                        yield return TimeSpanMinValue.RuntimeDefinedParameter;
                        yield return NotBlank.RuntimeDefinedParameter;
                        yield return SignDisplacement.RuntimeDefinedParameter;
                        yield return TestTableRelation.RuntimeDefinedParameter;
                        yield return ValidateTableRelation.RuntimeDefinedParameter;
                        yield return ValuesAllowed.RuntimeDefinedParameter;
                        break;
                    #endregion
                }
            }
        }
    }
}
