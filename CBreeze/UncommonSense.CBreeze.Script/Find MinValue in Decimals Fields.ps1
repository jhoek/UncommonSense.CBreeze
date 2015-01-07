Import-Module "c:\Users\jhoek\Dropbox\Work in Progress\UncommonSense.CBreeze.Core.dll"
Import-Module "c:\Users\jhoek\Dropbox\Work in Progress\UncommonSense.CBreeze.Read.dll"

$application = [UncommonSense.CBreeze.Read.ApplicationBuilder]::FromFile("c:\Users\jhoek\Desktop\shipit.txt")

foreach($table in $application.Tables)
{
    Write-Host $table.ID $table.Name

    foreach($field in $table.Fields)
    {
        if (($table.ID -gt 50000) -or ($field.ID -gt 50000)){
            $decimalField = $field -as [UncommonSense.CBreeze.Core.DecimalTableField]

            if ($decimalField -ne $null)
            {
                if ($decimalField.Properties.MinValue -eq $null)
                {
                    Write-Host "`t" $field.No $field.Name $field.Properties.MinValue
                }
            }
        }
    }
}