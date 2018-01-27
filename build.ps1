# Framework "4.6"

Task Default -Depends NAV2017

Task NAV2017 {
    
}

Task Common {
    Exec { msbuild C:\users\jhoek\GitHub\UncommonSense.CBreeze.Common\UncommonSense.CBreeze.Common.sln /nologo /m /verbosity:minimal }       
}

Task Parse {
    Exec { msbuild C:\users\jhoek\GitHub\UncommonSense.CBreeze.Parse\UncommonSense.CBreeze.Parse.sln /nologo /m /verbosity:minimal /p:PreBuildEvent= /p:PostBuildEvent= }
}

Task CopyToModule {
    Copy-Item C:\users\jhoek\GitHub\UncommonSense.CBreeze.Common\UncommonSense.CBreeze.Common\bin\Debug\UncommonSense.CBreeze.Common.dll C:\users\jhoek\Documents\WindowsPowerShell\Modules\UncommonSense.CBreeze.Automation -Container -Verbose
    Copy-Item C:\Users\jhoek\GitHub\UncommonSense.CBreeze.Parse\UncommonSense.CBreeze.Parse\bin\Debug\UncommonSense.CBreeze.Parse.dll C:\users\jhoek\Documents\WindowsPowerShell\Modules\UncommonSense.CBreeze.Automation -Container -Verbose
    Copy-Item C:\users\jhoek\github\UncommonSense.CBreeze.Parse\UncommonSense.CBreeze.Parse.Automation\bin\Debug\UncommonSense.CBreeze.Parse.Automation.dll-Help.xml c:\users\jhoek\Documents\WindowsPowerShell\Modules\UncommonSense.CBreeze.Parse.Automation -Container -Verbose
}