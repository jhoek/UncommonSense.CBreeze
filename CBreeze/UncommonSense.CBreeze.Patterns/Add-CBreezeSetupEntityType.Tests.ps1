Describe 'Add-CBreezeSetupEntityType' {

    BeforeEach {
        $Application = New-CBreezeApplication
        $Range = [System.Linq.Enumerable]::Range(60000, 100)
        $Name = 'My Setup'
        $DateTime = Get-Date -Year 2015 -Month 8 -Day 10 -Hour 13 -Minute 0 -Second 0
        $Modified = $true
        $VersionList = 'NAVJH1.00'
    }

    It 'Creates a setup table and page' {
        $SetupEntityTypeResult = $Application | Add-CBreezeSetupEntityType -Range $Range -Name $Name -DateTime $DateTime -Modified $Modified -VersionList $VersionList -PassThru

        # Table
        $SetupEntityTypeResult.Table.ID | Should Be 60000
        $SetupEntityTypeResult.Table.Name | Should Be $Name

        $SetupEntityTypeResult.Table.ObjectProperties.DateTime | Should Be $DateTime
        $SetupEntityTypeResult.Table.ObjectProperties.Modified | Should Be $Modified
        $SetupEntityTypeResult.Table.ObjectProperties.VersionList | Should Be $VersionList

        $SetupEntityTypeResult.Table.Properties.CaptionML['ENU'] | Should Be $Name

        $SetupEntityTypeResult.Table.Fields.Count | Should Be 1
        $SetupEntityTypeResult.Table.Fields[1].Type | Should Be Code
        $SetupEntityTypeResult.Table.Fields[1].DataLength | Should Be 10
        $SetupEntityTypeResult.Table.Fields[1].Name | Should Be 'Primary Key'
        $SetupEntityTypeResult.Table.Fields[1].Properties.CaptionML['ENU'] | Should Be 'Primary Key'

        $SetupEntityTypeResult.Table.Keys.Count | Should Be 1
        $SetupEntityTypeResult.Table.Keys[0].Fields.Count | Should Be 1
        $SetupEntityTypeResult.Table.Keys[0].Fields[0] | Should Be 'Primary Key'
        $SetupEntityTypeResult.Table.Keys[0].Properties.Clustered | Should Be $true

        # Page
        $SetupEntityTypeResult.Page.ID | Should Be 60000
        $SetupEntityTypeResult.Page.Name | Should Be $Name

        $SetupEntityTypeResult.Page.ObjectProperties.DateTime | Should Be $DateTime
        $SetupEntityTypeResult.Page.ObjectProperties.Modified | Should Be $Modified
        $SetupEntityTypeResult.Page.ObjectProperties.VersionList | Should Be $VersionList
        
        $SetupEntityTypeResult.Page.Properties.CaptionML['ENU'] | Should Be $Name
        $SetupEntityTypeResult.Page.Properties.PageType | Should Be Card
        $SetupEntityTypeResult.Page.Properties.InsertAllowed | Should Be $false
        $SetupEntityTypeResult.Page.Properties.DeleteAllowed | Should Be $false
        $SetupEntityTypeResult.Page.Properties.SourceTable | Should Be $SetupEntityTypeResult.Table.ID

        $SetupEntityTypeResult.Page.Properties.OnOpenPage.CodeLines.Count | Should Be 5
    }
}