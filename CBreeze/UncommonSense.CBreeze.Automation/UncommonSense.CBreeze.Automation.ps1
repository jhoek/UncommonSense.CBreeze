function TableNameCompleter {
    param
    (
        $commandName, 
        $parameterName, 
        $wordToComplete, 
        $commandAst, 
        $fakeBoundParameter
    )

    Write-Host $wordToComplete

    [UncommonSense.CBreeze.Core.BaseApp+TableNames].GetFields('Static,Public') | 
        ForEach-Object { $_.GetValue($null) } |
        Where-Object { $_ -like "$WordToComplete*" } |
        Sort-Object |
        ForEach-Object { "'$_'" }
}

Register-ArgumentCompleter -CommandName 'New-CBreezeCalcFormula' -ParameterName TableName -ScriptBlock ${function:TableNameCompleter}
Register-ArgumentCompleter -CommandName 'Add-CBreezeTableRelation' -ParameterName TableName -ScriptBlock ${function:TableNameCompleter}