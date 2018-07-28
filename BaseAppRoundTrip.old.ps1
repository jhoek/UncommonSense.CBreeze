# FIXME: Instead of 1 large file, use a file per object (makes comparison faster; makes interpreting results easier)
# FIXME: Test all NAV versions; perhaps from outside? ~InvokePester BaseAppRoundTrip.Tests.ps1 -Parameters @{Version=2017}
# FIXME: Compare output files byte-for-byte with input files; report any changes
# FIXME: Path to dlls (AppVeyor vs. local)

Describe "Base App Roundtrip" {
    BeforeAll {
        Write-Host 'Loading System.IO.Compression.FileSystem assembly'
        Add-Type -AssemblyName System.IO.Compression.FileSystem

        Write-Host 'Loading C/Breeze assemblies'
        Add-Type -Path C:\users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Read\bin\Debug\UncommonSense.CBreeze.Common.dll
        Add-Type -Path C:\users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Read\bin\Debug\UncommonSense.CBreeze.Core.dll
        Add-Type -Path C:\users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Read\bin\Debug\UncommonSense.CBreeze.Parse.dll
        Add-Type -Path C:\users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Read\bin\Debug\UncommonSense.CBreeze.Read.dll
        Add-Type -Path C:\users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Write\bin\Debug\UncommonSense.CBreeze.Write.dll

        Write-Host 'Creating folders in test drive'
        New-Item -Path $TestDrive -Name nl2017_tables -ItemType Directory | Out-Null

        Write-Host 'Downloading zipped objects'
        Invoke-WebRequest -Uri https://www.dropbox.com/s/n36284b86rgxpcq/nl2017_tables.zip?dl=1 -OutFile TestDrive:\nl2017_tables.zip

        Write-Host 'Unzipping objects'
        [System.IO.Compression.ZipFile]::ExtractToDirectory((Join-Path -Path $TestDrive -ChildPath nl2017_tables.zip), $TestDrive)
    }

    It "Tables C#" {
        $InputPath = Join-Path -Path $TestDrive -ChildPath nl2017_tables
        $OutputPath = Join-Path -Path $TestDrive -ChildPath nl2017_tables_output

        Write-Host "Reading application from folder $InputPath"
        $Application = [UncommonSense.CBreeze.Read.ApplicationBuilder]::ReadFromFolder($InputPath)

        Write-Host "Writing application to folder $OutputPath"
        [UncommonSense.CBreeze.Write.WriteToFolderExtensionMethods]::WriteToFolder($Application, $OutputPath)

        Get-ChildItem -Path $InputPath | ForEach-Object {
            $InputFile = $_

            $InputFileName = $InputFile.FullName
            $OutputFileName = Join-Path -Path $OutputPath -ChildPath $InputFile.Name

            Write-Host "Comparing $InputFileName and $OutputFileName"
            $Differences = Compare-Object `
                -ReferenceObject (Get-Content -Path $InputFileName -Raw) `
                -DifferenceObject (Get-Content -Path $OutputFileName -Raw)

            $Differences | Should Be $null
        }
    }

    It "Pages C#" {
    }

    It "Tables PowerShell" {
    }

    It "Pages PowerShell" {
    }
}