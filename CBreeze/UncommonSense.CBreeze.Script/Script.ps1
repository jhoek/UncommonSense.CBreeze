Properties {
	[ValidateSet('tab', 'pag', 'rep', 'cod', 'xml', 'que', 'men')]
	[string[]]$ObjectTypes = 'tab', 'pag', 'rep', 'cod', 'xml', 'que', 'men'
	[string]$BaseFolder = "~\Desktop"
	[string]$InputFolder = Join-Path -Path $BaseFolder -ChildPath input
	[string]$OutputFolder = Join-Path -Path $BaseFolder -ChildPath output
	[string]$ScriptsFolder = Join-Path -Path $BaseFolder -ChildPath scripts
}

Task Default -Depends StartCompareTool

Task StartCompareTool -Depends RunScripts {
	
}

Task RunScripts -Depends CreateOutputFolder, CreateScripts {

}

Task CreateScripts -Depends CreateScriptFolder {
	Get-ChildItem -Path $InputFolder -File |
		ForEach-Object {
			Import-CBreezeApplication -Path $_.FullName | 
				ConvertTo-CBreezeScript |
				Out-File -FilePath ([System.IO.Path]::ChangeExtension($_.FullName, '.ps1'))
		}
}

Task CreateScriptFolder -depends DeleteScriptFolder {
	New-Item -Path $ScriptsFolder -ItemType Directory | Out-Null
}

Task DeleteScriptFolder {
	Remove-Item -Path $ScriptsFolder -Recurse -Force -ErrorAction Continue
}

Task CreateOutputFolder -Depends DeleteOutputFolder {
	New-Item -Path $OutputFolder -ItemType Directory | Out-Null
}

Task DeleteOutputFolder {
	Remove-Item -Path $OutputFolder -Recurse -Force -ErrorAction Continue
}