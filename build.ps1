Framework '4.7'

Properties {
    $RootFolder = $psake.build_script_dir
    $SolutionFolder = Join-Path -Path $RootFolder -ChildPath CBreeze
    $SolutionFileName = Join-Path -Path $SolutionFolder -ChildPath UncommonSense.CBreeze.sln
}

Task Default -Depends NAV2017

Task NAV2016 {
    Exec { msbuild $SolutionFileName /t:Build /p:"Configuration=Debug;DefineConstants=NAV2013 NAV2013R2 NAV2015 NAV2016;PreBuildEvent=;PostBuildEvent=" /v:minimal }
}

Task NAV2017 {
    Exec { msbuild $SolutionFileName /t:Build /p:"Configuration=Debug;DefineConstants=NAV2013 NAV2013R2 NAV2015 NAV2016 NAV2017;PreBuildEvent=;PostBuildEvent=" /v:minimal }
}