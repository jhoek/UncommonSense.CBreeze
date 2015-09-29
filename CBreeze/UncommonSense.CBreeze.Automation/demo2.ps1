Import-Module C:\Users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Automation\bin\Debug\UncommonSense.CBreeze.Automation.dll

$Application = New-CBreezeApplication

$Table = $Application | Add-CBreezeTable -Name Demo -PassThru 
$CodeField = $Table | Add-CBreezeCodeTableField -Name Code -NotBlank $true -PrimaryKeyFieldNoRange -PassThru
$DescriptionField = $Table | Add-CBreezeTextTableField -Name Description -DataLength 50 -PassThru
$Table.Properties.DataCaptionFields.AddRange($CodeField.Name, $DescriptionField.Name);

$Page = $Application | Add-CBreezePage -Name Demo -ID 50000 -SourceTable $Table.ID -PageType Card -PassThru
$ContentArea = $Page | Add-CBreezeContainerPageControl -Type ContentArea -PassThru
$Group = $ContentArea | Add-CBreezeGroupPageControl -PassThru


$Application | Export-CBreezeApplication -TextWriter ([Console]::Out)