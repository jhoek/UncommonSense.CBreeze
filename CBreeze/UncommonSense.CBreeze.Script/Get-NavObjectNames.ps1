Add-Type -Path "C:\Users\jhoek\Dropbox\Work in Progress\UncommonSense.CBreeze.Core.dll"
Add-Type -Path "C:\Users\jhoek\Dropbox\Work in Progress\Parser3\Parser3\bin\Debug\Parser3.dll"
Add-Type -Path "C:\Users\jhoek\Dropbox\Work in Progress\Parser3\Parser3.ApplicationBuilder\bin\Debug\Parser3.ApplicationBuilder.dll"

$fileName = "C:\Users\jhoek\Dropbox\Work in Progress\UncommonSense.CBreeze\UncommonSense.CBreeze.Script\powershell test.txt"
$application = [Parser3.ApplicationBuilder.ApplicationBuilder]::FromFile($fileName);

foreach($object in $application.Objects)
{
    "{0} {1} {2}" -f $object.GetType().Name, $object.ID, $object.Name
}