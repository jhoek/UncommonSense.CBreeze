Import-Module C:\Users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Automation\bin\Debug\UncommonSense.CBreeze.Automation.dll

$Application = New-CBreezeApplication
$Table = $Application | Add-CBreezeTable -Name Demo
$Table.Properties.DataCaptionFields.Add(($Table | Add-CBreezeCodeTableField -Name Code -NotBlank $true -PrimaryKeyFieldNoRange -PassThru))
$Table.Properties.DataCaptionFields.Add(($Table | Add-CBreezeTextTableField -Name Description -DataLength 50 -PassThru))

$Table2 = $Application | Add-CBreezeTable -Name 'Demo Translation'

$Application | Export-CBreezeApplication -TextWriter ([Console]::Out)