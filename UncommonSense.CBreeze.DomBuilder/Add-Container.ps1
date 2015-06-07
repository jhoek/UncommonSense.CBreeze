function Add-Container
{
    param
    (
        [Parameter(Mandatory=$true,ValueFromPipeLine=$true)]
        [UncommonSense.CBreeze.ObjectModelBuilder.ObjectModel]$ObjectModel,

        [Parameter(Mandatory=$true)]
        [string]$ItemTypeName,

        [string]$Name
    )

    if (-not $Name)
    {
        $Name = "$($ItemTypeName)s"
    }

    $Container = New-Object UncommonSense.CBreeze.ObjectModelBuilder.Container -ArgumentList $ItemTypeName, $Name
    $ObjectModel.Elements.Add($Container) 
}
