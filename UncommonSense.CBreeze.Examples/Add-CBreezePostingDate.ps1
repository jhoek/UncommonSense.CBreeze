<#
.Synopsis
   Adds a posting date field to a C/Breeze application
#>
function Add-CBreezePostingDate
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory,ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Table]$Table,

        [Parameter()]
        [UncommonSense.CBreeze.Core.Page[]] $Pages,

        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]]$Range,

        [Switch]$PassThru
    )

    Process
    {
        $Result = @{}
        $Result.Fields = @{}
        $Result.Controls = @{}
        $Result.Controls.PostingDate = @{}

        $Result.Fields.PostingDate = $Table | Add-CBreezeTableField -Type Date -Range $Range -PassThru -Name "Posting Date" -AutoCaption -ClosingDates $true
        
        foreach($Page in $Pages | Where-Object { $_.Properties.PageType = 'List' })
        {
            $Repeater = $Page | Get-CBreezePageControlGroup -GroupType Repeater -Position FirstWithinContainer -Range $Range
            $Result.Controls.PostingDate.Add($Page, ($Repeater | Add-CBreezePageControl -Type Field -Range $Range -PassThru -SourceExpr $Result.Fields.PostingDate.QuotedName))
        }

        if ($PassThru)
        {
            $Result
        }
    }
}