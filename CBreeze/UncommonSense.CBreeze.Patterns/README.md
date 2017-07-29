# UncommonSense.CBreeze.Patterns

The PowerShell cmdlets in this folder are intended as a demonstration of what is possible with C/Breeze in terms of macroing your C/SIDE development tasks. They are written in PowerShell (as opposed to a compiled .NET language) to encourage user exploration and customization.

## -Manifest switch

Although their names seem to imply that these cmdlets add only one element (table, page, field, ...) to your C/SIDE application, they tend to make all sorts of required, related modifications as well. For example, when adding a field to a table, they typically also offer the possibility to add a corresponding control to one or more pages.

In some use cases, you're primarily interested in receiving the newly created field as a return value from the cmdlet. In some others, however, you need references to all the objects and subobjects that were created. The `-Manifest` switch parameter can be added to cmdlets to indicate what you would like the cmdlet's return value to be:

- If `-Manifest` is not present, the cmdlet should return only the newly created, primary item. Without `-Manifest`, `New-CBreezeUserIDField` simply returns the User ID that it created;
- If `-Manifest` is present, the cmdlet should return a structure containing references to all objects and subobjects that it created (or modified #FIXME).

For consistency's sake, I strongly encourage you to follow this same pattern in any custom pattern cmdlets that you might make. The returned structure should look like this:

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
