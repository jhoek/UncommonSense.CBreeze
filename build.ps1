function Invoke-Build
{
    Param
    (
        [Parameter(Mandatory)]
        [ValidateSet('Core','Parse','Read','Write','Automation', 'IO')]
        [string]$Assembly,

        [Parameter(Mandatory)]
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

function New-ModuleFolder
{
    Param
    (
        [ValidateNotNullOrEmpty()]
        [ValidateScript( { Test-Path $_ } )]
        [string]$BaseFolder = "$Home\Desktop",

        [Parameter(Mandatory)]
        [ValidateSet('2013','2013R2','2015','2016')]
        [string]$Version
    )

    Write-Host "Creating module folder $Version" -ForegroundColor DarkYellow

    $ModuleFolderName = Join-Path $BaseFolder "UncommonSense.CBreeze.$Version.Automation"
    Remove-Item -Path $ModuleFolderName -Recurse -Force -ErrorAction SilentlyContinue 
    Start-Sleep -Milliseconds 100
    New-Item -Path $ModuleFolderName -ItemType Directory | Out-Null 

    $ManifestFileName = Join-Path $ModuleFolderName "UncommonSense.CBreeze.Automation.psd1"
    New-ModuleManifest `
        -Path $ManifestFileName `
        -RootModule "UncommonSense.CBreeze.$Version.Automation.dll" `
        -Guid 999a0b81-d816-4d68-8337-f70c1096f30e `
        -Author 'Jan Hoek' `
        -CompanyName 'UncommonSense' `
        -Copyright 'Copyright (c) 2015 Jan Hoek. All rights reserved.' `
        -RequiredAssemblies "UncommonSense.CBreeze.$Version.Core.dll", "UncommonSense.CBreeze.$Version.IO.dll", "UncommonSense.CBreeze.$Version.Write.dll"

    'Core', 'IO', 'Write' | ForEach-Object { 
        Copy-Item `
            -Path "C:\Users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.$_\bin\Debug\UncommonSense.CBreeze.$Version.$_.dll" `
            -Destination $ModuleFolderName }
}

Clear-Host
<#
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
#>

New-ModuleFolder -Version 2013 
New-ModuleFolder -Version 2013R2
New-ModuleFolder -Version 2015
New-ModuleFolder -Version 2016

function SystemManagementAutomation()
{
    "C:\Users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\packages\System.Management.Automation.6.1.7601.17515\lib\net40\System.Management.Automation.dll"
}