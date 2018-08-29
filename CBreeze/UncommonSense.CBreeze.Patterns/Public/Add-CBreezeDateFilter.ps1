using namespace UncommonSense.CBreeze.Core
<#
.Synopsis
   Add a date filter to a C/Breeze application
#>
function Add-CBreezeDateFilter
{
    [OutputType([Table])]
    Param
    (
        [Parameter(Mandatory, ValueFromPipeLine)]
        [Table]$Table,

        [ValidateNotNullOrEmpty()]
        [ValidateLength(1, 30)]
        [string]$Name = 'Date Filter',

        [string]$DateFilterFieldVariable
    )

    Process
    {
        $DateFilterField = $Table | 
            Add-CBreezeDateTableField `
            -Name $Name `
            -AutoCaption `
            -FieldClass FlowFilter `
            -PassThru

        Set-OutVariable -Name $DateFilterFieldVariable -Value $DateFilterField

        $Table
    }
}