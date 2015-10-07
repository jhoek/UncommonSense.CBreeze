$Activity = 'Preparing C/Breeze Automation Demo'
$PSDefaultParameterValues['*CBreeze*:AutoCaption'] = $true
$CompareToolFileName = 'c:\Program Files\Araxis\Araxis Merge\compare.exe'
$OutputFileName = 'c:\users\jhoek\desktop\tab7.generated.txt'
$ReferenceFileName = 'c:\users\jhoek\desktop\tab7.txt'

Clear-Host
Import-Module .\Bin\Debug\UncommonSense.CBreeze.Automation.dll

Write-Progress -Activity $Activity -CurrentOperation 'Exporting reference file'
$Application = Import-CBreezeApplication -ServerName '.\NAVDEMO' -Database 'Demo Database NAV (7-0)' -Filter 'Type=Table;ID=7|8'
Export-CBreezeApplication -Application $Application -Path $ReferenceFileName

Write-Progress -Activity $Activity -CurrentOperation 'Building C/Breeze application'
$Application = New-CBreezeApplication

$DateTime = Get-Date -Year 2012 -Month 9 -Day 7 -Hour 12 -Minute 0 -Second 0
$VersionList = 'NAVW17.00'

$Table = Add-CBreezeObject -Application $application -Type Table -ID 7 -Name 'Standard Text' -DateTime $DateTime -VersionList $VersionList -LookupPageID 8 -PassThru
$Table | Add-CBreezeMLValue -Property CaptionML -LanguageName 1043 -Value Standaardtekst
$Table | Add-CBreezeVariable -ID 1000 -Type Record ExtTextHeader -SubType 279 -Verbose
$Table | Add-CBreezeTableField -Type Code -Name Code -DataLength 20 -NotBlank $true -PassThru | Add-CBreezeMLValue CaptionML NLD Code
$Table | Add-CBreezeTableField -Type Text -Name Description -DataLength 50 -AutoCaption -PassThru | Add-CBreezeMLValue CaptionML NLD Omschrijving
$Table | Add-CBreezeTableKey -Fields Code -Clustered $true
$Table.Properties.OnDelete | Add-CBreezeCodeLine 'ExtTextHeader.SETRANGE("Table Name",ExtTextHeader."Table Name"::"Standard Text");'
$Table.Properties.OnDelete | Add-CBreezeCodeLine 'ExtTextHeader.SETRANGE("No.",Code);'
$Table.Properties.OnDelete | Add-CBreezeCodeLine 'ExtTextHeader.DELETEALL(TRUE);'

$Table = Add-CBreezeObject -Application $Application -Type Table -ID 8 -Name Language -DateTime $DateTime -VersionList $VersionList -LookupPageID 9 -PassThru
$Table | Add-CBreezeMLValue CaptionML NLD Taal
$Table | Add-CBreezeTableField -Type Code -Name Code -NotBlank $true -PassThru | Add-CBreezeMLValue CaptionML NLD Code
$Table | Add-CBreezeTableField -Type Text -Name Name -DataLength 50 -PassThru | Add-CBreezeMLValue CaptionML NLD Naam
$Table | Add-CBreezeTableKey -Fields Code -Clustered $true

$Function = $Table | Add-CBreezeFunction -Name GetUserLanguage -ReturnValueType Code -PassThru
$Function | Add-CBreezeCodeLine 'CLEAR(Rec);'
$Function | Add-CBreezeCodeLine 'SETRANGE("Windows Language ID",GLOBALLANGUAGE);'
$Function | Add-CBreezeCodeLine 'IF FINDFIRST THEN;'
$Function | Add-CBreezeCodeLine 'SETRANGE("Windows Language ID");'
$Function | Add-CBreezeCodeLine 'EXIT(Code);'

$Function = $Table | Add-CBreezeFunction -Name GetLanguageID -ReturnValueType Integer -PassThru
$Function | Add-CBreezeParameter -Type Code -ID 1000 -Name LanguageCode -DataLength 10
$Function | Add-CBreezeCodeLine 'CLEAR(Rec);'
$Function | Add-CBreezeCodeLine 'IF LanguageCode <> '''' THEN'
$Function | Add-CBreezeCodeLine '  IF GET(LanguageCode) THEN'
$Function | Add-CBreezeCodeLine '    EXIT("Windows Language ID");'
$Function | Add-CBreezeCodeLine '"Windows Language ID" := GLOBALLANGUAGE;'
$Function | Add-CBreezeCodeLine 'EXIT("Windows Language ID");'

Write-Progress -Activity $Activity -CurrentOperation 'Exporting C/Breeze application'
Export-CBreezeApplication -Path $OutputFileName -Application $Application

Write-Progress -Activity $Activity -CurrentOperation 'Starting compare tool'
& $CompareToolFileName $ReferenceFileName $OutputFileName