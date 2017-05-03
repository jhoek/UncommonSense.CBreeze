function Slide
{
    Param
    (
        [ScriptBlock]$Contents
    )

    $global:WordCount = 0

    Clear-Host
    . $Contents
}

function Paragraph
{
    Param
    (
        [ScriptBlock]$Contents
    )    

    . $Contents
    BlankLine

    $Pause = (($global:WordCount * 150), 2000 | Measure-Object -Maximum).Maximum
    Start-Sleep -Milliseconds $Pause

    $global:WordCount = 0
}

function Title 
{
    Param
    (
        [Parameter(Mandatory)]
        [string]$Text
    )

    Text -Text $Text -ForegroundColor Cyan
    BlankLine 
}

function BlankLine
{
    Write-Host ""
}

function Text
{
    Param
    (
        [Parameter(Mandatory)]
        [string]$Text,

        [ValidateNotNullOrEmpty()]
        [string]$ForegroundColor = 'DarkCyan',

        [Switch]$EndOfParagraph
    )

    Write-Host $Text -ForegroundColor $ForegroundColor
    $global:WordCount += ($Text | Measure-Object -Word).Words
}

function Script
{
    Param
    (
        [Parameter(Mandatory)][ScriptBlock]$Script,
        [ValidateRange(0, 10)][int]$PauseAfter = 4
    )
        Write-Host "PS>$($Script -replace 'global:', '')"
        . $Script
        Write-Host ''

        Start-Sleep -Seconds $PauseAfter
}