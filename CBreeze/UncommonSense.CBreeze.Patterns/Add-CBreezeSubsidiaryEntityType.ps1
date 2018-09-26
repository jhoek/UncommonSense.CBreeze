<#
.SYNOPSIS
   Adds a subsidiary entity type to a C/Breeze application
#>
function Add-CBreezeSubsidiaryEntityType
{
    [Alias('SubsidiaryEntityType')]
    [OutputType([Table])]
    Param
    (
        [Parameter(Mandatory)]
        [ValidateRange(1, [int]::MaxValue)]
        [int]$TableID,

        [Parameter(Mandatory)]
        [ValidateRange(1, [int]::MaxValue)]
        [int]$PageID,

        [Parameter(Mandatory)]
        [ValidateLength(1, 30)]
        [string]$Name,

        [ValidateNotNullOrEmpty()]
        [ValidateLength(1, 30)]
        [string]$PluralName = [UncommonSense.CBreeze.Core.StringExtensionMethods]::MakePlural($Name),
        
        [Parameter(Mandatory)]
        [UncommonSense.CBreeze.Core.Table[]]$SubsidiaryTo,

        [ValidateSet('None', 'Code', 'LineNo')]
        [string]$DifferentiatorType = 'None',

        [DateTime]$DateTime,
        [bool]$Modified,
        [string]$VersionList,

        [string]$TableVariable,
        [string]$PageVariable,
        [string]$PrimaryKeyVariable,
        [string]$ForeignKeyFieldVariable,
        [string]$DifferentiatorFieldVariable,
        [string]$DifferentiatorControlVariable,
        [string]$DescriptionFieldVariable,
        [string]$DescriptionControlVariable
    )

        # Verify that all subsidiary-to tables have a valid primary key
        foreach ($Item in $SubsidiaryTo)
        {
            GetSubsidiaryToPrimaryKeyField($Item) | Out-Null
        }

        New-CBreezeTable `
            -ID $TableID `
            -Name $Name `
            -DateTime $DateTime `
            -Modified:$Modified `
            -VersionList $VersionList `
            -LookupPageID $PageID `
            -DrillDownPageID $PageID `
            -AutoCaption `
            -OutVariable Table

        New-CBreezePage `
            -ID $PageID `
            -Name $PluralName `
            -DateTime $DateTime `
            -Modified:$Modified `
            -VersionList $VersionList `
            -PageType List `
            -SourceTable $TablID `
            -AutoCaption `
            -OutVariable Page

        $PrimaryKeyFieldNames = @()
        $ForeignKeyFields = @{}
        $Repeater = $Page | Get-CBreezePageControlGroup -GroupType Repeater -Position FirstWithinContainer

        foreach ($Item in $SubsidiaryTo)
        {
            $TheirPrimaryKeyField = GetSubsidiaryToPrimaryKeyField($Item)

            $ForeignKeyFields.Add(
                $Item, 
                ($Table | 
                    Add-CBreezeCodeTableField `
                        -Name "$($Item.Name) $($TheirPrimaryKeyField.Name)" `
                        -DataLength $TheirPrimaryKeyField.DataLength `
                        -AutoCaption `
                        -NotBlank `
                        {
                            New-CBreezeTableRelation -TableName $Item.Name
                        }
                )
            )

            $Result.Controls.Add($Item.Name, ($Repeater | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.SubsidiaryTo[$Item].QuotedName -Range $Range -PassThru))
            
            $PrimaryKeyFieldNames += $Result.Fields.SubsidiaryTo[$Item].Name
        }

        switch ($DifferentiatorType)
        {
            'Code' 
            {
                $Result.Fields.Code = $Result.Table | Add-CBreezeTableField -Type Code -Name Code -PrimaryKeyFieldNoRange -DataLength 10 -AutoCaption -Range $Range -PassThru 
                $Result.Controls.Add('Code', ($Repeater | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.Code.QuotedName -Range $Range -PassThru))

                $PrimaryKeyFieldNames += $Result.Fields.Code.Name
            }

            'LineNo'
            {
                $Result.Fields.LineNo = $Result.Table | Add-CBreezeTableField -Type Integer -Name 'Line No.' -PrimaryKeyFieldNoRange -AutoCaption -Range $Range -PassThru 
                $Result.Controls.Add('LineNo', ($Repeater | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.LineNo.QuotedName -Range $Range -PassThru))

                $PrimaryKeyFieldNames += $Result.Fields.LineNo.Name
                $Result.Page.Properties.AutoSplitKey = $true
            }
        }

        $Result.PrimaryKey = $Result.Table | Add-CBreezeTableKey -Clustered $true -Fields $PrimaryKeyFieldNames -PassThru
        $Result.SecondaryKeys = @{}

        foreach ($Item in ($Result.Fields.SubsidiaryTo.Values | Select-Object -Skip 1))
        {
            $SecondaryKey = $Result.Table | Add-CBreezeTableKey -Fields $Item.Name -PassThru
            $Result.SecondaryKeys.Add($Item.Name, $SecondaryKey)    
        }

        foreach ($Item in $SubsidiaryTo)
        {
            $TheirPrimaryKeyField = GetSubsidiaryToPrimaryKeyField($Item)
            $Variable = $Item.Properties.OnDelete | Add-CBreezeVariable -Type Record -SubType $Result.Table.ID -Name $Result.Table.VariableName -PassThru -Range $Range 
            $Item.Properties.OnDelete | Add-CBreezeCodeLine '{0}.SETCURRENTKEY({1});' $Variable.Name, $Result.Fields.SubsidiaryTo[$Item].QuotedName
            $Item.Properties.OnDelete | Add-CBreezeCodeLine '{0}.SETRANGE({1},{2});' $Variable.Name, $Result.Fields.SubsidiaryTo[$Item].QuotedName, $TheirPrimaryKeyField.QuotedName
            $Item.Properties.OnDelete | Add-CBreezeCodeLine '{0}.DELETEALL(TRUE);' $Variable.Name
        }

        if ($PassThru)
        {
            $Result
        }
    }
}

function GetSubsidiaryToPrimaryKeyField([UncommonSense.CBreeze.Core.Table]$SubsidiaryTo)
{
    $SubsidiaryTo | Test-CBreezePrimaryKey -Test ShouldHave -ThrowError

    $PrimaryKey = $SubsidiaryTo.Keys | Select-Object -First 1
    
    if (($PrimaryKey.Fields | Measure-Object).Count -ne 1)
    {
        throw "Primary key must consist of exactly one field of type Code with length 10 or 20."
    }

    $PrimaryKeyFieldName = $PrimaryKey.Fields | Select-Object -First 1
    [UncommonSense.CBreeze.Core.CodeTableField]$PrimaryKeyField = $SubsidiaryTo.Fields[$PrimaryKeyFieldName]
    
    if (10, 20 -notcontains $PrimaryKeyField.DataLength)
    {
        throw "Primary key must consist of exactly one field of type Code with length 10 or 20."
    }

    return $PrimaryKeyField
}