# Import-Module ".\UncommonSense.CBreeze.PowerShell.dll" -Verbose

$manifest = New-CBreezeSetupEntityType -TableID 50000 -TableName "Foo Setup" -PageID 50000 -PageName "Foo Setup"
$manifest.Table.Fields.AddCodeTableField(2, "Foo", 50) | Out-Null

$manifest = $manifest.Application | New-CBreezeSetupEntityType -TableID 50001 -TableName "Baz Setup" -PageID 50001 -PageName "Baz Setup" 
$manifest.Application | ConvertTo-NavObjectText 