$DemoPath = Join-Path -Path $PSScriptRoot -ChildPath .\CBreeze\UncommonSense.CBreeze.Demo

Get-ChildItem -Path $DemoPath -Filter *.cs |
    Where-Object Name -ne Program.cs |
    ForEach-Object { 
        $FileName = $_.FullName

        Get-Content -Path $FileName |
        Where-Object { $_ -notmatch '^using' } |
        Where-Object { $_ -notmatch '^namespace' } |
        Where-Object { $_ -notmatch '^\s*\{' } | 
        Foreach-Object { if ($_ -match '^\s{8}}') { '```' } else { $_} } |
        Where-Object { $_ -notmatch '^\s*}' } | 
        Where-Object { $_ -notmatch '^\s*public static class' } | 
        ForEach-Object { if ($_ -match '^\s*public static void') { '```c#' } else { $_ } } |
        ForEach-Object { $_ -replace '^\s*//', '' } | 
        Set-Content -Path ($FileName + '.md')
    }


    
    