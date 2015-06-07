function Add-Attribute
{
    param
    (
        [Parameter(Mandatory=$true,ValueFromPipeLine=$true)]
        [UncommonSense.CBreeze.ObjectModelBuilder.Item]$Item,

        [Switch]$ValueAttribute,

        [Parameter(Mandatory=$true)]
        [string]$TypeName,

        [string]$Name
    )

    if (-not $Name)
    {
        $Name= $TypeName
    }

    switch($ValueAttribute)
    {
        ($true) { $Attribute = New-Object UncommonSense.CBreeze.ObjectModelBuilder.ValueAttribute -ArgumentList $TypeName, $Name } 
        ($false) { $Attribute = New-Object UncommonSense.CBreeze.ObjectModelBuilder.ReferenceAttribute -ArgumentList $TypeName, $Name }
    }
 
    $Item.Attributes.Add($Attribute) | Out-Null
    $Item
}
