function Add-Item
{
    param
    (
        [Parameter(Mandatory=$true,ValueFromPipeLine=$true)]
        [UncommonSense.CBreeze.ObjectModelBuilder.ObjectModel]$ObjectModel,

        [Parameter(Mandatory=$true)]
        [string]$Name,

        [string]$BaseTypeName,

        [Switch]$Abstract,

        [Switch]$CreateContainer,

        [string]$ContainerName
    )

    $Item = New-Object UncommonSense.CBreeze.ObjectModelBuilder.Item -ArgumentList $Name
    $Item.BaseTypeName = $BaseTypeName
    $Item.Abstract = $Abstract
    $ObjectModel.Elements.Add($Item) | Out-Null

    if ($Abstract)
    {
        Add-Enum -Name "$($Name)Type" | Out-Null
    }

    if ($BaseTypeName)
    {
        $EnumName = "$($BaseTypeName)Type"
        $Enum = $ObjectModel.Elements | Where-Object -Property Name -Eq -Value $EnumName | Select-Object -First 1
        $Enum.Values.Add($Name)
    }

    if ($CreateContainer)
    {
        switch ($ContainerName)
        {
            {$false} { Add-Container -ItemTypeName $Item.Name | Out-Null } 
            {$true} { Add-Container -ItemTypeName $Item.Name -Name $ContainerName | Out-Null }
        }
    }

    $Item
}
