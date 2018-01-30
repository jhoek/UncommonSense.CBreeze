Framework '4.6'

Properties {
    $Configuration = "Debug"
    $CompilationConstants = 'NAV2013 NAV2013R2 NAV2015 NAV2016 NAV2017'
    $RootFolder = $psake.build_script_dir
    $SolutionFolder = Join-Path -Path $RootFolder -ChildPath CBreeze
    $SolutionFileName = Join-Path -Path $SolutionFolder -ChildPath UncommonSense.CBreeze.sln
}

Task -Name Default -Depends Build

Task -Name Build {
    Exec { msbuild $SolutionFileName /t:Build /p:"Configuration=$Configuration;DefineConstants=$CompilationConstants;PreBuildEvent=;PostBuildEvent=" /v:minimal }
}