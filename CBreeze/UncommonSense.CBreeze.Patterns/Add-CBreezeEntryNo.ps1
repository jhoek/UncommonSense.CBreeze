<#
.Synopsis
   Adds an Entry No. primary key field to a C/Breeze application
#>
function Add-CBreezeEntryNo
{
    Param
    (
        [Parameter(Mandatory, ValueFromPipeline)]
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
        $Result.Controls.EntryNo = @{}

        $Result.Fields.EntryNo = $Table | Add-CBreezeTableField -Type Integer -Name 'Entry No.' -PrimaryKeyFieldNoRange -AutoCaption -Range $Range -PassThru
        $Result.PrimaryKey = $TableKey = $Table | Add-CBreezeTableKey -Fields $Result.Fields.EntryNo.Name -Clustered $true -PassThru

        foreach ($Page in $Pages | Where-Object { $_.Properties.PageType -eq 'List' })
        {
            $Repeater = $Page | Get-CBreezePageControlGroup -GroupType Repeater -Range $Range
            $Result.Controls.EntryNo.Add($Page, ($Repeater | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.EntryNo.QuotedName -PassThru -Range $Range))
        }

        if ($PassThru)
        {
            $Result
        }
    }
}