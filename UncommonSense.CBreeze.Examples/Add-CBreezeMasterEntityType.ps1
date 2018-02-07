<#
.Synopsis
   Adds a master entity type to a C/Breeze application
#>
function Add-CBreezeMasterEntityType
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

        [Switch]$HasLastDateModified = $true,

        [Switch]$HasDateFilter,

        [Switch]$HasGlobalDimensionFilters,

        [Switch]$HasStatisticsPage = $true,

        [UncommonSense.CBreeze.Core.Table]$SetupTable,

        [UncommonSense.CBreeze.Core.Page]$SetupPage,

        [ValidateSet('Name','Description')]
        [string]$DescriptionStyle = 'Name',

        [Switch]$PassThru
    )

    Process
    {
        $Result = @{}
        $Result.MasterEntityType = @{}
        $Result.MasterEntityType.Fields = @{}
        $Result.MasterEntityType.Controls = @{}

        $Result.MasterEntityType.Table = $Application | Add-CBreezeObject -Type Table -Name $Name -DateTime $DateTime -Modified $Modified -VersionList $VersionList -AutoCaption -Range $Range -PassThru
        $Result.MasterEntityType.CardPage = $Application | Add-CBreezeObject -Type Page -Name "$Name Card" -AutoCaption -DateTime $DateTime -Modified $Modified -VersionList $VersionList -PageType Card -SourceTable $Result.MasterEntityType.Table.ID -RefreshOnActivate $true -Range $Range -PassThru
        $Result.MasterEntityType.ListPage = $Application | Add-CBreezeObject -Type Page -Name "$Name List" -AutoCaption -DateTime $DateTime -Modified $Modified -VersionList $VersionList -PageType List -SourceTable $Result.MasterEntityType.Table.ID -CardPageID $Result.MasterEntityType.CardPage.ID -Editable $false -Range $Range -PassThru
        
        if ($HasStatisticsPage)
        {
            $Result.MasterEntityType.StatisticsPage = $Application | Add-CBreezeObject -Type Page -Name "$Name Statistics" -AutoCaption -DateTime $DateTime -Modified $Modified -VersionList $VersionList -PageType Card -SourceTable $Result.MasterEntityType.Table.ID -Range $Range -PassThru
        }

        $Result.MasterEntityType.Table.Properties.LookupPageID = $Result.MasterEntityType.ListPage.ID
        $Result.MasterEntityType.Table.Properties.DrillDownPageID = $Result.MasterEntityType.ListPage.ID

        # Apply No. Series micro-pattern
        $NoSeriesResult = $Result.MasterEntityType.Table | Add-CBreezeNoSeries -SetupTable $SetupTable -SetupPage $SetupPage -Pages $Result.MasterEntityType.CardPage,$Result.MasterEntityType.ListPage -Range $Range -PassThru
        $Result.MasterEntityType.Fields += $NoSeriesResult.Fields
        $Result.MasterEntityType.Controls += $NoSeriesResult.Controls

        # Apply Description micro-pattern
        $DescriptionResult = $Result.MasterEntityType.Table | Add-CBreezeDescription -Pages $Result.MasterEntityType.CardPage, $Result.MasterEntityType.ListPage -DescriptionStyle $DescriptionStyle -Range $Range -PassThru
        $Result.MasterEntityType.Fields += $DescriptionResult.Fields
        $Result.MasterEntityType.Controls += $DescriptionResult.Controls

        # Apply Last Date Modified micro-pattern
        if ($HasLastDateModified)
        {
            $LastDateModifiedResult = $Result.MasterEntityType.Table | Add-CBreezeLastDateModified -Pages $Result.MasterEntityType.CardPage, $Result.MasterEntityType.ListPage -Range $Range -PassThru
            $Result.MasterEntityType.Fields += $LastDateModifiedResult.Fields
            $Result.MasterEntityType.Controls += $LastDateModifiedResult.Controls
        }

        # Apply Date Filter micro-pattern
        if ($HasDateFilter)
        {
            $DateFilterResult = $Result.MasterEntityType.Table | Add-CBreezeDateFilter -Range $Range -PassThru
            $Result.MasterEntityType.Fields += $DateFilterResult.Fields
            $Result.MasterEntityType.Controls += $DateFilterResult.Controls
        }

        # Apply Global Dimension Filters micro-pattern
        if ($HasGlobalDimensionFilters)
        {
            $GlobalDimensionFilterResult = $Result.MasterEntityType.Table | Add-CBreezeGlobalDimensionFilter -Range $Range -PassThru
            $Result.MasterEntityType.Fields += $GlobalDimensionFilterResult.Fields
            $Result.MasterEntityType.Controls += $GlobalDimensionFilterResult.Controls
        }

        # Set DataCaptionFields
        $Result.MasterEntityType.Table.Properties.DataCaptionFields.AddRange($Result.MasterEntityType.Fields.No.Name, $Result.MasterEntityType.Fields.Description.Name)

        # Create DropDown table field group
        $Result.MasterEntityType.Table | Add-CBreezeTableFieldGroup -FieldNames $Result.MasterEntityType.Fields.No.Name, $Result.MasterEntityType.Fields.Description.Name

        # Add parts to card page
        $FactBoxArea = $Result.MasterEntityType.CardPage | Get-CBreezePageControlContainer -Type FactBoxArea -Range $Range 
        $FactBoxArea | Add-CBreezePageControl -Type Part -SystemPartID RecordLinks -Position LastWithinContainer -Visible $false -Range $Range 
        $FactBoxArea | Add-CBreezePageControl -Type Part -SystemPartID Notes -Position LastWithinContainer -Visible $false -Range $Range

        foreach($Page in $Result.MasterEntityType.CardPage, $Result.MasterEntityType.ListPage)
        {
            $RoutingChoices = $Page | Get-CBreezePageActionGroup -ContainerType RelatedInformation -Caption History -Position FirstWithinContainer -Range $Range
            
            if ($HasStatisticsPage)
            {
                $Action = `
                    $RoutingChoices | `
                        Add-CBreezePageAction `
                            -Type Action `
                            -Caption Statistics `
                            -Image ([UncommonSense.CBreeze.Core.RunTime+Images]::Statistics) `
                            -ShortcutKey F7 `
                            -Promoted $true `
                            -PromotedIsBig $false `
                            -PromotedCategory Process `
                            -RunObjectType Page `
                            -RunObjectID $Result.MasterEntityType.StatisticsPage.ID `
                            -PassThru `
                            -Range $Range 
                Add-CBreezeLink -InputObject $Action.Properties.RunPageLink -FieldName $Result.MasterEntityType.Fields.No.Name -Field -Value $Result.MasterEntityType.Fields.No.Name

                if ($HasDateFilter)
                {
                    Add-CBreezeLink -InputObject $Action.Properties.RunPageLink -FieldName $Result.MasterEntityType.Fields.DateFilter.Name -Field -Value $Result.MasterEntityType.Fields.DateFilter.Name
                }

                if ($HasGlobalDimensionFilters)
                {
                    Add-CBreezeLink -InputObject $Action.Properties.RunPageLink -FieldName $Result.MasterEntityType.Fields.GlobalDimension1Filter.Name -Field -Value $Result.MasterEntityType.Fields.GlobalDimension1Filter.Name
                    Add-CBreezeLink -InputObject $Action.Properties.RunPageLink -FieldName $Result.MasterEntityType.Fields.GlobalDimension2Filter.Name -Field -Value $Result.MasterEntityType.Fields.GlobalDimension2Filter.Name
                }
            }
        }

        if ($PassThru)
        {
            $Result
        }
    }
}