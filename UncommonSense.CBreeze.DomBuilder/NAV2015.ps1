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
        $ObjectModel | Add-Enum -Name "$($Name)Type" | Out-Null
    }

    if ($BaseTypeName)
    {
        $Enum = $ObjectModel.Elements["$($BaseTypeName)Type"]
        $Enum.Values.Add($Name)
    }

    if ($CreateContainer)
    {
        switch ($ContainerName)
        {
            false { $ObjectModel | Add-Container -ItemTypeName $Item.Name | Out-Null } 
            true { $ObjectModel | Add-Container -ItemTypeName $Item.Name -Name $ContainerName | Out-Null }
        }
    }

    $Item
}

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

function Add-Attribute
{
    param
    (
        [Parameter(Mandatory=$true,ValueFromPipeLine=$true)]
        [UncommonSense.CBreeze.ObjectModelBuilder.Item]$Item,

        [Switch]$ValueAttribute,

        [Parameter(Mandatory=$true)]
        [string]$TypeName,

        [string]$Name
    )

    if (-not $Name)
    {
        $Name= $TypeName
    }

    switch($ValueAttribute)
    {
        ($true) { $Attribute = New-Object UncommonSense.CBreeze.ObjectModelBuilder.ValueAttribute -ArgumentList $TypeName, $Name } 
        ($false) { $Attribute = New-Object UncommonSense.CBreeze.ObjectModelBuilder.ReferenceAttribute -ArgumentList $TypeName, $Name }
    }
 
    $Item.Attributes.Add($Attribute) | Out-Null
    $Item
}

function Add-Enum
{
    param
    (
        [Parameter(Mandatory=$true,ValueFromPipeLine=$true)]
        [UncommonSense.CBreeze.ObjectModelBuilder.ObjectModel]$ObjectModel,

        [Parameter(Mandatory=$true)]
        [string]$Name,

        [string[]]$Values
    )

    $Enum = New-Object UncommonSense.CBreeze.ObjectModelBuilder.Enumeration -ArgumentList $Name

    if ($Values)
    {
        $Enum.Values.AddRange($Values)
    }

    $ObjectModel.Elements.Add($Enum)
}

Clear-Host
Add-Type -Path (Join-Path $PSScriptRoot UncommonSense.CBreeze.ObjectModelBuilder/Bin/Debug/UncommonSense.CBreeze.ObjectModelBuilder.dll)
Add-Type -Path (Join-Path $PSScriptRoot UncommonSense.CBreeze.ObjectModelWriter/Bin/Debug/UncommonSense.CBreeze.ObjectModelWriter.dll)

$ErrorActionPreference = 'Stop'

$ObjectModel = New-Object UncommonSense.CBreeze.ObjectModelBuilder.ObjectModel -ArgumentList 'UncommonSense.CBreeze.ObjectModelBuilder.Demo'
$ObjectModel | Add-Enum -Name AutoFormatType -Values Other,Amount,UnitAmount

$ObjectModel | Add-Item -Name TableField -Abstract | Add-Attribute -Name No -TypeName int -ValueAttribute| Add-Attribute -Name Name -TypeName string -ValueAttribute | Add-Attribute -Name Enabled -TypeName bool? -ValueAttribute

$ObjectModel | Add-Item -Name Object -Abstract | Add-Attribute -Name ID -TypeName int -ValueAttribute | Add-Attribute -Name Name -TypeName string -ValueAttribute
$ObjectModel | Add-Item -Name Table -BaseTypeName Object -CreateContainer | Add-Attribute -Name Fields -TypeName TableFields
$ObjectModel | Add-Item -Name Page -BaseTypeName Object -CreateContainer
$ObjectModel | Add-Item -Name Report -BaseTypeName Object -CreateContainer
$ObjectModel | Add-Item -Name Codeunit -BaseTypeName Object -CreateContainer
$ObjectModel | Add-Item -Name XmlPort -BaseTypeName Object -CreateContainer
$ObjectModel | Add-Item -Name Query -BaseTypeName Object -CreateContainer -ContainerName Queries
$ObjectModel | Add-Item -Name MenuSuite -BaseTypeName Object -CreateContainer 
$ObjectModel | Add-Item -Name Application | Add-Attribute -TypeName Tables | Add-Attribute -TypeName Pages |Add-Attribute -TypeName Reports | Add-Attribute -TypeName Codeunits | Add-Attribute -TypeName XmlPorts | Add-Attribute -TypeName Queries | Add-Attribute -TypeName MenuSuites

$CompilationUnits = [UncommonSense.CBreeze.ObjectModelWriter.ObjectModelWriter]::ToCompilationUnits($ObjectModel)

$CompilationUnits | ForEach-Object { $_.WriteTo([System.Console]::Out) } 