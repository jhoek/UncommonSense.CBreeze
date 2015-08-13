$Application = New-CBreezeApplication

$Table = $Application | Add-CBreezeTable -ID 50000 -Name 'My Test Table' -VersionList NAVJH1.00 -AutoCaption -PassThru
$Table | Add-CBreezeCodeTableField -Name 'Primary Key' -DataLength 20 -NotBlank $true -AutoCaption

$Application | Export-CBreezeApplication -ServerName '.\NAVDEMO' -Database 'Demo Database NAV (7-0)'