Clear-Host

Add-Type -Path (Join-Path $PSScriptRoot UncommonSense.CBreeze.ObjectModelBuilder/Bin/Debug/UncommonSense.CBreeze.ObjectModelBuilder.dll)
Add-Type -Path (Join-Path $PSScriptRoot UncommonSense.CBreeze.ObjectModelWriter/Bin/Debug/UncommonSense.CBreeze.ObjectModelWriter.dll)

. (Join-Path $PSScriptRoot Add-Item.ps1)
. (Join-Path $PSScriptRoot Add-Properties.ps1)
. (Join-Path $PSScriptRoot Add-Container.ps1)
. (Join-Path $PSScriptRoot Add-Attribute.ps1)
. (Join-Path $PSScriptRoot Add-Enum.ps1)
. (Join-Path $PSScriptRoot ConvertTo-CompilationUnit.ps1)

$ErrorActionPreference = 'Stop'
$ObjectModel = New-Object UncommonSense.CBreeze.ObjectModelBuilder.ObjectModel -ArgumentList 'UncommonSense.CBreeze.ObjectModelBuilder.Demo'
$PSDefaultParameterValues["Add-*:ObjectModel"] = $ObjectModel

Add-Enum -Name AutoFormatType -Values Other,Amount,UnitAmount 
Add-Enum -Name BlankNumbers -Values DontBlank,BlankNeg,BlankNegAndZero,BlankZero,BlankZeroAndPos,BlankPos 
Add-Enum -Name BlobSubType -Values UserDefined,Bitmap,Memo 
Add-Enum -Name FieldClass -Values Normal,FlowField,FlowFilter
Add-Enum -Name MinOccurs -Values Once,Zero 
Add-Enum -Name MaxOccurs -Values Unbounded,Once 

Add-Item -Name TableField -Abstract | Add-Attribute -Name No -TypeName int -ValueAttribute| Add-Attribute -Name Name -TypeName string -ValueAttribute | Add-Attribute -Name Enabled -TypeName bool? -ValueAttribute | Out-Null
Add-Item -Name IntegerTableField -BaseTypeName TableField | Add-Attribute -Name Properties -TypeName IntegerTableFieldProperties | Out-null
Add-Item -Name DecimalTableField -BaseTypeName TableField | Out-Null

Add-Item -Name Application | Add-Attribute -TypeName Tables | Add-Attribute -TypeName Pages |Add-Attribute -TypeName Reports | Add-Attribute -TypeName Codeunits | Add-Attribute -TypeName XmlPorts | Add-Attribute -TypeName Queries | Add-Attribute -TypeName MenuSuites| out-null
Add-Item -Name Object -Abstract | Add-Attribute -Name ID -TypeName int -ValueAttribute | Add-Attribute -Name Name -TypeName string -ValueAttribute | out-null
Add-Item -Name Table -BaseTypeName Object -CreateContainer | Add-Attribute -Name Fields -TypeName TableFields | out-null
Add-Item -Name Page -BaseTypeName Object -CreateContainer | out-null
Add-Item -Name Report -BaseTypeName Object -CreateContainer| out-null
Add-Item -Name Codeunit -BaseTypeName Object -CreateContainer| Add-Attribute -Name Properties -TypeName CodeunitProperties | out-null
Add-Item -Name XmlPort -BaseTypeName Object -CreateContainer| out-null
Add-Item -Name Query -BaseTypeName Object -CreateContainer -ContainerName Queries| out-null
Add-Item -Name MenuSuite -BaseTypeName Object -CreateContainer | out-null

Add-Properties -Name TableProperties 
Add-Properties -Name CodeunitProperties

Add-Item -Name Parameter -Abstract | Add-Attribute -TypeName string -Name Dimensions | out-null
Add-Item -Name ActionParameter -BaseTypeName Parameter | OUt-Null

($ObjectModel | ConvertTo-CompilationUnit).WriteTo([System.Console]::Out)