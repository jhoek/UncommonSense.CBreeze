$Application = New-CBreezeApplication

$Table = $Application | Add-CBreezeTable 50000 'My Test Table' -VersionList NAVJH1.00 -DateTime (Get-Date) -AutoCaption
$Table | Add-CBreezeCodeTableField 'Primary Key' -AutoCaption

$Application | Export-CBreezeApplication -ServerName '.\NAVDEMO' -Database 'Demo Database NAV (7-0)'