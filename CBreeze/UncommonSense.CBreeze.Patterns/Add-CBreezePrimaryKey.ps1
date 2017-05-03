<#
.Synopsis
   Adds a setup table style Primary Key field to a C/Breeze application
#>
function Add-CBreezePrimaryKey
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory,ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Table]$Table,

        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]]$Range,

        [Switch]$PassThru
    )

    Process
    {
        $Table | Test-CBreezePrimaryKey -Test ShouldNotHave -ThrowError

        $Result = @{}
        $Result.Fields = @{}
        $Result.Fields.PrimaryKey = $Table | Add-CBreezeTableField -Type Code -DataLength 10 -AutoCaption -Name 'Primary Key' -Range $Range -PassThru -PrimaryKeyFieldNoRange
        $Result.PrimaryKey = $Table | Add-CBreezeTableKey -Fields $Result.Fields.PrimaryKey.Name -Clustered $true -PassThru

        if ($PassThru)
        {
            $Result
        }
    }
}