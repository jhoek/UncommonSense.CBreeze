<#
.Synopsis
   Adds a register entity type to a C/Breeze application
#>
function Add-CBreezeRegisterEntityType
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

        [Parameter()]
        [UncommonSense.CBreeze.Core.Table[]]$LedgerEntryTables,

        [Switch]$HasCreationDate = $true,

        [Switch]$HasSourceCode = $true,

        [Switch]$HasUserID = $true,

        [Switch]$HasJournalBatchName = $true,

        [DateTime]$DateTime,

        [bool]$Modified,

        [string]$VersionList,

        [Switch]$PassThru        
    )

    Process
    {
        $Result = @{}
        $Result.Fields = @{}
        $Result.Fields.FromEntryNo = @{}
        $Result.Fields.ToEntryNo = @{}
        $Result.Controls = @{}
        $Result.Controls.FromEntryNo = @{}
        $Result.Controls.ToEntryNo = @{}
        $Result.Controls.JournalBatchNameControl = @{}

        $Result.Table = $Application | Add-CBreezeObject -Type Table -Name $Name -Range $Range -AutoCaption -PassThru -DateTime $DateTime -Modified $Modified -VersionList $VersionList
        $Result.Page = $Application | Add-CBreezeObject -Type Page -Name $Name -Range $Range -AutoCaption -PassThru -PageType List -Editable $false -SourceTable $Result.Table.ID -DateTime $DateTime -Modified $Modified -VersionList $VersionList

        $Result.Table.Properties.LookupPageID = $Result.Page.ID
        $Result.Table.Properties.DrillDownPageID = $Result.Page.ID        

        $NoResult = $Result.Table | Add-CBreezeNo -Pages $Result.Page -Range $Range -PassThru
        $Result.Fields += $NoResult.Fields
        $Result.Controls += $NoResult.Controls
        $Result.PrimaryKey = $NoResult.PrimaryKey

        $Repeater = $Result.Page | Get-CBreezePageControlGroup -GroupType Repeater -Range $Range -Position FirstWithinContainer

        foreach($LedgerEntryTable in $LedgerEntryTables)
        {
            $Result.Fields.FromEntryNo.Add($LedgerEntryTable,  ($Result.Table | Add-CBreezeTableField -Type Integer -Range $Range -Name "From $($LedgerEntryTable.Name) No." -AutoCaption -PassThru -TestTableRelation $false))
            $Result.Fields.FromEntryNo[$LedgerEntryTable] | Add-CBreezeTableRelation -TableName $LedgerEntryTable.Name

            $Result.Fields.ToEntryNo.Add($LedgerEntryTable, ($Result.Table | Add-CBreezeTableField -Type Integer -Range $Range -Name "To $($LedgerEntryTable.Name) No." -AutoCaption -PassThru -TestTableRelation $false))
            $Result.Fields.ToEntryNo[$LedgerEntryTable] | Add-CBreezeTableRelation -TableName $LedgerEntryTable.Name

            $Result.Controls.FromEntryNo.Add($LedgerEntryTable, ($Repeater | Add-CBreezePageControl -Type Field -Range $Range  -PassThru -SourceExpr $Result.Fields.FromEntryNo[$LedgerEntryTable].QuotedName))
            $Result.Controls.ToEntryNo.Add($LedgerEntryTable, ($Repeater | Add-CBreezePageControl -Type Field -Range $Range -PassThru -SourceExpr $Result.Fields.ToEntryNo[$LedgerEntryTable].QuotedName))
        }

        if ($HasCreationDate)
        {
            $CreationDateResult = $Result.Table | Add-CBreezeCreationDate -Pages $Result.Page -Range $Range -CreateKey -PassThru
            $Result.Fields += $CreationDateResult.Fields
            $Result.Controls += $CreationDateResult.Controls
            $Result.Keys = @($CreationDateResult.Key)
        }

        if ($HasSourceCode)
        {
            $SourceCodeResult = $Result.Table | Add-CBreezeSourceCode -Pages $Result.Page -Range $Range -PassThru
            $Result.Fields += $SourceCodeResult.Fields
            $Result.Controls += $SourceCodeResult.Controls
        }

        if ($HasUserID)
        {
            $UserIDResult = $Result.Table | Add-CBreezeUserID -Pages $Result.Page -Range $Range -PassThru
            $Result.Fields += $UserIDResult.Fields
            $Result.Controls += $UserIDResult.Controls
        }

        if ($HasJournalBatchName)
        {
            $Result.Fields.JournalBatchName = $Result.Table | Add-CBreezeTableField -Type Code -DataLength 10 -Name 'Journal Batch Name' -AutoCaption -Range $Range -PassThru
            $Result.Controls.JournalBatchNameControl.Add($Result.Page, ($Repeater | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.JournalBatchName.QuotedName -Range $Range -PassThru))
        }

        $Group = $Result.Page | Get-CBreezePageActionGroup -ContainerType RelatedInformation -Caption '&Register' -Position FirstWithinContainer -Range $Range 

        foreach($LedgerEntryTable in $LedgerEntryTables)
        {
            $Action = $Group | Add-CBreezePageAction -Type Action -Caption (ActionCaptionFromLedgerTableName($LedgerEntryTable.Name)) -Image ([UncommonSense.CBreeze.Core.RunTime+Images]::GLRegisters) -Promoted $true -PromotedCategory Process -PromotedIsBig $true -Range $Range -PassThru 
            $Action.Properties.OnAction | Add-CBreezeCodeLine '// TODO: Add action code here'
        }

        if ($PassThru)
        {
            $Result
        }
    }
}

function ActionCaptionFromLedgerTableName([string] $LedgerTableName)
{
    $Result = $LedgerTableName

    $Result = $Result -replace '\bG/L\b', 'General Ledger'  # e.g. G/L Entry -> General Ledger Entry
    $Result = $Result -replace '\bLedger Entry$', 'Ledger'  # e.g. General Ledger Entry -> General Ledger
    $Result = $Result -replace '\bEntry$', 'Entries'        # e.g. VAT Entry -> VAT Entries

    $Result
}