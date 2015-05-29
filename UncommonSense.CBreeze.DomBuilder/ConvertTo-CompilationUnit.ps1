function ConvertTo-CompilationUnit
{
    Param
    (
        [Parameter(Mandatory=$true,ValueFromPipeline=$true)]
        [UncommonSense.CBreeze.ObjectModelBuilder.ObjectModel]$ObjectModel
    )

    $ObjectModel.Elements | Where-Object { $_ -is [UncommonSense.CBreeze.ObjectModelBuilder.Item] } | Convert-ItemToCompilationUnit
    $ObjectModel.Elements | Where-Object { $_ -is [UncommonSense.CBreeze.ObjectModelBuilder.Properties] } | Convert-PropertiesToCompilationUnit
    $ObjectModel.Elements | Where-Object { $_ -is [UncommonSense.CBreeze.ObjectModelBuilder.Container] } | Convert-ContainerToCompilationUnit
    $ObjectModel.Elements | Where-Object { $_ -is [UncommonSense.CBreeze.ObjectModelBuilder.Enumeration] } | Convert-EnumerationToCompilationUnit
}

function Convert-ItemToCompilationUnit
{
    param
    (
        [Parameter(Mandatory=$true,ValueFromPipeline=$true)]
        [UncommonSense.CBreeze.ObjectModelBuilder.Item[]]$Item
    )

    Process
    {
        $Public = [UncommonSense.CSharp.Visibility]::Public
        $Class = New-Object -TypeName UncommonSense.CSharp.Class -ArgumentList $Public , $Item.Name, $Item.BaseTypeName, @()
        $Class.Abstract = $Item.Abstract
        $Namespace = New-Object -TypeName UncommonSense.CSharp.Namespace -ArgumentList $Item.ObjectModel.Namespace, $Class
        $CompilationUnit = New-Object UncommonSense.CSharp.CompilationUnit -ArgumentList $Namespace

        $CompilationUnit
    }
}

function Convert-PropertiesToCompilationUnit
{
    param
    (
        [Parameter(Mandatory=$true,ValueFromPipeLine=$true)]
        [UncommonSense.CBreeze.ObjectModelBuilder.Properties[]]$Properties
    )

    Process
    {
        $Public = [UncommonSense.CSharp.Visibility]::Public
        $Class = New-Object -TypeName UncommonSense.CSharp.Class -ArgumentList $Public, $Properties.Name, "Properties", @()
    
        $Namespace = New-Object -TypeName UncommonSense.CSharp.Namespace -ArgumentList $Properties.ObjectModel.Namespace, $Class
        $CompilationUnit = New-Object UncommonSense.CSharp.CompilationUnit -ArgumentList $Namespace
        
        $CompilationUnit    
    }
}

function Convert-ContainerToCompilationUnit
{
    param
    (
        [Parameter(Mandatory=$true,ValueFromPipeLine=$true)]
        [UncommonSense.CBreeze.ObjectModelBuilder.Container[]]$Container
    )

    Process
    {
        $Public = [UncommonSense.CSharp.Visibility]::Public
        $Class = New-Object -TypeName UncommonSense.CSharp.Class -ArgumentList $Public, $Container.Name, $null, @()
        $Namespace = New-Object -TypeName UncommonSense.CSharp.Namespace -ArgumentList $Container.ObjectModel.Namespace, $Class
        $CompilationUnit = New-Object UncommonSense.CSharp.CompilationUnit -ArgumentList $Namespace

        $CompilationUnit
    }
}

function Convert-EnumerationToCompilationUnit
{
    param
    (
        [Parameter(Mandatory=$true,ValueFromPipeLine=$true)]
        [UncommonSense.CBreeze.ObjectModelBuilder.Enumeration[]]$Enumeration
    )

    Process
    {
        $Public = [UncommonSense.CSharp.Visibility]::Public
        $None = [UncommonSense.CSharp.IntegralType]::None
        $Values = ($Enumeration.Values | ForEach-Object { New-Object -TypeName UncommonSense.CSharp.EnumValue -ArgumentList $_ })
        $Enum = New-Object -TypeName UncommonSense.CSharp.Enum -ArgumentList $Public, $Enumeration.Name, $None, $Values
        $Namespace = New-Object -Typename UncommonSense.CSharp.Namespace -ArgumentList $Enumeration.ObjectModel.Namespace, $Enum
        $CompilationUnit = New-Object UncommonSense.CSharp.CompilationUnit -ArgumentList $Namespace

        $CompilationUnit
    }
}

Clear-Host
Add-Type -Path C:\Users\jhoek\GitHub\UncommonSense.CSharp\UncommonSense.CSharp\bin\Debug\UncommonSense.CSharp.dll
Add-Type -Path C:\Users\jhoek\GitHub\UncommonSense.CBreeze\UncommonSense.CBreeze.DomBuilder\UncommonSense.CBreeze.ObjectModelBuilder\bin\Debug\UncommonSense.CBreeze.ObjectModelBuilder.dll

$ErrorActionPreference = 'Stop'
$ObjectModel = New-Object -TypeName UncommonSense.CBreeze.ObjectmodelBuilder.ObjectModel -ArgumentList MyNamespace
$Item = New-Object -TypeName UncommonSense.CBreeze.ObjectModelBuilder.Item -ArgumentList "MyItem" 
$Item.Abstract = $true
$ObjectModel.Elements.Add($Item) | Out-Null

($ObjectModel | ConvertTo-CompilationUnit).WriteTo([System.Console]::Out)