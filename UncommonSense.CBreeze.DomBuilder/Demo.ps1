function Add-Item
{
    param
    (
        [Parameter(Mandatory=$true)]
        [string]$Name,

        [string]$BaseTypeName,

        [bool]$Abstract,

        [Switch]$CreateContainer
    )

    $Item = New-Object UncommonSense.CBreeze.ObjectModelBuilder.Item -ArgumentList $Name
    $Item.BaseTypeName = $BaseTypeName
    $Item.Abstract = $Abstract 
    $ObjectModel.Elements.Add($Item) | Out-Null

    if ($CreateContainer)
    {
        Add-Container -ItemTypeName $Item.Name | Out-Null
    }

    $Item
}

function Add-Container
{
    param
    (
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

Add-Type -Path (Join-Path $PSScriptRoot UncommonSense.CBreeze.ObjectModelBuilder/Bin/Debug/UncommonSense.CBreeze.ObjectModelBuilder.dll)
Add-Type -Path (Join-Path $PSScriptRoot UncommonSense.CBreeze.ObjectModelWriter/Bin/Debug/UncommonSense.CBreeze.ObjectModelWriter.dll)

$ErrorActionPreference = 'Stop'
$Namespace = "UncommonSense.CBreeze.ObjectModelBuilder.Demo"
$ObjectModel = New-Object UncommonSense.CBreeze.ObjectModelBuilder.ObjectModel -ArgumentList $Namespace

Add-Item -Name Object -Abstract $true | Add-Attribute -Name ID -TypeName int | Add-Attribute -Name Name -TypeName string 
Add-Item -Name Table -BaseTypeName Object -CreateContainer 
Add-Item -Name Page -BaseTypeName Object -CreateContainer
Add-Item -Name Report -BaseTypeName Object -CreateContainer
Add-Item -Name Codeunit -BaseTypeName Object -CreateContainer

Add-Item -Name Application | Add-Attribute -TypeName Tables | Add-Attribute -TypeName Pages |Add-Attribute -TypeName Reports | Add-Attribute -TypeName Codeunits

$CompilationUnits = [UncommonSense.CBreeze.ObjectModelWriter]::ToCompilationUnits($ObjectModel)

$CompilationUnits | ForEach-Object { $_.WriteTo([System.Console]::Out) } 