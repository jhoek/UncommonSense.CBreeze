<#
.SYNOPSIS
   Adds a reason code to a C/Breeze application
#>
function Add-CBreezeReasonCode
{
    [OutputType([UncommonSense.CBreeze.Core.Table])]
    Param
    (
        [Parameter(Mandatory, ValueFromPipeLine)]
        [UncommonSense.CBreeze.Core.Table]$Table,

        [Parameter()]
        [UncommonSense.CBreeze.Core.Page[]]$Pages,

        [ValidateNotNullOrEmpty()]
        [ValidateLength(1, 30)]
        [string]$FieldName = 'Reason Code',

        [string]$ReasonCodeFieldVariable,
        [string]$ReasonCodeControlVariable
    )

    Process
    {
        $ReasonCodeField = $Table | 
            Add-CBreezeCodeTableField `
            -Name $FieldName `
            -AutoCaption `
            -DataLength 10 `
            -PassThru `
            -SubObjects {
            New-CBreezeTableRelation -TableName ([UncommonSense.CBreeze.Core.Baseapp+TableNames]::Reason_Code) 
        }
        
        $ReasonCodeControl = [Ordered]@{}

        foreach ($Page in $Pages)        
        {
            if ($Page.Properties.PageType -eq 'List') 
            {
                $Repeater = $Page | 
                    Get-CBreezePageControlGroup `
                    -GroupType Repeater `
                    -Position FirstWithinContainer

                $ReasonCodeControl.Add(
                    $Page, 
                    ($Repeater | Add-CBreezePageControl -SourceExpr $ReasonCodeField.QuotedName -PassThru -Position LastWithinContainer)
                )
            }
        }

        Set-OutVariable -Name $ReasonCodeFieldVariable -Value $ReasonCodeField
        Set-OutVariable -Name $ReasonCodeControlVariable -Value $ReasonCodeControl

        $Table
    }
}