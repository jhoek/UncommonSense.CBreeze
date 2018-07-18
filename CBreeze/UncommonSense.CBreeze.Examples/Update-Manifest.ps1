Update-ModuleManifest `
    -Path ./UncommonSense.CBreeze.Examples.psd1 `
    -FunctionsToExport (Get-ChildItem -Path $PSScriptRoot\Public\*.ps1 -ErrorAction SilentlyContinue).BaseName