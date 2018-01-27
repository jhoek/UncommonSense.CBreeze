function Test-BaseAppRoundTrip
{
    Param
    (
        [Parameter(Mandatory)]
        [ValidateSet('2013', '2013R2', '2015', '2016')]
        [string]$Version
    )

    Add-Type -Path "c:\users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Core\bin\Debug\UncommonSense.CBreeze.$Version.Core.dll"
    Add-Type -Path "c:\users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Parse\bin\Debug\UncommonSense.CBreeze.$Version.Parse.dll"
    Add-Type -Path "C:\Users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Read\bin\Debug\UncommonSense.CBreeze.$Version.Read.dll"
    Add-Type -Path "C:\Users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Write\bin\Debug\UncommonSense.CBreeze.$Version.Write.dll"

    $InputFileName = "~\Desktop\nl$Version.txt"
    $OutputFileName = "~\Desktop\nl$Version.output.txt"
    
    $Reading = Measure-Command { $Lines = [System.IO.File]::ReadLines($InputFileName, [System.Text.Encoding]::GetEncoding('ibm850')) }
    $Parsing = Measure-Command { $Application = [UncommonSense.CBreeze.Read.ApplicationBuilder]::FromLines($Lines) }
    $Writing = Measure-Command { [UncommonSense.CBreeze.Write.ApplicationWriter]::Write($Application, $OutputFileName) }

    $Result = [Ordered]@{}
    $Result.Version = $Version
    $Result.Reading = $Reading.TotalMilliseconds
    $Result.Parsing = $Parsing.TotalMilliseconds
    $Result.Writing = $Writing.TotalMilliseconds
    $Result

    # Start-Process -FilePath 'C:\Program Files\Araxis\Araxis Merge\Compare.exe' -ArgumentList $InputFileName, $OutputFileName
}

Clear-Host

#Verify-Build -Version 2013 | Format-Table
#Verify-Build -Version 2013R2 | Format-Table
#Verify-Build -Version 2015 | Format-Table 
Verify-Build -Version 2016 | Format-Table