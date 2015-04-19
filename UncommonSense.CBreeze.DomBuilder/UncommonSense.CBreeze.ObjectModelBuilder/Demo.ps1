function New-Item
{
    param
    (
        [Parameter(Mandatory=$true,ValueFromPipeLine=$true)]
        [UncommonSense.CBreeze.ObjectModelBuilder.ObjectModel]$ObjectModel,

        [Parameter(Mandatory=$true)]
        [string]$Name,

        [string]$BaseTypeName
    )

    $Item = New-Object UncommonSense.CBreeze.ObjectModelBuilder.Item -ArgumentList $Name
    $Item.BaseTypeName = $BaseTypeName
    $ObjectModel.Elements.Add($Item)
}

function New-Container
{
    param
    (
        [Parameter(Mandatory=$true,ValueFromPipeLine=$true)]
        [UncommonSense.CBreeze.ObjectModelBuilder.ObjectModel]$ObjectModel,

        [Parameter(Mandatory=$true)]
        [string]$Name    
    )

    $Container = New-Object UncommonSense.CBreeze.ObjectModelBuilder.Container -ArgumentList $Name
    $ObjectModel.Elements.Add($Container)
}

function New-Attribute
{
    param
    (
        [Parameter(Mandatory=$true,ValueFromPipeLine=$true)]
        [UncommonSense.CBreeze.ObjectModelBuilder.Item]$Item,

        [Parameter(Mandatory=$true)]
        [string]$TypeName,

        [string]$Name
    )

    if ($Name)
    {
        $TypeName = $Name
    }

    $Attribute = New-Object UncommonSense.CBreeze.ObjectModelBuilder.Attribute -ArgumentList $TypeName, $Name
    $Item.Attributes.Add($Attribute) | Out-Null
    $Item
}

$LibraryPath = Join-Path $PSScriptRoot Bin/Debug/UncommonSense.CBreeze.ObjectModelBuilder.dll
Add-Type -Path $LibraryPath

$ErrorActionPreference = 'Stop'
$Namespace = "UncommonSense.CBreeze.ObjectModelBuilder.Demo"

$ObjectModel = New-Object UncommonSense.CBreeze.ObjectModelBuilder.ObjectModel -ArgumentList $Namespace
$ObjectModel | New-Item -Name Object | New-Attribute -Name ID -TypeName int | New-Attribute -Name Name -TypeName string
$ObjectModel | New-Item -Name Table -BaseTypeName Object
$ObjectModel | New-Item -Name Page -BaseTypeName Object
$ObjectModel | New-Container -Name Tables
$ObjectModel | New-Container -Name Pages
$ObjectModel | New-Item -Name Application | New-Attribute -TypeName Tables | New-Attribute -TypeName Pages
