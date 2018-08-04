Describe 'UncommonSense.CBreeze.Patterns cmdlets' {
    It 'Cmdlets should have Table as OutputType' {
        Get-ChildItem -Path $PSScriptRoot/../Public/*.ps1 |
            Should -FileContentMatch '\[OutputType\(\[Table\]\)\]'
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
}