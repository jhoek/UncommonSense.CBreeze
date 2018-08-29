function Add-CBreezeNoSeriesWithDocumentTypes
{
    Param
    (
        # Note: parameters added here should also be added to Add-CBreezeNoSeries

        [Parameter(Mandatory, ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Table]$Table,

        [Parameter(Mandatory)]
        [UncommonSense.CBreeze.Core.Table]$SetupTable,

        [Parameter()]
        [UncommonSense.CBreeze.Core.Page]$SetupPage,

        [Parameter()]
        [UncommonSense.CBreeze.Core.Page[]]$Pages,

        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]]$Range,

        [string[]]$DocumentTypes,

        [UncommonSense.CBreeze.Core.DateTableField]$PostingDateField,

        [Switch]$PassThru
    )

    Process
    {
        $Table | Test-CBreezePrimaryKey -Test ShouldNotHave -ThrowError

        $Result = @{}
        $Result.Fields = @{}
        $Result.Fields.Setup = @{}
        $Result.Controls = @{}
        $Result.Controls.No = @{}
        $Result.Controls.Setup = @{}

        $Result.Fields.DocumentType = $Table | Add-CBreezeTableField -Type Option -Name 'Document Type' -PassThru -AutoCaption -AutoOptionCaption -OptionString ($DocumentTypes -join ',') -Range $Range -PrimaryKeyFieldNoRange
        $Result.Fields.No = $Table | Add-CBreezeTableField -Type Code -DataLength 20 -Name 'No.' -PassThru -AutoCaption -Range $Range -PrimaryKeyFieldNoRange
        $Result.Fields.NoSeries = $Table | Add-CBreezeTableField -Type Code -DataLength 10 -Name 'No. Series' -AutoCaption -Range $Range -Editable $false -PassThru
        $Result.Fields.NoSeries | Add-CBreezeTableRelation -TableName ([UncommonSense.CBreeze.Core.BaseApp+TableNames]::No_Series)    

        $Result.PrimaryKey = $Table | Add-CBreezeTableKey -Fields $Result.Fields.DocumentType.Name, $Result.Fields.No.Name -Clustered $true -PassThru

        # AssistEdit function
        $Result.AssistEditFunction = $Table | Add-CBreezeFunction -Name AssistEdit -Range $Range -ReturnValueType Boolean -PassThru
        $VariableName = $Table.VariableName
        $ParameterName = "Old$VariableName"
        $Parameter = $Result.AssistEditFunction | Add-CBreezeParameter -Type Record -Name $ParameterName -Range $Range -SubType $Table.ID -PassThru
        $Variable = $Result.AssistEditFunction | Add-CBreezeVariable -Type Record -Name $VariableName -Range $Range -SubType $Table.ID -PassThru
        $SetupRecordVariable = $Result.AssistEditFunction | Add-CBreezeVariable -Type Record -Name $SetupTable.VariableName -Range $Range -SubType $SetupTable.ID -PassThru
        $NoSeriesMgtCodeunitVariable = $Result.AssistEditFunction | Add-CBreezeVariable -Type Codeunit -Name NoSeriesMgt -Range $Range -SubType ([UncommonSense.CBreeze.Core.BaseApp+CodeunitIDs]::NoSeriesManagement) -PassThru
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line 'WITH {0} DO BEGIN' -ArgumentList $VariableName
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line '  COPY(Rec);'
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line '  {0}.GET;' -ArgumentList $SetupRecordVariable.Name
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line '  TestNoSeries;'
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line '  IF {0}.SelectSeries(GetNoSeriesCode, {1}.{2}, {2}) THEN BEGIN' -ArgumentList $NoSeriesMgtCodeunitVariable.Name, $Parameter.Name, $Result.Fields.NoSeries.QuotedName
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line '    {0}.SetSeries({1});' -ArgumentList $NoSeriesMgtCodeunitVariable.Name, $Result.Fields.No.QuotedName
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line '    Rec := {0};' -ArgumentList $VariableName
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line '    EXIT(TRUE);'
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line '  END;'
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line 'END;'

        # TestNoSeries function
        $Result.TestNoSeriesFunction = $Table | Add-CBreezeFunction -Name TestNoSeries -Range $Range -ReturnValueType Boolean -Local $true -PassThru
        $SetupRecordVariable = $Result.TestNoSeriesFunction | Add-CBreezeVariable -Type Record -Name $SetupTable.VariableName -Range $Range -SubType $SetupTable.ID -PassThru
        $Result.TestNoSeriesFunction | Add-CBreezeCodeLine -Line '{0}.GET;' -ArgumentList $SetupRecordVariable.Name
        $Result.TestNoSeriesFunction | Add-CBreezeCodeLine 
        $Result.TestNoSeriesFunction | Add-CBreezeCodeLine -Line 'CASE "Document Type" OF'
        foreach ($DocumentType in $DocumentTypes)
        {
            $Result.TestNoSeriesFunction | Add-CBreezeCodeLine -Line '  "Document Type"::{0}:' -ArgumentList $DocumentType
            $Result.TestNoSeriesFunction | Add-CBreezeCodeLine -Line '    {0}.TESTFIELD("{1} Nos.");' -ArgumentList $SetupRecordVariable.Name, $DocumentType
        }
        $Result.TestNoSeriesFunction | Add-CBreezeCodeLine -Line 'END;'

        # GetNoSeriesCode function
        $Result.GetNoSeriesCodeFunction = $Table | Add-CBreezeFunction -Name GetNoSeriesCode -Range $Range -ReturnValueType Code -ReturnValueDataLength 10 -Local $true -PassThru
        $SetupRecordVariable = $Result.GetNoSeriesCodeFunction | Add-CBreezeVariable -Type Record -Name $SetupTable.VariableName -Range $Range -SubType $SetupTable.ID -PassThru
        $Result.GetNoSeriesCodeFunction | Add-CBreezeCodeLine -Line '{0}.GET;' -ArgumentList $SetupRecordVariable.Name
        $Result.GetNoSeriesCodeFunction | Add-CBreezeCodeLine 
        $Result.GetNoSeriesCodeFunction | Add-CBreezeCodeLine -Line 'CASE "Document Type" OF'
        foreach ($DocumentType in $DocumentTypes)
        {
            $Result.GetNoSeriesCodeFunction | Add-CBreezeCodeLine -Line '  "Document Type"::{0}:' -ArgumentList $DocumentType
            $Result.GetNoSeriesCodeFunction | Add-CBreezeCodeLine -Line '    EXIT({0}."{1} Nos.");' -ArgumentList $SetupRecordVariable.Name, $DocumentType
        }
        $Result.GetNoSeriesCodeFunction | Add-CBreezeCodeLine -Line 'END;'

        foreach ($DocumentType in $DocumentTypes)
        {
            $Result.Fields.Setup[$DocumentType] = $SetupTable | Add-CBreezeTableField -Type Code -DataLength 10 -Name "$DocumentType Nos." -AutoCaption -Range $Range -PassThru
            $Result.Fields.Setup[$DocumentType] | Add-CBreezeTableRelation -TableName ([UncommonSense.CBreeze.Core.BaseApp+TableNames]::No_Series)

            if ($SetupPage)
            {
                $Group = $SetupPage | Get-CBreezePageControlGroup -GroupCaption "Numbering" -Range $Range -Position LastWithinContainer 
                $Result.Controls.Setup.Add($DocumentType, ($Group | Add-CBreezePageControl -Type Field -Range $Range -PassThru -SourceExpr $Result.Fields.Setup[$DocumentType].QuotedName))
            }
        }

        $SetupRecordVariable = $Result.Fields.No.Properties.OnValidate | Add-CBreezeVariable -Type Record -PassThru -SubType $SetupTable.ID -Name $SetupTable.VariableName -Range $Range
        $NoSeriesMgtCodeunitVariable = $Result.Fields.No.Properties.OnValidate | Add-CBreezeVariable -Type Codeunit -PassThru -SubType ([UncommonSense.CBreeze.Core.BaseApp+CodeunitIDs]::NoSeriesManagement) -Range $Range -Name NoSeriesMgt
        $Result.Fields.No.Properties.OnValidate | Add-CBreezeCodeLine -Line 'IF {0} <> xRec.{0} THEN BEGIN' -ArgumentList $Result.Fields.No.QuotedName
        $Result.Fields.No.Properties.OnValidate | Add-CBreezeCodeLine -Line '  {0}.GET;' -ArgumentList $SetupRecordVariable.Name
        $Result.Fields.No.Properties.OnValidate | Add-CBreezeCodeLine -Line '  {0}.TestManual({1});' -ArgumentList $NoSeriesMgtCodeunitVariable.Name, $Result.GetNoSeriesCodeFunction.Name
        $Result.Fields.No.Properties.OnValidate | Add-CBreezeCodeLine -Line '  "No. Series" := '''';'
        $Result.Fields.No.Properties.OnValidate | Add-CBreezeCodeLine -Line 'END;'

        $Date = if ($PostingDateField) { $PostingDateField.QuotedName } else { '0D' }

        $NoSeriesMgtCodeunitVariable = $Table.Properties.OnInsert | Add-CBreezeVariable -Type Codeunit -Name 'NoSeriesMgt' -SubType ([UncommonSense.CBreeze.Core.BaseApp+CodeunitIDs]::NoSeriesManagement) -Range $Range -PassThru
        $Table.Properties.OnInsert | Add-CBreezeCodeLine -Line 'IF {0} = '''' THEN BEGIN' -ArgumentList $Result.Fields.No.QuotedName
        $Table.Properties.OnInsert | Add-CBreezeCodeLine -Line '  TestNoSeries;'
        $Table.Properties.OnInsert | Add-CBreezeCodeLine -Line '  {0}.InitSeries(GetNoSeriesCode, xRec.{1}, {2}, {3}, {1});' -ArgumentList $NoSeriesMgtCodeunitVariable.Name, $Result.Fields.NoSeries.QuotedName, $Date, $Result.Fields.No.QuotedName
        $Table.Properties.OnInsert | Add-CBreezeCodeLine -Line 'END;'

        if ($Pages)
        {
            foreach ($CardPage in $Pages | Where-Object { $_.Properties.PageType -eq 'Card' } )
            {
                $Group = $CardPage | Get-CBreezePageControlGroup -GroupCaption General -Range $Range -Position FirstWithinContainer 
                $Result.Controls.No.Add($CardPage, ($Group | Add-CBreezePageControl -Type Field -Range $Range -SourceExpr $Result.Fields.No.QuotedName -Importance Promoted -PassThru -Position FirstWithinContainer))
                $Result.Controls.No[$CardPage].Properties.OnAssistEdit | Add-CBreezeCodeLine -Line 'IF AssistEdit(xRec) THEN'
                $Result.Controls.No[$CardPage].Properties.OnAssistEdit | Add-CBreezeCodeLine -Line '  CurrPage.UPDATE;'
            }

            foreach ($ListPage in $Pages | Where-Object { $_.Properties.PageType -eq 'List' } )
            {
                $Repeater = $ListPage | Get-CBreezePageControlGroup -GroupType Repeater -Range $Range -Position FirstWithinContainer
                $Result.Controls.No.Add($ListPage, ($Repeater | Add-CBreezePageControl -Type Field -Range $Range -SourceExpr $Result.Fields.No.QuotedName -PassThru))
            }
        }

        if ($PassThru)
        {
            $Result
        }
    }
}