using namespace UncommonSense.CBreeze.Core

<#
.SYNOPSIS
   Adds a creation date field to a C/Breeze application
#>
function Add-CBreezeCreationDate
{
    [OutputType([Table])]
    Param
    (
        [Parameter(Mandatory, ValueFromPipeline)]
        [Table]$Table,

        [Parameter()]
        [Page[]]$Page,

        [ValidateNotNullOrEmpty()]
        [ValidateLength(1, 30)]
        [string]$FieldName = 'Creation Date',

        [Switch]$SkipCreateKey,

        [string]$CreationDateFieldVariable,
        [string]$CreationDateKeyVariable,
        [string]$CreationDateControlVariable
    )

    Process
    {
        if (-not $SkipCreateKey)
        {
            Test-CBreezePrimaryKey -Test ShouldHave -ThrowError
        }

        $CreationDateField = $Table | 
            Add-CBreezeDateTableField `
            -Name $FieldName `
            -AutoCaption `
            -PassThru

        if (-not $SkipCreateKey)
        {
            $CreationDateKey = $Table | 
                Add-CBreezeTableKey `
                -Fields $FieldName `
                -PassThru
        }

        $CreationDateControl = [Ordered]@{}

        foreach ($Page in $Pages | Where-Object { $_.Properties.PageType -eq 'List' })
        {
            $Repeater = $Page | Get-CBreezePageControlGroup -GroupType Repeater -Position FirstWithinContainer
            $CreationDateControl.Add($Page, ($Repeater | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.CreationDate.QuotedName -PassThru))
        }

        Set-OutVariable -Name $CreationDateFieldVariable -Value $CreationDateField
        Set-OutVariable -Name $CreationDateKeyVariable -Value $CreationDateKey
        Set-OutVariable -Name $CreationDateControlVariable -Value $CreationDateControl

        $Table
    }
}