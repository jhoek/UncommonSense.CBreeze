Properties {
    [string]$RootFolderName = $Psake.build_script_dir
    [string]$CBreezeFolderName = Join-Path $RootFolderName 'CBreeze'
    [string]$CBreezeAutomationFolderName = Join-Path $CBreezeFolderName 'UncommonSense.CBreeze.Automation'
    [string]$CBreezeAutomationManifestFileName = Join-Path $CBreezeAutomationFolderName 'manifest.psd1'
}

Task default -depends Publish

Task Publish -depends UpdateManifest {
    # FIXME: Publish to PowerShell Gallery
}

Task UpdateManifest -depends BuildSolution {
    Import-Module UncommonSense.CBreeze.Automation -Force

    Update-ModuleManifest `
    -Path $CBreezeAutomationManifestFileName `
    -ModuleVersion $script:BuildVersion.ToString() `
    -CmdletsToExport 'FIXME'
}

Task UpdateReadMe -depends BuildSolution {
    Import-Module UncommonSense.CBreeze.Automation -Force

    # FIXME
}

Task BuildSolution -depends UpdateAssemblyInfo

Task UpdateAssemblyInfo -depends BumpBuildNo {
    Get-ChildItem -Path $psake.build_script_dir -Name AssemblyInfo.cs -Recurse |
        ForEach-Object {
            $AssemblyInfoFileName = $_
            $AssemblyInfoContents = Get-Content -Path $AssemblyInfoFileName -Encoding UTF8

            $AssemblyInfoContents | 
                ForEach-Object {
                    $_ -replace '^\[assembly: AssemblyVersion\(".*"\)\]$', "[assembly: AssemblyVersion(`"$($script:BuildVersion)`")]" 
                    $_ -replace '^\[assembly: AssemblyFileVersion\(".*"\)\]$', "[assembly: AssemblyFileVersion(`"$($script:BuildVersion)`")]"
                } | 
                Set-Content -Path $AssemblyInfoFileName -Encoding UTF8
        }
}

Task BumpBuildNo -depends GetBuildNo {
    $script:BuildVersion = `
        New-Object `
            -TypeName Version `
            -ArgumentList `
                $script:BuildVersion.Major, 
                $script:BuildVersion.Minor, 
                $script:BuildVersion.Build, 
                ($script:BuildVersion.Revision + 1)
    Write-Verbose "New build version is $($script:BuildVersion)"
}

Task GetBuildNo {
    $BuildNo = (Import-PowerShellDataFile -Path $CBreezeAutomationManifestFileName)['ModuleVersion']
    $script:BuildVersion = New-Object -TypeName Version -ArgumentList $BuildNo
    Write-Verbose "Existing build version is $($script:BuildVersion)"
}