Import-Module UncommonSense.CBreeze.Automation -Force

Get-Command `
    -Module UncommonSense.CBreeze.Automation | `
    Sort-Object -Property Noun,Verb | `
        Get-HelpAsMarkDown `
            -Title UncommonSense.CBreeze.Automation `
            -Description 'PowerShell interface for UncommonSense.CBreeze.Automation.dll' `
            -PrefacePath (Join-Path $Pwd PREFACE.md) |`
                Out-File .\README.md