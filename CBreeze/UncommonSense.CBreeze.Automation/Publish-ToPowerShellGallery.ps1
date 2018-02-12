$ErrorActionPreference = 'Stop'

Publish-Module `
    -Path (Join-Path -Path $PSScriptRoot -ChildPath bin/Debug/UncommonSense.CBreeze.Automation) `
    -Repository PSGallery `
    -NuGetApiKey $env:NuGetApiKey
