$NextVariableID = 1
$OptionString = 'Oink,Boink'

$PSDefaultParameterValues["New-CBreeze*Variable:Dimensions"] = '1,2,3'
$PSDefaultParameterValues["New-CBreeze*Variable:IncludeInDataset"] = $true
$PSDefaultParameterValues["New-CBreeze*Variable:RunOnClient"] = $true
$PSDefaultParameterValues["New-CBreeze*Variable:WithEvents"] = $true
$PSDefaultParameterValues["New-CBreeze*Variable:SecurityFiltering"] = 'Filtered'
$PSDefaultParameterValues["New-CBreeze*Variable:Temporary"] = $true

Describe "Syntax for New-CBreezeVariable" {
    It "Correctly creates variables" {
        $Codeunit = Codeunit Test {
            ActionVariable MyActionVariable
            ActionVariable ($NextVariableID++) MyOtherActionVariable

            AutomationVariable MyAutomationVariable MySubType
            AutomationVariable ($NextVariableID++) MyOtherAutomationVariable MySubType

            BigIntegerVariable MyBigIntegerVariable
            BigIntegerVariable ($NextVariableID++) MyOtherBigIntegerVariable 

            BigTextVariable MyBigTextVariable
            BigTextVariable ($NextVariableID++) MyOtherBigTextVariable 

            BinaryVariable MyBinaryVariable 123
            BinaryVariable ($NextVariableID++) MyOtherBinaryVariable 123

            BooleanVariable MyBooleanVariable
            BooleanVariable ($NextVariableID++) MyOtherBooleanVariable

            ByteVariable MyByteVariable
            ByteVariable ($NextVariableID++) MyOtherByteVariable

            CharVariable MyCharVariable
            CharVariable ($NextVariableID++) MyOtherCharVariable

            CodeVariable MyCodeVariable 123 
            CodeVariable ($NextVariableID++) MyOtherCodeVariable 123

            CodeunitVariable MyCodeunitVariable 123
            CodeunitVariable ($NextVariableID++) MyOtherCodeunitVariable 123

            DateVariable MyDateVariable
            DateVariable ($NextVariableID++) MyOtherDateVariable

            DateFormulaVariable MyDateFormulaVariable
            DateFormulaVariable ($NextVariableID++) MyOtherDateFormulaVariable

            DateTimeVariable MyDateTimeVariable
            DateTimeVariable ($NextVariableID++) MyOtherDateTimeVariable

            DecimalVariable MyDecimalVariable
            DecimalVariable ($NextVariableID++) MyOtherDecimalVariable

            DialogVariable MyDialogVariable
            DialogVariable ($NextVariableID++) MyOtherDialogVariable

            DotNetVariable MyDotNetVariable MySubType
            DotNetVariable ($NextVariableID++) MyOtherDotNetVariable MySubType

            DurationVariable MyDurationVariable 
            DurationVariable ($NextVariableID++) MyOtherDurationVariable

            ExecutionModeVariable MyExecutionModeVariable
            ExecutionModeVariable ($NextVariableID++) MyOtherExecutionModeVariable

            FieldRefVariable MyFieldRefVariable
            FieldRefVariable ($NextVariableID++) MyOtherFieldRefVariable

            FileVariable MyFileVariable
            FileVariable ($NextVariableID++) MyOtherFileVariable

            GuidVariable MyGuidVariable
            GuidVariable ($NextVariableID++) MyOtherGuidVariable

            InstreamVariable MyInstreamVariable
            InStreamVariable ($NextVariableID++) MyOtherInStreamVariable

            IntegerVariable MyIntegerVariable
            IntegerVariable ($NextVariableID++) MyOtherIntegerVariable

            KeyRefVariable MyKeyRefVariable
            KeyRefVariable ($NextVariableID++) MyOtherKeyRefVariable

            OcxVariable MyOcxVariable MySubType
            OcxVariable ($NextVariableID++) MyOtherOcxVariable MySubType

            OptionVariable MyOptionVariable $OptionString
            OptionVariable ($NextVariableID++) MyOtherOptionVariable $OptionString

            OutStreamVariable MyOutStreamVariable
            OutStreamVariable ($NextVariableID++) MyOtherOutStreamVariable

            PageVariable MyPageVariable 123
            PageVariable ($NextVariableID++) MyOtherPageVariable 123

            QueryVariable MyQueryVariable 123
            QueryVariable ($NextVariableID++) MyOtherQueryVariable 123

            RecordVariable MyRecordVariable 123
            RecordVariable ($NextVariableID++) MyOtherRecordVariable 123

            RecordIDVariable MyRecordIDVariable
            RecordIDVariable ($NextVariableID++) MyOtherRecordIDVariable

            RecordRefVariable MyRecordRefVariable
            RecordRefVariable ($NextVariableID++) MyOtherRecordRefVariable

            ReportVariable MyReportVariable 123
            ReportVariable ($NextVariableID++) MyOtherReportVariable 123

            ReportFormatVariable MyReportFormatVariable 
            ReportFormatVariable ($NextVariableID++) MyOtherReportFormatVariable

            TableConnectionTypeVariable MyTableConnectionTypeVariable
            TableConnectionTypeVariable ($NextVariableID++) MyOtherTableConnectionTypeVariable

            TestPageVariable MyTestPageVariable 123
            TestPageVariable ($NextVariableID++) MyOtherTestPageVariable 123

            TextVariable MyTextVariable
            TextVariable MyTextVariableWithDataLength 123
            TextVariable ($NextVariableID++) MyOtherTextVariable
            TextVariable ($NextVariableID++) MyOtherTextVariableWithDataLength 123
            
            TextEncodingVariable MyTextEncodingVariable
            TextEncodingVariable ($NextVariableID++) MyOtherTextEncodingVariable

            TextConstant MyTextConstant | Set-CBreezeMLValue CaptionML ENU Foo -PassThru | Set-CBreezeMLValue CaptionML NLD Baz -PassThru
            TextConstant ($NextVariableID++) MyOtherTextConstant | Set-CBreezeMLValue CaptionML ENU Foo -PassThru | Set-CBreezeMLValue CaptionML NLD Baz -PassThru

            TimeVariable MyTimeVariable 
            TimeVariable ($NextVariableID++) MyOtherTimeVariable 

            TransactionTypeVariable MyTransactionTypeVariable
            TransactionTypeVariable ($NextVariableID++) MyOtherTransactionTypeVariable

            VariantVariable MyVariantVariable
            VariantVariable ($NextVariableID++) MyOtherVariantVariable

            XmlPortVariable MyXmlPortVariable 123
            XmlPortVariable ($NextVariableID++) MyOtherXmlPortVariable 123
        } 

        Write-Host ($Codeunit | Export-CBreezeApplication)
    }
}