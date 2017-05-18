// FIXME Field numbering if table is in "own" range
// FIXME Rename output file, remove old classes

using System;
using UncommonSense.CBreeze.Core;
using System.Management.Automation;

namespace UncommonSense.CBreeze.Automation
{
	[Cmdlet(VerbsCommon.Add, "CBreezeBigIntegerTableField")]
	[OutputType(typeof(BigIntegerTableField))]
	[Alias("BigIntegerField")]
	public class AddCBreezeBigIntegerTableField : AddCBreezeTableField2<BigIntegerTableField>
	{


		protected override BigIntegerTableField CreateItem()
		{
			var bigIntegerTableField = new BigIntegerTableField(ID, Name);
			bigIntegerTableField.Enabled = Enabled;
            bigIntegerTableField.Properties.Description = Description;

			bigIntegerTableField.Properties.AltSearchField = AltSearchField;
			bigIntegerTableField.Properties.AutoFormatExpr = AutoFormatExpr;
			bigIntegerTableField.Properties.AutoFormatType = AutoFormatType;
			bigIntegerTableField.Properties.AutoIncrement = AutoIncrement;
			bigIntegerTableField.Properties.BlankNumbers = BlankNumbers;
			bigIntegerTableField.Properties.BlankZero = BlankZero;
			bigIntegerTableField.Properties.CalcFormula.Set(CalcFormula);
			bigIntegerTableField.Properties.CaptionClass = CaptionClass;
			bigIntegerTableField.Properties.Editable = Editable;
			bigIntegerTableField.Properties.ExtendedDatatype = ExtendedDatatype;
			bigIntegerTableField.Properties.ExternalAccess = ExternalAccess;
			bigIntegerTableField.Properties.ExternalName = ExternalName;
			bigIntegerTableField.Properties.ExternalType = ExternalType;
			bigIntegerTableField.Properties.FieldClass = FieldClass;
			bigIntegerTableField.Properties.InitValue = InitValue;
			bigIntegerTableField.Properties.MaxValue = MaxValue;
			bigIntegerTableField.Properties.MinValue = MinValue;
			bigIntegerTableField.Properties.NotBlank = NotBlank;
			bigIntegerTableField.Properties.SignDisplacement = SignDisplacement;
			bigIntegerTableField.Properties.SqlTimestamp = SqlTimestamp;
			bigIntegerTableField.Properties.TestTableRelation = TestTableRelation;
			bigIntegerTableField.Properties.ValidateTableRelation = ValidateTableRelation;
			bigIntegerTableField.Properties.ValuesAllowed = ValuesAllowed;
			bigIntegerTableField.Properties.Volatile = Volatile;
			bigIntegerTableField.Properties.Width = Width;

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
	[OutputType(typeof(BinaryTableField))]
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
	[OutputType(typeof(BlobTableField))]
	[Alias("BlobField")]
	public class AddCBreezeBlobTableField : AddCBreezeTableField2<BlobTableField>
	{


		protected override BlobTableField CreateItem()
		{
			var blobTableField = new BlobTableField(ID, Name);
			blobTableField.Enabled = Enabled;
            blobTableField.Properties.Description = Description;

			blobTableField.Properties.Compressed = Compressed;
			blobTableField.Properties.ExternalAccess = ExternalAccess;
			blobTableField.Properties.ExternalName = ExternalName;
			blobTableField.Properties.ExternalType = ExternalType;
			blobTableField.Properties.Owner = Owner;
			blobTableField.Properties.SubType = SubType;
			blobTableField.Properties.Volatile = Volatile;

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
	[OutputType(typeof(BooleanTableField))]
	[Alias("BooleanField")]
	public class AddCBreezeBooleanTableField : AddCBreezeTableField2<BooleanTableField>
	{


		protected override BooleanTableField CreateItem()
		{
			var booleanTableField = new BooleanTableField(ID, Name);
			booleanTableField.Enabled = Enabled;
            booleanTableField.Properties.Description = Description;

			booleanTableField.Properties.AltSearchField = AltSearchField;
			booleanTableField.Properties.AutoFormatExpr = AutoFormatExpr;
			booleanTableField.Properties.AutoFormatType = AutoFormatType;
			booleanTableField.Properties.BlankNumbers = BlankNumbers;
			booleanTableField.Properties.BlankZero = BlankZero;
			booleanTableField.Properties.CalcFormula.Set(CalcFormula);
			booleanTableField.Properties.CaptionClass = CaptionClass;
			booleanTableField.Properties.Editable = Editable;
			booleanTableField.Properties.ExtendedDatatype = ExtendedDatatype;
			booleanTableField.Properties.ExternalAccess = ExternalAccess;
			booleanTableField.Properties.ExternalName = ExternalName;
			booleanTableField.Properties.ExternalType = ExternalType;
			booleanTableField.Properties.FieldClass = FieldClass;
			booleanTableField.Properties.InitValue = InitValue;
			booleanTableField.Properties.MaxValue = MaxValue;
			booleanTableField.Properties.MinValue = MinValue;
			booleanTableField.Properties.NotBlank = NotBlank;
			booleanTableField.Properties.SignDisplacement = SignDisplacement;
			booleanTableField.Properties.TestTableRelation = TestTableRelation;
			booleanTableField.Properties.ValidateTableRelation = ValidateTableRelation;
			booleanTableField.Properties.ValuesAllowed = ValuesAllowed;

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
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeCodeTableField")]
	[OutputType(typeof(CodeTableField))]
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

			codeTableField.Properties.AltSearchField = AltSearchField;
			codeTableField.Properties.AutoFormatExpr = AutoFormatExpr;
			codeTableField.Properties.AutoFormatType = AutoFormatType;
			codeTableField.Properties.CalcFormula.Set(CalcFormula);
			codeTableField.Properties.CaptionClass = CaptionClass;
			codeTableField.Properties.CharAllowed = CharAllowed;
			codeTableField.Properties.DateFormula = DateFormula;
			codeTableField.Properties.Editable = Editable;
			codeTableField.Properties.ExtendedDatatype = ExtendedDatatype;
			codeTableField.Properties.ExternalAccess = ExternalAccess;
			codeTableField.Properties.ExternalName = ExternalName;
			codeTableField.Properties.ExternalType = ExternalType;
			codeTableField.Properties.FieldClass = FieldClass;
			codeTableField.Properties.InitValue = InitValue;
			codeTableField.Properties.NotBlank = NotBlank;
			codeTableField.Properties.Numeric = Numeric;
			codeTableField.Properties.SQLDataType = SQLDataType;
			codeTableField.Properties.TestTableRelation = TestTableRelation;
			codeTableField.Properties.ValidateTableRelation = ValidateTableRelation;
			codeTableField.Properties.ValuesAllowed = ValuesAllowed;
			codeTableField.Properties.Width = Width;

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
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }

	[Parameter()]
	public Nullable<Int32> Width { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeDateFormulaTableField")]
	[OutputType(typeof(DateFormulaTableField))]
	[Alias("DateFormulaField")]
	public class AddCBreezeDateFormulaTableField : AddCBreezeTableField2<DateFormulaTableField>
	{


		protected override DateFormulaTableField CreateItem()
		{
			var dateFormulaTableField = new DateFormulaTableField(ID, Name);
			dateFormulaTableField.Enabled = Enabled;
            dateFormulaTableField.Properties.Description = Description;

			dateFormulaTableField.Properties.AltSearchField = AltSearchField;
			dateFormulaTableField.Properties.AutoFormatExpr = AutoFormatExpr;
			dateFormulaTableField.Properties.AutoFormatType = AutoFormatType;
			dateFormulaTableField.Properties.CalcFormula.Set(CalcFormula);
			dateFormulaTableField.Properties.CaptionClass = CaptionClass;
			dateFormulaTableField.Properties.Editable = Editable;
			dateFormulaTableField.Properties.ExtendedDatatype = ExtendedDatatype;
			dateFormulaTableField.Properties.ExternalAccess = ExternalAccess;
			dateFormulaTableField.Properties.ExternalName = ExternalName;
			dateFormulaTableField.Properties.ExternalType = ExternalType;
			dateFormulaTableField.Properties.FieldClass = FieldClass;
			dateFormulaTableField.Properties.InitValue = InitValue;
			dateFormulaTableField.Properties.NotBlank = NotBlank;
			dateFormulaTableField.Properties.TestTableRelation = TestTableRelation;
			dateFormulaTableField.Properties.ValidateTableRelation = ValidateTableRelation;
			dateFormulaTableField.Properties.ValuesAllowed = ValuesAllowed;

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
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeDateTableField")]
	[OutputType(typeof(DateTableField))]
	[Alias("DateField")]
	public class AddCBreezeDateTableField : AddCBreezeTableField2<DateTableField>
	{


		protected override DateTableField CreateItem()
		{
			var dateTableField = new DateTableField(ID, Name);
			dateTableField.Enabled = Enabled;
            dateTableField.Properties.Description = Description;

			dateTableField.Properties.AltSearchField = AltSearchField;
			dateTableField.Properties.AutoFormatExpr = AutoFormatExpr;
			dateTableField.Properties.AutoFormatType = AutoFormatType;
			dateTableField.Properties.BlankNumbers = BlankNumbers;
			dateTableField.Properties.CalcFormula.Set(CalcFormula);
			dateTableField.Properties.CaptionClass = CaptionClass;
			dateTableField.Properties.ClosingDates = ClosingDates;
			dateTableField.Properties.Editable = Editable;
			dateTableField.Properties.ExtendedDatatype = ExtendedDatatype;
			dateTableField.Properties.ExternalAccess = ExternalAccess;
			dateTableField.Properties.ExternalName = ExternalName;
			dateTableField.Properties.ExternalType = ExternalType;
			dateTableField.Properties.FieldClass = FieldClass;
			dateTableField.Properties.InitValue = InitValue;
			dateTableField.Properties.MaxValue = MaxValue;
			dateTableField.Properties.MinValue = MinValue;
			dateTableField.Properties.NotBlank = NotBlank;
			dateTableField.Properties.SignDisplacement = SignDisplacement;
			dateTableField.Properties.TestTableRelation = TestTableRelation;
			dateTableField.Properties.ValidateTableRelation = ValidateTableRelation;
			dateTableField.Properties.ValuesAllowed = ValuesAllowed;

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
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeDateTimeTableField")]
	[OutputType(typeof(DateTimeTableField))]
	[Alias("DateTimeField")]
	public class AddCBreezeDateTimeTableField : AddCBreezeTableField2<DateTimeTableField>
	{


		protected override DateTimeTableField CreateItem()
		{
			var dateTimeTableField = new DateTimeTableField(ID, Name);
			dateTimeTableField.Enabled = Enabled;
            dateTimeTableField.Properties.Description = Description;

			dateTimeTableField.Properties.AltSearchField = AltSearchField;
			dateTimeTableField.Properties.AutoFormatExpr = AutoFormatExpr;
			dateTimeTableField.Properties.AutoFormatType = AutoFormatType;
			dateTimeTableField.Properties.BlankNumbers = BlankNumbers;
			dateTimeTableField.Properties.CalcFormula.Set(CalcFormula);
			dateTimeTableField.Properties.CaptionClass = CaptionClass;
			dateTimeTableField.Properties.Editable = Editable;
			dateTimeTableField.Properties.ExtendedDatatype = ExtendedDatatype;
			dateTimeTableField.Properties.ExternalAccess = ExternalAccess;
			dateTimeTableField.Properties.ExternalName = ExternalName;
			dateTimeTableField.Properties.ExternalType = ExternalType;
			dateTimeTableField.Properties.FieldClass = FieldClass;
			dateTimeTableField.Properties.InitValue = InitValue;
			dateTimeTableField.Properties.MaxValue = MaxValue;
			dateTimeTableField.Properties.MinValue = MinValue;
			dateTimeTableField.Properties.NotBlank = NotBlank;
			dateTimeTableField.Properties.SignDisplacement = SignDisplacement;
			dateTimeTableField.Properties.TestTableRelation = TestTableRelation;
			dateTimeTableField.Properties.ValidateTableRelation = ValidateTableRelation;
			dateTimeTableField.Properties.ValuesAllowed = ValuesAllowed;
			dateTimeTableField.Properties.Volatile = Volatile;

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
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }

	[Parameter()]
	public Nullable<Boolean> Volatile { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeDecimalTableField")]
	[OutputType(typeof(DecimalTableField))]
	[Alias("DecimalField")]
	public class AddCBreezeDecimalTableField : AddCBreezeTableField2<DecimalTableField>
	{


		protected override DecimalTableField CreateItem()
		{
			var decimalTableField = new DecimalTableField(ID, Name);
			decimalTableField.Enabled = Enabled;
            decimalTableField.Properties.Description = Description;

			decimalTableField.Properties.AltSearchField = AltSearchField;
			decimalTableField.Properties.AutoFormatExpr = AutoFormatExpr;
			decimalTableField.Properties.AutoFormatType = AutoFormatType;
			decimalTableField.Properties.BlankNumbers = BlankNumbers;
			decimalTableField.Properties.BlankZero = BlankZero;
			decimalTableField.Properties.CalcFormula.Set(CalcFormula);
			decimalTableField.Properties.CaptionClass = CaptionClass;
			decimalTableField.Properties.DecimalPlaces.AtLeast = DecimalPlacesAtLeast;
			decimalTableField.Properties.DecimalPlaces.AtMost = DecimalPlacesAtMost;
			decimalTableField.Properties.Editable = Editable;
			decimalTableField.Properties.ExtendedDatatype = ExtendedDatatype;
			decimalTableField.Properties.ExternalAccess = ExternalAccess;
			decimalTableField.Properties.ExternalName = ExternalName;
			decimalTableField.Properties.ExternalType = ExternalType;
			decimalTableField.Properties.FieldClass = FieldClass;
			decimalTableField.Properties.InitValue = InitValue;
			decimalTableField.Properties.MaxValue = MaxValue;
			decimalTableField.Properties.MinValue = MinValue;
			decimalTableField.Properties.NotBlank = NotBlank;
			decimalTableField.Properties.SignDisplacement = SignDisplacement;
			decimalTableField.Properties.TestTableRelation = TestTableRelation;
			decimalTableField.Properties.ValidateTableRelation = ValidateTableRelation;
			decimalTableField.Properties.ValuesAllowed = ValuesAllowed;
			decimalTableField.Properties.Width = Width;

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
	public Nullable<Int32> DecimalPlacesAtLeast { get;set; }

	[Parameter()]
	public Nullable<Int32> DecimalPlacesAtMost { get;set; }

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
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }

	[Parameter()]
	public Nullable<Int32> Width { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeDurationTableField")]
	[OutputType(typeof(DurationTableField))]
	[Alias("DurationField")]
	public class AddCBreezeDurationTableField : AddCBreezeTableField2<DurationTableField>
	{


		protected override DurationTableField CreateItem()
		{
			var durationTableField = new DurationTableField(ID, Name);
			durationTableField.Enabled = Enabled;
            durationTableField.Properties.Description = Description;

			durationTableField.Properties.AltSearchField = AltSearchField;
			durationTableField.Properties.AutoFormatExpr = AutoFormatExpr;
			durationTableField.Properties.AutoFormatType = AutoFormatType;
			durationTableField.Properties.BlankNumbers = BlankNumbers;
			durationTableField.Properties.BlankZero = BlankZero;
			durationTableField.Properties.CalcFormula.Set(CalcFormula);
			durationTableField.Properties.CaptionClass = CaptionClass;
			durationTableField.Properties.Editable = Editable;
			durationTableField.Properties.ExtendedDatatype = ExtendedDatatype;
			durationTableField.Properties.ExternalAccess = ExternalAccess;
			durationTableField.Properties.ExternalName = ExternalName;
			durationTableField.Properties.ExternalType = ExternalType;
			durationTableField.Properties.FieldClass = FieldClass;
			durationTableField.Properties.InitValue = InitValue;
			durationTableField.Properties.MaxValue = MaxValue;
			durationTableField.Properties.MinValue = MinValue;
			durationTableField.Properties.NotBlank = NotBlank;
			durationTableField.Properties.SignDisplacement = SignDisplacement;
			durationTableField.Properties.StandardDayTimeUnit = StandardDayTimeUnit;
			durationTableField.Properties.TestTableRelation = TestTableRelation;
			durationTableField.Properties.ValidateTableRelation = ValidateTableRelation;
			durationTableField.Properties.ValuesAllowed = ValuesAllowed;

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
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeGuidTableField")]
	[OutputType(typeof(GuidTableField))]
	[Alias("GuidField")]
	public class AddCBreezeGuidTableField : AddCBreezeTableField2<GuidTableField>
	{


		protected override GuidTableField CreateItem()
		{
			var guidTableField = new GuidTableField(ID, Name);
			guidTableField.Enabled = Enabled;
            guidTableField.Properties.Description = Description;

			guidTableField.Properties.AltSearchField = AltSearchField;
			guidTableField.Properties.AutoFormatExpr = AutoFormatExpr;
			guidTableField.Properties.AutoFormatType = AutoFormatType;
			guidTableField.Properties.CalcFormula.Set(CalcFormula);
			guidTableField.Properties.CaptionClass = CaptionClass;
			guidTableField.Properties.Editable = Editable;
			guidTableField.Properties.ExtendedDatatype = ExtendedDatatype;
			guidTableField.Properties.ExternalAccess = ExternalAccess;
			guidTableField.Properties.ExternalName = ExternalName;
			guidTableField.Properties.ExternalType = ExternalType;
			guidTableField.Properties.FieldClass = FieldClass;
			guidTableField.Properties.InitValue = InitValue;
			guidTableField.Properties.NotBlank = NotBlank;
			guidTableField.Properties.TestTableRelation = TestTableRelation;
			guidTableField.Properties.ValidateTableRelation = ValidateTableRelation;
			guidTableField.Properties.ValuesAllowed = ValuesAllowed;

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
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeIntegerTableField")]
	[OutputType(typeof(IntegerTableField))]
	[Alias("IntegerField")]
	public class AddCBreezeIntegerTableField : AddCBreezeTableField2<IntegerTableField>
	{


		protected override IntegerTableField CreateItem()
		{
			var integerTableField = new IntegerTableField(ID, Name);
			integerTableField.Enabled = Enabled;
            integerTableField.Properties.Description = Description;

			integerTableField.Properties.AltSearchField = AltSearchField;
			integerTableField.Properties.AutoFormatExpr = AutoFormatExpr;
			integerTableField.Properties.AutoFormatType = AutoFormatType;
			integerTableField.Properties.AutoIncrement = AutoIncrement;
			integerTableField.Properties.BlankNumbers = BlankNumbers;
			integerTableField.Properties.BlankZero = BlankZero;
			integerTableField.Properties.CalcFormula.Set(CalcFormula);
			integerTableField.Properties.CaptionClass = CaptionClass;
			integerTableField.Properties.Editable = Editable;
			integerTableField.Properties.ExtendedDatatype = ExtendedDatatype;
			integerTableField.Properties.ExternalAccess = ExternalAccess;
			integerTableField.Properties.ExternalName = ExternalName;
			integerTableField.Properties.ExternalType = ExternalType;
			integerTableField.Properties.FieldClass = FieldClass;
			integerTableField.Properties.InitValue = InitValue;
			integerTableField.Properties.MaxValue = MaxValue;
			integerTableField.Properties.MinValue = MinValue;
			integerTableField.Properties.NotBlank = NotBlank;
			integerTableField.Properties.SignDisplacement = SignDisplacement;
			integerTableField.Properties.TestTableRelation = TestTableRelation;
			integerTableField.Properties.ValidateTableRelation = ValidateTableRelation;
			integerTableField.Properties.ValuesAllowed = ValuesAllowed;
			integerTableField.Properties.Volatile = Volatile;
			integerTableField.Properties.Width = Width;

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
	[OutputType(typeof(OptionTableField))]
	[Alias("OptionField")]
	public class AddCBreezeOptionTableField : AddCBreezeTableField2<OptionTableField>
	{


		protected override OptionTableField CreateItem()
		{
			var optionTableField = new OptionTableField(ID, Name);
			optionTableField.Enabled = Enabled;
            optionTableField.Properties.Description = Description;

			optionTableField.Properties.AltSearchField = AltSearchField;
			optionTableField.Properties.AutoFormatExpr = AutoFormatExpr;
			optionTableField.Properties.AutoFormatType = AutoFormatType;
			optionTableField.Properties.BlankNumbers = BlankNumbers;
			optionTableField.Properties.BlankZero = BlankZero;
			optionTableField.Properties.CalcFormula.Set(CalcFormula);
			optionTableField.Properties.CaptionClass = CaptionClass;
			optionTableField.Properties.Editable = Editable;
			optionTableField.Properties.ExtendedDatatype = ExtendedDatatype;
			optionTableField.Properties.ExternalAccess = ExternalAccess;
			optionTableField.Properties.ExternalName = ExternalName;
			optionTableField.Properties.ExternalType = ExternalType;
			optionTableField.Properties.FieldClass = FieldClass;
			optionTableField.Properties.InitValue = InitValue;
			optionTableField.Properties.MaxValue = MaxValue;
			optionTableField.Properties.MinValue = MinValue;
			optionTableField.Properties.NotBlank = NotBlank;
			optionTableField.Properties.OptionOrdinalValue = OptionOrdinalValue;
			optionTableField.Properties.OptionString = OptionString;
			optionTableField.Properties.SignDisplacement = SignDisplacement;
			optionTableField.Properties.TestTableRelation = TestTableRelation;
			optionTableField.Properties.ValidateTableRelation = ValidateTableRelation;
			optionTableField.Properties.ValuesAllowed = ValuesAllowed;
			
			if (AutoOptionCaption) 
				optionTableField.AutoOptionCaption();

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
	public String OptionOrdinalValue { get;set; }

	[Parameter(Mandatory=true)]
	public String OptionString { get;set; }

	[Parameter()]
	public Nullable<Int32> SignDisplacement { get;set; }

	[Parameter()]
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }

	[Parameter()]
	public SwitchParameter AutoOptionCaption { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeRecordIDTableField")]
	[OutputType(typeof(RecordIDTableField))]
	[Alias("RecordIDField")]
	public class AddCBreezeRecordIDTableField : AddCBreezeTableField2<RecordIDTableField>
	{


		protected override RecordIDTableField CreateItem()
		{
			var recordIDTableField = new RecordIDTableField(ID, Name);
			recordIDTableField.Enabled = Enabled;
            recordIDTableField.Properties.Description = Description;

			recordIDTableField.Properties.AltSearchField = AltSearchField;
			recordIDTableField.Properties.AutoFormatExpr = AutoFormatExpr;
			recordIDTableField.Properties.AutoFormatType = AutoFormatType;
			recordIDTableField.Properties.CalcFormula.Set(CalcFormula);
			recordIDTableField.Properties.CaptionClass = CaptionClass;
			recordIDTableField.Properties.Editable = Editable;
			recordIDTableField.Properties.ExtendedDatatype = ExtendedDatatype;
			recordIDTableField.Properties.ExternalAccess = ExternalAccess;
			recordIDTableField.Properties.ExternalName = ExternalName;
			recordIDTableField.Properties.ExternalType = ExternalType;
			recordIDTableField.Properties.FieldClass = FieldClass;
			recordIDTableField.Properties.InitValue = InitValue;
			recordIDTableField.Properties.NotBlank = NotBlank;
			recordIDTableField.Properties.TestTableRelation = TestTableRelation;
			recordIDTableField.Properties.ValidateTableRelation = ValidateTableRelation;
			recordIDTableField.Properties.ValuesAllowed = ValuesAllowed;

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
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeTableFilterTableField")]
	[OutputType(typeof(TableFilterTableField))]
	[Alias("FilterField")]
	public class AddCBreezeTableFilterTableField : AddCBreezeTableField2<TableFilterTableField>
	{


		protected override TableFilterTableField CreateItem()
		{
			var tableFilterTableField = new TableFilterTableField(ID, Name);
			tableFilterTableField.Enabled = Enabled;
            tableFilterTableField.Properties.Description = Description;

			tableFilterTableField.Properties.TableIDExpr = TableIDExpr;

			if (AutoCaption)
                tableFilterTableField.AutoCaption();

			return tableFilterTableField;
		}

	[Parameter()]
	public String TableIDExpr { get;set; }


	}

	[Cmdlet(VerbsCommon.Add, "CBreezeTextTableField")]
	[OutputType(typeof(TextTableField))]
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

			textTableField.Properties.AltSearchField = AltSearchField;
			textTableField.Properties.AutoFormatExpr = AutoFormatExpr;
			textTableField.Properties.AutoFormatType = AutoFormatType;
			textTableField.Properties.CalcFormula.Set(CalcFormula);
			textTableField.Properties.CaptionClass = CaptionClass;
			textTableField.Properties.CharAllowed = CharAllowed;
			textTableField.Properties.DateFormula = DateFormula;
			textTableField.Properties.Editable = Editable;
			textTableField.Properties.ExtendedDatatype = ExtendedDatatype;
			textTableField.Properties.ExternalAccess = ExternalAccess;
			textTableField.Properties.ExternalName = ExternalName;
			textTableField.Properties.ExternalType = ExternalType;
			textTableField.Properties.FieldClass = FieldClass;
			textTableField.Properties.InitValue = InitValue;
			textTableField.Properties.NotBlank = NotBlank;
			textTableField.Properties.Numeric = Numeric;
			textTableField.Properties.TestTableRelation = TestTableRelation;
			textTableField.Properties.Title = Title;
			textTableField.Properties.ValidateTableRelation = ValidateTableRelation;
			textTableField.Properties.ValuesAllowed = ValuesAllowed;
			textTableField.Properties.Width = Width;

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
	[OutputType(typeof(TimeTableField))]
	[Alias("TimeField")]
	public class AddCBreezeTimeTableField : AddCBreezeTableField2<TimeTableField>
	{


		protected override TimeTableField CreateItem()
		{
			var timeTableField = new TimeTableField(ID, Name);
			timeTableField.Enabled = Enabled;
            timeTableField.Properties.Description = Description;

			timeTableField.Properties.AltSearchField = AltSearchField;
			timeTableField.Properties.AutoFormatExpr = AutoFormatExpr;
			timeTableField.Properties.AutoFormatType = AutoFormatType;
			timeTableField.Properties.BlankNumbers = BlankNumbers;
			timeTableField.Properties.CalcFormula.Set(CalcFormula);
			timeTableField.Properties.CaptionClass = CaptionClass;
			timeTableField.Properties.Editable = Editable;
			timeTableField.Properties.ExtendedDatatype = ExtendedDatatype;
			timeTableField.Properties.ExternalAccess = ExternalAccess;
			timeTableField.Properties.ExternalName = ExternalName;
			timeTableField.Properties.ExternalType = ExternalType;
			timeTableField.Properties.FieldClass = FieldClass;
			timeTableField.Properties.InitValue = InitValue;
			timeTableField.Properties.MaxValue = MaxValue;
			timeTableField.Properties.MinValue = MinValue;
			timeTableField.Properties.NotBlank = NotBlank;
			timeTableField.Properties.SignDisplacement = SignDisplacement;
			timeTableField.Properties.TestTableRelation = TestTableRelation;
			timeTableField.Properties.ValidateTableRelation = ValidateTableRelation;
			timeTableField.Properties.ValuesAllowed = ValuesAllowed;

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
	public Nullable<Boolean> TestTableRelation { get;set; }

	[Parameter()]
	public Nullable<Boolean> ValidateTableRelation { get;set; }

	[Parameter()]
	public String ValuesAllowed { get;set; }


	}

}
