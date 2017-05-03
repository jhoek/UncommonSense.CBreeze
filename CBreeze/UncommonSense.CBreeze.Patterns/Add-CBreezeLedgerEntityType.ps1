<#
.Synopsis
   Adds a ledger entity type to a C/Breeze application
#>
function Add-CBreezeLedgerEntityType
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory,ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Application]$Application,

        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]]$Range,

        [Parameter()]
        [UncommonSense.CBreeze.Core.Table]$MasterEntityTypeTable,

        [Parameter(Mandatory)]
        [string]$Name,

        [string]$PluralName,

        [DateTime]$DateTime,

        [bool]$Modified,

        [string]$VersionList,

        [Switch]$HasPostingDate,

        [string[]]$DocumentTypes,

        [Switch]$HasDescription = $true,

        [Switch]$PassThru        
    )

    Process    
    {
        if (-not $PluralName)
        {
            $PluralName = [UncommonSense.CBreeze.Core.StringExtensionMethods]::MakePlural($Name)
        }

        $Result = @{}
        $Result.Fields = @{}
        $Result.Controls = @{}

        $Result.Table = $Application | Add-CBreezeObject -Type Table -Name $Name -Range $Range -AutoCaption -PassThru -DateTime $DateTime -Modified $Modified -VersionList $VersionList
        $Result.ListPage = $Application | Add-CBreezeObject -Type Page -Name $PluralName -Range $Range -AutoCaption -PassThru -DateTime $DateTime -Modified $Modified -VersionList $VersionList -SourceTable $Result.Table.ID -PageType List -Editable $false

        $Result.Table.Properties.LookupPageID = $Result.ListPage.ID
        $Result.Table.Properties.DrillDownPageID = $Result.ListPage.ID

        $Repeater = $Result.ListPage | Get-CBreezePageControlGroup -Range $Range -GroupType Repeater -Position FirstWithinContainer
        $FieldGroupFields = New-Object System.Collections.ArrayList

        $EntryNoResult = $Result.Table | Add-CBreezeEntryNo -Pages $Result.ListPage -Range $Range -PassThru
        $Result.Fields += $EntryNoResult.Fields
        $Result.Controls += $EntryNoResult.Controls
        $Result.PrimaryKey = $EntryNoResult.PrimaryKey

        $FieldGroupFields.Add($Result.Fields.EntryNo.QuotedName) | Out-Null

        if ($MasterEntityTypeTable)
        {
            $Result.Fields.MasterEntityType = $Result.Table | Add-CBreezeTableField -Type Code -DataLength 20 -Range $Range -Name "$($MasterEntityTypeTable.Name) No." -AutoCaption -PassThru 
            $Result.Fields.MasterEntityType | Add-CBreezeTableRelation -TableName $MasterEntityTypeTable.Name
            $FieldGroupFields.Add($Result.Fields.MasterEntityType.QuotedName) | Out-Null

            $Result.Controls.MasterEntityType = @{}
            $Result.Controls.MasterEntityType.Add($Result.ListPage, ($Repeater | Add-CBreezePageControl -Type Field -Range $Range -PassThru -SourceExpr $Result.Fields.MasterEntityType.QuotedName))
        }

        if ($HasPostingDate)
        {
            $PostingDateResult = $Result.Table | Add-CBreezePostingDate -Pages $Result.ListPage -Range $Range -PassThru
            $Result.Fields += $PostingDateResult.Fields
            $Result.Controls += $PostingDateResult.Controls
        }

        if ($DocumentTypes)
        {
            $Result.Fields.DocumentType = $Result.Table | Add-CBreezeTableField -Type Option -Range $Range -PassThru -Name "Document Type" -AutoCaption -OptionString ($DocumentTypes -join ',') -AutoOptionCaption
            $FieldGroupFields.Add($Result.Fields.DocumentType.QuotedName) | Out-Null
            $Result.Controls.DocumentType = @{}
            $Result.Controls.DocumentType.Add($Result.ListPage, ($Repeater | Add-CBreezePageControl -Type Field -Range $Range -PassThru -SourceExpr $Result.Fields.DocumentType.QuotedName))
            
            $Result.Fields.DocumentNo = $Result.Table | Add-CBreezeTableField -Type Code -DataLength 20 -Range $Range -PassThru -Name "Document No." -AutoCaption 
            $FieldGroupFields.Add($Result.Fields.DocumentNo.QuotedName) | Out-Null
            $Result.Controls.DocumentNo = @{}
            $Result.Controls.DocumentNo.Add($Result.ListPage, ($Repeater | Add-CBreezePageControl -Type Field -Range $Range -PassThru -SourceExpr $Result.Fields.DocumentNo.QuotedName))
        }

        if ($HasDescription)
        {
            $DescriptionResult = $Result.Table | Add-CBreezeDescription -Pages $Result.ListPage -HasDescription2:$false -HasSearchDescription:$false -Range $Range -PassThru
            $Result.Fields += $DescriptionResult.Fields
            $Result.Controls += $DescriptionResult.Controls
            $FieldGroupFields.Add($DescriptionResult.Fields.Description.QuotedName) | Out-Null
        }

        $Result.Table | Add-CBreezeTableFieldGroup -FieldNames $FieldGroupFields

        if ($HasPostingDate -and $DocumentTypes)
        {
            $ActionItems = $Result.ListPage | Get-CBreezePageActionContainer -Type ActionItems -Range $Range
            $NavigateAction = $ActionItems | Add-CBreezePageAction -Type Action -Image ([UncommonSense.CBreeze.Core.RunTime+Images]::Navigate) -Promoted $true -PromotedCategory Process -Range $Range -PassThru -Caption '&Navigate'
            $Variable = $NavigateAction.Properties.OnAction | Add-CBreezeVariable -Type Page -Name Navigate -SubType ([UncommonSense.CBreeze.Core.BaseApp+PageIDs]::Navigate) -Range $Range -PassThru
            $NavigateAction.Properties.OnAction | Add-CBreezeCodeLine -Line '{0}.SetDoc({1},{2});' -ArgumentList $Variable.Name, $Result.Fields.PostingDate.QuotedName, $Result.Fields.DocumentNo.QuotedName
            $NavigateAction.Properties.OnAction | Add-CBreezeCodeLine -Line '{0}.RUN;' -ArgumentList $Variable.Name
        }

        if ($PassThru)
        {
            $Result
        }
    }
}