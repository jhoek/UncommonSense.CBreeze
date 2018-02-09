dotnet msbuild /p:DefineConstants="NAV2013R2 NAV2015 NAV2016 NAV2017"

copy ./UncommonSense.CBreeze.Automation/manifest.psd1 './UncommonSense.CBreeze.Automation/bin/Debug/netcoreapp2.0/UncommonSense.CBreeze.Automation.psd1'
copy ./UncommonSense.CBreeze.Automation/format.ps1xml './UncommonSense.CBreeze.Automation/bin/Debug/netcoreapp2.0/UncommonSense.CBreeze.Automation.Format.ps1xml'
copy ./UncommonSense.CBreeze.Automation/init.ps1 './UncommonSense.CBreeze.Automation/bin/Debug/netcoreapp2.0/UncommonSense.CBreeze.Automation.ps1'