$CompareToolFileName = 'c:\Program Files\Araxis\Araxis Merge\compare.exe'
$OutputFileName = 'c:\users\jhoek\desktop\tab7.generated.txt'
$ReferenceFileName = 'c:\users\jhoek\desktop\tab7.txt'

$Application = New-CBreezeApplication

$Table = $Application | Add-CBreezeTable 7 'Standard Text' -DateTime (Get-Date -Year 2012 -Month 9 -Day 7 -Hour 12 -Minute 0 -Second 0) -VersionList NAVW17.00 -LookupPageID 8 -AutoCaption -PassThru 

$Table | Add-CBreezeMLValue CaptionML NLD Standaardtekst
$Table | Add-CBreezeVariable -ID 1000 -Record ExtTextHeader -SubType 279 -Verbose

$Table | Add-CBreezeCodeTableField -Name Code -DataLength 20 -NotBlank $true -AutoCaption -PassThru | Add-CBreezeMLValue CaptionML NLD Code
$Table | Add-CBreezeTextTableField -Name Description -DataLength 50 -AutoCaption -PassThru | Add-CBreezeMLValue CaptionML NLD Omschrijving

$Table | Add-CBreezeTableKey -Fields Code -Clustered $true
$Table.Properties.OnDelete | Add-CBreezeCodeLine 'ExtTextHeader.SETRANGE("Table Name",ExtTextHeader."Table Name"::"Standard Text");'
$Table.Properties.OnDelete | Add-CBreezeCodeLine 'ExtTextHeader.SETRANGE("No.",Code);'
$Table.Properties.OnDelete | Add-CBreezeCodeLine 'ExtTextHeader.DELETEALL(TRUE);'

$Application| Export-CBreezeApplication -Path $OutputFileName
& $CompareToolFileName $ReferenceFileName $OutputFileName