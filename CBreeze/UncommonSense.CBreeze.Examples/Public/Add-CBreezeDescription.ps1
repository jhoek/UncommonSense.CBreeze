<#
.Synopsis
   Add description (or name) table field(s) to a C/Breeze table
#>
function Add-CBreezeDescription
{
    [Alias('Add-CBreezeName')]
    Param
    (
        [Parameter(Mandatory, ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Table]$Table,

        [Parameter()]
        [UncommonSense.CBreeze.Core.Page[]]$Pages,

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
        if (-not $HasSearchDescription)
        {
            $CreateKey = $false
        }

        if ($CreateKey)
        {
            $Table | Test-CBreezePrimaryKey -Test ShouldHave -ThrowError
        }

        $DescriptionField = $Table | 
            Add-CBreezeTextTableField `
            -Name ("{0}$DescriptionStyle" -f $Prefix) `
            -DataLength $DescriptionLength `
            -AutoCaption `
            -PassThru

        Set-OutVariable $DescriptionFieldVariable $DescriptionField

        if ($HasDescription2) 
        { 
            $Description2Field = $Table | 
                Add-CBreezeTextTableField `
                -Name ("{0}$DescriptionStyle 2" -f $Prefix) `
                -DataLength $DescriptionLength `
                -AutoCaption `
                -PassThru

            Set-OutVariable $Description2FieldVariable $Description2Field
        }     

        if ($HasSearchDescription) 
        { 
            $SearchDescriptionField = $Table | 
                Add-CBreezeCodeTableField `
                -Name ("{0}Search $DescriptionStyle" -f $Prefix) `
                -DataLength $DescriptionLength `
                -AutoCaption `
                -PassThru `
                -OnValidate {
                'IF ({0} = UPPERCASE(xRec.{1})) OR ({0} = '''') THEN' -f $Result.Fields.SearchDescription.QuotedName, $Result.Fields.Description.QuotedName
                '  {0} := {1};' -f $Result.Fields.SearchDescription.QuotedName, $Result.Fields.Description.QuotedName
            }

            Set-OutVariable $SearchDescriptionFieldVariable $SearchDescriptionField
                 
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

        foreach ($Page in $Pages)
        {
            $Group = switch ($Page.Properties.PageType)
            {
                ([UncommonSense.CBreeze.Core.PageType]::Card) { $Page | Get-CBreezePageControlGroup -GroupCaption $GroupCaption -Position $GroupPosition }
                ([UncommonSense.CBreeze.Core.PageType]::List) { $Page | Get-CBreezePageControlGroup -GroupType Repeater -Position FirstWithinContainer }
            }

            $DescriptionControl.Add($Page, ($Group | Add-CBreezePageControl -SourceExpr ($DescriptionField.QuotedName)))

            if ($HasSearchDescription)
            {
                $SearchDescriptionControl.Add($Page, ($Group | Add-CBreezePageControl -SourceExpr ($SearchDescriptionField.QuotedName)))
            }
        }

        Set-OutVariable $DescriptionControlVariable $DescriptionControl

        if ($HasSearchDescription)
        {
            Set-OutVariable $SearchDescriptionControlVariable $SearchDescriptionControl
        }
    }
}