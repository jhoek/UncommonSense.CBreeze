#.SYNOPSIS
#Adds a supplemental entity type to a C/Breeze application
function Add-CBreezeSupplementalEntityType
{
    [Alias('SupplementalEntityType')]
    [OutputType([Table])]
    Param
    (
        [Parameter(Mandatory)]
        [ValidateRange(1, [int]::MaxValue)]
        [int]$TableID,

        [Parameter(Mandatory)]
        [ValidateRange(1, [int]::MaxValue)]
        [int]$PageID,

        [Parameter(Mandatory)]
        [ValidateLength(1, 30)]
        [string]$Name,

        [ValidateNotNullOrEmpty()]
        [ValidateLength(1, 30)]
        [string]$PluralName = [UncommonSense.CBreeze.Core.StringExtensionMethods]::MakePlural($Name),

        [DateTime]$DateTime,
        [bool]$Modified,
        [string]$VersionList,

        [string]$TableVariable,
        [string]$PageVariable,
        [string]$PrimaryKeyVariable,
        [string]$CodeFieldVariable,
        [string]$CodeControlVariable,
        [string]$DescriptionFieldVariable,
        [string]$DescriptionControlVariable
    )

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

    $Table | 
        Add-CBreezeCodePrimaryKey `
        -Page $Page `
        -FieldNo 1 `
        -KeyVariable Key `
        -FieldVariable CodeField `
        -ControlVariable CodeControl

    $Table | 
        Add-CBreezeDescription `
        -Page $Page `
        -DescriptionFieldVariable DescriptionField `
        -DescriptionControlVariable DescriptionControl

    Set-OutVariable $TableVariable $Table
    Set-OutVariable $PageVariable $Page
    Set-OutVariable $PrimaryKeyVariable $Key
    Set-OutVariable $CodeFieldVariable $CodeField
    Set-OutVariable $CodeControlVariable $CodeControl
    Set-OutVariable $DescriptionFieldVariable $DescriptionField
    Set-OutVariable $DescriptionControlVariable $DescriptionControl

    $Table
}