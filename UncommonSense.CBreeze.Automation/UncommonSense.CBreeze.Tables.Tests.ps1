using namespace System.Linq
using namespace UncommonSense.CBreeze.Core

# FIXME: Pester tests van maken
# FIXME: Move reftable.txt to project

$MyStringWriter = New-Object -TypeName System.IO.StringWriter

$PSDefaultParameterValues.Clear()
$PSDefaultParameterValues.Add('*CBreeze*:AutoCaption', $true)
$PSDefaultParameterValues.Add('*CBreeze*:DateTime', (Get-Date -Year 2017 -Month 6 -Day 28 -Hour 12 -Minute 0 -Second 0))
$PSDefaultParameterValues.Add('*CBreeze*:Modified', $true)
$PSDefaultParameterValues.Add('*CBreeze*:VersionList', 'NAVJH1.00')

[DefaultRanges]::ID = [Enumerable]::Range(51000, 100)

Application {
    Table 'My Test Table' {
        CodeField 'Primary Key'
        BlobField 'BLOB Field' -Compressed $true | Set-CBreezeMLValue CaptionML NLD 'BLOB-veld' -PassThru
    }
} | Export -TextWriter $MyStringWriter

$MyStringWriter.ToString() | Should Be (Get-Content C:\Users\jhoek\Desktop\reftable.txt -Raw)