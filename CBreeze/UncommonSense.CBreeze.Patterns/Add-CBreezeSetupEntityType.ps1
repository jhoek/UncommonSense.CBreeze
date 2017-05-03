<#
.Synopsis
   Adds a setup entity type to a C/Breeze application
#>
function Add-CBreezeSetupEntityType
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

        [DateTime]$DateTime,

        [bool]$Modified,

        [string]$VersionList,

        [Switch]$PassThru
    )

    Process
    {
        $Result = @{}
        $Result.Table = $Application | Add-CBreezeObject -Type Table -Range $Range -Name $Name -AutoCaption -PassThru -DateTime $DateTime -Modified $Modified -VersionList $VersionList
        $Result.Page = $Application | Add-CBreezeObject -Type Page -Range $Range -Name $Name -AutoCaption -PassThru -PageType Card -InsertAllowed $false -DeleteAllowed $false -SourceTable $Result.Table.ID -DateTime $DateTime -Modified $Modified -VersionList $VersionList
        $Result.Fields = @{}

        $PrimaryKeyResult = $Result.Table | Add-CBreezePrimaryKey -Range $Range -PassThru
        $Result.Fields += $PrimaryKeyResult.Fields
        $Result.PrimaryKey = $PrimaryKeyResult.PrimaryKey

        $Result.Page.Properties.OnOpenPage | Add-CBreezeCodeLine 'RESET;'
        $Result.Page.Properties.OnOpenPage | Add-CBreezeCodeLine 'IF NOT GET THEN BEGIN'
        $Result.Page.Properties.OnOpenPage | Add-CBreezeCodeLine '  INIT;'
        $Result.Page.Properties.OnOpenPage | Add-CBreezeCodeLine '  INSERT;'
        $Result.Page.Properties.OnOpenPage | Add-CBreezeCodeLine 'END;'

        if ($PassThru)
        {
            $Result
        }
    }
}