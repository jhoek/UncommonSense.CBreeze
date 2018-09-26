﻿using namespace UncommonSense.CBreeze.Core

<#
.SYNOPSIS
   Adds a posting date field to a C/Breeze application
#>
function Add-CBreezePostingDate
{
    [OutputType([Table])]
    Param
    (
        [Parameter(Mandatory, ValueFromPipeline)]
        [Table]$Table,

        [Parameter()]
        [Page[]] $Page,

        [ValidateNotNullOrEmpty()]
        [ValidateLength(1, 30)]
        [string]$FieldName = 'Posting Date',

        [string]$PostingDateFieldVariable,
        [string]$PostingDateControlVariable
    )

    Process
    {
        $PostingDateField = $Table | 
            Add-CBreezeDateTableField `
            -Name $FieldName `
            -AutoCaption `
            -ClosingDates $true `
            -PassThru

        $PostingDateControl = [Ordered]@{}

        foreach ($Item in $Page)
        {
            if ($Item.Properties.PageType -eq 'List')
            {
                $Repeater = $Item | Get-CBreezePageControlGroup -GroupType Repeater -Position FirstWithinContainer
                $PostingDateControl.Add($Item, ($Repeater | Add-CBreezePageControl -SourceExpr $PostingDateField.QuotedName -PassThru))
            }
        }

        Set-OutVariable -Name $PostingDateFieldVariable -Value $PostingDateField
        Set-OutVariable -Name $PostingDateControlVariable -Value $PostingDateControl

        $Table
    }
}