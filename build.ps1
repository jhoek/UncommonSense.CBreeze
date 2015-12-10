function Invoke-Build
{
    Param
    (
        [ValidateSet('Core','Parse','Read','Write','Automation', 'IO')]
        [string]$Assembly,

        [ValidateSet('2013', '2013R2', '2015', '2016')]
        [string]$Version,

        [ValidateSet('Core','Parse','Read','Write','Automation', 'IO')]
        [string[]]$Reference,

        [string[]]$ExternalReference,

        [string[]]$Constant
    )

    Write-Host "Building $Assembly $Version..." -ForegroundColor DarkYellow

    cd C:\Users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.$Assembly
    $Out = "C:\Users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.$Assembly\bin\Debug\UncommonSense.CBreeze.$Version.$Assembly.dll"

    $References = if ($Reference) { $Reference | ForEach-Object { "/reference:C:\Users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.$_\bin\Debug\UncommonSense.CBreeze.$Version.$_.dll" } }
    $ExternalReferences = if ($ExternalReference) { $ExternalReference | ForEach-Object { "/reference:$_" } }
    $Constants = if ($Constant) { $Constant | ForEach-Object { "/define:$_" } }

    & C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /nologo /out:$Out /target:library $References $ExternalReferences $Constants *.cs .\Properties\AssemblyInfo.cs 
}

Clear-Host

Invoke-Build -Assembly Core -Version 2013
Invoke-Build -Assembly Core -Version 2013R2 -Constant NAV2013R2
Invoke-Build -Assembly Core -Version 2015 -Constant NAV2013R2,NAV2015
Invoke-Build -Assembly Core -Version 2016 -Constant NAV2013R2,NAV2015,NAV2016

Invoke-Build -Assembly Parse -Version 2013 -Reference Core
Invoke-Build -Assembly Parse -Version 2013R2 -Constant NAV2013R2 -Reference Core
Invoke-Build -Assembly Parse -Version 2015 -Constant NAV2013R2,NAV2015 -Reference Core
Invoke-Build -Assembly Parse -Version 2016 -Constant NAV2013R2,NAV2015,NAV2016 -Reference Core

Invoke-Build -Assembly Read -Version 2013 -Reference Core,Parse
Invoke-Build -Assembly Read -Version 2013R2 -Constant NAV2013R2 -Reference Core,Parse
Invoke-Build -Assembly Read -Version 2015 -Constant NAV2013R2,NAV2015 -Reference Core,Parse
Invoke-Build -Assembly Read -Version 2016 -Constant NAV2013R2,NAV2015,NAV2016 -Reference Core,Parse

Invoke-Build -Assembly Write -Version 2013 -Reference Core
Invoke-Build -Assembly Write -Version 2013R2 -Constant NAV2013R2 -Reference Core
Invoke-Build -Assembly Write -Version 2015 -Constant NAV2013R2,NAV2015 -Reference Core
Invoke-Build -Assembly Write -Version 2016 -Constant NAV2013R2,NAV2015,NAV2016 -Reference Core

Invoke-Build -Assembly IO -Version 2013 -Reference Core,Read,Write,Parse
Invoke-Build -Assembly IO -Version 2013R2 -Constant NAV2013R2 -Reference Core,Read,Write,Parse
Invoke-Build -Assembly IO -Version 2015 -Constant NAV2013R2,NAV2015 -Reference Core,Read,Write,Parse
Invoke-Build -Assembly IO -Version 2016 -Constant NAV2013R2,NAV2015,NAV2016 -Reference Core,Read,Write,Parse

Invoke-Build -Assembly Automation -Version 2013 -Reference Core,Write,IO,Read,Parse -ExternalReference (SystemManagementAutomation)
Invoke-Build -Assembly Automation -Version 2013R2 -Constant NAV2013R2 -Reference Core,Write,IO,Read,Parse -ExternalReference (SystemManagementAutomation)
Invoke-Build -Assembly Automation -Version 2015 -Constant NAV2013R2,NAV2015 -Reference Core,Write,IO,Read,Parse -ExternalReference (SystemManagementAutomation)
Invoke-Build -Assembly Automation -Version 2016 -Constant NAV2013R2,NAV2015,NAV2016 -Reference Core,Write,IO,Read,Parse -ExternalReference (SystemManagementAutomation)

function SystemManagementAutomation()
{
    "C:\Users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\packages\System.Management.Automation.6.1.7601.17515\lib\net40\System.Management.Automation.dll"
}