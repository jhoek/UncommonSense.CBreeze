Import-Module UncommonSense.CBreeze.Automation

$Name = 'MyParameter'
$Dimensions = '1,2,8'
$DataLength = 42
$StringSubType = 'MyStringSubType'

function Test-Parameter([Parameter(ValueFromPipeLine)]$Parameter)
{
    Process 
    { 
        foreach($Item in $Parameter)
        {
            $Parameter.Name | Should Be $Name
            $Parameter.Var | Should Be $true
            $Parameter.Dimensions | Should Be $Dimensions
        }
    }
}

$TestCases = @(
    @{
        Type = 'ActionParameter'
    },
    @{
        Type = 'CodeunitParameter'
        TypeSpecificTests = { param($Parameter) $Parameter.SubType | Should Be $IntegerSubType }
    }
)

Describe 'Add-CBreezeParameter' {
    It 'Works for <Type>' -TestCases $TestCases {
        param($Type, $TypeSpecificTests)



    }



    It 'Works for Action parameters' {
        ActionParameter -Dimensions $Dimensions -Var -Name $Name | Test-Parameter
    }

    It 'Works for Automation parameters' {
        $Parameter = AutomationParameter -Dimensions $Dimensions -Var -Name $Name -SubType $StringSubType 
        $Parameter | Test-Parameter 
        $Parameter.SubType | Should Be $StringSubType
    }

    It 'Works for BigInteger parameters' {
        BigIntegerParameter -Dimensions $Dimensions -Var -Name $Name | Test-Parameter
    }

    It 'Works for BigText parameters' {
        BigTextParameter -Dimensions $Dimensions -Var -Name $Name | Test-Parameter
    }

    It 'Works for Binary parameters ' {
        $Parameter = BinaryParameter -Dimensions $Dimensions -DataLength $DataLength -Var -Name $Name
        $Parameter | Test-Parameter 
        $Parameter.DataLength | Should Be $DataLength
    }

    It 'Works for Boolean parameters' {
        BooleanParameter -Var -Dimensions $Dimensions -Name $Name | Test-Parameter
    }

    It 'Works for Byte parameters' {
        ByteParameter -Var -Dimensions $Dimensions -Name $Name | Test-Parameter
    }

    It 'Works for Char parameters' {
        CharParameter -Var -Dimensions $Dimensions -Name $Name | Test-Parameter
    }

    It 'Works for Code parameters' {
        $Parameter = CodeParameter -Var -Dimensions $Dimensions -DataLength $DataLength -Name $Name 
        $Parameter | Test-Parameter
        $Parameter.DataLength | Should Be $DataLength
        
        $Parameter = CodeParameter -Var -Dimensions $Dimensions -Name $Name 
        $Parameter | Test-Parameter 
        $Parameter.DataLength | Should Be 0
    }    

    It 'Works for Codeunit parameters ' {
        $Parameter = 
    }
    

<#
FIXME: remaining types
Procedure 1 Test {
    Codeunit,
    DateFormula,
    Date,
    DateTime,
    Decimal,
    Dialog,
    DotNet,
    Duration,
    ExecutionMode,
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
}