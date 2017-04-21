using namespace System.Linq
using namespace UncommonSense.CBreeze.Automation

Import-Module UncommonSense.CBreeze.Automation -Force -DisableNameChecking

function Test-Application
{
    param
    (
        [Parameter(Mandatory)]
        [UncommonSense.CBreeze.Core.Application]$Application
    )

    $Table = $Application.Tables[60000]
    $Table.Name | Should Be MyTable
	#$Table.Properties.CaptionML['ENU'] | Should Be MyTable

    $Page = $Application.Pages[60000]
    $Page.Name | Should Be MyPage

    $Report = $Application.Reports[60000]
    $Report.Name | Should Be Report

    $Codeunit = $Application.Codeunits[60000]
    $Codeunit.Name | Should Be Codeunit

    $Query = $Application.Queries[60000]
    $Query.Name | Should Be Query

    $XmlPort = $Application.XmlPorts[60000]
    $XmlPort.Name | Should Be XmlPort

    $MenuSuite = $Application.MenuSuites[60000]
    $MenuSuite.Name | Should Be MenuSuite
}

Describe 'UncommonSense.CBreeze.Automation' {
    BeforeEach {
        [UncommonSense.CBreeze.Core.DefaultRanges]::ID = [Enumerable]::Range(60000, 100)
        [UncommonSense.CBreeze.Core.DefaultRanges]::UID = [Enumerable]::Range(2000000, 100)
	}

	It 'Creates objects using New* cmdlets' {
        $Application = Application {
            Table MyTable
            Page 50000 Page
            Report 50000 Report
            Codeunit 50000 Codeunit
            Query 50000 Query
            XmlPort 50000 XmlPort {
				XmlPortNode -Name Customer -Element -Table -SourceTable ([UncommonSense.CBreeze.Core.BaseApp+TableIDs]::Customer) -ChildNodes {
                    XmlPortNode -Name No -Element -Field -SourceFieldName "NO."
                }
			}
            MenuSuite 50000 MenuSuite
        }

        Test-Application -Application $Application
    }

    It 'Creates objects using Add* cmdlets' {
        $Application = New-CBreezeApplication

        $Application | Add-CBreezeTable MyTable -PassThru
        $Application | Add-CBreezePage MyPage -PassThru:$false
        $Application | Add-CBreezeReport MyReport -PassThru:$false
        $Application | Add-CBreezeCodeunit MyCodeunit -PassThru:$false
        $Application | Add-CBreezeQuery MyQuery -PassThru:$false
        $Application | Add-CBreezeXmlPort MyXmlPort -PassThru:$false
        $Application | Add-CBreezeMenuSuite MyMenuSuite -PassThru:$false

        Test-Application -Application $Application
    }
}