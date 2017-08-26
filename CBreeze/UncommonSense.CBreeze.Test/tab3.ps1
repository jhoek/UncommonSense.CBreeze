$PSDefaultParameterValues.{*CBreeze*:AutoCaption} = $true

Application {
    Table 3 'Payment Terms' `
        -DateTime (Get-Date '15-09-15 12:00') `
        -VersionList NAVW19.00 `
        -OnDelete { 
            RecordVariable 1000 PaymentTermsTranslation 462
            'WITH PaymentTermsTranslation DO BEGIN'
            '  SETRANGE("Payment Term",Code);'
            '  DELETEALL'
            'END;' } `
        -SubObjects {
            CodeField 1 Code -NotBlank $true -CaptionML @{NLD='Code'}
            DateFormulaField 2 'Due Date Calculation' -CaptionML @{NLD='Vervaldatumformule'}
            DateFormulaField 3 'Discount Date Calculation' -CaptionML @{NLD='Kortingsvervaldatum'}
            DecimalField 4 'Discount %' -DecimalPlacesAtLeast 0 -DecimalPlacesAtMost 5 -MinValue 0 -MaxValue 100 -CaptionML @{NLD='Korting %'}
            TextField 5 Description -DataLength 50 -CaptionML @{NLD='Omschrijving'}
            BooleanField 6 'Calc. Pmt. Disc. on Cr. Memos' -CaptionML @{NLD='Cont.-kort. op creditnota''s berekenen'}
            Key Code -Clustered $true
            FieldGroup -ID 1 -Name DropDown -FieldNames Code, Description, 'Due Date Calculation'
            FieldGroup -ID 2 -Name Brick -FieldNames Code, Description, 'Due Date Calculation'
            Procedure -ID 1 -Name TranslateDescription -SubObjects {
                RecordParameter 1000 PaymentTerms -SubType 3 -Var
                CodeParameter 1001 Language -DataLength 10
                RecordVariable 1002 PaymentTermsTranslation -SubType 462

                'IF PaymentTermsTranslation.GET(PaymentTerms.Code,Language) THEN'
                '  PaymentTerms.Description := PaymentTermsTranslation.Description;'
            }
        } `
        -DataCaptionFields Code, Description `
        -LookupPageID 4 `
        -CaptionML @{NLD='Betalingscondities'} `
        -AutoCaption
} | Export -Path C:\Users\jhoek\Desktop\tab3.txt