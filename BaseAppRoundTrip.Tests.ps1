# FIXME: Instead of 1 large file, use a file per object (makes comparison faster; makes interpreting results easier)
# FIXME: Test all NAV versions; perhaps from outside? ~InvokePester BaseAppRoundTrip.Tests.ps1 -Parameters @{Version=2017}
# FIXME: Path to dlls (AppVeyor vs. local)

function Split-TextFile 
{
    param
    (
        [Parameter(Mandatory)][string]$Path,
        [string]$Destination
    )

    if (-not $Destination)
    {
        $Destination = Join-Path -Path (Get-Item -Path $Path).DirectoryName -ChildPath (Get-Item -Path $Path).BaseName
    }

    if (-not (Test-Path $Destination -PathType Container))
    {
        New-Item -Path $Destination -ItemType Directory | Out-Null
    }
}

Describe "Base App Roundtrip" {
    BeforeAll {
        Invoke-WebRequest -Uri https://www.dropbox.com/s/41zo30tllnu8nw0/nl2017_tables.txt?dl=1 -OutFile TestDrive:\nl2017_tables.txt
        Invoke-WebRequest -Uri https://www.dropbox.com/s/s6a8u9keo41ovkd/nl2017_pages.txt?dl=1 -OutFile TestDrive:\nl2017_pages.txt

        Split-TextFile -Path TestDrive:\nl2017_tables.txt
        Split-TextFile -Path TestDrive:\nl2017_pages.txt

        Add-Type -Path C:\users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Read\bin\Debug\UncommonSense.CBreeze.Common.dll
        Add-Type -Path C:\users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Read\bin\Debug\UncommonSense.CBreeze.Core.dll
        Add-Type -Path C:\users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Read\bin\Debug\UncommonSense.CBreeze.Parse.dll
        Add-Type -Path C:\users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Read\bin\Debug\UncommonSense.CBreeze.Read.dll
        Add-Type -Path C:\users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Write\bin\Debug\UncommonSense.CBreeze.Write.dll
    }

    It "Tables C#" -Skip {
        

        $InputPath = Join-Path -Path $TestDrive -ChildPath nl2017_tables
        $OutputPath = Join-Path -Path $TestDrive -ChildPath nl2017_tables_output
        $Application = [UncommonSense.CBreeze.Read.ApplicationBuilder]::ReadFromFolder($InputPath)
        [UncommonSense.CBreeze.Write.ApplicationWriter]::WriteToFolder($Application, $OutputPath)

        $Differences = Compare-Object `
            -ReferenceObject (Get-Content -Path $InputPath -Raw) `
            -DifferenceObject (Get-Content -Path $OutputPath -Raw)

        $Differences.Length | Should Be 0
    }

    It "Pages C#" {
    }

    It "Tables PowerShell" {
    }

    It "Pages PowerShell" {
    }
}