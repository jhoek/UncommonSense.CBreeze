function Add-CBreezeNoSeriesWithoutDocumentTypes
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

        $Result.Fields.No = $Table | Add-CBreezeTableField -Type Code -DataLength 20 -Name 'No.' -PassThru -AutoCaption -Range $Range -PrimaryKeyFieldNoRange
        $Result.Fields.NoSeries = $Table | Add-CBreezeTableField -Type Code -DataLength 10 -Name 'No. Series' -AutoCaption -Range $Range -Editable $false -PassThru
        $Result.Fields.NoSeries | Add-CBreezeTableRelation -TableName ([UncommonSense.CBreeze.Core.BaseApp+TableNames]::No_Series)    

        $Result.PrimaryKey = $Table | Add-CBreezeTableKey -Fields $Result.Fields.No.Name -Clustered $true -PassThru

        # AssistEdit function
        $Result.AssistEditFunction = $Table | Add-CBreezeFunction -Name AssistEdit -Range $Range -ReturnValueType Boolean -PassThru
        $VariableName = $Table.VariableName
        $ParameterName = "Old$VariableName"
        $Parameter = $Result.AssistEditFunction | Add-CBreezeParameter -Type Record -Name $ParameterName -Range $Range -SubType $Table.ID -PassThru
        $Variable = $Result.AssistEditFunction | Add-CBreezeVariable -Type Record -Name $VariableName -Range $Range -SubType $Table.ID -PassThru
        $SetupRecordVariable = $Result.AssistEditFunction | Add-CBreezeVariable -Type Record -Name $SetupTable.VariableName -Range $Range -SubType $SetupTable.ID -PassThru
        $NoSeriesMgtCodeunitVariable = $Result.AssistEditFunction | Add-CBreezeVariable -Type Codeunit -Name NoSeriesMgt -Range $Range -SubType ([UncommonSense.CBreeze.Core.BaseApp+CodeunitIDs]::NoSeriesManagement) -PassThru
        $SetupFieldName = "$($Table.Name) Nos."

        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line 'WITH {0} DO BEGIN' -ArgumentList $VariableName
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line '  {0} := Rec;' -ArgumentList $VariableName
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line '  {0}.GET;' -ArgumentList $SetupRecordVariable.Name
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line '  {0}.TESTFIELD("{1}");' -ArgumentList $SetupRecordVariable.Name, $SetupFieldName
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line '  IF {0}.SelectSeries({1}."{2}", {3}.{4}, {4}) THEN BEGIN' -ArgumentList $NoSeriesMgtCodeunitVariable.Name, $SetupRecordVariable.Name, $SetupFieldName, $Parameter.Name, $Result.Fields.NoSeries.QuotedName
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line '    {0}.GET;' -ArgumentList $SetupRecordVariable.Name
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line '    {0}.TESTFIELD("{1}");' -ArgumentList $SetupRecordVariable.Name, $SetupFieldName
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line '    {0}.SetSeries({1});' -ArgumentList $NoSeriesMgtCodeunitVariable.Name, $Result.Fields.No.QuotedName
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line '    Rec := {0};' -ArgumentList $VariableName
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line '    EXIT(TRUE);'
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line '  END;'
        $Result.AssistEditFunction | Add-CBreezeCodeLine -Line 'END;'

        $Result.Fields.Setup = $SetupTable | Add-CBreezeTableField -Type Code -DataLength 10 -Name $SetupFieldName -AutoCaption -Range $Range -PassThru
        $Result.Fields.Setup | Add-CBreezeTableRelation -TableName ([UncommonSense.CBreeze.Core.BaseApp+TableNames]::No_Series)

        if ($SetupPage)
        {
            $Group = $SetupPage | Get-CBreezePageControlGroup -GroupCaption "Numbering" -Range $Range -Position LastWithinContainer 
            $Result.Controls.Setup = $Group | Add-CBreezePageControl -Type Field -Range $Range -PassThru -SourceExpr $Result.Fields.Setup.QuotedName 
        }

        $SetupRecordVariable = $Result.Fields.No.Properties.OnValidate | Add-CBreezeVariable -Type Record -PassThru -SubType $SetupTable.ID -Name $SetupTable.VariableName -Range $Range
        $NoSeriesMgtCodeunitVariable = $Result.Fields.No.Properties.OnValidate | Add-CBreezeVariable -Type Codeunit -PassThru -SubType ([UncommonSense.CBreeze.Core.BaseApp+CodeunitIDs]::NoSeriesManagement) -Range $Range -Name NoSeriesMgt
        $Result.Fields.No.Properties.OnValidate | Add-CBreezeCodeLine -Line 'IF {0} <> xRec.{0} THEN BEGIN' -ArgumentList $Result.Fields.No.QuotedName
        $Result.Fields.No.Properties.OnValidate | Add-CBreezeCodeLine -Line '  {0}.GET;' -ArgumentList $SetupRecordVariable.Name
        $Result.Fields.No.Properties.OnValidate | Add-CBreezeCodeLine -Line '  {0}.TestManual({1}."{2} Nos.");' -ArgumentList $NoSeriesMgtCodeunitVariable.Name, $SetupRecordVariable.Name, $Table.Name
        $Result.Fields.No.Properties.OnValidate | Add-CBreezeCodeLine -Line '  "No. Series" := '''';'
        $Result.Fields.No.Properties.OnValidate | Add-CBreezeCodeLine -Line 'END;'

        $SetupRecordVariable = $Table.Properties.OnInsert | Add-CBreezeVariable -Type Record -Name $SetupTable.VariableName -SubType $SetupTable.ID -Range $Range -PassThru
        $NoSeriesMgtCodeunitVariable = $Table.Properties.OnInsert | Add-CBreezeVariable -Type Codeunit -Name 'NoSeriesMgt' -SubType ([UncommonSense.CBreeze.Core.BaseApp+CodeunitIDs]::NoSeriesManagement) -Range $Range -PassThru
        $Table.Properties.OnInsert | Add-CBreezeCodeLine -Line 'IF {0} = '''' THEN BEGIN' -ArgumentList $Result.Fields.No.QuotedName
        $Table.Properties.OnInsert | Add-CBreezeCodeLine -Line '  {0}.GET;' -ArgumentList $SetupRecordVariable.Name
        $Table.Properties.OnInsert | Add-CBreezeCodeLine -Line '  {0}.TESTFIELD("{1} Nos.");' -ArgumentList $SetupRecordVariable.Name, $Table.Name
        $Table.Properties.OnInsert | Add-CBreezeCodeLine -Line '  {0}.InitSeries({1}."{2} Nos.", xRec.{3}, 0D, {4}, {3});' -ArgumentList $NoSeriesMgtCodeunitVariable.Name, $SetupRecordVariable.Name, $Table.Name, $Result.Fields.NoSeries.QuotedName, $Result.Fields.No.QuotedName
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