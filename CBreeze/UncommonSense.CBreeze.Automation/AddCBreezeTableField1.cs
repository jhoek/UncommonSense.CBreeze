using UncommonSense.CBreeze.Core;
using System.Management.Automation;

namespace UncommonSense.CBreeze.Automation
{
	[Cmdlet(VerbsCommon.Add, "CBreezeBigIntegerTableField")]
	[Alias("BigIntegerField")]
	public class AddCBreezeBigIntegerTableField : AddCBreezeTableField2<BigIntegerTableField>
	{


		protected override BigIntegerTableField CreateItem()
		{
			var bigIntegerTableField = new BigIntegerTableField(ID, Name);
			bigIntegerTableField.Enabled = Enabled;
            bigIntegerTableField.Properties.Description = Description;

			if (AutoCaption)
                bigIntegerTableField.AutoCaption();

			return bigIntegerTableField;
		}

	[Parameter()]
	public String AltSearchField { get;set; }

	[Parameter()]
	public String AutoFormatExpr { get;set; }

	[Parameter()]
	public Nullable<AutoFormatType> AutoFormatType { get;set; }

	[Parameter()]
	public Nullable<Boolean> AutoIncrement { get;set; }

	[Parameter()]
	public Nullable<BlankNumbers> BlankNumbers { get;set; }

	[Parameter()]
	public Nullable<Boolean> BlankZero { get;set; }

	[Parameter()]
	public CalcFormula CalcFormula { get;set; }

	[Parameter()]
	public String CaptionClass { get;set; }

	[Parameter()]
	public Nullable<Boolean> Editable { get;set; }

	[Parameter()]
	public Nullable<ExtendedDataType> ExtendedDatatype { get;set; }

	[Parameter()]
	public Nullable<ExternalAccess> ExternalAccess { get;set; }

	[Parameter()]
	public String ExternalName { get;set; }

	[Parameter()]
	public String ExternalType { get;set; }

	[Parameter()]
	public Nullable<FieldClass> FieldClass { get;set; }

	[Parameter()]
	public Nullable<Int64> InitValue { get;set; }

	[Parameter()]
	public Nullable<Int64> MaxValue { get;set; }

	[Parameter()]
	public Nullable<Int64> MinValue { get;set; }

	[Parameter()]
	public Nullable<Boolean> NotBlank { get;set; }

	[Parameter()]
	public Nullable<Int32> SignDisplacement { get;set; }

	[Parameter()]
	public Nullable<Boolean> SqlTimestamp { get;set; }

	[Parameter()]
	public TableRelation TableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }

	[Parameter()]
	public Nullable<Boolean> Volatile { get;set; }

	[Parameter()]
	public Nullable<Int32> Width { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeBinaryTableField")]
	[Alias("BinaryField")]
	public class AddCBreezeBinaryTableField : AddCBreezeTableField2<BinaryTableField>
	{

		[Parameter()]
		[ValidateRange(1, 250)]
		public int? DataLength { get; set; } 	

		protected override BinaryTableField CreateItem()
		{
			var binaryTableField = new BinaryTableField(ID, Name, DataLength ?? 4);
			binaryTableField.Enabled = Enabled;
            binaryTableField.Properties.Description = Description;

			if (AutoCaption)
                binaryTableField.AutoCaption();

			return binaryTableField;
		}


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeBlobTableField")]
	[Alias("BlobField")]
	public class AddCBreezeBlobTableField : AddCBreezeTableField2<BlobTableField>
	{


		protected override BlobTableField CreateItem()
		{
			var blobTableField = new BlobTableField(ID, Name);
			blobTableField.Enabled = Enabled;
            blobTableField.Properties.Description = Description;

			if (AutoCaption)
                blobTableField.AutoCaption();

			return blobTableField;
		}

	[Parameter()]
	public Nullable<Boolean> Compressed { get;set; }

	[Parameter()]
	public Nullable<ExternalAccess> ExternalAccess { get;set; }

	[Parameter()]
	public String ExternalName { get;set; }

	[Parameter()]
	public String ExternalType { get;set; }

	[Parameter()]
	public String Owner { get;set; }

	[Parameter()]
	public Nullable<BlobSubType> SubType { get;set; }

	[Parameter()]
	public Nullable<Boolean> Volatile { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeBooleanTableField")]
	[Alias("BooleanField")]
	public class AddCBreezeBooleanTableField : AddCBreezeTableField2<BooleanTableField>
	{


		protected override BooleanTableField CreateItem()
		{
			var booleanTableField = new BooleanTableField(ID, Name);
			booleanTableField.Enabled = Enabled;
            booleanTableField.Properties.Description = Description;

			if (AutoCaption)
                booleanTableField.AutoCaption();

			return booleanTableField;
		}

	[Parameter()]
	public String AltSearchField { get;set; }

	[Parameter()]
	public String AutoFormatExpr { get;set; }

	[Parameter()]
	public Nullable<AutoFormatType> AutoFormatType { get;set; }

	[Parameter()]
	public Nullable<BlankNumbers> BlankNumbers { get;set; }

	[Parameter()]
	public Nullable<Boolean> BlankZero { get;set; }

	[Parameter()]
	public CalcFormula CalcFormula { get;set; }

	[Parameter()]
	public String CaptionClass { get;set; }

	[Parameter()]
	public Nullable<Boolean> Editable { get;set; }

	[Parameter()]
	public Nullable<ExtendedDataType> ExtendedDatatype { get;set; }

	[Parameter()]
	public Nullable<ExternalAccess> ExternalAccess { get;set; }

	[Parameter()]
	public String ExternalName { get;set; }

	[Parameter()]
	public String ExternalType { get;set; }

	[Parameter()]
	public Nullable<FieldClass> FieldClass { get;set; }

	[Parameter()]
	public Nullable<Boolean> InitValue { get;set; }

	[Parameter()]
	public Nullable<Boolean> MaxValue { get;set; }

	[Parameter()]
	public Nullable<Boolean> MinValue { get;set; }

	[Parameter()]
	public Nullable<Boolean> NotBlank { get;set; }

	[Parameter()]
	public Nullable<Int32> SignDisplacement { get;set; }

	[Parameter()]
	public TableRelation TableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeCodeTableField")]
	[Alias("CodeField")]
	public class AddCBreezeCodeTableField : AddCBreezeTableField2<CodeTableField>
	{

		[Parameter()]
		[ValidateRange(1, 250)]
		public int? DataLength { get; set; } 	

		protected override CodeTableField CreateItem()
		{
			var codeTableField = new CodeTableField(ID, Name, DataLength ?? 10);
			codeTableField.Enabled = Enabled;
            codeTableField.Properties.Description = Description;

			if (AutoCaption)
                codeTableField.AutoCaption();

			return codeTableField;
		}

	[Parameter()]
	public String AltSearchField { get;set; }

	[Parameter()]
	public String AutoFormatExpr { get;set; }

	[Parameter()]
	public Nullable<AutoFormatType> AutoFormatType { get;set; }

	[Parameter()]
	public CalcFormula CalcFormula { get;set; }

	[Parameter()]
	public String CaptionClass { get;set; }

	[Parameter()]
	public String CharAllowed { get;set; }

	[Parameter()]
	public Nullable<Boolean> DateFormula { get;set; }

	[Parameter()]
	public Nullable<Boolean> Editable { get;set; }

	[Parameter()]
	public Nullable<ExtendedDataType> ExtendedDatatype { get;set; }

	[Parameter()]
	public Nullable<ExternalAccess> ExternalAccess { get;set; }

	[Parameter()]
	public String ExternalName { get;set; }

	[Parameter()]
	public String ExternalType { get;set; }

	[Parameter()]
	public Nullable<FieldClass> FieldClass { get;set; }

	[Parameter()]
	public String InitValue { get;set; }

	[Parameter()]
	public Nullable<Boolean> NotBlank { get;set; }

	[Parameter()]
	public Nullable<Boolean> Numeric { get;set; }

	[Parameter()]
	public Nullable<SqlDataType> SQLDataType { get;set; }

	[Parameter()]
	public TableRelation TableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }

	[Parameter()]
	public Nullable<Int32> Width { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeDateFormulaTableField")]
	[Alias("DateFormulaField")]
	public class AddCBreezeDateFormulaTableField : AddCBreezeTableField2<DateFormulaTableField>
	{


		protected override DateFormulaTableField CreateItem()
		{
			var dateFormulaTableField = new DateFormulaTableField(ID, Name);
			dateFormulaTableField.Enabled = Enabled;
            dateFormulaTableField.Properties.Description = Description;

			if (AutoCaption)
                dateFormulaTableField.AutoCaption();

			return dateFormulaTableField;
		}

	[Parameter()]
	public String AltSearchField { get;set; }

	[Parameter()]
	public String AutoFormatExpr { get;set; }

	[Parameter()]
	public Nullable<AutoFormatType> AutoFormatType { get;set; }

	[Parameter()]
	public CalcFormula CalcFormula { get;set; }

	[Parameter()]
	public String CaptionClass { get;set; }

	[Parameter()]
	public Nullable<Boolean> Editable { get;set; }

	[Parameter()]
	public Nullable<ExtendedDataType> ExtendedDatatype { get;set; }

	[Parameter()]
	public Nullable<ExternalAccess> ExternalAccess { get;set; }

	[Parameter()]
	public String ExternalName { get;set; }

	[Parameter()]
	public String ExternalType { get;set; }

	[Parameter()]
	public Nullable<FieldClass> FieldClass { get;set; }

	[Parameter()]
	public String InitValue { get;set; }

	[Parameter()]
	public Nullable<Boolean> NotBlank { get;set; }

	[Parameter()]
	public TableRelation TableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeDateTableField")]
	[Alias("DateField")]
	public class AddCBreezeDateTableField : AddCBreezeTableField2<DateTableField>
	{


		protected override DateTableField CreateItem()
		{
			var dateTableField = new DateTableField(ID, Name);
			dateTableField.Enabled = Enabled;
            dateTableField.Properties.Description = Description;

			if (AutoCaption)
                dateTableField.AutoCaption();

			return dateTableField;
		}

	[Parameter()]
	public String AltSearchField { get;set; }

	[Parameter()]
	public String AutoFormatExpr { get;set; }

	[Parameter()]
	public Nullable<AutoFormatType> AutoFormatType { get;set; }

	[Parameter()]
	public Nullable<BlankNumbers> BlankNumbers { get;set; }

	[Parameter()]
	public CalcFormula CalcFormula { get;set; }

	[Parameter()]
	public String CaptionClass { get;set; }

	[Parameter()]
	public Nullable<Boolean> ClosingDates { get;set; }

	[Parameter()]
	public Nullable<Boolean> Editable { get;set; }

	[Parameter()]
	public Nullable<ExtendedDataType> ExtendedDatatype { get;set; }

	[Parameter()]
	public Nullable<ExternalAccess> ExternalAccess { get;set; }

	[Parameter()]
	public String ExternalName { get;set; }

	[Parameter()]
	public String ExternalType { get;set; }

	[Parameter()]
	public Nullable<FieldClass> FieldClass { get;set; }

	[Parameter()]
	public Nullable<DateTime> InitValue { get;set; }

	[Parameter()]
	public Nullable<DateTime> MaxValue { get;set; }

	[Parameter()]
	public Nullable<DateTime> MinValue { get;set; }

	[Parameter()]
	public Nullable<Boolean> NotBlank { get;set; }

	[Parameter()]
	public Nullable<Int32> SignDisplacement { get;set; }

	[Parameter()]
	public TableRelation TableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeDateTimeTableField")]
	[Alias("DateTimeField")]
	public class AddCBreezeDateTimeTableField : AddCBreezeTableField2<DateTimeTableField>
	{


		protected override DateTimeTableField CreateItem()
		{
			var dateTimeTableField = new DateTimeTableField(ID, Name);
			dateTimeTableField.Enabled = Enabled;
            dateTimeTableField.Properties.Description = Description;

			if (AutoCaption)
                dateTimeTableField.AutoCaption();

			return dateTimeTableField;
		}

	[Parameter()]
	public String AltSearchField { get;set; }

	[Parameter()]
	public String AutoFormatExpr { get;set; }

	[Parameter()]
	public Nullable<AutoFormatType> AutoFormatType { get;set; }

	[Parameter()]
	public Nullable<BlankNumbers> BlankNumbers { get;set; }

	[Parameter()]
	public CalcFormula CalcFormula { get;set; }

	[Parameter()]
	public String CaptionClass { get;set; }

	[Parameter()]
	public Nullable<Boolean> Editable { get;set; }

	[Parameter()]
	public Nullable<ExtendedDataType> ExtendedDatatype { get;set; }

	[Parameter()]
	public Nullable<ExternalAccess> ExternalAccess { get;set; }

	[Parameter()]
	public String ExternalName { get;set; }

	[Parameter()]
	public String ExternalType { get;set; }

	[Parameter()]
	public Nullable<FieldClass> FieldClass { get;set; }

	[Parameter()]
	public Nullable<DateTime> InitValue { get;set; }

	[Parameter()]
	public Nullable<DateTime> MaxValue { get;set; }

	[Parameter()]
	public Nullable<DateTime> MinValue { get;set; }

	[Parameter()]
	public Nullable<Boolean> NotBlank { get;set; }

	[Parameter()]
	public Nullable<Int32> SignDisplacement { get;set; }

	[Parameter()]
	public TableRelation TableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }

	[Parameter()]
	public Nullable<Boolean> Volatile { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeDecimalTableField")]
	[Alias("DecimalField")]
	public class AddCBreezeDecimalTableField : AddCBreezeTableField2<DecimalTableField>
	{


		protected override DecimalTableField CreateItem()
		{
			var decimalTableField = new DecimalTableField(ID, Name);
			decimalTableField.Enabled = Enabled;
            decimalTableField.Properties.Description = Description;

			if (AutoCaption)
                decimalTableField.AutoCaption();

			return decimalTableField;
		}

	[Parameter()]
	public String AltSearchField { get;set; }

	[Parameter()]
	public String AutoFormatExpr { get;set; }

	[Parameter()]
	public Nullable<AutoFormatType> AutoFormatType { get;set; }

	[Parameter()]
	public Nullable<BlankNumbers> BlankNumbers { get;set; }

	[Parameter()]
	public Nullable<Boolean> BlankZero { get;set; }

	[Parameter()]
	public CalcFormula CalcFormula { get;set; }

	[Parameter()]
	public String CaptionClass { get;set; }

	[Parameter()]
	public DecimalPlaces DecimalPlaces { get;set; }

	[Parameter()]
	public Nullable<Boolean> Editable { get;set; }

	[Parameter()]
	public Nullable<ExtendedDataType> ExtendedDatatype { get;set; }

	[Parameter()]
	public Nullable<ExternalAccess> ExternalAccess { get;set; }

	[Parameter()]
	public String ExternalName { get;set; }

	[Parameter()]
	public String ExternalType { get;set; }

	[Parameter()]
	public Nullable<FieldClass> FieldClass { get;set; }

	[Parameter()]
	public Nullable<Decimal> InitValue { get;set; }

	[Parameter()]
	public Nullable<Decimal> MaxValue { get;set; }

	[Parameter()]
	public Nullable<Decimal> MinValue { get;set; }

	[Parameter()]
	public Nullable<Boolean> NotBlank { get;set; }

	[Parameter()]
	public Nullable<Int32> SignDisplacement { get;set; }

	[Parameter()]
	public TableRelation TableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }

	[Parameter()]
	public Nullable<Int32> Width { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeDurationTableField")]
	[Alias("DurationField")]
	public class AddCBreezeDurationTableField : AddCBreezeTableField2<DurationTableField>
	{


		protected override DurationTableField CreateItem()
		{
			var durationTableField = new DurationTableField(ID, Name);
			durationTableField.Enabled = Enabled;
            durationTableField.Properties.Description = Description;

			if (AutoCaption)
                durationTableField.AutoCaption();

			return durationTableField;
		}

	[Parameter()]
	public String AltSearchField { get;set; }

	[Parameter()]
	public String AutoFormatExpr { get;set; }

	[Parameter()]
	public Nullable<AutoFormatType> AutoFormatType { get;set; }

	[Parameter()]
	public Nullable<BlankNumbers> BlankNumbers { get;set; }

	[Parameter()]
	public Nullable<Boolean> BlankZero { get;set; }

	[Parameter()]
	public CalcFormula CalcFormula { get;set; }

	[Parameter()]
	public String CaptionClass { get;set; }

	[Parameter()]
	public Nullable<Boolean> Editable { get;set; }

	[Parameter()]
	public Nullable<ExtendedDataType> ExtendedDatatype { get;set; }

	[Parameter()]
	public Nullable<ExternalAccess> ExternalAccess { get;set; }

	[Parameter()]
	public String ExternalName { get;set; }

	[Parameter()]
	public String ExternalType { get;set; }

	[Parameter()]
	public Nullable<FieldClass> FieldClass { get;set; }

	[Parameter()]
	public Nullable<TimeSpan> InitValue { get;set; }

	[Parameter()]
	public Nullable<TimeSpan> MaxValue { get;set; }

	[Parameter()]
	public Nullable<TimeSpan> MinValue { get;set; }

	[Parameter()]
	public Nullable<Boolean> NotBlank { get;set; }

	[Parameter()]
	public Nullable<Int32> SignDisplacement { get;set; }

	[Parameter()]
	public Nullable<StandardDayTimeUnit> StandardDayTimeUnit { get;set; }

	[Parameter()]
	public TableRelation TableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeGuidTableField")]
	[Alias("GuidField")]
	public class AddCBreezeGuidTableField : AddCBreezeTableField2<GuidTableField>
	{


		protected override GuidTableField CreateItem()
		{
			var guidTableField = new GuidTableField(ID, Name);
			guidTableField.Enabled = Enabled;
            guidTableField.Properties.Description = Description;

			if (AutoCaption)
                guidTableField.AutoCaption();

			return guidTableField;
		}

	[Parameter()]
	public String AltSearchField { get;set; }

	[Parameter()]
	public String AutoFormatExpr { get;set; }

	[Parameter()]
	public Nullable<AutoFormatType> AutoFormatType { get;set; }

	[Parameter()]
	public CalcFormula CalcFormula { get;set; }

	[Parameter()]
	public String CaptionClass { get;set; }

	[Parameter()]
	public Nullable<Boolean> Editable { get;set; }

	[Parameter()]
	public Nullable<ExtendedDataType> ExtendedDatatype { get;set; }

	[Parameter()]
	public Nullable<ExternalAccess> ExternalAccess { get;set; }

	[Parameter()]
	public String ExternalName { get;set; }

	[Parameter()]
	public String ExternalType { get;set; }

	[Parameter()]
	public Nullable<FieldClass> FieldClass { get;set; }

	[Parameter()]
	public Nullable<Guid> InitValue { get;set; }

	[Parameter()]
	public Nullable<Boolean> NotBlank { get;set; }

	[Parameter()]
	public TableRelation TableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeIntegerTableField")]
	[Alias("IntegerField")]
	public class AddCBreezeIntegerTableField : AddCBreezeTableField2<IntegerTableField>
	{


		protected override IntegerTableField CreateItem()
		{
			var integerTableField = new IntegerTableField(ID, Name);
			integerTableField.Enabled = Enabled;
            integerTableField.Properties.Description = Description;

			if (AutoCaption)
                integerTableField.AutoCaption();

			return integerTableField;
		}

	[Parameter()]
	public String AltSearchField { get;set; }

	[Parameter()]
	public String AutoFormatExpr { get;set; }

	[Parameter()]
	public Nullable<AutoFormatType> AutoFormatType { get;set; }

	[Parameter()]
	public Nullable<Boolean> AutoIncrement { get;set; }

	[Parameter()]
	public Nullable<BlankNumbers> BlankNumbers { get;set; }

	[Parameter()]
	public Nullable<Boolean> BlankZero { get;set; }

	[Parameter()]
	public CalcFormula CalcFormula { get;set; }

	[Parameter()]
	public String CaptionClass { get;set; }

	[Parameter()]
	public Nullable<Boolean> Editable { get;set; }

	[Parameter()]
	public Nullable<ExtendedDataType> ExtendedDatatype { get;set; }

	[Parameter()]
	public Nullable<ExternalAccess> ExternalAccess { get;set; }

	[Parameter()]
	public String ExternalName { get;set; }

	[Parameter()]
	public String ExternalType { get;set; }

	[Parameter()]
	public Nullable<FieldClass> FieldClass { get;set; }

	[Parameter()]
	public Nullable<Int32> InitValue { get;set; }

	[Parameter()]
	public Nullable<Int32> MaxValue { get;set; }

	[Parameter()]
	public Nullable<Int32> MinValue { get;set; }

	[Parameter()]
	public Nullable<Boolean> NotBlank { get;set; }

	[Parameter()]
	public Nullable<Int32> SignDisplacement { get;set; }

	[Parameter()]
	public TableRelation TableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }

	[Parameter()]
	public Nullable<Boolean> Volatile { get;set; }

	[Parameter()]
	public Nullable<Int32> Width { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeOptionTableField")]
	[Alias("OptionField")]
	public class AddCBreezeOptionTableField : AddCBreezeTableField2<OptionTableField>
	{


		protected override OptionTableField CreateItem()
		{
			var optionTableField = new OptionTableField(ID, Name);
			optionTableField.Enabled = Enabled;
            optionTableField.Properties.Description = Description;

			if (AutoCaption)
                optionTableField.AutoCaption();

			return optionTableField;
		}

	[Parameter()]
	public String AltSearchField { get;set; }

	[Parameter()]
	public String AutoFormatExpr { get;set; }

	[Parameter()]
	public Nullable<AutoFormatType> AutoFormatType { get;set; }

	[Parameter()]
	public Nullable<BlankNumbers> BlankNumbers { get;set; }

	[Parameter()]
	public Nullable<Boolean> BlankZero { get;set; }

	[Parameter()]
	public CalcFormula CalcFormula { get;set; }

	[Parameter()]
	public String CaptionClass { get;set; }

	[Parameter()]
	public Nullable<Boolean> Editable { get;set; }

	[Parameter()]
	public Nullable<ExtendedDataType> ExtendedDatatype { get;set; }

	[Parameter()]
	public Nullable<ExternalAccess> ExternalAccess { get;set; }

	[Parameter()]
	public String ExternalName { get;set; }

	[Parameter()]
	public String ExternalType { get;set; }

	[Parameter()]
	public Nullable<FieldClass> FieldClass { get;set; }

	[Parameter()]
	public String InitValue { get;set; }

	[Parameter()]
	public String MaxValue { get;set; }

	[Parameter()]
	public String MinValue { get;set; }

	[Parameter()]
	public Nullable<Boolean> NotBlank { get;set; }

	[Parameter()]
	public MultiLanguageValue OptionCaptionML { get;set; }

	[Parameter()]
	public String OptionOrdinalValue { get;set; }

	[Parameter()]
	public String OptionString { get;set; }

	[Parameter()]
	public Nullable<Int32> SignDisplacement { get;set; }

	[Parameter()]
	public TableRelation TableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeRecordIDTableField")]
	[Alias("RecordIDField")]
	public class AddCBreezeRecordIDTableField : AddCBreezeTableField2<RecordIDTableField>
	{


		protected override RecordIDTableField CreateItem()
		{
			var recordIDTableField = new RecordIDTableField(ID, Name);
			recordIDTableField.Enabled = Enabled;
            recordIDTableField.Properties.Description = Description;

			if (AutoCaption)
                recordIDTableField.AutoCaption();

			return recordIDTableField;
		}

	[Parameter()]
	public String AltSearchField { get;set; }

	[Parameter()]
	public String AutoFormatExpr { get;set; }

	[Parameter()]
	public Nullable<AutoFormatType> AutoFormatType { get;set; }

	[Parameter()]
	public CalcFormula CalcFormula { get;set; }

	[Parameter()]
	public String CaptionClass { get;set; }

	[Parameter()]
	public Nullable<Boolean> Editable { get;set; }

	[Parameter()]
	public Nullable<ExtendedDataType> ExtendedDatatype { get;set; }

	[Parameter()]
	public Nullable<ExternalAccess> ExternalAccess { get;set; }

	[Parameter()]
	public String ExternalName { get;set; }

	[Parameter()]
	public String ExternalType { get;set; }

	[Parameter()]
	public Nullable<FieldClass> FieldClass { get;set; }

	[Parameter()]
	public String InitValue { get;set; }

	[Parameter()]
	public Nullable<Boolean> NotBlank { get;set; }

	[Parameter()]
	public TableRelation TableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeTableFilterTableField")]
	[Alias("FilterField")]
	public class AddCBreezeTableFilterTableField : AddCBreezeTableField2<TableFilterTableField>
	{


		protected override TableFilterTableField CreateItem()
		{
			var tableFilterTableField = new TableFilterTableField(ID, Name);
			tableFilterTableField.Enabled = Enabled;
            tableFilterTableField.Properties.Description = Description;

			if (AutoCaption)
                tableFilterTableField.AutoCaption();

			return tableFilterTableField;
		}

	[Parameter()]
	public String TableIDExpr { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeTextTableField")]
	[Alias("TextField")]
	public class AddCBreezeTextTableField : AddCBreezeTableField2<TextTableField>
	{

		[Parameter()]
		[ValidateRange(1, 250)]
		public int? DataLength { get; set; } 	

		protected override TextTableField CreateItem()
		{
			var textTableField = new TextTableField(ID, Name, DataLength ?? 30);
			textTableField.Enabled = Enabled;
            textTableField.Properties.Description = Description;

			if (AutoCaption)
                textTableField.AutoCaption();

			return textTableField;
		}

	[Parameter()]
	public String AltSearchField { get;set; }

	[Parameter()]
	public String AutoFormatExpr { get;set; }

	[Parameter()]
	public Nullable<AutoFormatType> AutoFormatType { get;set; }

	[Parameter()]
	public CalcFormula CalcFormula { get;set; }

	[Parameter()]
	public String CaptionClass { get;set; }

	[Parameter()]
	public String CharAllowed { get;set; }

	[Parameter()]
	public Nullable<Boolean> DateFormula { get;set; }

	[Parameter()]
	public Nullable<Boolean> Editable { get;set; }

	[Parameter()]
	public Nullable<ExtendedDataType> ExtendedDatatype { get;set; }

	[Parameter()]
	public Nullable<ExternalAccess> ExternalAccess { get;set; }

	[Parameter()]
	public String ExternalName { get;set; }

	[Parameter()]
	public String ExternalType { get;set; }

	[Parameter()]
	public Nullable<FieldClass> FieldClass { get;set; }

	[Parameter()]
	public String InitValue { get;set; }

	[Parameter()]
	public Nullable<Boolean> NotBlank { get;set; }

	[Parameter()]
	public Nullable<Boolean> Numeric { get;set; }

	[Parameter()]
	public TableRelation TableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> Title { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }

	[Parameter()]
	public Nullable<Int32> Width { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeTimeTableField")]
	[Alias("TimeField")]
	public class AddCBreezeTimeTableField : AddCBreezeTableField2<TimeTableField>
	{


		protected override TimeTableField CreateItem()
		{
			var timeTableField = new TimeTableField(ID, Name);
			timeTableField.Enabled = Enabled;
            timeTableField.Properties.Description = Description;

			if (AutoCaption)
                timeTableField.AutoCaption();

			return timeTableField;
		}

	[Parameter()]
	public String AltSearchField { get;set; }

	[Parameter()]
	public String AutoFormatExpr { get;set; }

	[Parameter()]
	public Nullable<AutoFormatType> AutoFormatType { get;set; }

	[Parameter()]
	public Nullable<BlankNumbers> BlankNumbers { get;set; }

	[Parameter()]
	public CalcFormula CalcFormula { get;set; }

	[Parameter()]
	public String CaptionClass { get;set; }

	[Parameter()]
	public Nullable<Boolean> Editable { get;set; }

	[Parameter()]
	public Nullable<ExtendedDataType> ExtendedDatatype { get;set; }

	[Parameter()]
	public Nullable<ExternalAccess> ExternalAccess { get;set; }

	[Parameter()]
	public String ExternalName { get;set; }

	[Parameter()]
	public String ExternalType { get;set; }

	[Parameter()]
	public Nullable<FieldClass> FieldClass { get;set; }

	[Parameter()]
	public Nullable<TimeSpan> InitValue { get;set; }

	[Parameter()]
	public Nullable<TimeSpan> MaxValue { get;set; }

	[Parameter()]
	public Nullable<TimeSpan> MinValue { get;set; }

	[Parameter()]
	public Nullable<Boolean> NotBlank { get;set; }

	[Parameter()]
	public Nullable<Int32> SignDisplacement { get;set; }

	[Parameter()]
	public TableRelation TableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }


	}

}
