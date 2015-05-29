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

Clear-Host
Add-Type -Path (Join-Path $PSScriptRoot UncommonSense.CBreeze.ObjectModelBuilder/Bin/Debug/UncommonSense.CBreeze.ObjectModelBuilder.dll)
Add-Type -Path (Join-Path $PSScriptRoot UncommonSense.CBreeze.ObjectModelWriter/Bin/Debug/UncommonSense.CBreeze.ObjectModelWriter.dll)

$ErrorActionPreference = 'Stop'
$ObjectModel = New-Object UncommonSense.CBreeze.ObjectModelBuilder.ObjectModel -ArgumentList 'UncommonSense.CBreeze.ObjectModelBuilder.Demo'
$PSDefaultParameterValues["Add-*:ObjectModel"] = $ObjectModel

Add-Enum -Name AutoFormatType -Values Other,Amount,UnitAmount 
Add-Enum -Name BlankNumbers -Values DontBlank,BlankNeg,BlankNegAndZero,BlankZero,BlankZeroAndPos,BlankPos 
Add-Enum -Name BlobSubType -Values UserDefined,Bitmap,Memo 
Add-Enum -Name MinOccurs -Values Once,Zero 
Add-Enum -Name MaxOccurs -Values Unbounded,Once 

Add-Item -Name TableField -Abstract | Add-Attribute -Name No -TypeName int -ValueAttribute| Add-Attribute -Name Name -TypeName string -ValueAttribute | Add-Attribute -Name Enabled -TypeName bool? -ValueAttribute | Out-Null
Add-Item -Name IntegerTableField -BaseTypeName TableField | Out-null
Add-Item -Name DecimalTableField -BaseTypeName TableField | Out-Null

Add-Item -Name Application | Add-Attribute -TypeName Tables | Add-Attribute -TypeName Pages |Add-Attribute -TypeName Reports | Add-Attribute -TypeName Codeunits | Add-Attribute -TypeName XmlPorts | Add-Attribute -TypeName Queries | Add-Attribute -TypeName MenuSuites| out-null
Add-Item -Name Object -Abstract | Add-Attribute -Name ID -TypeName int -ValueAttribute | Add-Attribute -Name Name -TypeName string -ValueAttribute | out-null
Add-Item -Name Table -BaseTypeName Object -CreateContainer | Add-Attribute -Name Fields -TypeName TableFields | out-null
Add-Item -Name Page -BaseTypeName Object -CreateContainer | out-null
Add-Item -Name Report -BaseTypeName Object -CreateContainer| out-null
Add-Item -Name Codeunit -BaseTypeName Object -CreateContainer| out-null
Add-Item -Name XmlPort -BaseTypeName Object -CreateContainer| out-null
Add-Item -Name Query -BaseTypeName Object -CreateContainer -ContainerName Queries| out-null
Add-Item -Name MenuSuite -BaseTypeName Object -CreateContainer | out-null

Add-Properties -Name TableProperties 

Add-Item -Name Parameter -Abstract | Add-Attribute -TypeName string -Name Dimensions | out-null
Add-Item -Name ActionParameter -BaseTypeName Parameter | OUt-Null

($ObjectModel | ConvertTo-CompilationUnit).WriteTo([System.Console]::Out)

#$CompilationUnits = [UncommonSense.CBreeze.ObjectModelWriter.ObjectModelWriter]::ToCompilationUnits($ObjectModel)
#$CompilationUnits | ForEach-Object { $_.WriteTo([System.Console]::Out) } 
#$ObjectModel.Elements 


