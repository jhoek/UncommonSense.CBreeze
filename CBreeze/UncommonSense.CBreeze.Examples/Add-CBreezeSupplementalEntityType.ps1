#.SYNOPSIS
#Adds a supplemental entity type to a C/Breeze application
function Add-CBreezeSupplementalEntityType
{
    [CmdletBinding()]
    [Alias('SupplementalEntityType')]
    Param
    (
        [Parameter(Mandatory)]
        [ValidateRange(1, [int]::MaxValue)]
        [int]$TableID,

        [Parameter(Mandatory)]
        [ValidateRange(1, [int]::MaxValue)]
        [int]$PageID,

        [Parameter(Mandatory)]
        [string]$Name,

        [ValidateNotNullOrEmpty()]
        [string]$PluralName = [UncommonSense.CBreeze.Core.StringExtensionMethods]::MakePlural($Name),

        [DateTime]$DateTime,
        [bool]$Modified,
        [string]$VersionList,

        [string]$TableVariable,
        [string]$PageVariable,
        [string]$CodeFieldVariable,
        [string]$DescriptionFieldVariable
    )

    Process
    {
        New-CBreezeTable `
            -ID $TableID `
            -Name $Name `
            -AutoCaption `
            -LookupPageID $PageID `
            -DrillDownPageID $PageID `
            -DateTime $DateTime `
            -Modified:$Modified `
            -VersionList $VersionList `
            -OutVariable Table

        New-CBreezePage `
            -ID $PageID `
            -Name $PluralName `
            -AutoCaption `
            -SourceTable $TableID `
            -PageType List `
            -DateTime $DateTime `
            -Modified:$Modified `
            -VersionList $VersionList `
            -OutVariable Page

        Set-OutVariable $TableVariable $Table
        Set-OutVariable $PageVariable $Page

        <#
        $CodeResult = $Result.Table | Add-CBreezeCode -Pages $Result.Page -Range $Range -PassThru
        $Result.Fields += $CodeResult.Fields
        $Result.Controls += $CodeResult.Controls

        $DescriptionResult = $Result.Table | Add-CBreezeDescription -Pages $Result.Page -Range $Range -HasDescription2:$false -HasSearchDescription:$false -PassThru
        $Result.Fields += $DescriptionResult.Fields
        $Result.Controls += $DescriptionResult.Controls
        #>
    }
}