<#
.Synopsis
   Add description (or name) table field(s) to a C/Breeze table
#>
function Add-CBreezeDescription
{
    [CmdletBinding()]
    [Alias('Add-CBreezeName')]
    Param
    (
        [Parameter(Mandatory,ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Table]$Table,

        [Parameter()]
        [UncommonSense.CBreeze.Core.Page[]]$Pages,

        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]]$Range,

        [ValidateNotNullOrEmpty()]
        [string]$GroupCaption = 'General',

        [ValidateSet('FirstWithinContainer','LastWithinContainer')]
        [string]$GroupPosition = 'FirstWithinContainer',

        [string]$Prefix,

        [ValidateSet('Name','Description')]
        [string]$DescriptionStyle = 'Description',

        [Switch]$HasDescription2 = $true,

        [Switch]$HasSearchDescription = $true,

        [Switch]$CreateKey = $true,

        [Switch]$PassThru
    )

    Process
    {
        if (-not $HasSearchDescription)
        {
            $CreateKey = $false
        }

        $Result = @{}
        $Result.Fields = @{}
        $Result.Controls = @{}
        $Result.Controls.Description = @{}
        
        if ($CreateKey)
        {
            $Table | Test-CBreezePrimaryKey -Test ShouldHave -ThrowError
        }

        $Result.Fields.Description = $Table | Add-CBreezeTableField -Type Text -Name ("{0}$DescriptionStyle" -f $Prefix) -DataLength 50 -AutoCaption -Range $Range -PassThru

        if ($HasDescription2) 
        { 
            $Result.Controls.Description2 = @{}
            $Result.Fields.Description2 =  $Table | Add-CBreezeTableField -Type Text -Name ("{0}$DescriptionStyle 2" -f $Prefix) -DataLength 50 -AutoCaption -Range $Range -PassThru
        }     

        if ($HasSearchDescription) 
        { 
            $Result.Controls.SearchDescription = @{}

            $Result.Fields.SearchDescription = $Table | Add-CBreezeTableField -Type Code -Name ("{0}Search $DescriptionStyle" -f $Prefix) -DataLength 50 -PassThru -AutoCaption -Range $Range
            $Result.Fields.Description.Properties.OnValidate | Add-CBreezeCodeLine -Line 'IF ({0} = UPPERCASE(xRec.{1})) OR ({0} = '''') THEN' -ArgumentList $Result.Fields.SearchDescription.QuotedName, $Result.Fields.Description.QuotedName
            $Result.Fields.Description.Properties.OnValidate | Add-CBreezeCodeLine -Line '  {0} := {1};' -ArgumentList $Result.Fields.SearchDescription.QuotedName, $Result.Fields.Description.QuotedName

            if ($CreateKey)
            {
                $Result.Key = $Table | Add-CBreezeTableKey -Fields $Result.Fields.SearchDescription.Name -PassThru
            }
        }

        foreach($Page in $Pages)
        {
            switch($Page.Properties.PageType)
            {
                ([UncommonSense.CBreeze.Core.PageType]::Card)
                {
                    $Group = $Page | Get-CBreezePageControlGroup -Range $Range -GroupCaption $GroupCaption -Position $GroupPosition 
                    $Result.Controls.Description.Add($Page, ($Group | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.Description.QuotedName -Range $Range -PassThru))

                    if ($HasSearchDescription)
                    {
                        $Result.Controls.SearchDescription.Add($Page, ($Group | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.SearchDescription.QuotedName -Range $Range -PassThru))
                    }
                }

                ([UncommonSense.CBreeze.Core.PageType]::List)
                {
                    $Group = $Page | Get-CBreezePageControlGroup -Range $Range -GroupType Repeater -Position FirstWithinContainer
                    $Result.Controls.Description.Add($Page, ($Group | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.Description.QuotedName -Range $Range -PassThru))

                    if ($HasSearchDescription)
                    {
                        $Result.Controls.SearchDescription.Add($Page, ($Group | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.SearchDescription.QuotedName -Range $Range -PassThru))
                    }
                }
            }
        }

        if ($PassThru)
        {
            $Result
        }
    }
}