<#
.Synopsis
   Adds a document entity type to a C/Breeze application
#>
function Add-CBreezeDocumentEntityType
{
    Param
    (
        [Parameter(Mandatory, ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Application]$Application,

        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]]$Range,

        [Parameter(Mandatory)]
        [string]$BaseName,

        [string]$HeaderName,

        [string]$LineName,

        [DateTime]$DateTime,

        [bool]$Modified,

        [string]$VersionList,

        [string[]]$DocumentTypes,

        [Switch]$HasPostingDate,

        [Switch]$HasStatisticsPage,

        [Parameter(Mandatory)]
        [UncommonSense.CBreeze.Core.Table]$SetupTable,

        [UncommonSense.CBreeze.Core.Page]$SetupPage,

        [Switch]$PassThru
    )

    Process
    {
        if (-not $HeaderName)
        {
            $HeaderName = "$BaseName Header"
        }

        if (-not $LineName)
        {
            $LineName = "$BaseName Line"
        }

        $Result = @{}
        $Result.Header = @{}
        $Result.Line = @{}

        $Result.Header.Table = $Application | Add-CBreezeObject -Type Table -Name $HeaderName -AutoCaption -Range $Range -PassThru -DateTime $DateTime -Modified $Modified -VersionList $VersionList
        $Result.Line.Table = $Application | Add-CBreezeObject -Type Table -Name $LineName -AutoCaption -Range $Range -PassThru -DateTime $DateTime -Modified $Modified -VersionList $VersionList

        $Result.Header.Fields = @{}
        $Result.Header.Controls = @{}

        $Result.Line.Fields = @{}
        $Result.Line.Controls = @{}
        
        $Result.Header.DocumentPages = @{}
        $Result.Header.ListPages = @{}

        if ($DocumentTypes)
        {
            foreach ($DocumentType in $DocumentTypes)
            {
                $Result.Header.DocumentPages.Add($DocumentType, ($Application | Add-CBreezeObject -Type Page -Name "$BaseName $DocumentType" -AutoCaption -PageType Document -SourceTable $Result.Header.Table.ID -Range $Range -PassThru))
                $Result.Header.ListPages.Add($DocumentType, ($Application | Add-CBreezeObject -Type Page -Name "$BaseName $DocumentType List" -AutoCaption -PageType List -SourceTable $Result.Header.Table.ID -Range $Range -PassThru))
            }
        }
        else
        {
            $Result.Header.DocumentPages.Add($BaseName, ($Application | Add-CBreezeObject -Type Page -Name $BaseName -AutoCaption -PageType Document -SourceTable $Result.Header.Table.ID -Range $Range -PassThru))
            $Result.Header.ListPages.Add($BaseName, ($Application | Add-CBreezeObject -Type Page -Name "$BaseName List" -AutoCaption -PageType List -SourceTable $Result.Header.Table.ID -Range $Range -PassThru))
        }

        # Optionally apply Posting Date micro-pattern
        if ($HasPostingDate)
        {
            $PostingDateResult = $Result.Header.Table | Add-CBreezePostingDate -Pages ($Result.Header.DocumentPages.Values + $Result.Header.ListPages.Values) -Range $Range -PassThru 
            $Result.Header.Fields += $PostingDateResult.Fields
            $Result.Header.Controls += $PostingDateResult.Controls
        }
        else
        {
            $Result.Header.Fields.PostingDate = $null
        }

        # Apply No. Series micro-pattern
        if ($DocumentTypes)
        {
            $NoSeriesResult = $Result.Header.Table | Add-CBreezeNoSeries -DocumentTypes $DocumentTypes -SetupTable $SetupTable -SetupPage $SetupPage -Pages ($Result.Header.DocumentPages.Values + $Result.Header.ListPages.Values) -Range $Range -PassThru -PostingDateField $Result.Header.Fields.PostingDate
            $Result.Header.Fields += $NoSeriesResult.Fields
            $Result.Header.Controls += $NoSeriesResult.Controls
            $Result.Header.PrimaryKey = $NoSeriesResult.PrimaryKey
        }
        else
        {
            $NoSeriesResult = $Result.Header.Table | Add-CBreezeNoSeries -SetupTable $SetupTable -SetupPage $SetupPage -Pages ($Result.Header.DocumentPages.Values + $Result.Header.ListPages.Values) -Range $Range -PassThru 
            $Result.Header.Fields += $NoSeriesResult.Fields
            $Result.Header.Controls += $NoSeriesResult.Controls
            $Result.Header.PrimaryKey = $NoSeriesResult.PrimaryKey
        }

        # Line table primary key fields
        if ($DocumentTypes)
        {
            $Result.Line.Fields.DocumentType = $Result.Line.Table | Add-CBreezeTableField -Type Option -Name 'Document Type' -PrimaryKeyFieldNoRange -OptionString ($DocumentTypes -join ',') -AutoCaption -AutoOptionCaption -Range $Range -PassThru
            $Result.Line.Fields.DocumentNo = $Result.Line.Table | Add-CBreezeTableField -Type Code -DataLength 20 -Name 'Document No.' -PrimaryKeyFieldNoRange -Range $Range -PassThru
            $Result.Line.Fields.LineNo = $Result.Line.Table | Add-CBreezeTableField -Type Integer -Name 'Line No.' -PrimaryKeyFieldNoRange -Range $Range -PassThru

            $TableRelation = $Result.Line.Fields.DocumentNo | Add-CBreezeTableRelation -TableName $Result.Header.Table.Name -FieldName $NoSeriesResult.Fields.No.Name -PassThru
            $TableRelation | Add-CBreezeFilter -FieldName $NoSeriesResult.Fields.DocumentType.Name -Field $Result.Line.Fields.DocumentType.Name

            $Result.Line.PrimaryKey = $Result.Line.Table | Add-CBreezeTableKey -Fields $Result.Line.Fields.DocumentType.Name, $Result.Line.Fields.DocumentNo.Name, $Result.Line.Fields.LineNo.Name -Clustered $true -PassThru
        }
        else
        {
            $Result.Line.Fields.DocumentNo = $Result.Line.Table | Add-CBreezeTableField -Type Code -DataLength 20 -Name 'Document No.' -PrimaryKeyFieldNoRange -Range $Range -PassThru
            $Result.Line.Fields.LineNo = $Result.Line.Table | Add-CBreezeTableField -Type Integer -Name 'Line No.' -PrimaryKeyFieldNoRange -Range $Range -PassThru

            $TableRelation = $Result.Line.Fields.DocumentNo | Add-CBreezeTableRelation -TableName $Result.Header.Table.Name -FieldName $NoSeriesResult.Fields.No.Name
        }

        if ($PassThru)
        {
            $Result
        }
    }
}