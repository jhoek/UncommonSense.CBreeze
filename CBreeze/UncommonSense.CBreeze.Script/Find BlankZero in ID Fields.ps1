Import-Module "c:\Users\jhoek\Dropbox\Work in Progress\UncommonSense.CBreeze.Core.dll"
Import-Module "c:\Users\jhoek\Dropbox\Work in Progress\UncommonSense.CBreeze.Read.dll"

$application = [UncommonSense.CBreeze.Read.ApplicationBuilder]::FromFile("c:\Users\jhoek\Desktop\shipit.txt")

foreach($table in $application.Tables)
{
    Write-Host $table.ID $table.Name

    foreach($field in $table.Fields)
    {
            if ($field.Name -notcontains "ID") { continue }

            $integerField = $field -as [UncommonSense.CBreeze.Core.IntegerTableField]
            if ($integerField -eq $null) { continue }
            if ($integerField.Properties.BlankZero -ne $null) { continue }

            Write-Host $integerField.Name
    }
}