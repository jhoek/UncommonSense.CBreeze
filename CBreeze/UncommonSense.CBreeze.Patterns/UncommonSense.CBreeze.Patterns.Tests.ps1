Describe 'Patterns project' {
    It 'Should not contain FIXMEs' {
        Get-ChildItem -Path $PSScriptRoot -Exclude .gitattributes | Select-String -Pattern FIXME | Should Be Empty
    }
}