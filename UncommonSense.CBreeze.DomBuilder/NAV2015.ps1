Import-Module UncommonSense.ObjectModelBuilder -Force
Clear-Host

$ErrorActionPreference = 'Stop'
$ObjectModel = New-ObjectModel -Namespace 'UncommonSense.CBreeze.ObjectModelBuilder.Demo'
$PSDefaultParameterValues['Add-*:ObjectModel'] = $ObjectModel

Add-Enum -Name AutoFormatType -Values Other,Amount,UnitAmount 
Add-Enum -Name BlankNumbers -Values DontBlank,BlankNeg,BlankNegAndZero,BlankZero,BlankZeroAndPos,BlankPos 
Add-Enum -Name BlobSubType -Values UserDefined,Bitmap,Memo 
Add-Enum -Name FieldClass -Values Normal,FlowField,FlowFilter
Add-Enum -Name MinOccurs -Values Once,Zero 
Add-Enum -Name MaxOccurs -Values Unbounded,Once

Add-Item -Name Application | `
    Add-Attribute -TypeName Tables -AttributeType Reference | `
    Add-Attribute -TypeName Pages -AttributeType Reference | `
    Add-Attribute -TypeName Reports -AttributeType Reference | `
    Add-Attribute -TypeName Codeunits -AttributeType Reference | `
    Add-Attribute -TypeName XmlPorts -AttributeType Reference | `
    Add-Attribute -TypeName Queries -AttributeType Reference | `
    Add-Attribute -TypeName MenuSuite -AttributeType Reference | `
    Out-Null

Add-Item -Name Object -Abstract | `
    Add-Attribute -Name ID -TypeName int -AttributeType Value | `
    Add-Attribute -Name Name -TypeName string -AttributeType Value | `
    Out-Null

Add-Item -Name Table -BaseTypeName Object -CreateContainer | `
    Add-Attribute -Name Fields -TypeName TableFields -AttributeType Reference | `
    Out-Null

Add-Item -Name Page -BaseTypeName Object -CreateContainer | out-null
Add-Item -Name Report -BaseTypeName Object -CreateContainer| out-null
Add-Item -Name Codeunit -BaseTypeName Object -CreateContainer| Add-Attribute -Name Properties -TypeName CodeunitProperties | out-null
Add-Item -Name XmlPort -BaseTypeName Object -CreateContainer| out-null
Add-Item -Name Query -BaseTypeName Object -CreateContainer -ContainerName Queries| out-null
Add-Item -Name MenuSuite -BaseTypeName Object -CreateContainer | out-null

Add-Item -Name TableField -Abstract | Add-Attribute -Name No -TypeName int -ValueAttribute| Add-Attribute -Name Name -TypeName string -ValueAttribute | Add-Attribute -Name Enabled -TypeName bool? -ValueAttribute | Out-Null
Add-Item -Name BigIntegerTableField -BaseTypeName TableField -PassThru:$false
Add-Item -Name BinaryTableField -BaseTypeName TableField -PassThru:$false
Add-Item -Name BlobTableField -BaseTypeName TableField -PassThru:$false
Add-Item -Name IntegerTableField -BaseTypeName TableField | Add-Attribute -Name Properties -TypeName IntegerTableFieldProperties | Out-null
Add-Item -Name DecimalTableField -BaseTypeName TableField | Add-Attribute -Name Properties -Typename DecimalTableFieldProperties | Out-Null

Add-Item -Name Variable -Abstract | Add-Attribute -Name ID -TypeName int -ValueAttribute | Add-Attribute -Name Name -TypeName string -ValueAttribute | Out-Null
Add-Item -Name ActionVariable -BaseTypeName Variable | Add-Attribute -Name Dimensions -TypeName string -ValueAttribute | Out-Null

Add-Properties -Name TableProperties 
Add-Properties -Name CodeunitProperties

Add-Item -Name Parameter -Abstract | Add-Attribute -TypeName string -Name Dimensions | out-null
Add-Item -Name ActionParameter -BaseTypeName Parameter | OUt-Null

($ObjectModel | ConvertTo-CompilationUnit).WriteTo([System.Console]::Out)