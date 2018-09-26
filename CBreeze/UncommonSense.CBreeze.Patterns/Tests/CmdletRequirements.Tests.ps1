Describe 'UncommonSense.CBreeze.Patterns cmdlets' {
    It 'Cmdlets should have Table as OutputType' {
        Get-ChildItem -Path $PSScriptRoot/../Public/*.ps1 |
            Should -FileContentMatch '\[OutputType\(\[(UncommonSense\.CBreeze\.Core\.)?Table\]\)\]'
    }

    It 'Cmdlets should return a Table' {
        Get-ChildItem -Path $PSScriptRoot/../Public/*.ps1 | 
            Should -FileContentMatch '^\s*\$Table$'
    }

    It 'Cmdlets should have consistent names' {
        Get-ChildItem -Path $PSScriptRoot/../Public/*.ps1 |
            Select-Object -ExpandProperty BaseName |
            Should -Not -Match 'Field$'
    }

    It 'Cmdlets should not a $Range parameter' {
        Get-ChildItem -Path $PSScriptRoot/../Public/*.ps1 | 
            Should -Not -FileContentMatch '\$Range'
    }

    It 'Cmdlets should not contain FIXMEs' {
        Get-ChildItem -Path $PSScriptRoot/../Public/*.ps1 | 
            Should -Not -FileContentMatch 'FIXME'
    }

    It 'Cmdlet documentation contains at least a synopsis' {
        Get-ChildItem -Path $PSScriptRoot/../Public/*.ps1 |
            Should -FileContentMatchExactly '.SYNOPSIS'
    }
}