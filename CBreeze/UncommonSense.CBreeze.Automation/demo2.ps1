Import-Module C:\Users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Automation\bin\Debug\UncommonSense.CBreeze.Automation.dll

$Application = New-CBreezeApplication

$Table = $Application | Add-CBreezeTable -Name Demo -PassThru 
$Table | Add-CBreezeCodeTableField -Name Code -NotBlank $true -PrimaryKeyFieldNoRange 
$Table | Add-CBreezeTextTableField -Name Description -DataLength 50
$Table | Add-CBreezeVariable -Record -Name Cust -SubType ([UncommonSense.CBreeze.Core.BaseApp+TableIDs]::Customer) 
$Table | Add-CBreezeVariable -Option -Name MyOption -OptionString 'Foo,Baz'

$Page = $Application | Add-CBreezePage -Name Demo -ID 50000 -SourceTable $Table.ID -PageType Card -PassThru

$Application | Export-CBreezeApplication -TextWriter ([Console]::Out)