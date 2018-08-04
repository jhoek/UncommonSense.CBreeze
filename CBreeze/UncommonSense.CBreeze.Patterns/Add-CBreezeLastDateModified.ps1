<#
.Synopsis
   Adds a last date modified field to a C/Breeze application
#>
function Add-CBreezeLastDateModified
{
    Param
    (
        [Parameter(Mandatory, ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Table]$Table,

        [UncommonSense.CBreeze.Core.Page[]]$Pages,

        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]]$Range,

        [ValidateNotNullOrEmpty()]
        [string]$GroupCaption = 'General',

        [ValidateSet('FirstWithinContainer', 'LastWithinContainer')]
        [string]$GroupPosition = 'FirstWithinContainer',

        [ValidateNotNullOrEmpty()]
        [string]$FieldName = 'Last Date Modified',

        [Switch]$PassThru
    )

    Process
    {
        $Result = @{}
        $Result.Fields = @{}
        $Result.Controls = @{}
        $Result.Controls.LastDateModified = @{}

        $Result.Fields.LastDateModified = $Table | Add-CBreezeTableField -Range $Range -Type Date -Name $FieldName -AutoCaption -PassThru -Editable $false

        $Table.Properties.OnModify | Add-CBreezeCodeLine -Line '{0} := TODAY;' -ArgumentList $Result.Fields.LastDateModified.QuotedName
        $Table.Properties.OnRename | Add-CBreezeCodeLine -Line '{0} := TODAY;' -ArgumentList $Result.Fields.LastDateModified.QuotedName

        foreach ($Page in $Pages)
        {
            switch ($Page.Properties.PageType)
            {
                ([UncommonSense.CBreeze.Core.PageType]::Card) 
                {
                    $Group = $Page | Get-CBreezePageControlGroup -GroupCaption $GroupCaption -Range $Range -Position $GroupPosition
                    $Result.Controls.LastDateModified.Add($Page, ($Group | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.LastDateModified.QuotedName -PassThru -Range $Range))
                }

                ([UncommonSense.CBreeze.Core.PageType]::List) 
                {
                    $Repeater = $Page | Get-CBreezePageControlGroup -GroupType Repeater -Position FirstWithinContainer -Range $Range
                    $Result.Controls.LastDateModified.Add($Page, ($Repeater | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.LastDateModified.QuotedName -PassThru -Range $Range -Visible $false))
                }
            }
        }

        if ($PassThru)
        {
            $Result
        }
    }
}