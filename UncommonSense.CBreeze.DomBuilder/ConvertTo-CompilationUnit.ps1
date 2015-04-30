function ConvertTo-CompilationUnit
{
    Param
    (
        [Parameter(Mandatory=$true,ValueFromPipeline=$true)]
        [UncommonSense.CBreeze.ObjectModelBuilder.ObjectModel]$ObjectModel
    )

    $ObjectModel.Elements | Where-Object { $_ -is [UncommonSense.CBreeze.ObjectModelBuilder.Item] } | Convert-ItemToCompilationUnit
    $ObjectModel.Elements | Where-Object { $_ -is [UncommonSense.CBreeze.ObjectModelBuilder.Container] } | Convert-ContainerToCompilationUnit
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
        $Class = New-Object -TypeName UncommonSense.CSharp.Class -ArgumentList [UncommonSense.CSharp.Visibility]::Public, $Item.Name, $Item.BaseTypeName, @()
        $Namespace = New-Object -TypeName UncommonSense.CSharp.Namespace -ArgumentList $Item.ObjectModel.Namespace, $Class
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
$ObjectModel.Elements.Add($Item)

$ObjectModel | ConvertTo-CompilationUnit