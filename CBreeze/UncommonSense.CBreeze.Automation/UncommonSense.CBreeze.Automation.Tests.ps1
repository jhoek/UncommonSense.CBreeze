using namespace System.Linq
using namespace UncommonSense.CBreeze.Automation

Import-Module UncommonSense.CBreeze.Automation -Force -DisableNameChecking

function Test-Application
{
	Param
	(
		[Parameter(Mandatory)]
		[UncommonSense.CBreeze.Core.Application]$Application
	)

	Test-ObjectCounts -Application $Application
	Test-Tables -Application $Application
	Test-Pages -Application $Application
	Test-Reports -Application $Application
	Test-Codeunits -Application $Application
	Test-Queries -Application $Application
}

function Test-ObjectCounts
{
    param
    (
        [Parameter(Mandatory)]
        [UncommonSense.CBreeze.Core.Application]$Application
    )

	$Application.Tables.Count | Should Be 2
	$Application.Pages.Count | Should Be 2
	$Application.Reports.Count | Should Be 2
	$Application.Codeunits.Count | Should Be 2
	$Application.Queries.Count | Should Be 2
}

function Test-Tables
{
	Param
	(
		[Parameter(Mandatory)]
		[UncommonSense.CBreeze.Core.Application]$Application
	)

	$Table = $Application.Tables[10]
	$Table.Name | Should Be MyTableInSpecifiedRange
	$Table.Properties.CaptionML['ENU'] | Should Be $Table.Name

    $Table = $Application.Tables[60000]
    $Table.Name | Should Be MyTableInDefaultRange
	$Table.Properties.CaptionML['ENU'] | Should Be $Table.Name
}

function Test-Pages
{
	Param
	(
		[Parameter(Mandatory)]
		[UncommonSense.CBreeze.Core.Application]$Application
	)

	$Page = $Application.Pages[10]
	$page.Name | Should Be MyPageInSpecifiedRange
	$page.Properties.CaptionML['ENU'] | Should Be $Page.Name

	$Page = $Application.Pages[60000]
	$Page.Name | Should Be MyPageInDefaultRange
	$Page.Properties.CaptionML['ENU'] | Should Be $Page.Name
}

function Test-Reports
{
	Param
	(
		[Parameter(Mandatory)]
		[UncommonSense.CBreeze.Core.Application]$Application
	)

	$Report = $Application.Reports[10]
	$Report.Name | Should Be MyReportInSpecifiedRange
	$Report.Properties.CaptionML['ENU'] | Should Be $Report.Name

	$Report = $Application.Reports[60000]
	$Report.Name | Should Be MyReportInDefaultRange
	$Report.Properties.CaptionML['ENU'] | Should Be $Report.Name
}

function Test-Codeunits
{
	Param
	(
		[Parameter(Mandatory)]
		[UncommonSense.CBreeze.Core.Application]$Application
	)

	$Codeunit = $Application.Codeunits[10]
	$Codeunit.Name | Should Be MyCodeunitInSpecifiedRange

	$Codeunit = $Application.Codeunits[60000]
	$Codeunit.Name | Should Be MyCodeunitInDefaultRange
}

function Test-Queries
{
	Param
	(
		[Parameter(Mandatory)]
		[UncommonSense.CBreeze.Core.Application]$Application
	)

	$Query = $Application.Queries[10]
	$Query.Name | Should Be MyQueryInSpecifiedRange
	$Query.Properties.CaptionML['ENU'] | Should Be $Query.Name

	$Query = $Application.Queries[60000]
	$Query.Name | Should Be MyQueryInDefaultRange
	$Query.Properties.CaptionML['ENU'] | Should Be $Query.Name
}

Describe 'UncommonSense.CBreeze.Automation' {
    BeforeAll {
        [UncommonSense.CBreeze.Core.DefaultRanges]::ID = [Enumerable]::Range(60000, 100)
        [UncommonSense.CBreeze.Core.DefaultRanges]::UID = [Enumerable]::Range(2000000, 100)
	}

	It 'Creates objects using New* cmdlets' {
        $Application = Application {
            Table MyTableInDefaultRange -AutoCaption
			Table 10 MyTableInSpecifiedRange -AutoCaption
			Page MyPageInDefaultRange -AutoCaption
			Page 10 MyPageInSpecifiedRange -AutoCaption
			Report MyReportInDefaultRange -AutoCaption
			Report 10 MyReportInSpecifiedRange -AutoCaption
			Codeunit MyCodeunitInDefaultRange -AutoCaption
			Codeunit 10 MyCodeunitInSpecifiedRange -AutoCaption
			Query MyQueryInDefaultRange -AutoCaption
			Query 10 MyQueryInSpecifiedRange -AutoCaption
        }

		Test-Application -Application $Application
    }

    It 'Creates objects using Add* cmdlets' {
        $Application = Application
        $Application | Table MyTableInDefaultRange -AutoCaption
		$Application | Table 10 MyTableInSpecifiedRange -AutoCaption
		$Application | Page MyPageInDefaultRange -AutoCaption
		$Application | Page 10 MyPageInSpecifiedRange -AutoCaption
		$Application | Report MyReportInDefaultRange -AutoCaption
		$Application | Report 10 MyReportInSpecifiedRange -AutoCaption
		$Application | Codeunit MyCodeunitInDefaultRange -AutoCaption
		$Application | Codeunit 10 MyCodeunitInSpecifiedRange -AutoCaption
		$Application | Query MyQueryInDefaultRange -AutoCaption
		$Application | Query 10 MyQueryInSpecifiedRange -AutoCaption

		Test-Application $Application
    }
}