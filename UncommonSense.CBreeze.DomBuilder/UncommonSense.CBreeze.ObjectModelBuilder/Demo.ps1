$LibraryPath = Join-Path $PSScriptRoot Bin/Debug/UncommonSense.CBreeze.ObjectModelBuilder.dll
Add-Type -Path $LibraryPath

function New-Item
{
    param
    (
        [Parameter(Mandatory=$true,ValueFromPipeLine=$true)]
        [UncommonSense.CBreeze.ObjectModelBuilder.ObjectModel]$ObjectModel,

        [Parameter(Mandatory=$true)]
        [string]$Name
    )

    $Item = New-Object UncommonSense.CBreeze.ObjectModelBuilder.Item -ArgumentList $Name
    $ObjectModel.Elements.Add($Item)

    $Item
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

    $Container
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

    $Attribute = New-Object UncommonSense.CBreeze.ObjectModelBuilder.Attribute 
    $Item.Attributes.Add($Attribute)
    $Item
}

$ErrorActionPreference = 'Stop'

$Namespace = "UncommonSense.CBreeze.ObjectModelBuilder.Demo"
$ObjectModel = New-Object UncommonSense.CBreeze.ObjectModelBuilder.ObjectModel -ArgumentList $Namespace
$ObjectModel | New-Container -Name Tables
$ObjectModel | New-Item -Name Application | New-Attribute -TypeName Tables
