Application {
    Report 111 'Customer - Top 10 List' `
        -DateTime '25/10/16 12:00' `
        -VersionList NAVW110.0 `
        -CaptionML @{NLD='Klant - Top 10'} `
        -AutoCaption `
        -RequestPageSaveValues `
        -RequestPageOnInit { 'ChartTypeVisible := TRUE;' } `
        -RequestPageOnOpenPage { 'IF NoOfRecordsToPrint = 0 THEN'; '  NoOfRecordsToPrint := 10;' } `
        -OnPreReport {
            CodeunitVariable 1000 CaptionManagement 42
            'CustFilter := CaptionManagement.GetRecordFiltersWithCaptions(Customer);'
            'CustDateFilter := Customer.GETFILTER("Date Filter");'
        } `
        -RequestPageSubObjects {
            ContainerControl 1900000001 -ContainerType ContentArea {
                GroupControl 1900000002 -CaptionML @{ENU='Options'; NLD='Opties'} {
                    FieldControl 1 ShowType `
                        -Name Show `
                        -CaptionML @{ENU='Show';NLD='Weergeven'} `
                        -ToolTipML @{ENU='Specifies how the report will sort the customers: Sales, to sort by purchase volume; or Balance, to sort by balance. In either case, the customers with the largest amounts will be shown first.'} `
                        -OptionCaptionML @{ENU='Sales (LCY),Balance (LCY)';NLD='Verkoop (LV),Saldo (LV)'} `
                        -ApplicationArea '#Basic', '#Suite'
                    FieldControl 3 NoOfRecordsToPrint `
                        -CaptionML @{ENU='Quantity';NLD='Aantal'} `
                        -ToolTipML @{ENU='Specifies the number of customers that will be included in the report.'} `
                        -ApplicationArea '#Basic', '#Suite'
                    FieldControl 4 ChartType `
                        -Name ChartType `
                        -CaptionML @{ENU='Chart Type'; NLD='Diagramtype'} `
                        -OptionCaptionML @{ENU='Bar chart,Pie chart'; NLD='Staafdiagram,Cirkeldiagram'} `
                        -ToolTipML @{ENU='Specifies the chart type.'} `
                        -ApplicationArea '#All' `
                        -Visible ChartTypeVisible
                }
            }
        } `
        -SubObjects {
            ReportDataItem `
                -ID 6836 `
                -DataItemTable 18 `
                -DataItemTableViewKey 'No.' `
                -ReqFilterFields 'No.', 'Customer Posting Group', 'Currency Code', 'Date Filter' `
                -OnPreDataItem { 
					'Window.OPEN(Text000);' 
					'i := 0;'
					'CustAmount.DELETEALL;'
					'CurrReport.CREATETOTALS("Sales (LCY)","Balance (LCY)");'
				} `
                -OnAfterGetRecord {
                    'Window.UPDATE(1,"No.");'
                    'CALCFIELDS("Sales (LCY)","Balance (LCY)");'
                    'IF ("Sales (LCY)" = 0) AND ("Balance (LCY)" = 0) THEN'
                    '  CurrReport.SKIP;'
                    'CustAmount.INIT;'
                    'CustAmount."Customer No." := "No.";'
                    'IF ShowType = ShowType::"Sales (LCY)" THEN BEGIN'
                    '  CustAmount."Amount (LCY)" := -"Sales (LCY)";'
                    '  CustAmount."Amount 2 (LCY)" := -"Balance (LCY)";'
                    'END ELSE BEGIN'
                    '  CustAmount."Amount (LCY)" := -"Balance (LCY)";'
                    '  CustAmount."Amount 2 (LCY)" := -"Sales (LCY)";'
                    'END;'
                    'CustAmount.INSERT;'
                    'IF (NoOfRecordsToPrint = 0) OR (i < NoOfRecordsToPrint) THEN'
                    '  i := i + 1'
                    'ELSE BEGIN'
                    '  CustAmount.FIND(''+'');'
                    '  CustAmount.DELETE;'
                    'END;'
                    ''
                    'TotalSales += "Sales (LCY)";'
                    'TotalBalance += "Balance (LCY)";'
                    'ChartTypeNo := ChartType;'
                    'ShowTypeNo := ShowType;'
                } 
            ReportDataItem `
                -ID 5444 `
                -DataItemTable 2000000026 `
                -DataItemTableViewKey Number `
                -OnPreDataItem {
                    'Window.CLOSE;'
                    'CurrReport.CREATETOTALS(Customer."Sales (LCY)",Customer."Balance (LCY)");'
                } `
                -OnAfterGetRecord {
                    'IF Number = 1 THEN BEGIN'
                    '  IF NOT CustAmount.FIND(''-'') THEN'
                    '    CurrReport.BREAK;'
                    'END ELSE'
                    '  IF CustAmount.NEXT = 0 THEN'
                    '    CurrReport.BREAK;'
                    'CustAmount."Amount (LCY)" := -CustAmount."Amount (LCY)";'
                    'Customer.GET(CustAmount."Customer No.");'
                    'Customer.CALCFIELDS("Sales (LCY)","Balance (LCY)");'
                    'IF MaxAmount = 0 THEN'
                    '  MaxAmount := CustAmount."Amount (LCY)";'
                    'CustAmount."Amount (LCY)" := -CustAmount."Amount (LCY)";'
                } `
                -SubObjects {
                    TableFilter -FieldName Number -Type Filter -Value '1..'
                    ReportColumn 3 SortingCustomersCustDateFilter 'STRSUBSTNO(Text001,CustDateFilter)'
                    ReportColumn 6 CompanyName 'COMPANYNAME'
                    ReportColumn 8 RankedAccordingShowType 'STRSUBSTNO(Text002,SELECTSTR(ShowType + 1,Text004))'
                    ReportColumn 32 ShowTypeNo ShowTypeNo
                    ReportColumn 36 ChartTypeNo ChartTypeNo
                    ReportColumn 9 CustFilter_Customer 'Customer.TABLECAPTION + '': '' + CustFilter'
                    ReportColumn 31 CustFilter CustFilter
                    ReportColumn 17 No_Customer 'Customer."No."'-IncludeCaption 
                    ReportColumn 18 Name_Customer 'Customer.Name' -IncludeCaption
                    ReportColumn 19 SalesLCY_Customer 'Customer."Sales (LCY)"' -IncludeCaption
                    ReportColumn 20 BalanceLCY_Customer 'Customer."Balance (LCY)"' -IncludeCaption
                    ReportColumn 34 TotalSales TotalSales
                    ReportColumn 35 TotalBalance TotalBalance
                    ReportColumn 1 CustomerTop10ListCaption CustomerTop10ListCaptionLbl
                    ReportColumn 4 CurrReportPageNoCaption CurrReportPageNoCaptionLbl
                    ReportColumn 22 TotalCaption TotalCaptionLbl
                    ReportColumn 25 TotalSalesCaption TotalSalesCaptionLbl
                    ReportColumn 28 PercentofTotalSalesCaption PercentofTotalSalesCaptionLbl
                }
                TextConstant 1000 Text000 @{ENU='Sorting customers    #1##########'; NLD='Sorteren klanten     #1##########'}
                TextConstant 1001 Text001 @{ENU='Period: %1'; NLD='Periode: %1'}
                TextConstant 1002 Text002 @{ENU='Ranked according to %1'; NLD='Gerangschikt volgens %1'}
                RecordVariable 1003 CustAmount 266 -Temporary
                DialogVariable 1004 Window 
                TextVariable 1006 CustFilter
                TextVariable 1007 CustDateFilter
                OptionVariable 1008 ShowType 'Sales (LCY),Balance (LCY)' 
                IntegerVariable 1009 NoOfRecordsToPrint
                DecimalVariable 1014 MaxAmount
                IntegerVariable 1019 i
                DecimalVariable 1016 TotalSales
                TextConstant 1017 Text004 @{ENU='Sales (LCY),Balance (LCY)'; NLD='Verkoop (LV),Saldo (LV)'}
                DecimalVariable 1018 TotalBalance
                OptionVariable 1020 ChartType 'Bar chart,Pie chart'
                IntegerVariable 1021 ChartTypeNo
                IntegerVariable 1022 ShowTypeNo
                BooleanVariable 19004067 ChartTypeVisible -IncludeInDataset
                TextConstant 3137 CustomerTop10ListCaptionLbl @{ENU='Customer - Top 10 List'; NLD='Klant - Top 10'}
                TextConstant 2595 CurrReportPageNoCaptionLbl @{ENU='Page';NLD='Pagina'}
                TextConstant 1909 TotalCaptionLbl @{ENU='Total'; NLD='Totaal'}
                TextConstant 1450 TotalSalesCaptionLbl @{ENU='Total Sales'; NLD='Totale verkoop'}
                TextConstant 2243 PercentofTotalSalesCaptionLbl @{ENU='% of Total Sales'; NLD='% van totale verkoop'}
                Procedure 2 InitializeRequest {
                    OptionParameter 1002 SetChartType
                    OptionParameter 1000 SetShowType
                    IntegerParameter 1001 NoOfRecords
                    'ChartType := SetChartType;'
                    'ShowType := SetShowType;'
                    'NoOfRecordsToPrint := NoOfRecords;'
                }
            }
} | Export -Path ~\Desktop\output.txt