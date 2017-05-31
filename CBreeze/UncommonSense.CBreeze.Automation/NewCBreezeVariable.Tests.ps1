Describe "New-CBreezeVariable" {
    It "Correctly creates variables" {
        $Codeunit = Codeunit Test {
            ActionVariable MyActionVariable -Dimensions '1,2,3'
            AutomationVariable MyAutomationVariable MySubType -Dimensions '1,2,3'
        } 

        Write-Host ($Codeunit | Export-CBreezeApplication)
    }
}