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

Task UpdateManifest -depends ReloadModule {
    Update-ModuleManifest `
    -Path $CBreezeAutomationManifestFileName `
    -ModuleVersion $script:BuildVersion.ToString() `
    -CmdletsToExport 'FIXME'
}

Task ReloadModule -depends BuildSolution {
    Import-Module UncommonSense.CBreeze.Automation -Force
}

Task BuildSolution -depends UpdateAssemblyInfo

Task UpdateAssemblyInfo -depends BumpBuildNo {
    Get-ChildItem -Path $psake.build_script_dir -Name AssemblyInfo.cs -Recurse |
        ForEach-Object {
            $AssemblyInfoFileName = $_
            $AssemblyInfoContents = Get-Content -Path $AssemblyInfoFileName -Encoding UTF8

            $AssemblyInfoContents | 
                ForEach-Object { $_ -replace '^\[assembly: AssemblyVersion\(".*"\)\]$', "[assembly: AssemblyVersion(`"$($script:BuildVersion)`")]" } | 
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
    Write-Verbose $script:BuildVersion
}

Task GetBuildNo {
    $BuildNo = (Import-PowerShellDataFile -Path $CBreezeAutomationManifestFileName)['ModuleVersion']
    $script:BuildVersion = New-Object -TypeName Version -ArgumentList $BuildNo
    Write-Verbose $script:BuildVersion
}