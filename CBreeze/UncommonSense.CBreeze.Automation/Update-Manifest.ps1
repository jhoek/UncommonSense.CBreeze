$ErrorActionPreference = 'Stop'

Import-Module (Join-Path -Path $PSScriptRoot -ChildPath 'bin/release/UncommonSense.CBreeze.Automation/UncommonSense.CBreeze.Automation.dll') -Force

Update-ModuleManifest `
    -Path (Join-Path -Path $PSScriptRoot -ChildPath manifest.psd1) `
    -CmdletsToExport (Get-Command -Module UncommonSense.CBreeze.Automation -CommandType Cmdlet | Select-Object -ExpandProperty Name) `
    -AliasesToExport (Get-Command -Module UncommonSense.CBreeze.Automation -CommandType Alias | Select-Object -ExpandProperty Name) 