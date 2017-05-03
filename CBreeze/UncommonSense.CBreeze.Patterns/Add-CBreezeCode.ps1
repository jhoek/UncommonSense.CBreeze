<#
.Synopsis
   Adds a Code primary key field to a C/Breeze application
#>
function Add-CBreezeCode
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory,ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Table] $Table,

        [Parameter()]
        [UncommonSense.CBreeze.Core.Page[]] $Pages,

        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]]$Range,

        [Switch] $PassThru
    )

    Process
    {
        $Table | Test-CBreezePrimaryKey -Test ShouldNotHave -ThrowError

        $Result = @{}
        $Result.Fields = @{}
        $Result.Controls = @{}
        $Result.Controls.Code = @{}

        $Result.Fields.Code = $Table | Add-CBreezeTableField -Type Code -Name Code -PrimaryKeyFieldNoRange -AutoCaption -Range $Range -PassThru -NotBlank $true
        $Result.PrimaryKey = $Table | Add-CBreezeTableKey -Fields $Result.Fields.Code.Name -Clustered $true -PassThru

        foreach($Page in $Pages | Where-Object { $_.Properties.PageType -eq 'List' })
        {
            $Repeater = $Page | Get-CBreezePageControlGroup -GroupType Repeater -Range $Range
            $Result.Controls.Code.Add($Page, ($Repeater | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.Code.QuotedName -PassThru -Range $Range))
        }

        if ($PassThru)
        {
            $Result
        }
    }
}