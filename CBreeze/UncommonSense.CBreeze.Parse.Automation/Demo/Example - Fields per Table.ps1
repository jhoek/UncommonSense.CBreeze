$BeginObject = { Param($Type, $ID, $Name) if ($Type -eq 'Table') { Write-Host "Table $ID $Name" -ForegroundColor Yellow } }
$BeginTableField = { Param($FieldNo, $FieldEnabled, $FieldName, $FieldType, $FieldLength) Write-Host "`tField $FieldNo $FieldName : $FieldType $(if ($FieldLength) { $FieldLength })"; $global:WithinField = $true }
$EndTableField = { $global:WithinField = $false } 
$Property = { Param($Name, $Value) if ($global:WithinField) { Write-Host "`t`t$Name=$Value"} } 

$global:WithinField = $false

Get-ChildItem -Path "~/Desktop" -Filter *.txt | 
Invoke-CBreezeParser `
    -OnBeginObject $BeginObject `
    -OnBeginTableField $BeginTableField `
    -OnEndTableField $EndTableField `
    -OnProperty $Property