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
    public class AddCBreezeTableField : NewCBreezeTableField
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
            CalcFormula = new DynamicParameter<CalcFormula>("CalcFormula");
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

        [Parameter()]
        public SwitchParameter PassThru
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
                        yield return CalcFormula.RuntimeDefinedParameter;
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

                    #endregion BigInteger

                    #region Binary

                    case TableFieldType.Binary:
                        yield return DataLength.RuntimeDefinedParameter;
                        break;

                    #endregion Binary

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

                    #endregion Blob

                    #region Boolean

                    case TableFieldType.Boolean:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return BlankNumbers.RuntimeDefinedParameter;
                        yield return BlankZero.RuntimeDefinedParameter;
                        yield return CalcFormula.RuntimeDefinedParameter;
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

                    #endregion Boolean

                    #region Code

                    case TableFieldType.Code:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return CalcFormula.RuntimeDefinedParameter;
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

                    #endregion Code

                    #region Date

                    case TableFieldType.Date:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return BlankNumbers.RuntimeDefinedParameter;
                        yield return CalcFormula.RuntimeDefinedParameter;
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

                    #endregion Date

                    #region DateFormula

                    case TableFieldType.DateFormula:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return CalcFormula.RuntimeDefinedParameter;
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

                    #endregion DateFormula

                    #region DateTime

                    case TableFieldType.DateTime:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return BlankNumbers.RuntimeDefinedParameter;
                        yield return CalcFormula.RuntimeDefinedParameter;
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

                    #endregion DateTime

                    #region Decimal

                    case TableFieldType.Decimal:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return BlankNumbers.RuntimeDefinedParameter;
                        yield return BlankZero.RuntimeDefinedParameter;
                        yield return CalcFormula.RuntimeDefinedParameter;
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

                    #endregion Decimal

                    #region Duration

                    case TableFieldType.Duration:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return BlankNumbers.RuntimeDefinedParameter;
                        yield return BlankZero.RuntimeDefinedParameter;
                        yield return CalcFormula.RuntimeDefinedParameter;
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

                    #endregion Duration

                    #region Guid

                    case TableFieldType.Guid:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return CalcFormula.RuntimeDefinedParameter;
                        yield return CaptionClass.RuntimeDefinedParameter;
                        yield return Editable.RuntimeDefinedParameter;
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

                    #endregion Guid

                    #region Integer

                    case TableFieldType.Integer:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return AutoIncrement.RuntimeDefinedParameter;
                        yield return BlankNumbers.RuntimeDefinedParameter;
                        yield return BlankZero.RuntimeDefinedParameter;
                        yield return CalcFormula.RuntimeDefinedParameter;
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

                    #endregion Integer

                    #region Option

                    case TableFieldType.Option:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return AutoOptionCaption.RuntimeDefinedParameter;
                        yield return BlankNumbers.RuntimeDefinedParameter;
                        yield return BlankZero.RuntimeDefinedParameter;
                        yield return CalcFormula.RuntimeDefinedParameter;
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

                    #endregion Option

                    #region RecordID

                    case TableFieldType.RecordID:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return CalcFormula.RuntimeDefinedParameter;
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

                    #endregion RecordID

                    #region TableFilter

                    case TableFieldType.TableFilter:
                        yield return TableIDExpr.RuntimeDefinedParameter;
                        break;

                    #endregion TableFilter

                    #region Text

                    case TableFieldType.Text:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return CalcFormula.RuntimeDefinedParameter;
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

                    #endregion Text

                    #region Time

                    case TableFieldType.Time:
                        yield return AltSearchField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return CalcFormula.RuntimeDefinedParameter;
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

                        #endregion Time
                }
            }
        }
    }
}