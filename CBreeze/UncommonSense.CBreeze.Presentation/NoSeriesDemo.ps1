$ErrorActionPreference = 'Stop'
Clear-Host

$Range = [System.Linq.Enumerable]::Range(50000, 100)
$Application = New-CBreezeApplication

$SetupEntityType = $Application | Add-CBreezeSetupEntityType -Range $Range -Name 'Demo Setup' -PassThru

$Table = $Application | Add-CBreezeObject Table $Range Demo 
$Table2 = $Application | Add-CBreezeObject Table $Range Demo2

$QuotePage = $Application | Add-CBreezeObject Page $Range 'Demo Quote' -PageType Card -SourceTable $Table.ID 
$OrderPage = $Application | Add-CBreezeObject Page $Range 'Demo Order' -PageType Card -SourceTable $Table.ID
$InvoicePage = $Application | Add-CBreezeObject Page $Range 'Demo Invoice' -PageType Card -SourceTable $Table.ID
$ListPage = $application | Add-CBreezeObject Page $Range 'Demo List' -pageType List -SourceTable $TabLE.id -Editable $false

$Demo2CardPage = $Application | Add-CBreezeObject Page $Range 'Demo 2' -PageType Card -SourceTable $Table2.ID
$Demo2ListPage = $Application | Add-CBreezeObject Page $Range 'Demo 2 List' -PageType List -SourceTable $Table2.ID -Editable $false

$QuotePage.Properties.SourceTableView | Add-CBreezeFilter 'Document Type' -Const Quote
$OrderPage.Properties.SourceTableView | Add-CBreezeFilter 'Document Type' -Const Order
$InvoicePage.Properties.SourceTableView | Add-CBreezeFilter 'Document Type' -Const Invoice

$PostingDateResult = $Table | Add-CBreezePostingDate -Pages $QuotePage, $OrderPage, $InvoicePage,$ListPage -Range ([System.Linq.Enumerable]::Range(100, 10)) -PassThru

$Table | Add-CBreezeNoSeries -SetupTable $SetupEntityType.Table -SetupPage $SetupEntityType.Page -Range $Range -DocumentTypes Quote,Order,Invoice -Pages $QuotePage, $OrderPage, $InvoicePage, $ListPage -PostingDateField $PostingDateResult.Fields.PostingDate
$Table2 | Add-CBreezeNoSeries -SetupTable $SetupEntityType.Table -SetupPage $SetupEntityType.Page -Range $Range -Pages $Demo2CardPage, $Demo2ListPage

$Table | Add-CBreezeDescription -Pages $QuotePage, $OrderPage, $InvoicePage -Range $Range
$Table2 | Add-CBreezeDescription -Pages $Demo2CardPage, $Demo2ListPage -Range $Range

export $Application -DevClientPath $cside.v2013 -ServerName .\NAVDEMO -Database 'Demo Database NAV (7-0)' -AutoCompile