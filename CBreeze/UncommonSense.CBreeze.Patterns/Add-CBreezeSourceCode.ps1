<#
.Synopsis
   Adds a source code field to a C/Breeze application
#>
function Add-CBreezeSourceCode
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory,ValueFromPipeLine)]
        [UncommonSense.CBreeze.Core.Table]$Table,

        [Parameter()]
        [UncommonSense.CBreeze.Core.Page[]]$Pages,

        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]]$Range,

        [Switch]$PassThru
    )

    Process
    {
        $Result = @{}
        $Result.Fields = @{}
        $Result.Controls = @{}
        $Result.Controls.SourceCode = @{}

        $Result.Fields.SourceCode = $Table | Add-CBreezeTableField -Type Code -Name 'Source Code' -DataLength 10 -PassThru -Range $Range -AutoCaption
        $Result.Fields.SourceCode | Add-CBreezeTableRelation -TableName ([UncommonSense.CBreeze.Core.Baseapp+TableNames]::Source_Code) 

        foreach($Page in $Pages | Where-Object { $_.Properties.PageType -eq 'List'} )
        {
            $Repeater = $Page | Get-CBreezePageControlGroup -GroupType Repeater -Position FirstWithinContainer -Range $Range
            $Result.Controls.SourceCode.Add($Page, ($Repeater | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.SourceCode.QuotedName -PassThru -Range $Range -Position LastWithinContainer))
        }

        if ($PassThru)
        {
            $Result
        }
    }
}