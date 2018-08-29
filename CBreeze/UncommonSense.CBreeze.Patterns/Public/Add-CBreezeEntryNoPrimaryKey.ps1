# .SYNOPSIS
# Adds an Entry No. primary key field to a C/Breeze application
function Add-CBreezeEntryNoPrimaryKey
{
    [OutputType([UncommonSense.CBreeze.Core.Table])]
    Param
    (
        [Parameter(Mandatory, ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Table]$Table,

        [UncommonSense.CBreeze.Core.Page[]]$Pages,

        [ValidateNotNullOrEmpty()]
        [ValidateLength(1, 30)]
        [string]$Name = 'Entry No.',

        [string]$KeyVariable,
        [string]$FieldVariable,
        [string]$ControlVariable
    )

    Process
    {
        $Table | 
            Test-CBreezePrimaryKey `
            -Test ShouldNotHave `
            -ThrowError

        $EntryNoField = $Table | 
            Add-CBreezeIntegerTableField `
            -Name $Name `
            -AutoCaption `
            -PassThru

        $PrimaryKey = $Table | 
            Add-CBreezeTableKey `
            -Fields $EntryNoField.Name `
            -Clustered

        $EntryNoPageControls = @{}

        foreach ($Page in $Pages)
        {
            if ($Page.Properties.PageType -eq 'List')
            {
                $Repeater = $Page | Get-CBreezePageControlGroup -GroupType Repeater
                $EntryNoPageControls.Add($Page, ($Repeater | Add-CBreezePageControl -SourceExpr $EntryNoField.QuotedName -PassThru -Position LastWithinContainer))
            }
        }

        Set-OutVariable -Name $KeyVariable -Value $PrimaryKey
        Set-OutVariable -Name $FieldVariable -Value $EntryNoField
        Set-OutVariable -Name $ControlVariable -Value $EntryNoPageControls

        $Table
    }
}