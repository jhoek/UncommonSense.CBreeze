using namespace UncommonSense.CBreeze.Core

# .SYNOPSIS
# Adds a user ID field to a C/Breeze application
function Add-CBreezeUserIDField {
    param
    (
        [Parameter(Mandatory, ValueFromPipeline)]
        [Table]$Table,

        [Page[]]$Page,

        [ValidateNotNullOrEmpty()]
        [string]$Name = 'User ID',

        [Switch]$ReadOnly,

        [string]$UserIDFieldVariable,
        [string]$UserIDControlVariable
    )

    Process {
        $Editable = if ($ReadOnly) { $false} else { $null }

        $UserIDField = $Table | 
            Add-CBreezeCodeTableField `
                -Name $Name `
                -DataLength 50 `
                -AutoCaption `
                -Editable:$Editable `
                -ValidateTableRelation:$false `
                -OnValidate {
                    if (-not $ReadOnly) {
                    CodeunitVariable UserMgt -SubType 418
                    "UserMgt.ValidateUserID(`"$Name`");"
                    }
                } `
                -OnLookup {
                    CodeunitVariable UserMgt -SubType 418
            
                    if ($ReadOnly) {
                        CodeVariable Dummy -DataLength 50
                        "Dummy := `"$Name`";"
                        "UserMgt.LookupUserID(Dummy);"
                    }
                    else {
                        "UserMgt.LookupUserID(`"$Name`");"
                    }
                } `
                -SubObjects {
                    TableRelation User "User Name"
                } `
                -PassThru

        $UserIDControl = [Ordered]@{}

        foreach($Item in $Page)
        {
            if ($Item.Properties.PageType -eq 'List')
            {
                $Repeater = $Item | Get-CBreezePageControlGroup -GroupType Repeater -Position FirstWithinContainer

                switch($Item.Properties.Editable)
                {
                    $false { $UserIDControl.Add($Item, ($Repeater | Add-CBreezePageControl -SourceExpr $UserIDField.QuotedName -PassThru)) }
                    default { $UserIDControl.Add($Item, ($Repeater | Add-CBreezePageControl -SourceExpr $UserIDField.QuotedName -Editable:(-not $ReadOnly) -PassThru)) } 
                }                
            }
        }

        Set-OutVariable -Name $UserIDFieldVariable -Value $UserIDField
        Set-OutVariable -Name $UserIDControlVariable -Value $UserIDControl

        $Table
    }
}
