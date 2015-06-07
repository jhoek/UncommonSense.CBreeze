function Add-Enum
{
    param
    (
        [Parameter(Mandatory=$true,ValueFromPipeLine=$true)]
        [UncommonSense.CBreeze.ObjectModelBuilder.ObjectModel]$ObjectModel,

        [Parameter(Mandatory=$true)]
        [string]$Name,

        [string[]]$Values,

        [Switch]$PassThru = $false
    )

    $Enum = New-Object UncommonSense.CBreeze.ObjectModelBuilder.Enumeration -ArgumentList $Name

    if ($Values)
    {
        $Enum.Values.AddRange($Values)
    }

    $ObjectModel.Elements.Add($Enum) | Out-Null

    if ($PassThru)
    {
        $Enum
    }
}
