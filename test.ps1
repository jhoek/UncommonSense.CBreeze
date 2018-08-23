Properties {
    [ValidateScript({Test-Path -Path $_})][string]$WorkingFolder = (Get-Item -Path "~\Desktop").FullName
    [ValidateSet('2013', '2013R2', '2015', '2016', '2017', '2018')][string]$Version = '2017'
    [string]$BaseFolder = Join-Path -Path $WorkingFolder -ChildPath $Version
    [string]$InputFolder = Join-Path -Path $BaseFolder -ChildPath Input
    [string]$ScriptsFolder = Join-Path -Path $BaseFolder -ChildPath Scripts
    [string]$OutputFolder = Join-Path -Path $BaseFolder -ChildPath Output
}

Task default -Depends Compile,Run

Task Compile {
    Invoke-Psake -BuildFile ./build.ps1 -Task "Build$Version"    
}

Task Run -Depends RemovePrevious, PrepareInput, LoadScriptModule {
    New-Item -Path $ScriptsFolder -ItemType Container | Out-Null

    Get-ChildItem -Path (Join-Path -Path $InputFolder -ChildPath 'NL/RTM') |
        ForEach-Object {
            $InputFile = $_.FullName 
            Write-Host "FIXME: $($InputFile)"
            $ScriptFileName = Join-Path -Path $ScriptsFolder -ChildPath "$($_.BaseName).ps1"

            Import-CBreezeApplication -Path $InputFile |
                ConvertTo-CBreezeScript -Path $ScriptFileName 
        }
}

Task RemovePrevious {
    if (Test-Path -Path $BaseFolder) {
        Remove-Item -Path $BaseFolder -Recurse -Force 
    }
}

Task PrepareInput {
    New-Item -Path $InputFolder -ItemType Container | Out-Null
    Exec -Cmd { git clone --single-branch --branch=corrections --depth=1 "https://github.com/jhoek/Dynamics.NAV.ReferenceObjects.$Version" $InputFolder }
}

Task LoadScriptModule {
    Import-Module ./CBreeze/UncommonSense.CBreeze.Script/bin/Release/UncommonSense.CBreeze.Script/UncommonSense.CBreeze.Script.psd1
}