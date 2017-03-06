# Command-style aliases
Set-Alias -Name Compile -Value Compile-CBreezeApplication
Set-Alias -Name Export -Value Export-CBreezeApplication
Set-Alias -Name Import -Value Import-CBreezeApplication
Set-Alias -Name Invoke -Value Invoke-CBreezeObject

# Fluent-style aliases
Set-Alias -Name Application -Value New-CBreezeApplication
Set-Alias -Name CalcFormula -Value New-CBreezeCalcFormula
Set-Alias -Name Codeunit -Value New-CBreezeCodeunit
Set-Alias -name Event -Value New-CBreezeEvent
Set-Alias -Name Procedure -Value New-CBreezeFunction
Set-Alias -Name MenuSuite -Value New-CBreezeMenuSuite
Set-Alias -Name MenuSuiteNode -Value New-CBreezeMenuSuiteNode
Set-Alias -Name OrderBy -Value New-CBreezeOrderBy
Set-Alias -Name Page -Value New-CBreezePage
Set-Alias -Name Action -Value New-CBreezePageAction
Set-Alias -Name ActionContainer -Value New-CBreezePageActionContainer
Set-Alias -Name ActionGroup -Value New-CBreezePageActionGroup
Set-Alias -Name ActionSeparator -Value New-CBreezePageActionSeparator
Set-Alias -Name Control -Value New-CBreezePageControl
Set-Alias -Name Parameter -Value New-CBreezeParameter
Set-Alias -Name Query -Value New-CBreezeQuery
Set-Alias -Name Report -Value New-CBreezeReport
Set-Alias -Name Label -Value New-CBreezeReportLabel
Set-Alias -Name Table -Value New-CBreezeTable
Set-Alias -Name Field -Value New-CBreezeTableField
Set-Alias -Name FieldGroup -Value New-CBreezeTableFieldGroup
Set-Alias -Name Key -Value New-CBreezeTableKey
Set-Alias -Name Variable -Value New-CBreezeVariable
Set-Alias -Name XmlPort -Value New-CBreezeXmlPort

# Export members
Export-ModuleMember -Alias * -Function * -Cmdlet *