function New-UserIDField
{
    [Alias('UserIDField')]
    param
    (
        [ValidateNotNullOrEmpty()]
        [string]$Name = 'User ID',

        [Switch]$ReadOnly
    )

    CodeField $Name `
        -DataLength 50 `
        -AutoCaption `
        -Editable $(if ($ReadOnly) { $false} else { $null }) `
        -ValidateTableRelation $false `
        -OnValidate {
            if (-not $ReadOnly)
            {
                CodeunitVariable UserMgt -SubType 418
                "UserMgt.ValidateUserID(`"$Name`");"
            }
        } `
        -OnLookup {
            CodeunitVariable UserMgt -SubType 418
            
            if ($ReadOnly)
            {
                CodeVariable Dummy -DataLength 50
                "Dummy := `"$Name`";"
                "UserMgt.LookupUserID(Dummy);"
            }
            else
            {
                "UserMgt.LookupUserID(`"$Name`");"
            }
        } `
        -SubObjects {
            TableRelation User "User Name"
        }
}
