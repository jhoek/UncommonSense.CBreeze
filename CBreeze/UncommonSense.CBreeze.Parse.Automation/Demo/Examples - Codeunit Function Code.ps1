$BeginObject = { Param ($Type, $ID, $Name) if ($Type -eq 'Codeunit') { Write-Host "$Type $ID $Name" -ForegroundColor Yellow; $global:CollectFunctions = $true } } 
$EndObject = { $global:CollectFunctions = $false }
$BeginFunction = { Param ($ID, $Name, $Local) if ($global:CollectFunctions) { Write-Host "`tFunction $ID $Name"; $global:RemainingCodeLines = 5 }}
$EndFunction = { $global:RemainingCodeLines = 0 }
$CodeLine = { Param ($Line) if ($global:RemainingCodeLines -gt 0) { Write-Host "`t`t$Line" -ForegroundColor Gray; $global:RemainingCodeLines-- } } 

$global:CollectFunctions = $false
$global:RemainingCodeLines = 0

Clear-Host
Get-ChildItem -Path ~\Desktop -Filter *.txt |
Invoke-CBreezeParser `
    -OnBeginObject $BeginObject `
    -OnEndObject $EndObject `
    -OnBeginFunction $BeginFunction `
    -OnEndFunction $EndFunction `
    -OnCodeLine $CodeLine