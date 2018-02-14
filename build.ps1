Properties {
    $Configuration = "Debug"
    $RootFolder = $psake.build_script_dir
    $SolutionFolder = Join-Path -Path $RootFolder -ChildPath CBreeze
    $SolutionFileName = Join-Path -Path $SolutionFolder -ChildPath UncommonSense.CBreeze.sln
}

Task -Name Default -Depends Build2017, Build2016 #, Build2015, Build2013R2, Build2013

Task -Name Build2017 {
    Exec { msbuild $SolutionFileName /t:Build /p:"Configuration=$Configuration;DefineConstants="NAV2017; NAV2016; NAV2015; NAV2013R2; NAV2013";PreBuildEvent=;PostBuildEvent=" /v:minimal }
}

Task -Name Build2016 {
    Exec { msbuild $SolutionFileName /t:Build /p:"Configuration=$Configuration;DefineConstants="NAV2016; NAV2015; NAV2013R2; NAV2013";PreBuildEvent=;PostBuildEvent=" /v:minimal }
}

Task -Name Build2015 {
    Exec { msbuild $SolutionFileName /t:Build /p:"Configuration=$Configuration;DefineConstants="NAV2015; NAV2013R2; NAV2013";PreBuildEvent=;PostBuildEvent=" /v:minimal }
}

Task -Name Build2013R2 {
    Exec { msbuild $SolutionFileName /t:Build /p:"Configuration=$Configuration;DefineConstants="NAV2013R2; NAV2013";PreBuildEvent=;PostBuildEvent=" /v:minimal }
}

Task -Name Build2013 {
    Exec { msbuild $SolutionFileName /t:Build /p:"Configuration=$Configuration;DefineConstants="NAV2013";PreBuildEvent=;PostBuildEvent=" /v:minimal }
}