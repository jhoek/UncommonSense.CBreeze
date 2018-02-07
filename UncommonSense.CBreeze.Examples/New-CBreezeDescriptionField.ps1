function New-CBreezeDescriptionField 
{
    [Alias('DescriptionField')]
    param
    (
        [ValidateNotNullOrEmpty()]
        [string]$Name = 'Description'
    )

    TextField $Name -DataLength 50 -AutoCaption
}
