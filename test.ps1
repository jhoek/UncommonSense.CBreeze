Describe "C# interface" -Tag csharp {
    It "Correctly parses and writes W12017" {
        $env:APPVEYOR_BUILD_FOLDER | Should -Be '' # FIXME
    }
}