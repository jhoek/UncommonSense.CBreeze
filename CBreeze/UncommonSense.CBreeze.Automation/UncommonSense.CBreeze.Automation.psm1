# Short aliases
# Basic recipe:
# - Abbreviated approved verb
# - 'c' for C/Breeze
# - Abbreviated noun
Set-Alias -Name accl -Value Add-CBreezeCodeLine
Set-Alias -Name acco -Value Add-CBreezeCondition
Set-Alias -Name acev -Value Add-CBreezeEvent
Set-Alias -Name acfi -Value Add-CBreezeFilter
Set-Alias -Name acfu -Value Add-CBreezeFunction
Set-Alias -Name acli -Value Add-CBreezeLink
Set-Alias -Name acmn -Value Add-CBreezeMenuSuiteNode
Set-Alias -Name acob -Value Add-CBreezeObject
Set-Alias -Name acor -Value Add-CBreezeOrderBy
Set-Alias -Name acpa -Value Add-CBreezePageAction
Set-Alias -Name acpc -Value Add-CBreezePageControl
Set-Alias -Name acpm -Value Add-CBreezeParameter
Set-Alias -Name acqe -Value Add-CBreezeQueryElement
Set-Alias -Name acre -Value Add-CBreezeReportElement
Set-Alias -Name acrl -Value Add-CBreezeReportLabel
Set-Alias -Name actf -Value Add-CBreezeTableField
Set-Alias -Name acfg -Value Add-CBreezeTableFieldGroup
Set-Alias -Name actk -Value Add-CBreezeTableKey
Set-Alias -Name actr -Value Add-CBreezeTableRelation
Set-Alias -Name acva -Value Add-CBreezeVariable
Set-Alias -Name acxl -Value Add-CBreezeXmlPortLink
Set-Alias -Name acxn -Value Add-CBreezeXmlPortNode
Set-Alias -Name epca -Value Export-CBreezeApplication
Set-Alias -Name gcpac -Value Get-CBreezePageActionContainer
Set-Alias -Name gcpag -Value Get-CBreezePageActionGroup
Set-Alias -Name gcpcc -Value Get-CBreezePageControlContainer
Set-Alias -Name gcpcg -Value Get-CBreezePageControlGroup
Set-Alias -Name ipca -Value Import-CBreezeApplication
Set-Alias -Name icob -Value Invoke-CBreezeObject
Set-Alias -Name ncap -Value New-CBreezeApplication
Set-Alias -Name scabp -Value Set-CBreezeAccessByPermission
Set-Alias -Name scml -Value Set-CBreezeMLValue
Set-Alias -Name scpe -Value Set-CBreezePermission

# Command-style aliases
Set-Alias -Name Compile -Value Compile-CBreezeApplication
Set-Alias -Name Export -Value Export-CBreezeApplication
Set-Alias -Name Import -Value Import-CBreezeApplication
Set-Alias -Name Invoke -Value Invoke-CBreezeObject 

# Fluent-style aliases
Set-Alias -Name Application -Value New-CBreezeApplication
Set-Alias -Name Table -Value New-CBreezeTable
Set-Alias -Name Page -Value New-CBreezePage
Set-Alias -Name Report -Value New-CBreezeReport
Set-Alias -Name XmlPort -Value New-CBreezeXmlPort
Set-Alias -Name Codeunit -Value New-CBreezeCodeunit
Set-Alias -Name Query -Value New-CBreezeQuery
Set-Alias -Name MenuSuite -Value New-CBreezeMenuSuite

# Export members
Export-ModuleMember -Alias * -Function * -Cmdlet *