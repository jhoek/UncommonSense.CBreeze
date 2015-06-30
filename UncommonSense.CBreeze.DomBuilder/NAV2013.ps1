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

Add-Enum -Name AutoFormatType -Values Other,Amount,UnitAmount | Out-Null
Add-Enum -Name BlankNumbers -Values DontBlank,BlankNeg,BlankNegAndZero,BlankZero,BlankZeroAndPos,BlankPos | Out-Null
Add-Enum -Name BlobSubType -Values UserDefined,Bitmap,Memo | Out-Null
Add-Enum -Name FieldClass -Values Normal,FlowField,FlowFilter | Out-Null
Add-Enum -Name MinOccurs -Values Once,Zero | Out-Null
Add-Enum -Name MaxOccurs -Values Unbounded,Once | Out-Null