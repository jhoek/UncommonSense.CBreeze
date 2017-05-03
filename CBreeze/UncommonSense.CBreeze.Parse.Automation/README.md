# UncommonSense.CBreeze.Parse.Automation
PowerShell wrapper for UncommonSense.CBreeze.Parser library

## Installation instructions

- Build the C# project;
- Navigate to the folder containing the resulting DLL (actual path depends on your build configuration);
- Import the DLL into your PowerShell session:

```powershell
Import-Module .\UncommonSense.CBreeze.Parse.Automation.dll
```
      
<a name="Invoke-CBreezeParser"></a>
## Invoke-CBreezeParser
### Synopsis
Parses a Microsoft Dynamics NAV text export and enumerates the objects and subobjects found.
### Description
Uses the UncommonSense.CBreeze.Parser library to parse the objects in the file named LiteralPath. Provide scriptblock parameters to respond to the events that are triggered as (sub)objects are found.

### Syntax
```powershell
Invoke-CBreezeParser -LiteralPath <string[]> [-OnBeginApplication <scriptblock>] [-OnEndApplication <scriptblock>] [-OnBeginFile <scriptblock>] [-OnEndFile <scriptblock>] [-OnBeginObject <scriptblock>] [-OnEndObject <scriptblock>] [-OnBeginSection <scriptblock>] [-OnEndSection <scriptblock>] [-OnBeginTrigger <scriptblock>] [-OnEndTrigger <scriptblock>] [-OnObjectProperty <scriptblock>] [-OnProperty <scriptblock>] [-OnBeginTableField <scriptblock>] [-OnEndTableField <scriptblock>] [-OnBeginTableKey <scriptblock>] [-OnEndTableKey <scriptblock>] [-OnBeginTableFieldGroup <scriptblock>] [-OnEndTableFieldGroup <scriptblock>] [-OnBeginPageAction <scriptblock>] [-OnEndPageAction <scriptblock>] [-OnBeginPageControl <scriptblock>] [-OnEndPageControl <scriptblock>] [-OnBeginRequestPage <scriptblock>] [-OnEndRequestPage <scriptblock>] [-OnBeginReportElement <scriptblock>] [-OnEndReportElement <scriptblock>] [-OnBeginReportLabel <scriptblock>] [-OnEndReportLabel <scriptblock>] [-OnBeginEvent <scriptblock>] [-OnEndEvent <scriptblock>] [-OnFunctionAttribute <scriptblock>] [-OnBeginFunction <scriptblock>] [-OnEndFunction <scriptblock>] [-OnParameter <scriptblock>] [-OnVariable <scriptblock>] [-OnReturnValue <scriptblock>] [-OnCodeLine <scriptblock>] [-OnBeginQueryElement <scriptblock>] [-OnEndQueryElement <scriptblock>] [-OnBeginXmlPortElement <scriptblock>] [-OnEndXmlPortElement <scriptblock>] [-OnBeginMenuSuiteNode <scriptblock>] [-OnEndMenuSuiteNode <scriptblock>] [<CommonParameters>]
```
### Parameters
#### LiteralPath &lt;string[]&gt;
    
    Required?                    true
    Position?                    named
    Default value                
    Accept pipeline input?       true (ByValue, ByPropertyName)
    Accept wildcard characters?  false
#### FullName &lt;string[]&gt;
    This is an alias of the LiteralPath parameter.
    
    Required?                    true
    Position?                    named
    Default value                
    Accept pipeline input?       true (ByValue, ByPropertyName)
    Accept wildcard characters?  false
#### OnBeginApplication &lt;ScriptBlock&gt;
    Called before a parsing run starts, regardless of the input type.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnEndApplication &lt;ScriptBlock&gt;
    Called after a parsing run is complete.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnBeginFile &lt;ScriptBlock&gt;
    Called before parsing objects from a text file. This method is called only when parsing objects from text files. Receives the name of the file being loaded.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnEndFile &lt;ScriptBlock&gt;
    Called after parsing a text file is complete. This method is called only when parsing objects from text files.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnBeginObject &lt;ScriptBlock&gt;
    Called when an object is found in the input. Receives the type, ID and name of the object found.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnEndObject &lt;ScriptBlock&gt;
    Called when parsing of an object is complete.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnBeginSection &lt;ScriptBlock&gt;
    Called when an object section (object properties, table fields, C/AL code, etc.) is found in the input. Receives the type of the section found.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnEndSection &lt;ScriptBlock&gt;
    Called when parsing of a section is complete.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnBeginTrigger &lt;ScriptBlock&gt;
    Called when a trigger is found in the input. Receives the name of the trigger found.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnEndTrigger &lt;ScriptBlock&gt;
    Called when parsing of a trigger is complete.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnObjectProperty &lt;ScriptBlock&gt;
    Called when an object property (Date, Time, Modified or Version List) is found in the input. Receives the name and value (as string) of the property found.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnProperty &lt;ScriptBlock&gt;
    Called when a property (Date, Time, Modified or Version List) is found in the input. Receives the name and value (as string) of the property found.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnBeginTableField &lt;ScriptBlock&gt;
    Called when a table field is found in the input. Receives the ID, whether or not the field is enabled (null implies the default value, i.c. true), the name, the type (Integer, Decimal, GUID, etc.) and the length (if applicable to fields of this type) of the table field found.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnEndTableField &lt;ScriptBlock&gt;
    Called when parsing of a table field is complete.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnBeginTableKey &lt;ScriptBlock&gt;
    Called when a table key is found in the input. Receives whether or not the key is enabled (null implies the default value, i.c. true) and the names of the key fields.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnEndTableKey &lt;ScriptBlock&gt;
    Called when parsing of a table key is complete.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnBeginTableFieldGroup &lt;ScriptBlock&gt;
    Called when a table field group is found in the input. Receives the unique ID and name of the field group, and the names of the field group fields.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnEndTableFieldGroup &lt;ScriptBlock&gt;
    Called when parsing of a table field group is complete.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnBeginPageAction &lt;ScriptBlock&gt;
    Called when a page action is found in the input. Receives the indentation level (null implies the default value, i.c. 0) and the type of the action (container, group, action or separator).
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnEndPageAction &lt;ScriptBlock&gt;
    Called when parsing of a page action is complete.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnBeginPageControl &lt;ScriptBlock&gt;
    Called when a page control is found in the input. Receives the unique ID, the indentation level (null implies the default value, i.c. 0) and the type of the control (container, group, field or part).
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnEndPageControl &lt;ScriptBlock&gt;
    Called when parsing of a page control is complete.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnBeginRequestPage &lt;ScriptBlock&gt;
    Called when a request page is found in the input.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnEndRequestPage &lt;ScriptBlock&gt;
    Called when parsing of a request page is complete.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnBeginReportElement &lt;ScriptBlock&gt;
    Called when a report element is found in the input. Receives the unique ID, indentation level (null implies the default value, i.c. 0), name and type (dataitem or column) of the element.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnEndReportElement &lt;ScriptBlock&gt;
    Called when parsing of a report element is complete.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnBeginReportLabel &lt;ScriptBlock&gt;
    Called when a report label is found in the input. Receives the unique ID and the name of the label.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnEndReportLabel &lt;ScriptBlock&gt;
    Called when parsing of a report label is complete.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnBeginEvent &lt;ScriptBlock&gt;
    Called when an event is found in the input. Receives sourceID and sourceName, which describe the source (variable) for the event, eventID (contains the unique ID for the event) and eventName )contains the name for the event).
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnEndEvent &lt;ScriptBlock&gt;
    Called when parsing of an event is complete.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnFunctionAttribute &lt;ScriptBlock&gt;
    Called when a function attribute is found in the input. Receives the name for the attribute and an array that holds the attribute values.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnBeginFunction &lt;ScriptBlock&gt;
    Called when a C/AL function is found in the input. Receives the unique ID, name and whether or not the function is local (i.e. only accessible from the object in which it is defined).
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnEndFunction &lt;ScriptBlock&gt;
    Called when parsing of a C/AL function is complete.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnParameter &lt;ScriptBlock&gt;
    Called when a parameter is found in the input. Receives whether or not the parameter is passed by reference, its unique ID, name, data type, subtype (where applicable), length (where applicable), option string (where applicable), whether or not the parameter is temporary (applies to records parameters only), the array dimensions (if any), whether the parameter contains an object that lives on the client (as opposed to on the server), the security filtering and whether the parameter should be kept alive when it goes out of local scope.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnVariable &lt;ScriptBlock&gt;
    Called when a (global or local) variable is found in the input. Receives the unique ID, name, data type, subtype (where applicable), declared length (where applicable), option string (where applicable), text constant value(s) (applies only to text constants), whether or not the variable is temporary (applies to record variables only), the variable&#39;s array dimensions (if any), whether or not the variable contains an object that lives on the client (as opposed to on the server), whether or not events published by the variable should be subscribed to from C/AL, the security filtering and whether or not the variable should be sent as part of dataset that the server sends to the client.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnReturnValue &lt;ScriptBlock&gt;
    Called when a function return value is found in the input. Receives the name (if any), data type, declared length (where applicable) and array dimensions (if any) for the return value.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnCodeLine &lt;ScriptBlock&gt;
    Called when C/AL code line is found in the input. Receives the text of the code line, including any indentation.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnBeginQueryElement &lt;ScriptBlock&gt;
    Called when a query element is found in the input. Receives the unique ID, indentation level (null implies the default value, i.c. 0), name and type of the element (data item, column or filter).
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnEndQueryElement &lt;ScriptBlock&gt;
    Called when parsing of a query element is complete.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnBeginXmlPortElement &lt;ScriptBlock&gt;
    Called when an XMLport element is found in the input. Receives the unique ID, indentation level (null implies the default value, i.c. 0), name, node type (element or attribute) and source type (text, table or field) for the element.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnEndXmlPortElement &lt;ScriptBlock&gt;
    Called when parsing of an XMLport element is complete.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnBeginMenuSuiteNode &lt;ScriptBlock&gt;
    Called when a menu suite node is found in the input. Receives the type (root, menu, menu group, menu item or delta) and unique ID for the node.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
#### OnEndMenuSuiteNode &lt;ScriptBlock&gt;
    Called when parsing of a menu suite node is complete.
    
    Required?                    false
    Position?                    named
    Default value                
    Accept pipeline input?       false
    Accept wildcard characters?  false
<div style='font-size:small; color: #ccc'>Generated 16-10-2016 15:12:05</div>
