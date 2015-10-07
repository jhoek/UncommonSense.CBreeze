Import-Module C:\Users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Automation\bin\Debug\UncommonSense.CBreeze.Automation.dll

$Application = New-CBreezeApplication

$Table = $Application | Add-CBreezeObject -Type Table -Name Demo -PassThru 
$CodeField = $Table | Add-CBreezeTableField -Type Code -Name Code -NotBlank $true -PrimaryKeyFieldNoRange -PassThru
$DescriptionField = $Table | Add-CBreezeTableField -Type Text -Name Description -DataLength 50 -PassThru
$Table.Properties.DataCaptionFields.AddRange($CodeField.Name, $DescriptionField.Name);

$Page = $Application | Add-CBreezeObject -Type Page -Name Demo -ID 50000 -SourceTable $Table.ID -PageType Card -PassThru

$Application | Export-CBreezeApplication -TextWriter ([Console]::Out)