cd C:\Users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Core

Write-Host 'Building Core 2013...' -ForegroundColor DarkYellow
& C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /out:bin/debug/UncommonSense.CBreeze.2013.Core.dll /target:library *.cs .\Properties\AssemblyInfo.cs

Write-Host 'Building Core 2013R2...' -ForegroundColor DarkYellow
& C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /define:NAV2013R2 /target:library /out:bin/debug/UncommonSense.CBreeze.2013R2.Core.dll *.cs .\Properties\AssemblyInfo.cs

Write-Host 'Building Core 2015...' -ForegroundColor DarkYellow
& C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /define:NAV2015 /define:NAV2013R2 /target:library /out:bin/debug/UncommonSense.CBreeze.2015.Core.dll *.cs .\Properties\AssemblyInfo.cs

Write-Host 'Building Core 2016...' -ForegroundColor DarkYellow
& C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /define:NAV2016 /define:NAV2015 /define:NAV2013R2 /target:library /out:bin/debug/UncommonSense.CBreeze.2016.Core.dll *.cs .\Properties\AssemblyInfo.cs