<#
.Synopsis
   Adds number series support to a C/Breeze table object
.Description
   Adds a primary key field called "No." to $Table and the pages where $Table is the SourceTable. Also adds a field to $SetupTable and $SetupPage for setting up the no. series. If $DocumentTypes is specified, adds a setup field for each document type. Finally, adds the necessary table and page logic to deal with creating and renaming records with no. series based primary keys.
#>
function Add-CBreezeNoSeries
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory,ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Table]$Table,

        [Parameter(Mandatory)]
        [UncommonSense.CBreeze.Core.Table]$SetupTable,

        [Parameter()]
        [UncommonSense.CBreeze.Core.Page]$SetupPage,

        [Parameter()]
        [UncommonSense.CBreeze.Core.Page[]]$Pages,

        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]]$Range,

        [Parameter()]
        [string[]]$DocumentTypes,

        [UncommonSense.CBreeze.Core.DateTableField]$PostingDateField,

        [Switch]$PassThru
    )

    Process
    {
        if ($DocumentTypes)
        {
            Add-CBreezeNoSeriesWithDocumentTypes @PSBoundParameters
        }
        else
        {
            Add-CBReezeNoSeriesWithoutDocumentTypes @PSBoundParameters
        }
    }
}