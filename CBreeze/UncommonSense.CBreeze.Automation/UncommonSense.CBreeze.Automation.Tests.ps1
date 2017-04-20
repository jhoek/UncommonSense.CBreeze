Import-Module UncommonSense.CBreeze.Automation -Force -DisableNameChecking

$PSDefaultParameterValues['New-CBreeze*:AutoCaption'] = $true
$PSDefaultParameterValues['Add-CBreeze*:AutoCaption'] = $true

function Test-Application
{
    param
    (
        [Parameter(Mandatory)]
        [UncommonSense.CBreeze.Core.Application]$Application
    )

    $Table = $Application.Tables[50000]
    $Table.Name | Should Be Table
	$Table.Properties.CaptionML['ENU'] | Should Be Table

    $Page = $Application.Pages[50000]
    $Page.Name | Should Be Page

    $Report = $Application.Reports[50000]
    $Report.Name | Should Be Report

    $Codeunit = $Application.Codeunits[50000]
    $Codeunit.Name | Should Be Codeunit

    $Query = $Application.Queries[50000]
    $Query.Name | Should Be Query

    $XmlPort = $Application.XmlPorts[50000]
    $XmlPort.Name | Should Be XmlPort

    $MenuSuite = $Application.MenuSuites[50000]
    $MenuSuite.Name | Should Be MenuSuite
}

Describe 'UncommonSense.CBreeze.Automation' {
    It 'Creates objects using New* cmdlets' {
        $Application = Application {
            Table 50000 Table
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

        $Application | Add-CBreezeTable 50000 Table -PassThru:$false
        $Application | Add-CBreezePage 50000 Page -PassThru:$false
        $Application | Add-CBreezeReport 50000 Report -PassThru:$false
        $Application | Add-CBreezeCodeunit 50000 Codeunit -PassThru:$false
        $Application | Add-CBreezeQuery 50000 Query -PassThru:$false
        $Application | Add-CBreezeXmlPort 50000 XmlPort -PassThru:$false
        $Application | Add-CBreezeMenuSuite 50000 MenuSuite -PassThru:$false

        Test-Application -Application $Application
    }
}