Import-Module UncommonSense.CBreeze.Automation

$Name = 'MyParameter'
$Dimensions = '1,2,8'
$DataLength = 42
$IntegerSubType = 84
$StringSubType = 'MyStringSubType'
$OptionString = 'One,Two,Three'
$SecurityFiltering = 'Disallowed'

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
    @{
        Expression = 'FilterPageBuilderParameter'
    }
    @{
        Expression = 'GuidParameter'
    }
    @{
        Expression = 'InStreamParameter'
    },
    @{
        Expression = 'IntegerParameter'
    },
    @{
        Expression = 'KeyRefParameter'
    },
    @{
        Expression = "OcxParameter -SubType $StringSubType"
        TypeSpecificTests = {
            param($Parameter)
            $Parameter.SubType | Should Be $StringSubType
        }
    },
    @{
        Expression = "OptionParameter -OptionString '$OptionString'"
        TypeSpecificTests = {
            param($Parameter)
            $Parameter.OptionString | Should Be $OptionString
        }
    },
    @{
        Expression = 'OutStreamParameter'
    },
	@{
		Expression = "PageParameter -SubType $IntegerSubType"
        TypeSpecificTests = {
            param($Parameter)
            $Parameter.SubType | Should Be $IntegerSubType
        }
	},
    @{
        Expression = "QueryParameter -SubType $IntegerSubType"
        TypeSpecificTests = {
            param($Parameter)
            $Parameter.SubType | Should Be $IntegerSubType
        }
    },
    @{
        Expression = 'RecordIDParameter'
    },
    @{
        Expression = "RecordParameter -SecurityFiltering $SecurityFiltering -SubType $IntegerSubType -Temporary `$true"
        TypeSpecificTests = {
            param($Parameter)
            $Parameter.SecurityFiltering | Should Be $SecurityFiltering
            $Parameter.SubType | Should Be $IntegerSubType
            $Parameter.Temporary | Should Be $true
        }
    },
    @{
        Expression = 'RecordRefParameter'
    },
    @{
        Expression = "ReportParameter -SubType $IntegerSubType"
        TypeSpecificTests = {
            param($Parameter)
            $Parameter.SubType | Should Be $IntegerSubType
        }
    },
    @{
        Expression = 'ReportFormatParameter'
    },
    @{
        Expression = 'TableConnectionTypeParameter'
    },
    @{
        Expression = "TestPageParameter -SubType $IntegerSubType"
        TypeSpecificTests = {
            param($Parameter)
            $Parameter.SubType | Should Be $IntegerSubType
        }
    }
    @{
        Expression = "TestRequestPageParameter -SubType $IntegerSubType"
        TypeSpecificTests = {
            param($Parameter)
            $Parameter.SubType | Should Be $IntegerSubType
        }
    },
    @{
        Expression = "TextParameter -DataLength $DataLength"
        TypeSpecificTests = {
            param($Parameter)
            $Parameter.DataLength | Should Be $DataLength
        }
    },
    @{
        Expression = 'TextEncodingParameter'
    },
    @{
        Expression = 'TimeParameter'
    },
    @{
        Expression = 'TransactionTypeParameter'
    },
    @{
        Expression = 'VariantParameter'
    },
    @{
        Expression = "XmlPortParameter -SubType $IntegerSubType"
        TypeSpecificTests = {
            param($Parameter)
            $Parameter.SubType | Should Be $IntegerSubType
        }
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