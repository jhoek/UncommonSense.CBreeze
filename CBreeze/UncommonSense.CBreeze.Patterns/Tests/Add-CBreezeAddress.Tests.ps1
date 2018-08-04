Describe 'Add-CBreezeAddress' {
    BeforeEach {
        $Range = [System.Linq.Enumerable]::Range(50000, 100)
        $Application = New-CBreezeApplication
        $Table = $Application | Add-CBreezeObject -Type Table -ID 50000 -Name Demo
        $CardPage = $Application | Add-CBreezeObject -Type Page -ID 50000 -Name 'Demo Card' -SourceTable $Table.ID -PageType Card
        $ListPage = $Application | Add-CBreezeObject -Type Page -ID 50001 -Name 'Demo List' -SourceTable $Table.ID -PageType List
        $Codeunit = $Application | Add-CBreezeObject -Type Codeunit -ID 50000 -Name 'Demo' 
    }

    It 'Adds address fields to the tables and pages' {
        $AddAddressResult = $Table | Add-CBreezeAddress -Pages $CardPage, $ListPage -Range $Range -PassThru 

        $AddAddressResult.Fields.Address.ID | Should Be 10
        $AddAddressResult.Fields.Address.Type | Should Be Text
        $AddAddressResult.Fields.Address.DataLength | Should Be 50
        $AddAddressResult.Fields.Address.Name | Should Be Address
        $AddAddressResult.Fields.Address.Properties.CaptionML['ENU'] | Should Be Address

        $AddAddressResult.Fields.Address2.ID | Should Be 11
        $AddAddressResult.Fields.Address2.Type | Should Be Text
        $AddAddressResult.Fields.Address2.DataLength | Should Be 50
        $AddAddressResult.Fields.Address2.Name | Should Be 'Address 2'
        $AddAddressResult.Fields.Address2.Properties.CaptionML['ENU'] | Should Be 'Address 2'

        $AddAddressResult.Fields.PostCode.ID | Should Be 12
        $AddAddressResult.Fields.PostCode.Type | Should Be Code
        $AddAddressResult.Fields.PostCode.DataLength | Should Be 20
        $AddAddressResult.Fields.PostCode.Name | Should Be 'Post Code'
        $AddAddressResult.Fields.PostCode.Properties.CaptionML['ENU'] | Should Be 'Post Code'
        $AddAddressResult.Fields.PostCode.Properties.TestTableRelation | Should Be $false
        $AddAddressResult.Fields.PostCode.Properties.ValidateTableRelation | Should Be $false
        $AddAddressResult.Fields.PostCode.Properties.TableRelation.Count | Should Be 2

        $AddAddressResult.Fields.PostCode.Properties.TableRelation[0].TableName | Should Be 'Post Code'
        $AddAddressResult.Fields.PostCode.Properties.TableRelation[0].FieldName | Should Be Code
        $AddAddressResult.Fields.PostCode.Properties.TableRelation[0].Conditions.Count | Should Be 1
        $AddAddressResult.Fields.PostCode.Properties.TableRelation[0].Conditions[0].FieldName | Should Be $AddAddressResult.Fields.CountryRegionCode.Name
        $AddAddressResult.Fields.PostCode.Properties.TableRelation[0].Conditions[0].Type | Should Be Const
        $AddAddressResult.Fields.PostCode.Properties.TableRelation[0].Conditions[0].Value | Should Be ''''''
        $AddAddressResult.Fields.PostCode.Properties.TableRelation[0].TableFilter.Count | Should Be 0

        $AddAddressResult.Fields.PostCode.Properties.TableRelation[1].TableName | Should Be 'Post Code'
        $AddAddressResult.Fields.PostCode.Properties.TableRelation[1].FieldName | Should Be Code
        $AddAddressResult.Fields.PostCode.Properties.TableRelation[1].Conditions.Count | Should Be 1
        $AddAddressResult.Fields.PostCode.Properties.TableRelation[1].Conditions[0].FieldName | Should Be $AddAddressResult.Fields.CountryRegionCode.Name
        $AddAddressResult.Fields.PostCode.Properties.TableRelation[1].Conditions[0].Type | Should Be Filter
        $AddAddressResult.Fields.PostCode.Properties.TableRelation[1].Conditions[0].Value | Should Be '<>'''''
        $AddAddressResult.Fields.PostCode.Properties.TableRelation[1].TableFilter.Count | Should Be 1
        $AddAddressResult.Fields.PostCode.Properties.TableRelation[1].TableFilter[0].FieldName | Should Be 'Country/Region Code'
        $AddAddressResult.Fields.PostCode.Properties.TableRelation[1].TableFilter[0].Type | Should Be Field
        $AddAddressResult.Fields.PostCode.Properties.TableRelation[1].TableFilter[0].Value | Should Be $AddAddressResult.Fields.CountryRegionCode.Name

        $AddAddressResult.Fields.PostCode.Properties.OnValidate.Variables.Count | Should Be 1
        $AddAddressResult.Fields.PostCode.Properties.OnValidate.Variables[50000].Name | Should Be PostCode
        $AddAddressResult.Fields.PostCode.Properties.OnValidate.Variables[50000].Type | Should Be Record
        $AddAddressResult.Fields.PostCode.Properties.OnValidate.Variables[50000].SubType | Should Be ([UncommonSense.CBreeze.Core.BaseApp+TableIDs]::Post_Code)

        $AddAddressResult.Fields.PostCode.Properties.OnValidate.CodeLines.Count | Should Be 1
        # TODO: Verify code lines

        $AddAddressResult.Fields.City.ID | Should Be 13
        $AddAddressResult.Fields.City.Type | Should Be Text
        $AddAddressResult.Fields.City.DataLength | Should Be 30
        $AddAddressResult.Fields.City.Name | Should Be City
        $AddAddressResult.Fields.City.Properties.CaptionML['ENU'] | Should Be City
        $AddAddressResult.Fields.City.Properties.TestTableRelation | Should Be $false
        $AddAddressResult.Fields.City.Properties.ValidateTableRelation | Should Be $false
        $AddAddressResult.Fields.City.Properties.TableRelation.Count | Should Be 2

        $AddAddressResult.Fields.City.Properties.TableRelation[0].TableName | Should Be 'Post Code'
        $AddAddressResult.Fields.City.Properties.TableRelation[0].FieldName | Should Be City
        $AddAddressResult.Fields.City.Properties.TableRelation[0].Conditions.Count | Should Be 1
        $AddAddressResult.Fields.City.Properties.TableRelation[0].Conditions[0].FieldName | Should Be $AddAddressResult.Fields.CountryRegionCode.Name
        $AddAddressResult.Fields.City.Properties.TableRelation[0].Conditions[0].Type | Should Be Const
        $AddAddressResult.Fields.City.Properties.TableRelation[0].Conditions[0].Value | Should Be ''''''
        $AddAddressResult.Fields.City.Properties.TableRelation[0].TableFilter.Count | Should Be 0

        $AddAddressResult.Fields.City.Properties.TableRelation[1].TableName | Should Be 'Post Code'
        $AddAddressResult.Fields.City.Properties.TableRelation[1].FieldName | Should Be City
        $AddAddressResult.Fields.City.Properties.TableRelation[1].Conditions.Count | Should Be 1
        $AddAddressResult.Fields.City.Properties.TableRelation[1].Conditions[0].FieldName | Should Be $AddAddressResult.Fields.CountryRegionCode.Name
        $AddAddressResult.Fields.City.Properties.TableRelation[1].Conditions[0].Type | Should Be Filter
        $AddAddressResult.Fields.City.Properties.TableRelation[1].Conditions[0].Value | Should Be '<>'''''
        $AddAddressResult.Fields.City.Properties.TableRelation[1].TableFilter.Count | Should Be 1
        $AddAddressResult.Fields.City.Properties.TableRelation[1].TableFilter[0].FieldName | Should Be 'Country/Region Code'
        $AddAddressResult.Fields.City.Properties.TableRelation[1].TableFilter[0].Type | Should Be Field
        $AddAddressResult.Fields.City.Properties.TableRelation[1].TableFilter[0].Value | Should Be $AddAddressResult.Fields.CountryRegionCode.Name

        $AddAddressResult.Fields.City.Properties.OnValidate.Variables.Count | Should Be 1
        $AddAddressResult.Fields.City.Properties.OnValidate.Variables[50000].Name | Should Be PostCode
        $AddAddressResult.Fields.City.Properties.OnValidate.Variables[50000].Type | Should Be Record
        $AddAddressResult.Fields.City.Properties.OnValidate.Variables[50000].SubType | Should Be ([UncommonSense.CBreeze.Core.BaseApp+TableIDs]::Post_Code)

        $AddAddressResult.Fields.City.Properties.OnValidate.CodeLines.Count | Should Be 1
        # TODO: Verify code lines

        $AddAddressResult.Fields.County.ID | Should Be 14
        $AddAddressResult.Fields.County.Type | Should Be Text
        $AddAddressResult.Fields.County.DataLength | Should Be 30
        $AddAddressResult.Fields.County.Name | Should Be County
        $AddAddressResult.Fields.County.Properties.CaptionML['ENU'] | Should Be County

        $AddAddressResult.Fields.CountryRegionCode.ID | Should Be 15
        $AddAddressResult.Fields.CountryRegionCode.Type | Should Be Code
        $AddAddressResult.Fields.CountryRegionCode.DataLength | Should Be 10
        $AddAddressResult.Fields.CountryRegionCode.Name | Should Be 'Country/Region Code'
        $AddAddressResult.Fields.CountryRegionCode.Properties.CaptionML['ENU'] | Should Be 'Country/Region Code'
        $AddAddressResult.Fields.CountryRegionCode.Properties.TableRelation.Count | Should Be 1
        $AddAddressResult.Fields.CountryRegionCode.Properties.TableRelation[0].TableName | Should Be 'Country/Region'
        $AddAddressResult.Fields.CountryRegionCode.Properties.TableRelation[0].FieldName | Should Be $null
        $AddAddressResult.Fields.CountryRegionCode.Properties.TableRelation[0].Conditions.Count | Should Be 0
        $AddAddressResult.Fields.CountryRegionCode.Properties.TableRelation[0].TableFilter.Count | Should Be 0

        $Group = $CardPage | Get-CBreezePageControlGroup -GroupCaption General -Range $Range
        $Repeater = $ListPage | Get-CBreezePageControlGroup -GroupType Repeater -Range $Range

        $AddAddressResult.Controls.Address[$CardPage].ParentPageControl | Should Be $Group
        $AddAddressResult.Controls.Address2[$CardPage].ParentPageControl | Should Be $Group
        $AddAddressResult.Controls.PostCode[$CardPage].ParentPageControl | Should Be $Group
        $AddAddressResult.Controls.City[$CardPage].ParentPageControl | Should Be $Group
        $AddAddressResult.Controls.CountryRegionCode[$CardPage].ParentPageControl | Should Be $Group

        $AddAddressResult.Controls.Address[$CardPage].Type | Should Be Field
        $AddAddressResult.Controls.Address2[$CardPage].Type | Should Be Field
        $AddAddressResult.Controls.PostCode[$CardPage].Type | Should Be Field
        $AddAddressResult.Controls.City[$CardPage].Type | Should Be Field
        $AddAddressResult.Controls.CountryRegionCode[$CardPage].Type | Should Be Field

        $AddAddressResult.Controls.Address[$CardPage].ID | Should Be 3
        $AddAddressResult.Controls.Address2[$CardPage].ID | Should Be 4
        $AddAddressResult.Controls.PostCode[$CardPage].ID | Should Be 5
        $AddAddressResult.Controls.City[$CardPage].ID | Should Be 6
        $AddAddressResult.Controls.CountryRegionCode[$CardPage].ID | Should Be 7

        $AddAddressResult.Controls.Address[$CardPage].Properties.SourceExpr | Should Be $AddAddressResult.Fields.Address.QuotedName
        $AddAddressResult.Controls.Address2[$CardPage].Properties.SourceExpr | Should Be $AddAddressResult.Fields.Address2.QuotedName
        $AddAddressResult.Controls.PostCode[$CardPage].Properties.SourceExpr | Should Be $AddAddressResult.Fields.PostCode.QuotedName
        $AddAddressResult.Controls.City[$CardPage].Properties.SourceExpr | Should Be $AddAddressResult.Fields.City.QuotedName
        $AddAddressResult.Controls.CountryRegionCode[$CardPage].Properties.SourceExpr | Should Be $AddAddressResult.Fields.CountryRegionCode.QuotedName

        $AddAddressResult.Controls.PostCode[$CardPage].Properties.Importance | Should Be Promoted

        $AddAddressResult.Controls.PostCode[$ListPage].Type | Should Be Field
        $AddAddressResult.Controls.CountryRegionCode[$ListPage].Type | Should Be Field

        $AddAddressResult.Controls.PostCode[$ListPage].ID | Should Be 3
        $AddAddressResult.Controls.CountryRegionCode[$ListPage].ID | Should Be 4

        $AddAddressResult.Controls.PostCode[$ListPage].Properties.SourceExpr | Should Be $AddAddressResult.Fields.PostCode.QuotedName
        $AddAddressResult.Controls.CountryRegionCode[$ListPage].Properties.SourceExpr | Should Be $AddAddressResult.Fields.CountryRegionCode.QuotedName
    }

    It 'Allows names to be prefixed' {
        $Prefix = "Prefix "

        $AddAddressResult = $Table | Add-CBreezeAddress -Pages $CardPage, $ListPage -FormatAddressCodeunit $Codeunit -Range $Range -Prefix $Prefix -PassThru 

        $AddAddressResult.Fields.Address.Name | Should Be "$($Prefix)Address"
        $AddAddressResult.Fields.Address2.Name | Should Be "$($Prefix)Address 2"
        $AddAddressResult.Fields.PostCode.Name | Should Be "$($Prefix)Post Code"
        $AddAddressResult.Fields.City.Name | Should Be "$($Prefix)City"
        $AddAddressResult.Fields.County.Name | Should Be "$($Prefix)County"
        $AddAddressResult.Fields.CountryRegionCode.Name | Should Be "$($Prefix)Country/Region Code"

        $AddAddressResult.FormatFunction.Name | Should Be ([UncommonSense.CBreeze.Core.StringExtensionMethods]::MakeVariableName("Demo $Prefix"))
    }

    It 'Adds an address formatting function' {
        $AddAddressResult = $Table | Add-CBreezeAddress -FormatAddressCodeunit $Codeunit -Range $Range -PassThru

        $AddAddressResult.FormatFunction.ID | Should Be 1
        $AddAddressResult.FormatFunction.Name | Should Be Demo

        $AddAddressResult.FormatFunction.Parameters.Count | Should Be 2
        $AddAddressResult.FormatFunction.Parameters[1].Var | Should Be $true
        $AddAddressResult.FormatFunction.Parameters[1].Name | Should Be AddrArray
        $AddAddressResult.FormatFunction.Parameters[1].Type | Should Be Text
        $AddAddressResult.FormatFunction.Parameters[1].DataLength | Should Be 50
        $AddAddressResult.FormatFunction.Parameters[1].Dimensions | Should Be 8

        $AddAddressResult.FormatFunction.Parameters[2].Var | Should Be $true
        $AddAddressResult.FormatFunction.Parameters[2].Name | Should Be $Table.VariableName
        $AddAddressResult.FormatFunction.Parameters[2].Type | Should Be Record
        $AddAddressResult.FormatFunction.Parameters[2].SubType | Should Be $Table.ID

        $AddAddressResult.FormatFunction.CodeLines.Count | Should Be 4
        # TODO: Verify code lines
    }

    It 'Allows the card page group caption to be overriden' {
        $GroupCaption = "ABCDEF"
        $AddAddressResult = $Table | Add-CBreezeAddress -Pages $CardPage, $ListPage -Range $Range -GroupCaption $GroupCaption -PassThru
        $AddAddressResult.Controls.Address[$CardPage].ParentPageControl.Properties.CaptionML['ENU'] | Should Be $GroupCaption
    }

    It 'Allows the card page group position to be overridden' {
        $FirstGroup = $CardPage | Get-CBreezePageControlGroup -GroupType Group -Range $Range -Position LastWithinContainer
        $AddAddressResult = $Table | Add-CBreezeAddress -Pages $CardPage, $ListPage -Range $Range -CardGroupPosition LastWithinContainer -PassThru
        $AddAddressResult.Controls.Address[$CardPage].ParentPageControl.Index | Should BeGreaterThan $FirstGroup.Index
    }
}