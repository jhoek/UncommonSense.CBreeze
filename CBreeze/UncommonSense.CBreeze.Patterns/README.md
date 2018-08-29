# UncommonSense.CBreeze.Patterns

The PowerShell cmdlets in this folder are intended as a demonstration of what is possible with C/Breeze in terms of automating and standardizing your C/SIDE development tasks. They are written in PowerShell (as opposed to a compiled .NET language) to encourage user exploration and customization.

## Output Variables

Although their names seem to imply that these cmdlets add only one element (table, page, field, ...) to your C/SIDE application, they tend to make all sorts of required, related modifications as well. For example, when adding a field to a table, the cmdlets typically also offer the possibility to add a bound control to one or more pages. The cmdlets return the primary object of the modification, e.g. when adding a field, the table to which the field was added is returned. Optionally, you can specify an output variable name in the desired parameter to assign modified elements (e.g. fields, controls, keys) to variables for easier access.