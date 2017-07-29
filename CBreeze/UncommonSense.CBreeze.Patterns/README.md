# UncommonSense.CBreeze.Patterns

The PowerShell cmdlets in this folders are intended as a demonstration of what is possible with C/Breeze in terms of macroing your C/SIDE development tasks. They are written in PowerShell (as opposed to a compiled .NET language) to encourage user exploration and customization.

```powershell
# Field patterns
$Result = @{}
$Result.Fields = @{}
$Result.Controls = @{}
$Result.Controls.No = @{}
$Result.Controls.NoSeries = @{}

$Result.Fields.No = $NoField
$Result.Fields.NoSeries = $NoSeriesField
$Result.Controls.No.Add($Page, $NoControl)
$Result.Controls.NoSeries.Add($Page, $NoSeriesControl)

# Single table entity type patterns
$Result = @{}
$Result.Table = @Table
$Result.CardPage = @CardPage
$Result.ListPage = @ListPage
$Result.Fields = @{}
$Result.Fields.No = $NoField
$Result.PrimaryKey = @TableKey
$Result.Controls = @{}
$Result.Controls.No = @{}
$Result.Controls.No.Add($CardPage, $NoControl)

# Multiple table entity type patterns
$Result = @{}
$Result.Header = @{}
$Result.Header.Table = @Table
$Result.Header.Fields = @{}
$Result.Header.Fields.No = $NoField
$Result.Header.CardPage = @CardPage
$Result.Header.ListPage = @ListPage
$Result.Header.Controls = @{}
$Result.Header.Controls.No = @{}
$Result.Header.Controls.No.Add($CardPage, $NoControl)
$Result.Line = @{}
$Result.Line.Table = @Table
$Result.Line.Fields = @{}
$Result.Line.Fields.LineNo = $LineNoField
$Result.Line.SubPage = @SubPage
$Result.Line.Controls = @{}
$Result.Line.Controls.LineNo = @{}
$Result.Line.Controls.LineNo.Add($SubPage, $LineNoControl)
```	
