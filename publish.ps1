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
    Update-ModuleManifest -Path $CBreezeAutomationManifestFileName -ModuleVersion ($script:BuildVersion.ToString())
    Set-ExportedModuleMembers -Path $CBreezeAutomationManifestFileName
}

Task UpdateReadMe -depends BuildSolution {
    $UpdateReadMe = Join-Path -Path $psake.build_script_dir -ChildPath Update-README.ps1

    if (Test-Path -Path $UpdateReadMe)
    {
        Import-Module UncommonSense.CBreeze.Automation -Force -DisableNameChecking
        & $UpdateReadMe
    }
}

Task BuildSolution -depends UpdateAssemblyInfo{
    Invoke-Psake -BuildFile (Join-Path -Path $psake.build_script_dir -ChildPath build.ps1)
}

Task UpdateAssemblyInfo -depends BumpBuildNo {
    Set-AssemblyInfoVersion -Path $psake.build_script_dir -Version $script:BuildVersion -Recurse     
}

Task BumpBuildNo -depends GetBuildNo {
    $script:BuildVersion = Step-ModuleVersion -Version $script:BuildVersion -By Minor
}

Task GetBuildNo {
    $script:BuildVersion = Get-ModuleVersion -Path $CBreezeAutomationManifestFileName
}