<#
.Synopsis
   Adds a User ID field to a C/Breeze application
#>
function Add-CBreezeUserID
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory,ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Table]$Table,

        [Parameter()]
        [UncommonSense.CBreeze.Core.Page[]] $Pages,

        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]]$Range,

        [string]$FieldName = 'User ID',

        [Switch]$PassThru
    )

    Process
    {
        $Result = @{}
        $Result.Fields = @{}
        $Result.Controls = @{}
        $Result.Controls.UserID = @{}

        $Result.Fields.UserID = $Table | Add-CBreezeTableField -Type Code -Range $Range -DataLength 50 -Name $FieldName -TestTableRelation $false -ValidateTableRelation $false -AutoCaption -PassThru 
        $Result.Fields.UserID | Add-CBreezeTableRelation -TableName ([UncommonSense.CBreeze.Core.BaseApp+TableNames]::User) -FieldName 'User Name'
        $Result.Fields.UserID.Properties.OnValidate | Add-CBreezeVariable -Type Codeunit -Name 'UserMgt' -SubType ([UncommonSense.CBreeze.Core.BaseApp+CodeunitIDs]::User_Management) -Range $Range
        $Result.Fields.UserID.Properties.OnLookup | Add-CBreezeVariable -Type Codeunit -Name 'UserMgt' -SubType ([UncommonSense.CBreeze.Core.BaseApp+CodeunitIDs]::User_Management) -Range $Range
        $Result.Fields.UserID.Properties.OnValidate | Add-CBreezeCodeLine -Line 'UserMgt.ValidateUserID("{0}");' -ArgumentList $Result.Fields.UserID.Name
        $Result.Fields.UserID.Properties.OnLookup | Add-CBreezeCodeLine -Line 'UserMgt.LookupUserID("{0}");' -ArgumentList $Result.Fields.UserID.Name

        foreach($Page in $Pages | Where-Object { $_.Properties.PageType -eq 'List'} )
        {
            $Repeater = $Page | Get-CBreezePageControlGroup -GroupType Repeater -Position FirstWithinContainer -Range $Range
            $Result.Controls.UserID.Add($Page, ($Repeater | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.UserID.QuotedName -PassThru -Range $Range -Position LastWithinContainer))
        }

        if ($PassThru)
        {
            $Result
        }
    }
}