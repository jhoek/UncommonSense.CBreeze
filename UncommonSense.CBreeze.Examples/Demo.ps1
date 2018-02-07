Clear-Host
Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

Import-Module UncommonSense.CBreeze.Automation -Force -DisableNameChecking
Import-Module UncommonSense.CBreeze.Patterns -Force -DisableNameChecking

$Range = [System.Linq.Enumerable]::Range(50000, 100)
$Application = New-CBreezeApplication 
$SetupResult = $Application | Add-CBreezeSetupEntityType -Name "Item Setup" -Range $Range -PassThru 
$MasterResult = $Application | Add-CBreezeMasterEntityType -Name "Item" -SetupTable $SetupResult.Table -SetupPage $SetupResult.Page -Range $Range -PassThru
$LedgerResult = $Application | Add-CBreezeLedgerEntityType -Name "Item Entry" -Range $Range -MasterEntityTypeTable $MasterResult.MasterEntityType.Table -PassThru -HasPostingDate -DocumentTypes Foo,Baz
$MatrixPage = $Application | Add-CBreezeMatrixPage -Range $Range -MainPageName Foo -SubPageName Baz -ColumnSourceTable $MasterResult.MasterEntityType.Table.ID -ColumnSourceCaptionFieldNo 5 -RowSourceTable 50000 -RowSourceFields Huppelduif -RowSourceFieldsEditable -CellDataType Decimal -OnDrillDownStub 
$RegisterResult  =$Application | Add-CBreezeRegisterEntityType -Range $Range -Name FooBaz -LedgerEntryTables $LedgerResult.Table -HasSourceCode -PassThru 

$Application | Export-CBreezeApplication