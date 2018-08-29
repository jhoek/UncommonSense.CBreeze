using namespace UncommonSense.CBreeze.Core

<#
.Synopsis
   Add description (or name) table field(s) to a C/Breeze table
#>
function Add-CBreezeDescription
{
    [OutputType([Table])]
    [Alias('Add-CBreezeName')]
    Param
    (
        [Parameter(Mandatory, ValueFromPipeline)]
        [Table]$Table,

        [Parameter()]
        [Page[]]$Page,

        [ValidateNotNullOrEmpty()]
        [string]$GroupCaption = 'General',

        [ValidateSet('FirstWithinContainer', 'LastWithinContainer')]
        [string]$GroupPosition = 'FirstWithinContainer',

        [string]$Prefix,

        [ValidateSet('Name', 'Description')]
        [string]$DescriptionStyle = 'Description',

        [ValidateRange(1, 250)]
        [int]$DescriptionLength = 50,

        [Switch]$HasDescription2,

        [Switch]$HasSearchDescription,

        [Switch]$CreateSecondaryKey,

        [string]$KeyVariable,
        [string]$DescriptionFieldVariable,
        [string]$Description2FieldVariable,
        [string]$SearchDescriptionFieldVariable,
        [string]$DescriptionControlVariable,
        [string]$SearchDescriptionControlVariable
    )

    Process
    {
        $CreateSecondaryKey = $CreateSecondaryKey -and $HasSearchDescription

        if ($CreateSecondaryKey)
        {
            $Table | Test-CBreezePrimaryKey -Test ShouldHave -ThrowError
        }

        $DescriptionFieldName = "{0}$DescriptionStyle" -f $Prefix
        $Description2FieldName = "{0}$DescriptionStyle 2" -f $Prefix
        $SearchDescriptionFieldName = "{0}Search $DescriptionStyle" -f $Prefix

        $DescriptionField = $Table |
            Add-CBreezeTextTableField `
            -Name $DescriptionFieldName `
            -DataLength $DescriptionLength `
            -AutoCaption `
            -PassThru

        Set-OutVariable $DescriptionFieldVariable $DescriptionField

        $Description2Field =
        if ($HasDescription2)
        {
            $Table |
                Add-CBreezeTextTableField `
                -Name $Description2FieldName `
                -DataLength $DescriptionLength `
                -AutoCaption `
                -PassThru
        }

        Set-OutVariable $Description2FieldVariable $Description2Field

        $SearchDescriptionField = if ($HasSearchDescription)
        {
            $Table |
                Add-CBreezeCodeTableField `
                -Name $SearchDescriptionFieldName `
                -DataLength $DescriptionLength `
                -AutoCaption `
                -PassThru `
                -OnValidate {
                'IF ({0} = UPPERCASE(xRec.{1})) OR ({0} = '''') THEN' -f [StringExtensionMethods]::Quoted($SearchDescriptionFieldName), [StringExtensionMethods]::Quoted($DescriptionFieldName)
                '  {0} := {1};' -f [StringExtensionMethods]::Quoted($SearchDescriptionFieldName), [StringExtensionMethods]::Quoted($DescriptionFieldName)

                Set-OutVariable $SearchDescriptionFieldVariable $SearchDescriptionField
            }

            if ($CreateSecondaryKey)
            {
                $Key = $Table | 
                    Add-CBreezeTableKey `
                    -Fields $SearchDescriptionField.Name `
                    -PassThru

                Set-OutVariable $KeyVariable $Key
            }
        }

        $DescriptionControl = [Ordered]@{}
        $SearchDescriptionControl = [Ordered]@{}

        foreach ($Item in $Page)
        {
            $Group = switch ($Item.Properties.PageType)
            {
                ([UncommonSense.CBreeze.Core.PageType]::Card) { $Item | Get-CBreezePageControlGroup -GroupCaption $GroupCaption -Position $GroupPosition }
                ([UncommonSense.CBreeze.Core.PageType]::List) { $Item | Get-CBreezePageControlGroup -GroupType Repeater -Position FirstWithinContainer }
            }

            $DescriptionControl.Add($Item, ($Group | Add-CBreezePageControl -SourceExpr ($DescriptionField.QuotedName)))

            if ($HasSearchDescription)
            {
                $SearchDescriptionControl.Add($Item, ($Group | Add-CBreezePageControl -SourceExpr ($SearchDescriptionField.QuotedName)))
            }
        }

        Set-OutVariable $DescriptionControlVariable $DescriptionControl

        if ($HasSearchDescription)
        {
            Set-OutVariable $SearchDescriptionControlVariable $SearchDescriptionControl
        }

        $Table
    }
}
