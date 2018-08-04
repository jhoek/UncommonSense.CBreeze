using namespace UncommonSense.CBreeze.Core

<#
.Synopsis
    Add address table fields to a C/Breeze table
.Description
    Adds the fields and page controls for an address block to a table and
    zero or more C/Breeze pages.
#>
function Add-CBreezeAddress
{
    Param
    (
        # The table to which the fields will be added
        [Parameter(Mandatory, ValueFromPipeline)]
        [Table]$Table,

        # The page(s) to which the controls will be added
        [Parameter()]
        [Page[]]$Pages,

        # The Format Address codeunit to which a function will be 
        # added. This function combines the address fields into 
        # an array of text lines in the country's address format
        [Parameter()]
        [Codeunit]$FormatAddressCodeunit,

        # The range from which field and control IDs are assigned
        [int[]]$Range,

        # The FastTab to which the page controls are added on card pages
        [ValidateNotNullOrEmpty()]
        [string]$GroupCaption = 'General',

        # The position of the new fields within their container (FastTab for 
        # card pages, repeater for list pages)
        [ValidateSet('FirstWithinContainer', 'LastWithinContainer')]
        [string]$CardGroupPosition = 'FirstWithinContainer',

        # If specified, used as a prefix on the field names
        [string]$Prefix,

        # If true, the function returns a hashtable containing references
        # to the newly created application elements
        [Switch]$PassThru
    )

    Process
    {
        $Result = @{}
        $Result.Fields = @{}
        $Result.Controls = @{}
        $Result.Controls.Address = @{}
        $Result.Controls.Address2 = @{}
        $Result.Controls.PostCode = @{}
        $Result.Controls.City = @{}
        $Result.Controls.County = @{}
        $Result.Controls.CountryRegionCode = @{}

        $Result.Fields.Address = $Table | Add-CBreezeTableField -Type Text -DataLength 50 -Range $Range -AutoCaption -Name "$($Prefix)Address" -PassThru
        $Result.Fields.Address2 = $Table | Add-CBreezeTableField -Type Text -DataLength 50 -Range $Range -AutoCaption -Name "$($Prefix)Address 2" -PassThru
        $Result.Fields.PostCode = $Table | Add-CBreezeTableField -Type Code -DataLength 20 -Range $Range -AutoCaption -Name "$($Prefix)Post Code" -TestTableRelation $false -ValidateTableRelation $false -PassThru
        $Result.Fields.City = $Table | Add-CBreezeTableField -Type Text -DataLength 30 -Range $Range -AutoCaption -Name "$($Prefix)City" -TestTableRelation $false -ValidateTableRelation $false -PassThru
        $Result.Fields.County = $Table | Add-CBreezeTableField -Type Text -DataLength 30 -Range $Range -AutoCaption -Name "$($Prefix)County" -PassThru
        $Result.Fields.CountryRegionCode = $Table | Add-CBreezeTableField -Type Code -DataLength 10 -Range $Range -AutoCaption -Name "$($Prefix)Country/Region Code" -PassThru

        $Result.Fields.PostCode | `
            Add-CBreezeTableRelation -TableName ([UncommonSense.CBreeze.Core.BaseApp+TableNames]::Post_Code) -FieldName Code -PassThru | `
            Add-CBreezeCondition -FieldName ($Result.Fields.CountryRegionCode.Name) -Const -Value ''''''
        $Result.Fields.PostCode | `
            Add-CBreezeTableRelation -TableName ([UncommonSense.CBreeze.Core.BaseApp+TableNames]::Post_Code) -FieldName Code -PassThru | `
            Add-CBreezeCondition -FieldName ($Result.Fields.CountryRegionCode.Name) -Filter -Value '<>''''' -PassThru | `
            Add-CBreezeFilter -FieldName 'Country/Region Code' -Field -Value $Result.Fields.CountryRegionCode.Name
        $Result.Fields.City | `
            Add-CBreezeTableRelation -TableName ([UncommonSense.CBreeze.Core.BaseApp+TableNames]::Post_Code) -FieldName City -PassThru | `
            Add-CBreezeCondition -FieldName ($Result.Fields.CountryRegionCode.Name) -Const -Value ''''''
        $Result.Fields.City | `
            Add-CBreezeTableRelation -TableName ([UncommonSense.CBreeze.Core.BaseApp+TableNames]::Post_Code) -FieldName City -PassThru | `
            Add-CBreezeCondition -FieldName ($Result.Fields.CountryRegionCode.Name) -Filter -Value '<>''''' -PassThru | `
            Add-CBreezeFilter -FieldName 'Country/Region Code' -Field -Value $Result.Fields.CountryRegionCode.Name                                
        $Result.Fields.CountryRegionCode | `
            Add-CBreezeTableRelation -TableName ([UncommonSense.CBreeze.Core.BaseApp+TableNames]::CountryRegion)           

        Set-Variable -Name VariableName -Value PostCode -Option Constant

        $Result.Fields.PostCode.Properties.OnValidate | Add-CBreezeVariable -Type Record -SubType ([UncommonSense.CBreeze.Core.BaseApp+TableIDs]::Post_Code) -Range $Range -Name $VariableName
        $Result.Fields.City.Properties.OnValidate | Add-CBreezeVariable -Type Record -SubType ([UncommonSense.CBreeze.Core.BaseApp+TableIDs]::Post_Code) -Range $Range -Name $VariableName

        $Result.Fields.PostCode.Properties.OnValidate | `
            Add-CBreezeCodeLine `
            -Line '{0}.ValidatePostCode({1},{2},{3},{4}, (CurrFieldNo <> 0) AND GUIALLOWED);' `
            -ArgumentList $VariableName, $Result.Fields.City.QuotedName, $Result.Fields.PostCode.QuotedName, $Result.Fields.County.QuotedName, $Result.Fields.CountryRegionCode.QuotedName

        $Result.Fields.City.Properties.OnValidate | `
            Add-CBreezeCodeLine `
            -Line '{0}.ValidateCity({1},{2},{3},{4}, (CurrFieldNo <> 0) AND GUIALLOWED);' `
            -ArgumentList $VariableName, $Result.Fields.City.QuotedName, $Result.Fields.PostCode.QuotedName, $Result.Fields.County.QuotedName, $Result.Fields.CountryRegionCode.QuotedName

        if ($FormatAddressCodeunit)
        {
            Set-Variable -Name FormatFunctionName -Value ([UncommonSense.CBreeze.Core.StringExtensionMethods]::MakeVariableName("$($Table.Name) $($Prefix)")) -Option Constant
            Set-Variable -Name ArrayVariableName -Value AddrArray -Option Constant
            Set-Variable -Name RecordVariableName -Value ($Table.VariableName) -Option Constant

            $Result.FormatFunction = $FormatAddressCodeunit | Add-CBreezeFunction -Range $Range -Name $FormatFunctionName -PassThru
            $Result.FormatFunction | Add-CBreezeParameter -Type Text -Var -Range $Range -Name $ArrayVariableName -DataLength 50 -Dimensions 8
            $Result.FormatFunction | Add-CBreezeParameter -Type Record -Var -Range $Range -Name $RecordVariableName -SubType $Table.ID

            $Result.FormatFunction | Add-CBreezeCodeLine -Line 'WITH {0} DO' -ArgumentList $RecordVariableName
            $Result.FormatFunction | Add-CBreezeCodeLine -Line '  FormatAddr('

            $Result.FormatFunction | Add-CBreezeCodeLine `
                -Line '    {0},{1},{2},{3},{4},{5},' `
                -ArgumentList `
                $ArrayVariableName, `
            ([UncommonSense.CBreeze.Core.StringExtensionMethods]::Quoted("$($Prefix)Name")), `
            ([UncommonSense.CBreeze.Core.StringExtensionMethods]::Quoted("$($Prefix)Name 2")), `
            ([UncommonSense.CBreeze.Core.StringExtensionMethods]::Quoted("$($Prefix)Contact")), `
                $Result.Fields.Address.QuotedName, `
                $Result.Fields.Address2.QuotedName

            $Result.FormatFunction | Add-CBreezeCodeLine `
                -Line '    {0},{1},{2},{3});' `
                -ArgumentList `
                $Result.Fields.City.QuotedName, `
                $Result.Fields.PostCode.QuotedName, `
                $Result.Fields.County.QuotedName, `
                $Result.Fields.CountryRegionCode.QuotedName
        }

        if ($Pages)
        {
            foreach ($CardPage in $Pages | Where-Object { $_.Properties.PageType -eq 'Card' })
            {
                $Group = $CardPage | Get-CBreezePageControlGroup -GroupCaption $GroupCaption -Range $Range -Position $CardGroupPosition
                $Result.Controls.Address.Add($CardPage, ($Group | Add-CBreezePageControl -Type Field -Range $Range -PassThru -SourceExpr $Result.Fields.Address.QuotedName))
                $Result.Controls.Address2.Add($CardPage, ($Group | Add-CBreezePageControl -Type Field -Range $Range -PassThru -SourceExpr $Result.Fields.Address2.QuotedName))
                $Result.Controls.PostCode.Add($CardPage, ($Group | Add-CBreezePageControl -Type Field -Range $Range -PassThru -SourceExpr $Result.Fields.PostCode.QuotedName -Importance Promoted))
                $Result.Controls.City.Add($CardPage, ($Group | Add-CBreezePageControl -Type Field -Range $Range -PassThru -SourceExpr $Result.Fields.City.QuotedName))
                $Result.Controls.CountryRegionCode.Add($CardPage, ($Group | Add-CBreezePageControl -Type Field -Range $Range -PassThru -SourceExpr $Result.Fields.CountryRegionCode.QuotedName))
            }

            foreach ($ListPage in $Pages | Where-Object { $_.Properties.PageType -eq 'List' })
            {
                $Repeater = $ListPage | Get-CBreezePageControlGroup -GroupType Repeater -Range $Range -Position FirstWithinContainer
                $Result.Controls.PostCode.Add($ListPage, ($Repeater | Add-CBreezePageControl -Type Field -Range $Range -PassThru -SourceExpr $Result.Fields.PostCode.QuotedName))
                $Result.Controls.CountryRegionCode.Add($ListPage, ($Repeater | Add-CBreezePageControl -Type Field -Range $Range -PassThru -SourceExpr $Result.Fields.CountryRegionCode.QuotedName))
            }
        }

        if ($PassThru)
        {
            $Result
        }
    }
}