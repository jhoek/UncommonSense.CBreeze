<#
.Synopsis
   Adds a subsidiary entity type to a C/Breeze application
#>
function Add-CBreezeSubsidiaryEntityType
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory,ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Application]$Application,

        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]]$Range,

        [Parameter(Mandatory)]
        [string]$Name,

        [string]$PluralName,
        
        [Parameter(Mandatory)]
        [UncommonSense.CBreeze.Core.Table[]]$SubsidiaryTo,

        [ValidateSet('None','Code','LineNo')]
        [string]$DifferentiatorType = 'None',

        [DateTime]$DateTime,

        [bool]$Modified,

        [string]$VersionList,

        [Switch]$PassThru        
    )

    Process
    {
        if (-not $PluralName)
        {
            $PluralName = [UncommonSense.CBreeze.Core.StringExtensionMethods]::MakePlural($Name)
        }

        # Verify that all subsidiary-to tables have a valid primary key
        foreach($Item in $SubsidiaryTo)
        {
            GetSubsidiaryToPrimaryKeyField($Item) | Out-Null
        }

        $Result = @{}
        $Result.Table = $Application | Add-CBreezeObject -Type Table -Name $Name -DateTime $DateTime -Modified $Modified -VersionList $VersionList -AutoCaption -PassThru -Range $Range
        $Result.Page = $Application | Add-CBreezeObject -Type Page -Name $PluralName -DateTime $DateTime -Modified $Modified -VersionList $VersionList -PageType List -SourceTable $Result.Table.ID -AutoCaption -PassThru -Range $Range
        $Result.Fields = @{}
        $Result.Fields.SubsidiaryTo = [Ordered]@{}
        $Result.Controls = @{}

        $Result.Table.Properties.LookupPageID = $Result.Page.ID
        $Result.Table.Properties.DrillDownPageID = $Result.Page.ID

        $PrimaryKeyFieldNames = @()
        $Repeater = $Result.Page | Get-CBreezePageControlGroup -GroupType Repeater -Position FirstWithinContainer -Range $Range

        foreach($Item in $SubsidiaryTo)
        {
            $TheirPrimaryKeyField = GetSubsidiaryToPrimaryKeyField($Item)

            $Result.Fields.SubsidiaryTo.Add($Item, ($Result.Table | Add-CBreezeTableField -Type Code -PrimaryKeyFieldNoRange -Name "$($Item.Name) $($TheirPrimaryKeyField.Name)" -DataLength $TheirPrimaryKeyField.DataLength -AutoCaption -Range $Range -PassThru -NotBlank $true))
            $Result.Fields.SubsidiaryTo[$Item] | Add-CBreezeTableRelation -TableName $Item.Name
            $Result.Controls.Add($Item.Name, ($Repeater | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.SubsidiaryTo[$Item].QuotedName -Range $Range -PassThru))
            
            $PrimaryKeyFieldNames += $Result.Fields.SubsidiaryTo[$Item].Name
        }

        switch($DifferentiatorType)
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

        foreach($Item in ($Result.Fields.SubsidiaryTo.Values | Select-Object -Skip 1))
        {
            $SecondaryKey = $Result.Table | Add-CBreezeTableKey -Fields $Item.Name -PassThru
            $Result.SecondaryKeys.Add($Item.Name, $SecondaryKey)    
        }

        foreach($Item in $SubsidiaryTo)
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