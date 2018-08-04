<#
.Synopsis
   Adds a reason code to a C/Breeze application
#>
function Add-CBreezeReasonCode
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
        $Result.Controls.ReasonCode = @{}

        $Result.Fields.ReasonCode = $Table | Add-CBreezeTableField -Type Code -Name 'Reason Code' -DataLength 10 -PassThru -Range $Range -AutoCaption
        $Result.Fields.ReasonCode | Add-CBreezeTableRelation -TableName ([UncommonSense.CBreeze.Core.Baseapp+TableNames]::Reason_Code) 

        foreach($Page in $Pages | Where-Object { $_.Properties.PageType -eq 'List'} )
        {
            $Repeater = $Page | Get-CBreezePageControlGroup -GroupType Repeater -Position FirstWithinContainer -Range $Range
            $Result.Controls.ReasonCode.Add($Page, ($Repeater | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.ReasonCode.QuotedName -PassThru -Range $Range -Position LastWithinContainer))
        }

        if ($PassThru)
        {
            $Result
        }
    }
}