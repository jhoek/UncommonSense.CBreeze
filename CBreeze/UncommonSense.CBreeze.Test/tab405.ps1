$PSDefaultParameterValues.{*CBreeze*:AutoCaption} = $true

Application {
    Table 405 'Change Log Entry' `
        -DateTime (Get-Date '09-09-14 12:00') `
        -VersionList NAVW18.00 `
        -LookupPageID 595 `
        -DrillDownPageID 595 `
        -CaptionML @{ NLD = 'Wijzigingslogbestandregel' } `
        -SubObjects {
            BigIntegerField 1 'Entry No.' -AutoIncrement $true -CaptionML @{ NLD = 'Volgnummer' }
            DateTimeField 2 'Date and Time' -CaptionML @{ NLD = 'Datum en tijd' } 
            TimeField 3 Time -CaptionML @{ NLD = 'Tijd' }
            CodeField 4 'User ID' `
                -DataLength 50 `
                -CaptionML @{ NLD = 'Gebruikers-id' } `
                -TestTableRelation $false `
                -OnLookup {
                    CodeunitVariable 1000 UserMgt 418
                    'UserMgt.LookupUserID("User ID");'
                } `
                -SubObjects { 
                    TableRelation -TableName User -FieldName 'User Name' 
                }
            IntegerField 5 'Table No.' `
                -CaptionML @{ NLD = 'Tabelnr.' } `
                -SubObjects { 
                    TableRelation -TableName AllObj -FieldName 'Object ID' -SubObjects {
                        TableRelationFilter 'Object Type' Const Table
                    }
                }
            TextField 6 'Table Caption' `
                -DataLength 250 `
                -FieldClass FlowField `
                -CaptionML @{ NLD = 'Tabelbijschrift' } `
                -CalcFormula (CalcFormula `
                    -Lookup 'AllObjWithCaption' `
                    -FieldName 'Object Caption' `
                    -Filters {
                        CalcFormulaFilter 'Object Type' Const Table
                        CalcFormulaFilter 'Object ID' Field 'Table No.'
                    })
            IntegerField 7 'Field No.' `
                -CaptionML @{ NLD = 'Veldnr.' } `
                -SubObjects {
                    TableRelation Field No. {
                        TableRelationFilter TableNo Field 'Table No.'
                    }
                }
            TextField 8 'Field Caption' `
                -DataLength 80 `
                -CaptionML @{ NLD = 'Veldbijschrift' } `
                -FieldClass FlowField `
                -CalcFormula (
                    CalcFormula -Lookup Field 'Field Caption' {
                        CalcFormulaFilter TableNo Field 'Table No.'
                        CalcFormulaFilter 'No.' Field 'Field No.'
                    }
                )
            OptionField 9
        }
} | Export -Path C:\Users\jhoek\Desktop\tab405.txt