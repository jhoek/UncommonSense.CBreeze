Import-Module UncommonSense.ObjectModelBuilder -Force
Clear-Host

$ErrorActionPreference = 'Stop'
$ObjectModel = New-ObjectModel -Namespace 'UncommonSense.CBreeze.ObjectModelBuilder.Demo'
$PSDefaultParameterValues['Add-*:ObjectModel'] = $ObjectModel

Add-Item -Name Object -Abstract | `
    Add-Identifier -Name ID -TypeName int | `
    Add-Identifier -Name Name -TypeName string | `
    Out-Null

Add-Item -Name Table -BaseTypeName Object -CreateContainer | `
    Add-Property -TypeName MultiLanguageProperty -Name CaptionML | `
    Add-Property -TypeName FieldListProperty -Name DataCaptionFields | `
    Add-ChildNode -TypeName TableFields -Name Fields | `
    Out-Null

<#
Add-PropertyType -Name NullableBooleanProperty -InnerValue bool? -HasValueExpr Value.HasValue
Add-PropertyType -Name NullableDateTimeProperty -InnerValue DateTime? -HasValueExpr Value.HasValue 

Add-PropertyCollection -Name ObjectProperties | `
    Add-Property -Name DateTime -TypeName NullableDateTimeProperty | `
    Out-Null

Add-PropertyCollection -Name TableProperties | `
    Out-Null

Add-PropertyCollection -Name CodeunitProperties | `
    Out-Null

Add-Item -Name Application | `
    Add-ChildNode -TypeName Tables | `
    Add-ChildNode -TypeName Pages | `
    Add-ChildNode -TypeName Reports | `
    Add-ChildNode -TypeName Codeunits | `
    Add-ChildNode -TypeName XmlPorts | `
    Add-ChildNode -TypeName Queries | `
    Add-ChildNode -TypeName MenuSuite | `
    Out-Null


Add-Item -Name Table -BaseTypeName Object -CreateContainer | `
    Add-ChildNode -Name Properties -TypeName TableProperties | `
    Add-ChildNode -Name Fields -TypeName TableFields | `
    Out-Null

Add-Item -Name Page -BaseTypeName Object -CreateContainer | `
    Out-Null

Add-Item -Name Report -BaseTypeName Object -CreateContainer | `
    Out-Null

Add-Item -Name Codeunit -BaseTypeName Object -CreateContainer | `
    Add-ChildNode -Name Properties -TypeName CodeunitProperties | `
    Add-ChildNode -TypeName Code | ` 
    Out-Null

Add-Item -Name XmlPort -BaseTypeName Object -CreateContainer | `
    Out-Null

Add-Item -Name Query -BaseTypeName Object -CreateContainer -ContainerName Queries | `
    Out-Null

Add-Item -Name MenuSuite -BaseTypeName Object -CreateContainer | `
    Out-Null

Add-Item -Name TableField -Abstract -CreateContainer | `
    Add-Identifier -Name No -TypeName int | `
    Add-Identifier -Name Name -TypeName string | `
    Add-Attribute -Name Enabled -TypeName bool? | `
    Out-Null

Add-Item -Name BigIntegerTableField -BaseTypeName TableField | `
    Out-Null

Add-Item -Name BinaryTableField -BaseTypeName TableField | `
    Out-Null

Add-Item -Name BlobTableField -BaseTypeName TableField | `
    Out-Null

Add-Item -Name IntegerTableField -BaseTypeName TableField | `
    Add-ChildNode -Name Properties -TypeName IntegerTableFieldProperties | `
    Out-null

Add-Item -Name DecimalTableField -BaseTypeName TableField | `
    Add-ChildNode -Name Properties -Typename DecimalTableFieldProperties | `
    Out-Null

Add-Item -Name Variable -Abstract | `
    Add-Identifier -Name ID -TypeName int | `
    Add-Identifier -Name Name -TypeName string | `
    Out-Null

Add-Item -Name ActionVariable -BaseTypeName Variable | 
    Add-Attribute -Name Dimensions -TypeName string | `
    Out-Null

Add-Item -Name Parameter -Abstract | `
    Add-Identifier -Name ID -TypeName int | `
    Add-Attribute -TypeName string -Name Dimensions | `
    Out-Null

Add-Item -Name ActionParameter -BaseTypeName Parameter | `
    Out-Null

Add-Enum -Name AutoFormatType -Values Other,Amount,UnitAmount | Out-Null
Add-Enum -Name BlankNumbers -Values DontBlank,BlankNeg,BlankNegAndZero,BlankZero,BlankZeroAndPos,BlankPos | Out-Null
Add-Enum -Name BlobSubType -Values UserDefined,Bitmap,Memo | Out-Null
Add-Enum -Name FieldClass -Values Normal,FlowField,FlowFilter | Out-Null
Add-Enum -Name MinOccurs -Values Once,Zero | Out-Null
Add-Enum -Name MaxOccurs -Values Unbounded,Once | Out-Null
#>

$ObjectModel | ConvertTo-CompilationUnit -Path 'c:\users\jhoek\desktop\test'
#($ObjectModel | ConvertTo-CompilationUnit).WriteTo([System.Console]::Out)