<#
.Synopsis
Adds a setup table style Primary Key field to a C/Breeze application
#>
function Add-CBreezeSetupPrimaryKey
{
    [OutputType([Table])]
    Param
    (
        [Parameter(Mandatory, ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Table]$Table,

        [Parameter(Mandatory)]
        [ValidateRange(1, [int]::MaxValue)]
        [int]$FieldNo,

        [string]$KeyVariable,
        [string]$FieldVariable
    )

    Process
    {
        $Table |
            Test-CBreezePrimaryKey `
            -Test ShouldNotHave `
            -ThrowError

        $Field = $Table |
            Add-CBreezeCodeTableField `
            -ID $FieldNo `
            -DataLength 10 `
            -AutoCaption `
            -Name 'Primary Key'

        $Key = $Table |
            Add-CBreezeTableKey `
            -Fields 'Primary Key' `
            -Clustered

        Set-OutVariable $FieldVariable $Field
        Set-OutVariable $KeyVariable $Key

        $Table
    }
}