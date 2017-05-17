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

        // Field, ParentNode, AccessByPermission, AltSearchField, AutoFormatExpr, AutoFormatType, AutoIncrement, BlankNumbers, BlankZero, CalcFormula, CaptionClass, CaptionML, Description, Editable, ExtendedDatatype, ExternalAccess, ExternalName, ExternalType, FieldClass, InitValue, MaxValue, MinValue, NotBlank, OnLookup, OnValidate, SignDisplacement, SqlTimestamp, TableRelation, TestTableRelation, ValidateTableRelation, ValuesAllowed, Volatile, Width, Item, WithAValue, ChildNodes
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

        // Field, ParentNode, AccessByPermission, CaptionML, Description, OnLookup, OnValidate, Item, WithAValue, ChildNodes
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

        // Field, ParentNode, AccessByPermission, CaptionML, Compressed, Description, ExternalAccess, ExternalName, ExternalType, OnLookup, OnValidate, Owner, SubType, Volatile, Item, WithAValue, ChildNodes
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

        // Field, ParentNode, AccessByPermission, AltSearchField, AutoFormatExpr, AutoFormatType, BlankNumbers, BlankZero, CalcFormula, CaptionClass, CaptionML, Description, Editable, ExtendedDatatype, ExternalAccess, ExternalName, ExternalType, FieldClass, InitValue, MaxValue, MinValue, NotBlank, OnLookup, OnValidate, SignDisplacement, TableRelation, TestTableRelation, ValidateTableRelation, ValuesAllowed, Item, WithAValue, ChildNodes
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

        // Field, ParentNode, AccessByPermission, AltSearchField, AutoFormatExpr, AutoFormatType, CalcFormula, CaptionClass, CaptionML, CharAllowed, DateFormula, Description, Editable, ExtendedDatatype, ExternalAccess, ExternalName, ExternalType, FieldClass, InitValue, NotBlank, Numeric, OnLookup, OnValidate, SQLDataType, TableRelation, TestTableRelation, ValidateTableRelation, ValuesAllowed, Width, Item, WithAValue, ChildNodes
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

        // Field, ParentNode, AccessByPermission, AltSearchField, AutoFormatExpr, AutoFormatType, CalcFormula, CaptionClass, CaptionML, Description, Editable, ExtendedDatatype, ExternalAccess, ExternalName, ExternalType, FieldClass, InitValue, NotBlank, OnLookup, OnValidate, TableRelation, TestTableRelation, ValidateTableRelation, ValuesAllowed, Item, WithAValue, ChildNodes
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

        // Field, ParentNode, AccessByPermission, AltSearchField, AutoFormatExpr, AutoFormatType, BlankNumbers, CalcFormula, CaptionClass, CaptionML, ClosingDates, Description, Editable, ExtendedDatatype, ExternalAccess, ExternalName, ExternalType, FieldClass, InitValue, MaxValue, MinValue, NotBlank, OnLookup, OnValidate, SignDisplacement, TableRelation, TestTableRelation, ValidateTableRelation, ValuesAllowed, Item, WithAValue, ChildNodes
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

        // Field, ParentNode, AccessByPermission, AltSearchField, AutoFormatExpr, AutoFormatType, BlankNumbers, CalcFormula, CaptionClass, CaptionML, Description, Editable, ExtendedDatatype, ExternalAccess, ExternalName, ExternalType, FieldClass, InitValue, MaxValue, MinValue, NotBlank, OnLookup, OnValidate, SignDisplacement, TableRelation, TestTableRelation, ValidateTableRelation, ValuesAllowed, Volatile, Item, WithAValue, ChildNodes
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

        // Field, ParentNode, AccessByPermission, AltSearchField, AutoFormatExpr, AutoFormatType, BlankNumbers, BlankZero, CalcFormula, CaptionClass, CaptionML, DecimalPlaces, Description, Editable, ExtendedDatatype, ExternalAccess, ExternalName, ExternalType, FieldClass, InitValue, MaxValue, MinValue, NotBlank, OnLookup, OnValidate, SignDisplacement, TableRelation, TestTableRelation, ValidateTableRelation, ValuesAllowed, Width, Item, WithAValue, ChildNodes
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

        // Field, ParentNode, AccessByPermission, AltSearchField, AutoFormatExpr, AutoFormatType, BlankNumbers, BlankZero, CalcFormula, CaptionClass, CaptionML, Description, Editable, ExtendedDatatype, ExternalAccess, ExternalName, ExternalType, FieldClass, InitValue, MaxValue, MinValue, NotBlank, OnLookup, OnValidate, SignDisplacement, StandardDayTimeUnit, TableRelation, TestTableRelation, ValidateTableRelation, ValuesAllowed, Item, WithAValue, ChildNodes
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

        // Field, ParentNode, AccessByPermission, AltSearchField, AutoFormatExpr, AutoFormatType, CalcFormula, CaptionClass, CaptionML, Description, Editable, ExtendedDatatype, ExternalAccess, ExternalName, ExternalType, FieldClass, InitValue, NotBlank, OnLookup, OnValidate, TableRelation, TestTableRelation, ValidateTableRelation, ValuesAllowed, Item, WithAValue, ChildNodes
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

        // Field, ParentNode, AccessByPermission, AltSearchField, AutoFormatExpr, AutoFormatType, AutoIncrement, BlankNumbers, BlankZero, CalcFormula, CaptionClass, CaptionML, Description, Editable, ExtendedDatatype, ExternalAccess, ExternalName, ExternalType, FieldClass, InitValue, MaxValue, MinValue, NotBlank, OnLookup, OnValidate, SignDisplacement, TableRelation, TestTableRelation, ValidateTableRelation, ValuesAllowed, Volatile, Width, Item, WithAValue, ChildNodes
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

        // Field, ParentNode, AccessByPermission, AltSearchField, AutoFormatExpr, AutoFormatType, BlankNumbers, BlankZero, CalcFormula, CaptionClass, CaptionML, Description, Editable, ExtendedDatatype, ExternalAccess, ExternalName, ExternalType, FieldClass, InitValue, MaxValue, MinValue, NotBlank, OnLookup, OnValidate, OptionCaptionML, OptionOrdinalValue, OptionString, SignDisplacement, TableRelation, TestTableRelation, ValidateTableRelation, ValuesAllowed, Item, WithAValue, ChildNodes
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

        // Field, ParentNode, AccessByPermission, AltSearchField, AutoFormatExpr, AutoFormatType, CalcFormula, CaptionClass, CaptionML, Description, Editable, ExtendedDatatype, ExternalAccess, ExternalName, ExternalType, FieldClass, InitValue, NotBlank, OnLookup, OnValidate, TableRelation, TestTableRelation, ValidateTableRelation, ValuesAllowed, Item, WithAValue, ChildNodes
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

        // Field, ParentNode, AccessByPermission, CaptionML, Description, OnLookup, OnValidate, TableIDExpr, Item, WithAValue, ChildNodes
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

        // Field, ParentNode, AccessByPermission, AltSearchField, AutoFormatExpr, AutoFormatType, CalcFormula, CaptionClass, CaptionML, CharAllowed, DateFormula, Description, Editable, ExtendedDatatype, ExternalAccess, ExternalName, ExternalType, FieldClass, InitValue, NotBlank, Numeric, OnLookup, OnValidate, TableRelation, TestTableRelation, Title, ValidateTableRelation, ValuesAllowed, Width, Item, WithAValue, ChildNodes
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

        // Field, ParentNode, AccessByPermission, AltSearchField, AutoFormatExpr, AutoFormatType, BlankNumbers, CalcFormula, CaptionClass, CaptionML, Description, Editable, ExtendedDatatype, ExternalAccess, ExternalName, ExternalType, FieldClass, InitValue, MaxValue, MinValue, NotBlank, OnLookup, OnValidate, SignDisplacement, TableRelation, TestTableRelation, ValidateTableRelation, ValuesAllowed, Item, WithAValue, ChildNodes
    }
}