$Application = New-CBreezeApplication
$PSDefaultParameterValues.Add("*-CBreeze*:Application", $Application)

$Table = Add-CBreezeTable 7 'Standard Text' -DateTime (Get-Date -Year 2012 -Month 9 -Day 7 -Hour 12 -Minute 0 -Second 0) -VersionList NAVW17.00
$Table.Code | Add-CBreezeVariable -ID 1000 -Record ExtTextHeader -SubType 279 -Verbose
$Table.Properties.OnDelete | Add-CBreezeCodeLine 'ExtTextHeader.SETRANGE("Table Name",ExtTextHeader."Table Name"::"Standard Text");'
$Table.Properties.OnDelete | Add-CBreezeCodeLine 'ExtTextHeader.SETRANGE("No.",Code);'
$Table.Properties.OnDelete | Add-CBreezeCodeLine 'ExtTextHeader.DELETEALL(TRUE);'

Export-CBreezeApplication -Path 'c:\users\jhoek\desktop\generated.txt'
& 'c:\Program Files\Araxis\Araxis Merge\compare.exe' 'c:\users\jhoek\desktop\tab7.txt' 'c:\users\jhoek\desktop\generated.txt'