# Command-style aliases
Set-Alias -Name Compile -Value Compile-CBreezeApplication
Set-Alias -Name Export -Value Export-CBreezeApplication
Set-Alias -Name Import -Value Import-CBreezeApplication
Set-Alias -Name Invoke -Value Invoke-CBreezeObject

# Fluent-style aliases
Set-Alias -Name Application -Value New-CBreezeApplication
Set-Alias -Name CalcFormula -Value New-CBreezeCalcFormula
Set-Alias -Name Codeunit -Value Add-CBreezeCodeunit
Set-Alias -name Event -Value New-CBreezeEvent
Set-Alias -Name Procedure -Value New-CBreezeFunction
Set-Alias -Name _Function -Value New-CBreezeFunction
Set-Alias -Name MenuSuite -Value Add-CBreezeMenuSuite
Set-Alias -Name MenuSuiteNode -Value New-CBreezeMenuSuiteNode
Set-Alias -Name OrderBy -Value New-CBreezeOrderBy
Set-Alias -Name Page -Value Add-CBreezePage
Set-Alias -Name Action -Value New-CBreezePageAction
Set-Alias -Name ActionContainer -Value New-CBreezePageActionContainer
Set-Alias -Name ActionGroup -Value New-CBreezePageActionGroup
Set-Alias -Name ActionSeparator -Value New-CBreezePageActionSeparator
Set-Alias -Name Control -Value New-CBreezePageControl
Set-Alias -Name Parameter -Value New-CBreezeParameter
Set-Alias -Name Query -Value Add-CBreezeQuery
Set-Alias -Name Report -Value Add-CBreezeReport
Set-Alias -Name Label -Value New-CBreezeReportLabel
Set-Alias -Name Table -Value Add-CBreezeTable
Set-Alias -Name Field -Value New-CBreezeTableField
Set-Alias -Name FieldGroup -Value New-CBreezeTableFieldGroup
Set-Alias -Name Key -Value New-CBreezeTableKey
Set-Alias -Name Variable -Value New-CBreezeVariable
Set-Alias -Name XmlPort -Value Add-CBreezeXmlPort
Set-Alias -Name XmlPortNode -Value New-CBreezeXmlPortNode
Set-Alias -Name _Filter -Value Add-CBreezeFilter

# Export members
Export-ModuleMember -Alias * -Function * -Cmdlet *