function TableNameCompleter {
    param
    (
        $commandName, 
        $parameterName, 
        $wordToComplete, 
        $commandAst, 
        $fakeBoundParameter
    )

    [UncommonSense.CBreeze.Core.BaseApp+TableNames].GetFields('Static,Public') | 
        ForEach-Object { $_.GetValue($null) } |
        Where-Object { $_ -like "$WordToComplete*" } |
        Sort-Object |
        ForEach-Object { "'$_'" }
}

function PageNameCompleter {
    param
    (
        $commandName, 
        $parameterName, 
        $wordToComplete, 
        $commandAst, 
        $fakeBoundParameter
    )

    [UncommonSense.CBreeze.Core.BaseApp+PageNames].GetFields('Static,Public') | 
        ForEach-Object { $_.GetValue($null) } |
        Where-Object { $_ -like "$WordToComplete*" } |
        Sort-Object |
        ForEach-Object { "'$_'" }
}

function ImageNameCompleter {
    param
    (
        $commandName, 
        $parameterName, 
        $wordToComplete, 
        $commandAst, 
        $fakeBoundParameter
    )
	
	[UncommonSense.CBreeze.Core.RunTime+Images].GetFields('Static,Public') |
		ForEach-Object { $_.GetValue($null) } |
		Where-Object { $_ -like "$wordToComplete*"} |
		Sort-Object |
		ForEach-Object { "'$_'" }
}

Register-ArgumentCompleter -ParameterName TableName -ScriptBlock ${function:TableNameCompleter}
Register-ArgumentCompleter -ParameterName CardPageID -ScriptBlock ${function:PageNameCompleter}
Register-ArgumentCompleter -ParameterName DrillDownPageID -ScriptBlock ${function:PageNameCompleter}
Register-ArgumentCompleter -ParameterName LookupPageID -ScriptBlock ${function:PageNameCompleter}
Register-ArgumentCompleter -CommandName 'New-CBreezePageAction' -ParameterName Image -ScriptBlock ${function:ImageNameCompleter}
Register-ArgumentCompleter -CommandName 'New-CBreezePageGroup' -ParameterName Image -ScriptBlock ${function:ImageNameCompleter}