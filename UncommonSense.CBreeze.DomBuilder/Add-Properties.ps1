function Add-Properties
{
    param
    (
        [Parameter(Mandatory=$true,ValueFromPipeLine=$true)]
        [UncommonSense.CBreeze.ObjectModelBuilder.ObjectModel]$ObjectModel,

        [Parameter(Mandatory=$true)]
        [string]$Name,

        [Switch]$PassThru
    )

    $Properties = New-Object UncommonSense.CBreeze.ObjectModelBuilder.Properties -ArgumentList $Name
    $ObjectModel.Elements.Add($Properties) | Out-Null

    if ($PassThru)
    {
        $Properties
    }
}
