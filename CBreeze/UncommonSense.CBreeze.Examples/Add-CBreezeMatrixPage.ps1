<#
.Synopsis
   Adds a matrix page to a C/Breeze application
#>
function Add-CBreezeMatrixPage
{
    [CmdletBinding()]
    Param
    (
        # Application to which the pages should be added
        [Parameter(Mandatory,ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Application]$Application,
        
        # Range from which IDs should be assigned
        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]]$Range,

        # Name for the main page object
        [Parameter(Mandatory)]
        [string]$MainPageName,

        # Name for the sub page object
        [Parameter(Mandatory)]
        [string]$SubPageName,

        # Date/time object property value for the pages
        [DateTime]$DateTime,

        # Modified object property value for the pages
        [bool]$Modified,

        # Version List object property value for the pages
        [string]$VersionList,

        # ID for the column source table
        [Parameter(Mandatory)]
        [int]$ColumnSourceTable,

        # No. of the field to show in column captions
        [Parameter(Mandatory)]
        [int]$ColumnSourceCaptionFieldNo,

        # ID for the row source table
        [Parameter(Mandatory)]
        [int]$RowSourceTable,

        # Names for row source fields
        [Parameter(Mandatory)]
        [string[]]$RowSourceFields,

        # Make row source fields editable
        [Switch]$RowSourceFieldsEditable,

        # Datatype for matrix cells
        [ValidateSet('Text', 'Integer', 'Decimal')]
        [string]$CellDataType = 'Decimal',

        # Script to set more cell properties
        [ScriptBlock]$CellPostProcessing
    )

    $Result = @{}

    # Create pages
    $Result.MainPage = $Application | Add-CBreezeObject -Type Page -ID $Range -Name $MainPageName -DateTime $DateTime -Modified $Modified -VersionList $VersionList -AutoCaption
    $Result.SubPage = $Application | Add-CBreezeObject -Type Page -ID $Range -Name $SubPageName -PageType ListPart -SourceTable $RowSourceTable -PassThru -DateTime $DateTime -Modified $Modified -VersionList $VersionList -AutoCaption

    # Add main page globals
    $Result.MainPage | Add-CBreezeVariable -Type RecordRef -ID $Range -Name RecRef
    $Result.MainPage | Add-CBreezeVariable -Type Codeunit -ID $Range -Name MatrixMgt -SubType ([UncommonSense.CBreeze.Core.BaseApp+CodeunitIDs]::Matrix_Management)
    $Result.MainPage | Add-CBreezeVariable -Type Text -DataLength 1024 -ID $Range -Name Matrix_ColumnCaptions -Dimensions 32
    $Result.MainPage | Add-CBreezeVariable -Type Text -DataLength 1024 -ID $Range -Name PKFirstRecInCurrSet
    $Result.MainPage | Add-CBreezeVariable -Type Text -DataLength 1024 -ID $Range -Name ColumnSet
    $Result.MainPage | Add-CBreezeVariable -Type Option -ID $Range -Name SetWanted -OptionString 'Initial,Previous,Same,Next,PreviousColumn,NextColumn'
    $Result.MainPage | Add-CBreezeVariable -Type Integer -ID $Range -Name ColumnSetLength
        
    # Add sub page globals
    $Result.SubPage | Add-CBreezeVariable -Type Text -ID $Range -Name Matrix_Caption -Dimensions 32
    $Result.SubPage | Add-CBreezeVariable -Type $CellDataType -ID $Range -Name Matrix_CellData -Dimensions 32
    $Result.SubPage | Add-CBreezeVariable -Type Integer -ID $Range -Name Matrix_ColumnSetLength 

    # Define main page controls
    $Container = $Result.MainPage | Get-CBreezePageControlContainer -Range $Range -Type ContentArea
    $Group = $Result.MainPage | Get-CBreezePageControlGroup -Range $Range -GroupType Group
    $Group | Add-CBreezePageControl -Type Field -ID $Range -SourceExpr ColumnSet -PassThru -Editable $false | Set-CBreezeMLValue -Property CaptionML -LanguageName ENU -Value 'Column Set'
    $Container | Add-CBreezePageControl -Type Part -ID $Range -PagePartID $Result.SubPage.ID -Name MatrixSubPage -AutoCaption:$false

    # Define sub page controls
    $SubPageRepeater = $Result.SubPage | Get-CBreezePageControlGroup -GroupType Repeater -Range $Range

    switch($RowSourceFieldsEditable)
    {
        ($true) { $RowSourceFields | ForEach-Object { $SubPageRepeater | Add-CBreezePageControl -Type Field -ID $Range -SourceExpr $_ } }
        ($false) { $RowSourceFields | ForEach-Object { $SubPageRepeater | Add-CBreezePageControl -Type Field -ID $Range -SourceExpr $_ -Editable $false } }
    }

    1..32 | ForEach-Object { 
        $Cell = $SubPageRepeater | Add-CBreezePageControl -Type Field -ID $Range -SourceExpr "Matrix_CellData[$_]" -Visible "Matrix_Visible_$_" -CaptionClass "'3,'+Matrix_Caption[$_]" -PassThru
        Invoke-Command -ScriptBlock $CellPostProcessing -ArgumentList $Cell
    }

    # Control sub page control visibility
    1..32 | ForEach-Object { $Result.SubPage | Add-CBreezeVariable -Type Boolean -ID $Range -Name "Matrix_Visible_$_" }
    $Result.SubPage.Properties.OnOpenPage | Add-CBreezeCodeLine "ShowHideColumns;"

    # Add main page initialisation
    $Result.MainPage.Properties.OnOpenPage | Add-CBreezeCodeLine "RecRef.OPEN(Database::`"$ColumnSourceTable`");"
    $Result.MainPage.Properties.OnOpenPage | Add-CBreezeCodeLine "SetColumns(SetWanted::Initial);"

    # Add main page functions
    $SetColumns = $Result.MainPage | Add-CBreezeFunction -ID $Range -Name SetColumns -PassThru
    $SetColumns | Add-CBreezeParameter -Type Option -ID $Range -Name SetWanted 
    $SetColumns | Add-CBreezeCodeLine "MatrixMgt.GenerateMatrixData(RecRef, SetWanted, ARRAYLEN(Matrix_ColumnCaptions), $ColumnSourceCaptionFieldNo, PKFirstRecInCurrSet, Matrix_ColumnCaptions, ColumnSet, ColumnSetLength);"
    $SetColumns | Add-CBreezeCodeLine "CurrPage.MatrixSubPage.PAGE.SetMatrixData(Matrix_ColumnCaptions, RecRef, ColumnSetLength);"
    $SetColumns | Add-CBreezeCodeLine "CurrPage.UPDATE(FALSE);"

    # Add main page actions
    $ActionItems = $Result.MainPage | Get-CBreezePageActionContainer -Range $Range -Type ActionItems
    $PreviousSet = $ActionItems | Add-CBreezePageAction -Type Action -ID $Range -PassThru -Image ([UncommonSense.CBreeze.Core.RunTime+Images]::PreviousSet) -Promoted $true -PromotedCategory Process -PromotedIsBig $true -Caption 'Previous Set'
    $PreviousColumn = $ActionItems | Add-CBreezePageAction -Type Action -ID $Range -PassThru -Image ([UncommonSense.CBreeze.Core.RunTime+Images]::PreviousRecord) -Promoted $true -PromotedCategory Process -PromotedIsBig $true -Caption 'Previous Column'
    $NextColumn = $ActionItems | Add-CBreezePageAction -Type Action -ID $Range -PassThru -Image ([UncommonSense.CBreeze.Core.RunTime+Images]::NextRecord) -Promoted $true -PromotedCategory Process -PromotedIsBig $true -Caption 'Next Column'
    $NextSet = $ActionItems | Add-CBreezePageAction -Type Action -ID $Range -PassThru -Image ([UncommonSense.CBreeze.Core.RunTime+Images]::NextSet) -Promoted $true -PromotedCategory Process -PromotedIsBig $true -Caption 'Next Set'
    $PreviousSet.Properties.OnAction | Add-CBreezeCodeLine "SetColumns(SetWanted::Previous);"
    $PreviousColumn.Properties.OnAction | Add-CBreezeCodeLine "SetColumns(SetWanted::PreviousColumn);"
    $NextColumn.Properties.OnAction | Add-CBreezeCodeLine "SetColumns(SetWanted::NextColumn);"
    $NextSet.Properties.OnAction | Add-CBreezeCodeLine "SetColumns(SetWanted::Next);"

    # Add sub page triggers
    $Result.SubPage.Properties.OnAfterGetRecord | Add-CBreezeVariable -Type Integer -ID $Range -Name i
    $Result.SubPage.Properties.OnAfterGetRecord | Add-CBreezeCodeLine "FOR i := 1 TO Matrix_ColumnSetLength DO"
    $Result.Subpage.Properties.OnAfterGetRecord | Add-CBreezeCodeLine "  Matrix_OnAfterGetRecord(i);"

    # Add sub page functions
    $SetMatrixDataFunction = $Result.SubPage | Add-CBreezeFunction -ID $Range -Name SetMatrixData -PassThru
    $SetMatrixDataFunction | Add-CBreezeParameter -ID $Range -Name ColumnCaptions -Type Text -DataLength 1024 -Dimensions 32
    $SetMatrixDataFunction | Add-CBreezeParameter -ID $Range -Var -Name MatrixRec -Type RecordRef
    $SetMatrixDataFunction | Add-CBreezeParameter -ID $Range -Name ColumnSetLength -Type Integer
    $SetMatrixDataFunction | Add-CBreezeVariable -ID $Range -Type Integer -Name i
    $SetMatrixDataFunction | Add-CBreezeCodeLine "FOR i := 1 to ARRAYLEN(ColumnCaptions) DO"
    $SetMatrixDataFunction | Add-CBreezeCodeLine "  Matrix_Caption[i] := IIF(ColumnCaptions[i] = '', ' ', ColumnCaptions[i]);"    
    $SetMatrixDataFunction | Add-CBreezeCodeLine "Matrix_ColumnSetLength := ColumnSetLength;"
    $SetMatrixDataFunction | Add-CBreezeCodeLine ''
    $SetMatrixDataFunction | Add-CBreezeCodeLine 'ShowhideColumns();'

    $ShowHideColumnsFunction = $Result.SubPage | Add-CBreezeFunction -ID $Range -Name ShowHideColumns -Local $true -PassThru
    1..32 | ForEach-Object { $ShowHideColumnsFunction | Add-CBreezeCodeLine "Matrix_Visible_$_ := Matrix_ColumnSetLength >= $_;" }

    $MatrixOnAfterGetRecordFunction = $Result.SubPage | Add-CBreezeFunction -ID $Range -Name Matrix_OnAfterGetRecord -Local $true -PassThru
    $MatrixOnAfterGetRecordFunction | Add-CBreezeParameter -Type Integer -ID $Range -Name CurrentColumnNo
    $MatrixOnAfterGetRecordFunction | Add-CBreezeCodeLine "// FIXME: Add code to fill Matrix_CellData[CurrentColumnNo]" 

    $IIfFunction = $Result.SubPage | Add-CBreezeFunction -ID $Range -Name IIf -Local $true -PassThru -ReturnValueType Text -ReturnValueDataLength 1024
    $IIfFunction | Add-CBreezeParameter -ID $Range -Name Condition -Type Boolean
    $IIfFunction | Add-CBreezeParameter -ID $Range -Name ValueIfTrue -Type Text -DataLength 1024
    $IIfFunction | Add-CBreezeParameter -ID $Range -Name ValueIfFalse -Type Text -DataLength 1024
    $IIfFunction | Add-CBreezeCodeLine "IF Condition THEN"
    $IIfFunction | Add-CBreezeCodeLine "  EXIT(ValueIfTrue);"
    $IIfFunction | Add-CBreezeCodeLine "EXIT(ValueIfFalse);"

    $Result
}

<#
Clear-Host
$PSDefaultParameterValues.Clear()
$ErrorActionPreference = 'Stop'
$Range = [System.Linq.Enumerable]::Range(60000, 100)

$Application = New-CBreezeApplication
$Application | Add-CBreezeMatrixPage `
    -Range $Range `
    -MainPageName 'Matrix Main Page' `
    -SubPageName 'Matrix Sub Page' `
    -DateTime (Get-Date -Year 2015 -Month 8 -Day 10 -Hour 12 -Minute 0 -Second 0) `
    -VersionList NAVJH1.00 `
    -ColumnSourceTable ([UncommonSense.CBreeze.Core.BaseApp+TableIDs]::Standard_Text) `
    -ColumnSourceCaptionFieldNo 1 `
    -RowSourceTable ([UncommonSense.CBreeze.Core.BaseApp+TableIDs]::Company) `
    -RowSourceFields Name `
    -CellDataType Text `
    -CellPostProcessing { 
        Param
        (
            $Cell
        ) 
        
        $Cell.Properties.Editable = $false; 
        if ($Cell.ID % 2 -eq 0) { $Cell.Properties.OnValidate | Add-CBreezeCodeLine -Line '// Foo' }
        $Cell.Properties.Width = 6 
        $Cell.Properties.BlankZero = $true
        }

$Application | Export-CBreezeApplication 
#>