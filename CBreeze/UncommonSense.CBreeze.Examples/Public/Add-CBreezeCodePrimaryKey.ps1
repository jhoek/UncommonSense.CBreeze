<#
.Synopsis
   Adds a Code primary key field to a C/Breeze application
#>
function Add-CBreezeCodePrimaryKey
{
    Param
    (
        [Parameter(Mandatory, ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Table] $Table,

        [Parameter()]
        [UncommonSense.CBreeze.Core.Page[]] $Pages,

        [Parameter(Mandatory)]
        [ValidateRange(1, [int]::MaxValue)]
        [int]$FieldNo,

        [string]$KeyVariable,
        [string]$FieldVariable,
        [string]$ControlVariable
    )

    Process
    {
        $Table | 
            Test-CBreezePrimaryKey `
            -Test ShouldNotHave `
            -ThrowError

        $Table | 
            Add-CBreezeCodeTableField `
            -ID $FieldNo `
            -Name Code `
            -NotBlank `
            -AutoCaption `
            -OutVariable CodeField

        $Table | 
            Add-CBreezeTableKey `
            -Fields Code `
            -Clustered `
            -OutVariable PrimaryKey

        $PageControl = [Ordered]@{}

        $Page | 
            Where-Object { $_.Properties.PageType -eq 'List' } | 
            ForEach-Object {
            $Repeater = $Page | Get-CBreezePageControlGroup -GroupType Repeater 
            $PageControl.Add($Page, ($Repeater | Add-CBreezePageControl -SourceExpr CodeField.QuotedName))
        }

        Set-OutVariable $KeyVariable $PrimaryKey
        Set-OutVariable $FieldVariable $CodeField
        Set-OutVariable $ControlVariable $PageControl
    }
}