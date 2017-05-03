<#
.Synopsis
   Add a date filter to a C/Breeze application
#>
function Add-CBreezeDateFilter
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory,ValueFromPipeLine)]
        [UncommonSense.CBreeze.Core.Table]$Table,

        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]]$Range,

        [Switch]$PassThru
    )

    Process
    {
        $Result = @{}
        $Result.Fields = @{}
        $Result.Controls = @{}

        $Result.Fields.DateFilter = $Table | Add-CBreezeTableField -Type Date -FieldClass FlowFilter -Name 'Date Filter' -PassThru -AutoCaption -Range $Range

        if ($PassThru)
        {
            $Result
        }
    }
}