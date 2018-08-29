<#
.Synopsis
   Adds a creation date field to a C/Breeze application
#>
function Add-CBreezeCreationDate
{
    Param
    (
        [Parameter(Mandatory, ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Table]$Table,

        [Parameter()]
        [UncommonSense.CBreeze.Core.Page[]]$Pages,

        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]]$Range,

        [ValidateNotNullOrEmpty()]
        [string]$FieldName = 'Creation Date',

        [Switch]$CreateKey = $true,

        [Switch]$PassThru
    )

    Process
    {
        if ($CreateKey)
        {
            if ($Table.Keys.Count -eq 0)
            {
                throw "$Table does not have a primary key."
            }
        }

        $Result = @{}
        $Result.Fields = @{}
        $Result.Controls = @{}
        $Result.Controls.CreationDate = @{}

        $Result.Fields.CreationDate = $Table | Add-CBreezeTableField -Type Date -Name $FieldName -Range $Range -AutoCaption -PassThru

        if ($CreateKey)
        {
            $Result.Key = $Table | Add-CBreezeTableKey -Fields $Result.Fields.CreationDate.Name -PassThru
        }

        foreach ($Page in $Pages | Where-Object { $_.Properties.PageType -eq 'List' })
        {
            $Repeater = $Page | Get-CBreezePageControlGroup -GroupType Repeater -Position FirstWithinContainer -Range $Range
            $Result.Controls.CreationDate.Add($Page, ($Repeater | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.CreationDate.QuotedName -PassThru -Range $Range))
        }

        if ($PassThru)
        {
            $Result
        }
    }
}