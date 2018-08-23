Properties {
    [ValidateSet('2013', '2013R2', '2015', '2016', '2017', '2018')][string]$Version = '2017'
    [string]$WorkingFolder = (Get-Item -Path "~\Desktop").FullName
}

Task default -Depends Compile, Run

Task Compile {
    Invoke-Psake -BuildFile ./build.ps1 -Task "Build$Version"
}

Task Run -Depends SetFolders, RemovePrevious, PrepareInput, LoadScriptModule {
    New-Item -Path $ScriptsFolder -ItemType Container | Out-Null
    New-Item -Path $OutputFolder -Itemtype Container | Out-Null

    Get-ChildItem -Path (Join-Path -Path $InputFolder -ChildPath 'NL/RTM') |
        ForEach-Object {
            $InputFile = $_.FullName
            $ScriptFileName = Join-Path -Path $ScriptsFolder -ChildPath "$($_.BaseName).ps1"
            $OutputFileName = Join-Path -Path $OutputFolder -ChildPath "$($_.BaseName).txt"

            Import-CBreezeApplication -Path $InputFile | ConvertTo-CBreezeScript -Path $ScriptFileName

            & $ScriptFilename | Export-CBreezeApplication -Path $OutputFileName
        }
}

Task SetFolders {
    $script:BaseFolder = Join-Path -Path $WorkingFolder -ChildPath $Version
    $script:InputFolder = Join-Path -Path $script:BaseFolder -ChildPath Input
    $script:ScriptsFolder = Join-Path -Path $script:BaseFolder -ChildPath Scripts
    $script:OutputFolder = Join-Path -Path $script:BaseFolder -ChildPath Output
}

Task RemovePrevious {
    if (Test-Path -Path $BaseFolder) {
        Write-host "Removing $BaseFolder"
        Remove-Item -Path $BaseFolder -Recurse -Force
    }
    else
    {
        Write-Host "$BaseFolder did not exist"
    }
}

Task PrepareInput {
    New-Item -Path $InputFolder -ItemType Container | Out-Null
    Exec -Cmd { git clone --single-branch --branch=corrections --depth=1 "https://github.com/jhoek/Dynamics.NAV.ReferenceObjects.$Version" $InputFolder }
}

Task LoadScriptModule {
    Import-Module .\CBreeze\UncommonSense.CBreeze.Automation\bin\Release\UncommonSense.CBreeze.Automation\UncommonSense.CBreeze.Automation.psd1
    Import-Module ./CBreeze/UncommonSense.CBreeze.Script/bin/Release/UncommonSense.CBreeze.Script/UncommonSense.CBreeze.Script.psd1
}