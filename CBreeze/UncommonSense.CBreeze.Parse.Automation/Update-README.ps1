Import-Module .\bin\debug\UncommonSense.CBreeze.Parse.Automation.dll -Force

Get-Command -Module UncommonSense.CBreeze.Parse.Automation | 
    Get-HelpAsMarkdown `
        -Title UncommonSense.CBreeze.Parse.Automation `
        -PrefacePath ./INSTALL.md `
        -Description 'PowerShell wrapper for UncommonSense.CBreeze.Parser library' |
            Out-File -FilePath .\README.md -Width 1000 -Encoding utf8
        