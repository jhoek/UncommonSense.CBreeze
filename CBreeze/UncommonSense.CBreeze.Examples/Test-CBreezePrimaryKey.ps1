<#
.Synopsis
   Tests if a C/Breeze table object has a primary key
#>
function Test-CBreezePrimaryKey
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory,ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Table]$Table,
        
        [ValidateNotNullOrEmpty()]
        [ValidateSet('ShouldHave','ShouldNotHave')]
        [string]$Test = 'ShouldNotHave',
        
        [Switch]$ThrowError,

        [Switch]$PassThru
    )

    Process
    {
        $HasPrimaryKey = $Table.Keys.Count -gt 0

        switch($Test)
        {
            ('ShouldHave')
            {
                $Result = $HasPrimaryKey

                if ((-not $Result) -and ($ThrowError))
                {
                    throw "$Table doesn't have a primary key yet."
                }
            }

            ('ShouldNotHave')
            {
                $Result = -not $HasPrimaryKey

                if ((-not $Result) -and ($ThrowError))
                {
                    throw "$Table already has primary key."
                }
            }
        }        

        if ($PassThru)
        {
            $Result
        }
    }
}