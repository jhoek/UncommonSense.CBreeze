Describe 'Add-CBreezeSupplementalEntityType' {

    BeforeEach {
        $Application = New-CBreezeApplication
        $Range = [System.Linq.Enumerable]::Range(60000, 100)
        $Name = 'My Location'
        $SynthesizedPluralName = 'My Locations'
        $DateTime = Get-Date -Year 2015 -Month 8 -Day 10 -Hour 13 -Minute 0 -Second 0
        $Modified = $true
        $VersionList = 'NAVJH1.00'
    }

    It 'Creates a supplemental entity type table and page' {
        $SupplementalEntityTypeResult = $Application | Add-CBreezeSupplementalEntityType -Range $Range -Name $Name -DateTime $DateTime -Modified $Modified -VersionList $VersionList -PassThru

        # Table
        $SupplementalEntityTypeResult.Table.ID | Should Be 60000
        $SupplementalEntityTypeResult.Table.Name | Should Be $Name

        $SupplementalEntityTypeResult.Table.ObjectProperties.DateTime | Should Be $DateTime
        $SupplementalEntityTypeResult.Table.ObjectProperties.Modified | Should Be $Modified
        $SupplementalEntityTypeResult.Table.ObjectProperties.VersionList | Should Be $VersionList

        $SupplementalEntityTypeResult.Table.Properties.CaptionML['ENU'] | Should Be $Name
        $SupplementalEntityTypeResult.Table.Properties.LookupPageID | Should Be $SupplementalEntityTypeResult.Page.ID
        $SupplementalEntityTypeResult.Table.Properties.DrillDownPageID | Should Be $SupplementalEntityTypeResult.Page.ID

        $SupplementalEntityTypeResult.Table.Fields.Count | Should Be 2
        $SupplementalEntityTypeResult.Table.Fields[1].Type | Should Be Code
        $SupplementalEntityTypeResult.Table.Fields[1].DataLength | Should Be 10
        $SupplementalEntityTypeResult.Table.Fields[1].Name | Should Be Code
        $SupplementalEntityTypeResult.Table.Fields[1].Properties.CaptionML['ENU'] | Should Be Code
        $SupplementalEntityTypeResult.Table.Fields[10].Type | Should Be Text
        $SupplementalEntityTypeResult.Table.Fields[10].DataLength | Should Be 50
        $SupplementalEntityTypeResult.Table.Fields[10].Name | Should Be Description
        $SupplementalEntityTypeResult.Table.Fields[10].Properties.CaptionML['ENU'] | Should Be Description

        $SupplementalEntityTypeResult.Table.Keys.Count | Should Be 1
        $SupplementalEntityTypeResult.Table.Keys[0].Fields.Count | Should Be 1
        $SupplementalEntityTypeResult.Table.Keys[0].Fields[0] | Should Be Code
        $SupplementalEntityTypeResult.Table.Keys[0].Properties.Clustered | Should Be $true

        # Page
        $SupplementalEntityTypeResult.Page.ID | Should Be 60000
        $SupplementalEntityTypeResult.Page.Name | Should Be $SynthesizedPluralName

        $SupplementalEntityTypeResult.Page.ObjectProperties.DateTime | Should Be $DateTime
        $SupplementalEntityTypeResult.Page.ObjectProperties.Modified | Should Be $Modified
        $SupplementalEntityTypeResult.Page.ObjectProperties.VersionList | Should Be $VersionList

        $SupplementalEntityTypeResult.Page.Properties.CaptionML['ENU'] | Should Be $SynthesizedPluralName
        $SupplementalEntityTypeResult.Page.Properties.SourceTable | Should Be $SupplementalEntityTypeResult.Table.ID
        $SupplementalEntityTypeResult.Page.Properties.PageType | Should Be List

        $FieldPageControls = $SupplementalEntityTypeResult.Page.Controls | Where-Object { $_ -is [UncommonSense.CBreeze.Core.FieldPageControl] }
        $FieldPageControls | Where-Object { $_.Properties.SourceExpr -eq 'Code' } | Measure-Object | Select-Object -ExpandProperty Count | Should Be 1
        $FieldPageControls | Where-Object { $_.Properties.SourceExpr -eq 'Description' } | Measure-Object | Select-Object -ExpandProperty Count | Should Be 1
    }

    It 'Allows -PluralName to be overriden' {
        $MySpecialPluralName = 'MySpecialPluralName'
        $SupplementalEntityTypeResult = $Application | Add-CBreezeSupplementalEntityType -Range $Range -Name $Name -PluralName $MySpecialPluralName -PassThru

        $SupplementalEntityTypeResult.Page.Name | Should Be $MySpecialPluralName
    }
}