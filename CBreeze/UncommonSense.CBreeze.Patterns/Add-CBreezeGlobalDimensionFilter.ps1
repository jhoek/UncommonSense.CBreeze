<#
.Synopsis
   Adds Global Dimension Filters to a C/Breeze application
#>
function Add-CBreezeGlobalDimensionFilter
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory,ValueFromPipeLine)]
        [UncommonSense.CBreeze.Core.Table]$Table,

        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]]$Range,

        [Switch]$PassThru
    )

    Process
    {
        $Result = @{}
        $Result.Fields = @{}
        $Result.Controls = @{}

        $Result.Fields.GlobalDimension1Filter = $Table | Add-CBreezeTableField -Name 'Global Dimension 1 Filter' -Type Code -DataLength 20 -FieldClass FlowFilter -AutoCaption -CaptionClass "'1,3,1'" -PassThru -Range $Range
        $Result.Fields.GlobalDimension1Filter | Add-CBreezeTableRelation -TableName ([UncommonSense.CBreeze.Core.BaseApp+TableNames]::Dimension_Value) -FieldName Code -PassThru | Add-CBreezeFilter -FieldName 'Global Dimension No.' -Const -Value 1
        $Result.Fields.GlobalDimension2Filter = $Table | Add-CBreezeTableField -Name 'Global Dimension 2 Filter' -Type Code -DataLength 20 -FieldClass FlowFilter -AutoCaption -CaptionClass "'1,3,2'" -PassThru -Range $Range
        $Result.Fields.GlobalDimension2Filter | Add-CBreezeTableRelation -TableName ([UncommonSense.CBreeze.Core.BaseApp+TableNames]::Dimension_Value) -FieldName Code -PassThru | Add-CBreezeFilter -FieldName 'Global Dimension No.' -Const -Value 2

        if ($PassThru)
        {
            $Result
        }
    }
}