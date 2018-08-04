using namespace UncommonSense.CBreeze.Core

<#
.Synopsis
   Adds a Code primary key field to a C/Breeze application
#>
function Add-CBreezeCodePrimaryKey {
    Param
    (
        [Parameter(Mandatory, ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Table] $Table,

        [Parameter()]
        [UncommonSense.CBreeze.Core.Page[]] $Page,

        [ValidateRange(1, [int]::MaxValue)]
        [int]$FieldNo = 1,

        [string]$KeyVariable,
        [string]$FieldVariable,
        [string]$ControlVariable
    )

    Process {
        $Table | 
            Test-CBreezePrimaryKey `
            -Test ShouldNotHave `
            -ThrowError

        $CodeField = $Table | 
            Add-CBreezeCodeTableField `
            -ID $FieldNo `
            -Name Code `
            -NotBlank `
            -AutoCaption `
            -PassThru

        $PrimaryKey = $Table | 
            Add-CBreezeTableKey `
            -Fields Code `
            -Clustered

        Set-OutVariable $KeyVariable $PrimaryKey
        Set-OutVariable $FieldVariable $CodeField

        if ($Page) {
            $PageControl = [Ordered]@{}

            $Page | 
                Where-Object { $_.Properties.PageType -eq 'List' } | 
                ForEach-Object {
                $Repeater = $Page | Get-CBreezePageControlGroup -GroupType Repeater 
                $PageControl.Add($Page, ($Repeater | Add-CBreezePageControl -SourceExpr $CodeField.QuotedName))
            }

            Set-OutVariable $ControlVariable $PageControl
        }

        $Table
    }
}