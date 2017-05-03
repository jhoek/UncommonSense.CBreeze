Get-ChildItem -Path ~\Desktop -Filter *.txt |
Invoke-CBreezeParser `
    -OnBeginFile { Param($FileName) Write-Host $FileName -ForegroundColor Yellow } `
    -OnBeginObject { Param($Type, $ID, $Name) Write-Host "`t$Type $ID $Name" }