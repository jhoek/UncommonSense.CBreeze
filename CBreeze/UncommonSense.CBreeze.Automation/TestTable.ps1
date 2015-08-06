$Application = New-CBreezeApplication

$Table = Add-CBreezeTable -Application $Application -ID 1 -Name Foo -DataPerCompany $true -DrillDownPageID 1 
$Table2 = Add-CBreezeTable -Application $Application -ID 2 -Name Baz -DrillDownPageID $null

Export-CBreezeApplication -Path 'c:\users\jhoek\desktop\demo.txt'
& 'c:\Program Files\Internet Explorer\iexplore' 'c:\users\jhoek\desktop\demo.txt'