$Activity = 'Preparing C/Breeze Automation Demo'
$PSDefaultParameterValues['*CBreeze*:AutoCaption'] = $true
$CompareToolFileName = 'c:\Program Files\Araxis\Araxis Merge\compare.exe'
$OutputFileName = 'c:\users\jhoek\desktop\tab7.generated.txt'
$ReferenceFileName = 'c:\users\jhoek\desktop\tab7.txt'

Write-Progress -Activity $Activity -CurrentOperation 'Exporting reference file'
Import-CBreezeApplication -ServerName '.\NAVDEMO' -Database 'Demo Database NAV (7-0)' -Filter 'Type=Table;ID=7|8' | Export-CBreezeApplication -Path $ReferenceFileName

Write-Progress -Activity $Activity -CurrentOperation 'Building C/Breeze application'
$Application = New-CBreezeApplication
$DateTime = Get-Date -Year 2012 -Month 9 -Day 7 -Hour 12 -Minute 0 -Second 0
$VersionList = 'NAVW17.00'

$Table = $Application | Add-CBreezeTable 7 'Standard Text' -DateTime $DateTime -VersionList $VersionList -LookupPageID 8 
$Table | Add-CBreezeMLValue CaptionML NLD Standaardtekst
$Table | Add-CBreezeVariable -ID 1000 -Record ExtTextHeader -SubType 279 -Verbose
$Table | Add-CBreezeCodeTableField -Name Code -DataLength 20 -NotBlank $true -PassThru | Add-CBreezeMLValue CaptionML NLD Code
$Table | Add-CBreezeTextTableField -Name Description -DataLength 50 -AutoCaption -PassThru | Add-CBreezeMLValue CaptionML NLD Omschrijving
$Table | Add-CBreezeTableKey -Fields Code -Clustered $true
$Table.Properties.OnDelete | Add-CBreezeCodeLine 'ExtTextHeader.SETRANGE("Table Name",ExtTextHeader."Table Name"::"Standard Text");'
$Table.Properties.OnDelete | Add-CBreezeCodeLine 'ExtTextHeader.SETRANGE("No.",Code);'
$Table.Properties.OnDelete | Add-CBreezeCodeLine 'ExtTextHeader.DELETEALL(TRUE);'

$Table = $Application | Add-CBreezeTable 8 Language -DateTime $DateTime -VersionList $VersionList -LookupPageID 9 
$Table | Add-CBreezeMLValue CaptionML NLD Taal
$Table | Add-CBreezeCodeTableField -Name Code -NotBlank $true -PassThru | Add-CBreezeMLValue CaptionML NLD Code
$Table | Add-CBreezeTextTableField -Name Name -DataLength 50 -PassThru | Add-CBreezeMLValue CaptionML NLD Naam
$Function = $Table | Add-CBreezeFunction -Name GetUserLanguage -ReturnValueType Code -PassThru
$Function | Add-CBreezeCodeLine 'CLEAR(Rec);'
$Function | Add-CBreezeCodeLine 'SETRANGE("Windows Language ID",GLOBALLANGUAGE);'
$Function | Add-CBreezeCodeLine 'IF FINDFIRST THEN;'
$Function | Add-CBreezeCodeLine 'SETRANGE("Windows Language ID");'
$Function | Add-CBreezeCodeLine 'EXIT(Code);'




$Function = $Table | Add-CBreezeFunction -Name GetLanguageID -ReturnValueType Integer -PassThru

Write-Progress -Activity $Activity -CurrentOperation 'Exporting C/Breeze application'
$Application | Export-CBreezeApplication -Path $OutputFileName

Write-Progress -Activity $Activity -CurrentOperation 'Starting compare tool'
& $CompareToolFileName $ReferenceFileName $OutputFileName