function New-Item
{
    param
    (
        [Parameter(Mandatory=$true,ValueFromPipeLine=$true)]
        [UncommonSense.CBreeze.ObjectModelBuilder.ObjectModel]$ObjectModel,

        [Parameter(Mandatory=$true)]
        [string]$Name,

        [string]$BaseTypeName,

        [bool]$Abstract
    )

    $Item = New-Object UncommonSense.CBreeze.ObjectModelBuilder.Item -ArgumentList $Name
    $Item.BaseTypeName = $BaseTypeName
    $Item.Abstract = $Abstract 
    $ObjectModel.Elements.Add($Item)
}

function New-Container
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

    if (-not $Name)
    {
        $Name= $TypeName
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
$ObjectModel | New-Item -Name Object -Abstract $true | New-Attribute -Name ID -TypeName int | New-Attribute -Name Name -TypeName string 
$ObjectModel | New-Item -Name Table -BaseTypeName Object 
$ObjectModel | New-Item -Name Page -BaseTypeName Object 
$ObjectModel | New-Container -ItemTypeName Table 
$ObjectModel | New-Container -ItemTypeName Page 
$ObjectModel | New-Item -Name Application | New-Attribute -TypeName Tables | New-Attribute -TypeName Pages 
