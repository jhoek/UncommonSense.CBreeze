function Set-OutVariable
{
    param
    (
        [Parameter(Position = 0)][string]$Name,
        [Parameter(Position = 1)][object]$Value
    )

    if ($Name)
    {
        Set-Variable -Name $Name -Value $Value -Scope 2
    }
}