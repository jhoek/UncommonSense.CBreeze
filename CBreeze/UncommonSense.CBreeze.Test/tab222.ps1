using namespace 'UncommonSense.CBreeze.Core'

$PSDefaultParameterValues['*CBreeze*:Auto*Caption'] = $true

Table 222 'Ship-to Address' `
    -DateTime (Get-Date '25-10-2016 12:00') `
    -VersionList 'NAVW110.00,NAVNL10.00' `
    -CaptionML @{ NLD = 'Verzendadres' } `
    -LookupPageID 301 `
    -DataCaptionFields 'Customer No.', Name, Code `
    -OnInsert { 'Cust.GET("Customer No.");'; 'Name := Cust.Name;'} `
    -OnModify { '"Last Date Modified" := TODAY;' } `
    -OnRename { '"Last Date Modified" := TODAY;' } `
    -SubObjects {
        CodeField 1 'Customer No.' `
            -DataLength 20 `
            -NotBlank $true `
            -CaptionML @{ NLD = 'Klantnr.' } `
            -SubObjects { TableRelation Customer }
        CodeField 2 Code `
            -NotBlank $true `
            -CaptionML @{ NLD = 'Code' }
        TextField 3 Name `
            -DataLength 50 `
            -CaptionML @{ NLD = 'Naam' }
        TextField 4 'Name 2' `
            -DataLength 50 `
            -CaptionML @{ NLD = 'Naam 2' }
        TextField 5 Address `
            -DataLength 50 `
            -CaptionML @{ NLD = 'Adres' } `
            -OnValidate {
                'PostCodeMgt.FindStreetNameFromAddress('
                '  Address,"Address 2","Post Code",City,"Country/Region Code","Phone No.","Fax No.");' 
            }
        TextField 6 'Address 2' `
            -DataLength 50 `
            -CaptionML @{ NLD = 'Adres 2' }
        TextField 7 City `
            -CaptionML @{ NLD = 'Plaats' } `
            -ValidateTableRelation $false `
            -TestTableRelation $false `
            -OnValidate { 'PostCode.ValidateCity(City,"Post Code",County,"Country/Region Code",(CurrFieldNo <> 0) AND GUIALLOWED);' } `
            -SubObjects {
                TableRelation 'Post Code' City {
                    TableRelationCondition 'Country/Region Code' Const ''
                }
                TableRelation 'Post Code' City {
                    TableRelationCondition 'Country/Region Code' Filter "<>''"
                    TableRelationFilter 'Country/Region Code' Field 'Country/Region Code'
                }
            }
        TextField 8 Contact `
            -DataLength 50 `
            -CaptionML @{ NLD = 'Contact' }
        TextField 9 'Phone No.' `
            -ExtendedDatatype PhoneNo `
            -CaptionML @{ NLD = 'Telefoon' }
        TextField 10 'Telex No.' `
            -CaptionML @{ NLD = 'Telex'}
        CodeField 30 'Shipment Method Code' `
            -CaptionML @{ NLD = 'Verzendwijze' } { 
                TableRelation 'Shipment Method' }
        CodeField 31 'Shipping Agent Code' `
            -CaptionML @{ NLD = 'Expediteur' } `
            -OnValidate {
                'IF "Shipping Agent Code" <> xRec."Shipping Agent Code" THEN'
                '  VALIDATE("Shipping Agent Service Code",'''');' 
            } `
            { TableRelation 'Shipping Agent' } | AccessByPermission TableData 5790 -Read
        CodeField 32 'Place of Export' `
            -DataLength 20 `
            -CaptionML @{ NLD = 'Vertrekplaats' }
        CodeField 35 'Country/Region Code' `
            -CaptionML @{ NLD = 'Land-/regiocode' } `
            { TableRelation 'Country/Region' }
        DateField 54 'Last Date Modified' `
            -CaptionML @{ NLD = 'Gewijzigd op' } `
            -Editable $false
        CodeField 83 'Location Code' `
            -CaptionML @{ NLD = 'Vestiging' } `
            { 
                TableRelation Location -SubObjects {
                    TableRelationFilter 'Use As In-Transit' Const No
                }
            }
        TextField 84 'Fax No.' -CaptionML @{ NLD = 'Fax' }
        TextField 85 'Telex Answer Back' -DataLength 20 -CaptionML @{ NLD = 'Telexantwoord' }
        CodeField 91 'Post Code' `
            -DataLength 20 `
            -CaptionML @{ NLD = 'Postcode' } `
            -ValidateTableRelation $false `
            -TestTableRelation $false `
            -OnValidate { 'PostCode.ValidatePostCode(City,"Post Code",County,"Country/Region Code",(CurrFieldNo <> 0) AND GUIALLOWED);' } `
            {
                TableRelation "Post Code" -SubObjects {
                    TableRelationCondition 'Country/Region Code' Const ''
                }
                TableRelation "Post Code" -SubObjects {
                    TableRelationCondition 'Country/Region Code' Filter "<>''"
                    TableRelationFilter 'Country/Region Code' Field 'Country/Region Code'
                }
            }
        TextField 92 County -CaptionML @{ NLD = 'Provincie' }
        TextField 102 'E-Mail' `
            -DataLength 80 `
            -CaptionML @{ ENU='Email'; NLD = 'E-mail'} `
            -ExtendedDatatype EMail `
            -AutoCaption:$false
        TextField 103 'Home Page' `
            -DataLength 80 `
            -ExtendedDatatype Url `
            -CaptionML @{ NLD = 'Homepage' }
        CodeField 108 'Tax Area Code' `
            -DataLength 20 `
            -CaptionML @{ NLD = 'Tax Area Code' } `
            {
                TableRelation 'Tax Area'
            }
        BooleanField 109 'Tax Liable' `
            -CaptionML @{ NLD = 'Tax Liable' }
        CodeField 5792 'Shipping Agent Service Code' `
            -CaptionML @{ NLD = 'Servicecode expediteur' } `
            {
                TableRelation 'Shipping Agent Services' Code {
                    TableRelationFilter 'Shipping Agent Code' Field 'Shipping Agent Code'
                }
            }
        CodeField 5900 'Service Zone Code' `
            -CaptionML @{ NLD = 'Serviceregiocode' } `
            {
                TableRelation 'Service Zone'
            }
        Key 'Customer No.', Code -Clustered $true
        FieldGroup 1 DropDown Code,Name,Address,City,'Post Code'
        TextConstant 1000 Text000 @{ ENU='untitled'; NLD='naamloos' }
        RecordVariable 1001 Cust -SubType ([BaseApp+TableIds]::Customer)
        RecordVariable 1002 PostCode -SubType ([BaseApp+TableIds]::Post_Code)
        TextConstant 1003 Text001 @{ ENU='Before you can use Online Map, you must fill in the Online Map Setup window.\See Setting Up Online Map in Help.'; NLD='Voordat u Online Map kunt gebruiken, moet u het venster Online Map installeren invullen.\Zie Online Map instellen in de Help.' } 
        CodeunitVariable 1000000 PostCodeMgt -SubType 11401

        Procedure 1 Caption -ReturnValueType Text -ReturnValueDataLength 130 {
          'IF "Customer No." = '''' THEN'
          '  EXIT(Text000);'
          'Cust.GET("Customer No.");'
          'EXIT(STRSUBSTNO(''%1 %2 %3 %4'',Cust."No.",Cust.Name,Code,Name));'
        }

        Procedure 8 DisplayMap {
            RecordVariable 1001 MapPoint -SubType 800
            CodeunitVariable 1000 MapMgt -SubType 802
            'IF MapPoint.FINDFIRST THEN'
            '  MapMgt.MakeSelection(DATABASE::"Ship-to Address",GETPOSITION)'
            'ELSE'
            '  MESSAGE(Text001);'
        }

        Procedure 2 GetFilterCustNo -ReturnValueType Code -ReturnValueDataLength 20 {
            'IF GETFILTER("Customer No.") <> '''' THEN'
            '  IF GETRANGEMIN("Customer No.") = GETRANGEMAX("Customer No.") THEN'
            '    EXIT(GETRANGEMAX("Customer No."));'
        }
    } | 
    Export -Path C:\Users\jhoek\Desktop\tab222.txt