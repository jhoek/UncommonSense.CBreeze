using namespace System.Linq
using namespace UncommonSense.CBreeze.Automation

Import-Module UncommonSense.CBreeze.Automation -Force -DisableNameChecking

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
        }

        Test-ObjectCounts -Application $Application
		Test-Tables -Application $Application
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

        Test-ObjectCounts -Application $Application
		Test-Tables -Application $Application
    }
}