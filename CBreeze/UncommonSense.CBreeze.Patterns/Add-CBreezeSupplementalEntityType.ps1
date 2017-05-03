<#
.Synopsis
   Adds a supplemental entity type to a C/Breeze application
#>
function Add-CBreezeSupplementalEntityType
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory,ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Application]$Application,

        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]]$Range,

        [Parameter(Mandatory)]
        [string]$Name,

        [string]$PluralName,

        [DateTime]$DateTime,

        [bool]$Modified,

        [string]$VersionList,

        [Switch]$PassThru        
    )

    Process
    {
        if (-not $PluralName)
        {
            $PluralName = [UncommonSense.CBreeze.Core.StringExtensionMethods]::MakePlural($Name)
        }

        $Result = @{}
        $Result.Table = $Application | Add-CBreezeObject -Type Table -Range $Range -Name $Name -AutoCaption -PassThru -DateTime $DateTime -Modified $Modified -VersionList $VersionList
        $Result.Page = $Application | Add-CBreezeObject -Type Page -Range $Range -Name $PluralName -AutoCaption -PassThru -SourceTable $Result.Table.ID -PageType List -DateTime $DateTime -Modified $Modified -VersionList $VersionList
        $Result.Fields = @{}
        $Result.Controls = @{}

        $Result.Table.Properties.LookupPageID = $Result.Page.ID
        $Result.Table.Properties.DrillDownPageID = $Result.Page.ID

        $CodeResult = $Result.Table | Add-CBreezeCode -Pages $Result.Page -Range $Range -PassThru
        $Result.Fields += $CodeResult.Fields
        $Result.Controls += $CodeResult.Controls

        $DescriptionResult = $Result.Table | Add-CBreezeDescription -Pages $Result.Page -Range $Range -HasDescription2:$false -HasSearchDescription:$false -PassThru
        $Result.Fields += $DescriptionResult.Fields
        $Result.Controls += $DescriptionResult.Controls

        if ($PassThru)
        {
            $Result
        }
    }
}