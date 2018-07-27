Properties {
    [ValidateSet('Major', 'Minor', 'Revision', 'Build')][string]$StepVersionBy = 'Revision'
    [string]$RootFolderName = $Psake.build_script_dir
    [string]$CBreezeFolderName = Join-Path $RootFolderName 'CBreeze'
    [string]$CBreezeAutomationFolderName = Join-Path $CBreezeFolderName 'UncommonSense.CBreeze.Automation'
    [string]$CBreezeAutomationManifestFileName = Join-Path $CBreezeAutomationFolderName 'manifest.psd1'
    [string]$OutputFolderName = Join-Path $CBreezeAutomationFolderName 'bin/Release/UncommonSense.CBreeze.Automation'
    [string]$OutputManifestFileName = Join-Path $OutputFolderName 'UncommonSense.CBreeze.Automation.psd1'
}

Task default -depends UpdateManifest, UpdateReadMe

Task Publish -depends UpdateManifest {
    Publish-Module -Path $OutputFolderName -NuGetApiKey $env:NuGetApiKey
}

Task UpdateManifest -depends BuildSolution {    
    Set-ExportedModuleMembers -Path $OutputManifestFileName
}

Task UpdateReadMe -depends BuildSolution {
    $UpdateReadMe = Join-Path -Path $psake.build_script_dir -ChildPath Update-README.ps1

    if (Test-Path -Path $UpdateReadMe)
    {
        Import-Module UncommonSense.CBreeze.Automation -Force -DisableNameChecking
        & $UpdateReadMe
    }
}

Task BuildSolution -depends UpdateAssemblyInfo, UpdateModuleVersion {
    Invoke-Psake -BuildFile (Join-Path -Path $psake.build_script_dir -ChildPath build.ps1) -taskList Build2017
}

Task UpdateModuleVersion -depends BumpBuildNo {
    Update-ModuleManifest -Path $CBreezeAutomationManifestFileName -ModuleVersion ($script:BuildVersion.ToString())
}

Task UpdateAssemblyInfo -depends BumpBuildNo {
    Set-AssemblyInfoVersion -Path $psake.build_script_dir -Version $script:BuildVersion -Recurse     
}

Task BumpBuildNo -depends GetBuildNo {
    $script:BuildVersion = Step-ModuleVersion -Version $script:BuildVersion -By $StepVersionBy
}

Task GetBuildNo {
    $script:BuildVersion = Get-ModuleVersion -Path $CBreezeAutomationManifestFileName
}