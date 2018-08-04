Describe 'Add-CBreezeDocumentEntityType' {
    
    BeforeEach {
        $Application = New-CBreezeApplication 
        $SetupTable = $Application | Add-CBreezeObject -Type Table -ID 50000 -Name 'Dummy Setup Table'
        $SetupPage = $Application | Add-CBreezeObject -Type Page -ID 50000 -Name 'Dummy Setup Page'
        $Range = [System.Linq.Enumerable]::Range(60000, 100)
        $BaseName = 'My Document'
        $DocumentTypes = 'Type1', 'Type2', 'Type3'
        $DateTime = Get-Date -Year 2015 -Month 8 -Day 10 -Hour 13 -Minute 0 -Second 0
        $Modified = $true
        $VersionList = 'NAVJH1.00'
    }

    It 'Creates document entity type tables and pages without document types' {
        $DocumentEntityTypeResult = $Application | Add-CBreezeDocumentEntityType -Range $Range -BaseName $BaseName -SetupTable $SetupTable -SetupPage $SetupPage -DateTime $DateTime -Modified $Modified -VersionList $VersionList -PassThru

        $DocumentEntityTypeResult.Header.Table.ID | Should Be 60000
        $DocumentEntityTypeResult.Header.Table.Name | Should Be "$BaseName Header"
        $DocumentEntityTypeResult.Header.Table.Properties.CaptionML['ENU'] | Should Be $DocumentEntityTypeResult.Header.Table.Name
        $DocumentEntityTypeResult.Header.Table.ObjectProperties.DateTime | Should Be $DateTime
        $DocumentEntityTypeResult.Header.Table.ObjectProperties.Modified | Should Be $Modified
        $DocumentEntityTypeResult.Header.Table.ObjectProperties.VersionList | Should Be $VersionList

        $DocumentEntityTypeResult.Line.Table.ID | Should Be 60001
        $DocumentEntityTypeResult.Line.Table.Name | Should Be "$BaseName Line"
        $DocumentEntityTypeResult.Line.Table.Properties.CaptionML['ENU'] | Should Be $DocumentEntityTypeResult.Line.Table.Name
        $DocumentEntityTypeResult.Line.Table.ObjectProperties.DateTime | Should Be $DateTime
        $DocumentEntityTypeResult.Line.Table.ObjectProperties.Modified | Should Be $Modified
        $DocumentEntityTypeResult.Line.Table.ObjectProperties.VersionList | Should Be $VersionList
    }

    It 'Creates document entity type tables and pages with document types' {
        $DocumentEntityTypeResult = $Application | Add-CBreezeDocumentEntityType -Range $Range -BaseName $BaseName -DocumentTypes $DocumentTypes -SetupTable $SetupTable -SetupPage $SetupPage -DateTime $DateTime -Modified $Modified -VersionList $VersionList -PassThru

        $DocumentEntityTypeResult.Header.Table.ID | Should Be 60000
        $DocumentEntityTypeResult.Header.Table.Name | Should Be "$BaseName Header"
        $DocumentEntityTypeResult.Header.Table.Properties.CaptionML['ENU'] | Should Be $DocumentEntityTypeResult.Header.Table.Name
        $DocumentEntityTypeResult.Header.Table.ObjectProperties.DateTime | Should Be $DateTime
        $DocumentEntityTypeResult.Header.Table.ObjectProperties.Modified | Should Be $Modified
        $DocumentEntityTypeResult.Header.Table.ObjectProperties.VersionList | Should Be $VersionList

        $DocumentEntityTypeResult.Line.Table.ID | Should Be 60001
        $DocumentEntityTypeResult.Line.Table.Name | Should Be "$BaseName Line"
        $DocumentEntityTypeResult.Line.Table.Properties.CaptionML['ENU'] | Should Be $DocumentEntityTypeResult.Line.Table.Name
        $DocumentEntityTypeResult.Line.Table.ObjectProperties.DateTime | Should Be $DateTime
        $DocumentEntityTypeResult.Line.Table.ObjectProperties.Modified | Should Be $Modified
        $DocumentEntityTypeResult.Line.Table.ObjectProperties.VersionList | Should Be $VersionList
    }

    It 'Allows -HeaderName and -LineName to be overridden' {
        $HeaderName = 'My Header Name'
        $LineName = 'My Line Name'

        $DocumentEntityTypeResult = $Application | Add-CBreezeDocumentEntityType -Range $Range -BaseName $BaseName -HeaderName $HeaderName -LineName $LineName -SetupTable $SetupTable -PassThru

        $DocumentEntityTypeResult.Header.Table.Name | Should Be $HeaderName
        $DocumentEntityTypeResult.Line.Table.Name | Should Be $LineName
    }

    It 'Has a posting date if -HasPostingDate is set' {
        
    }

    It 'Has no posting date date if -HasPostingDate is not set' {
    }
}

