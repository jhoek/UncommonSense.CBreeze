<#
.Synopsis
   Adds a No. primary key field to a C/Breeze application
.Description
   Register tables have a No. primary key field
#>
function Add-CBreezeNo
{
    Param
    (
        [Parameter(Mandatory, ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Table] $Table,

        [Parameter()]
        [UncommonSense.CBreeze.Core.Page[]] $Pages,

        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]] $Range,

        [Switch] $PassThru
    )

    Process
    {
        $Table | Test-CBreezePrimaryKey -Test ShouldNotHave -ThrowError

        $Result = @{}
        $Result.Fields = @{}
        $Result.Controls = @{}
        $Result.Controls.No = @{}

        $Result.Fields.No = $Table | Add-CBreezeTableField -Type Integer -Name 'No.' -PrimaryKeyFieldNoRange -AutoCaption -Range $Range -PassThru
        $Result.PrimaryKey = $Table | Add-CBreezeTableKey -Clustered $true -Fields $Result.Fields.No.QuotedName

        foreach ($Page in $Pages | Where-Object { $_.Properties.PageType -eq 'List' })
        {
            $Repeater = $Page | Get-CBreezePageControlGroup -GroupType Repeater -Range $Range
            $Result.Controls.No.Add($Page, ($Repeater | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.No.QuotedName -Range $Range -PassThru))
        }

        if ($PassThru)
        {
            $Result
        }        
    }
}