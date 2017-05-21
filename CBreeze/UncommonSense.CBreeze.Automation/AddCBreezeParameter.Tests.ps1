Import-Module UncommonSense.CBreeze.Automation

$Name = 'MyParameter'
$Dimensions = '1,2,8'
$DataLength = 42
$IntegerSubType = 84
$StringSubType = 'MyStringSubType'

$TestCases = @(
    @{
        Expression = 'ActionParameter'
    },
    @{
        Expression = "AutomationParameter -SubType $StringSubType"
        TypeSpecificTests = { param($Parameter) $Parameter.SubType | Should Be $StringSubType }
    },
    @{
        Expression = "BigIntegerParameter"
    },
    @{
        Expression = 'BigTextParameter'
    },
    @{
        Expression = "BinaryParameter -DataLength $DataLength"
        TypeSpecificTests = { param($Parameter) $Parameter.DataLength | Should Be $DataLength }
    },
    @{
        Expression = 'BooleanParameter'
    },
    @{
        Expression = 'ByteParameter'
    },
    @{
        Expression = 'CharParameter'
    },
    @{
        Expression = "CodeParameter -DataLength $DataLength"
        TypeSpecificTests = { param($Parameter) $Parameter.DataLength | Should Be $DataLength }
    },
    @{
        Expression = "CodeParameter"
    },
    @{
        Expression = "CodeunitParameter -SubType $IntegerSubType"
        TypeSpecificTests = { param($Parameter) $Parameter.SubType | Should Be $IntegerSubType }
    },
    @{
        Expression = 'DateFormulaParameter'
    },
    @{
        Expression = 'DateParameter'
    },
    @{
        Expression = 'DateTimeParameter'
    },
    @{
        Expression = 'DecimalParameter'
    },
    @{
        Expression = 'DialogParameter'
    },
    @{
        Expression = "DotNetParameter -SubType $StringSubType -RunOnClient `$true -SuppressDispose `$true" 
        TypeSpecificTests = { 
            param($Parameter) 
            $Parameter.SubType | Should Be $StringSubType 
            $Parameter.RunOnClient | Should Be $true
            $Parameter.SuppressDispose | Should Be $true
        }
    },
    @{
        Expression = 'DurationParameter'
    },
    @{
        Expression = 'ExecutionModeParameter'
    },
    @{
        Expression = 'FieldRefParameter'
    },
    @{
        Expression = 'FileParameter'
    }
)

Describe 'Add-CBreezeParameter' {
    It 'Works for <Expression>' -TestCases $TestCases {
        param($Expression, $TypeSpecificTests)

        $Parameter = [ScriptBlock]::Create("$Expression -Var -Name `$Name -Dimensions `$Dimensions").Invoke()
        $Parameter.Name | Should Be $Name
        $Parameter.Var | Should Be $true
        $Parameter.Dimensions | Should Be $Dimensions

        if ($TypeSpecificTests) {
            & $TypeSpecificTests -Parameter $Parameter
        }
    }
}

<#
   

<#
FIXME: remaining types
Procedure 1 Test {
    FieldRef,
    File,
#if NAV2016
        FilterPageBuilder,
#endif
        Guid,
        InStream,
        Integer,
        KeyRef,
        Ocx,
        Option,
        OutStream,
        Page,
        Query,
        RecordID,
        Record,
        RecordRef,
        Report,
#if NAV2016
        ReportFormat,
        TableConnectionType,
#endif
        TestPage,
        TestRequestPage,
        Text,
#if NAV2016
        TextEncoding,
#endif
        Time,
        TransactionType,
        Variant,
        XmlPort,
}#>