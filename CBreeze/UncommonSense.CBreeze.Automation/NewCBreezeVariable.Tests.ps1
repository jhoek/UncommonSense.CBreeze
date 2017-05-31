$NextVariableID = 1
$PSDefaultParameterValues["New-CBreeze*Variable:Dimensions"] = '1,2,3'

Describe "New-CBreezeVariable" {
    It "Correctly creates variables" {
        $Codeunit = Codeunit Test {
            ActionVariable MyActionVariable
            ActionVariable ($NextVariableID++) MyOtherActionVariable

            AutomationVariable MyAutomationVariable MySubType -WithEvents $true
            AutomationVariable ($NextVariableID++) MyOtherAutomationVariable MySubType -WithEvents $true

            BigIntegerVariable MyBigIntegerVariable
            BigIntegerVariable ($NextVariableID++) MyOtherBigIntegerVariable 

            BigTextVariable MyBigTextVariable
            BigTextVariable ($NextVariableID++) MyOtherBigTextVariable 

            BinaryVariable MyBinaryVariable 123
            BinaryVariable ($NextVariableID++) MyOtherBinaryVariable 123
        } 

        Write-Host ($Codeunit | Export-CBreezeApplication)
    }
}