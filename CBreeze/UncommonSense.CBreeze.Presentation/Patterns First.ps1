#region 
# Stop on first error
$ErrorActionPreference = 'Stop'

# Set default parameter values
$PSDefaultParameterValues["*CBreeze*:AutoCaption"] = $true
$PSDefaultParameterValues["*CBreeze*:Range"] = ([System.Linq.Enumerable]::Range(50000, 100))
$PSDefaultParameterValues["*CBreeze*:DateTime"] = (Get-Date -Year 2015 -Month 8 -Day 10 -Hour 12 -Minute 0 -Second 0)
$PSDefaultParameterValues["*CBreeze*:VersionList"] = "NAVJH1.00"
$PSDefaultParameterValues["*CBreeze*:TextWriter"] = ([System.Console]::Out)

# Set the parameters for connecting to my database
$DevClientPath = 'C:\Program Files (x86)\Microsoft Dynamics NAV\70\RoleTailored Client\finsql.exe'
$RoleTailoredClientPath = 'C:\Program Files (x86)\Microsoft Dynamics NAV\70\RoleTailored Client\Microsoft.Dynamics.Nav.Client.exe'
$ServerName = '.\NAVDEMO'
$Database = 'Demo Database NAV (7-0)'

Clear-Host
#endregion

$Application = New-CBreezeApplication

$SetupEntityType = `
    Add-CBreezeSetupEntityType `
        -Application $Application `
        -Name 'Demo Setup' `
        -PassThru

$MasterEntityType = `
    Add-CBreezeMasterEntityType `
        -Application $Application `
        -Name 'Your Customer' `
        -SetupTable $SetupEntityType.Table `
        -SetupPage $SetupEntityType.Page `
        -PassThru

$Application | `
    Export-CBreezeApplication `
        -DevClientPath $DevClientPath `
        -ServerName $ServerName `
        -Database $Database `
        -AutoCompile

Invoke-CBreezeObject `
    -RoleTailoredClientPath $RoleTailoredClientPath `
    -ServerName localhost `
    -ServerPort 7146 `
    -ServerInstance dynamicsnav70 `
    -CompanyName 'CRONUS Nederland BV' `
    -Object $MasterEntityType.MasterEntityType.CardPage
