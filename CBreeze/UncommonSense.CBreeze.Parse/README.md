# UncommonSense.CBreeze.Parse

UncommonSense.CBreeze.Parse is a simple event-based parser for Microsoft Dynamics NAV object text files. While processing NAV objects, the parser reports what it finds by calling the methods on a user-provided listener (an implementation of the `IListener` interface).

## Project Structure
| Folder | Contents | 
| --- | --- |
| [UncommonSense.CBreeze.Parse](UncommonSense.CBreeze.Parse)| The parser library | 
| [UncommonSense.CBreeze.Parse.Demo](UncommonSense.CBreeze.Parse.Demo) | C# demo code for the parser library |
| [UncommonSense.CBreeze.Parse.Automation](UncommonSense.CBreeze.Parse.Automation) | PowerShell wrapper for the parser library | 
| [UncommonSense.CBreeze.Parse.Automation.Demo](UncommonSense.CBreeze.Parse.Automation.Demo) | PowerShell demo scripts for the PowerShell wrapper | 

## FAQ

### What can I do with this?
You could do as I do/did, and make this parser the basis for a larger NAV-related tool or API. Or perhaps you could read the source code and benefit from my efforts to reverse-engineer the object text format.

### Does the parser also parse out the C/AL code?
No, not at this point. The parser reports objects and subobjects. Codelines are simply reported as strings.

### Why does the parser not parse the C/AL code?
That just wasn't something I needed for my purposes right now. It might change in the future. Or perhaps not.

### Does the parser also parse out property values?
No, not at this point. However, this parser is part of a larger project that I plan to open-source in the coming months; the code contained in that project will interpret the property values.

### Which Microsoft Dynamics NAV versions is it compatible with?
Since the parser just reports the structure of your object text file, and doesn't care about the validity of e.g. property names, it's likely to be compatible with a wide range of NAV versions. My tests, however, are, at the time of this writing, focused on NAV 2016.

### Your parser implementation is very naive - why didn't you use {technology X}?
You're probably right. When I started this project, I didn't know even the first thing about writing a parser. Since then, I've learned a lot of new stuff which I haven't been able to incorporate into C/Breeze just yet. Also, the parser is only a small part of a larger project. Your constructive feedback may help future me improve the parser - please don't hesitate to create a GitHub issue! 

## Reported application elements
Under which conditions the parser calls each `IListener` method is described below.

### Application
<dl>
<dt>OnBeginApplication</dt>
<dd>Called before a parsing run starts, regardless of the input type.</dd>
<dt>OnEndApplication</dt>
<dd>Called after a parsing run is complete, regardless of the input type (files or lines).</dd>
</dl>
    
### File

<dl>
<dt>OnBeginFile</dt>
<dd>Called before parsing objects from a text file. This method is called only when parsing objects from text files. <code>fileName</code> contains the name of the file being loaded.</dd>
<dt>OnEndFile</dt>
<dd>Called after parsing a text file is complete. This method is called only when parsing objects from text files.</dd>
</dl>
	
### Object

<dl>
    <dt>OnBeginObject</dt>
    <dd>Called when an object is found in the input. <code>objectType</code> contains the type (table, page, etc.) of the object found, <code>objectID</code> contains the ID of the object found and <code>objectName</code> contains the name of the object found.</dd>
     <dt>OnEndObject</dt>
     <dd>Called when parsing of an object is complete.</dd>
</dl>

### Section
<dl>
    <dt>OnBeginSection</dt>
    <dd>Called when an object section (object properties, table fields, C/AL code, etc.) is found in the input. <code>sectionType</code> contains the type of the section found.</dd>
    <dt>OnEndSection</dt>
    <dd>Called when parsing of a section is complete.</dd>
</dl>

### Properties
<dl>
    <dt>OnObjectProperty</dt>
    <dd>Called when an object property (Date, Time, Modified or Version List) is found in the input. <code>propertyName</code> contains the name of the object property found and <code>propertyValue</code> contains the value (as a string) of the object property found.</dd>
    <dt>OnProperty</dt>
    <dd>Called when a property (but not an object property) is found in the input. <code>propertyName</code> contains the name of the property found and <code>propertyValue</code> contains the value (as a string) of the property found.</dd>
</dl>
    
### Triggers

<dl>
    <dt>OnBeginTrigger</dt>
    <dd>Called when a trigger is found in the input. <code>triggerName</code> contains the name of the trigger found.</dd>
    <dt>OnEndTrigger</dt>
    <dd>Called when parsing of a trigger is complete.</dd>
</dl>

### Table fields

<dl>
    <dt>OnBeginTableField</dt>
    <dd>Called when a table field is found in the input. <code>fieldNo</code> contains the number (ID) of the table field found, <code>fieldEnabled</code> indicates whether or not the field is enabled (<code>null</code> implies the default value, i.c. true), <code>fieldName</code> contains the name of the table field found, <code>fieldType</code> contains the type (Integer, Decimal, GUID, etc.) of the table field found and <code>fieldLength</code> contains the length of the table field found (if applicable to fields of type <code>fieldType</code>).</dd>
    <dt>OnEndTableField</dt>
    <dd>Called when parsing of a table field is complete.</dd>
</dl>
    
### Table keys

<dl>
    <dt>OnBeginTableKey</dt>
    <dd>Called when a table key is found in the input. <code>keyEnabled</code> indicates whether or not the key is enabled (<code>null</code> implies the default value, i.c. true) and <code>keyFields</code> contains the names of the key fields</dd>
    <dt>OnEndTableKey</dt>
    <dd>Called when parsing of a table key is complete.</dd>
</dl>

### Table field groups

<dl>
    <dt>OnBeginTableFieldGroup</dt>
    <dd>Called when a table field group is found in the input. <code>fieldGroupID</code> contains the unique ID for the field group, <code>fieldGroupName</code> contains the name of the field group and <code>fieldGroupFields</code> contains the names of the field group fields.</dd>
    <dt>OnEndTableFieldGroup</dt>
    <dd>Called when parsing of a table field group is complete.</dd>
</dl>

### Page controls 

<dl>
    <dt>OnBeginPageControl</dt>
    <dd>Called when a page control is found in the input. <code>controlID</code> contains the unique ID for the control, <code>controlIndentation</code> contains the indentation level for the control (<code>null</code> implies the default value, i.c. 0) and <code>controlType</code> contains the type of the control (container, group, field or part).</dd>
    <dt>OnEndPageControl</dt>
    <dd>Called when parsing of a page control is complete.</dd>
</dl>

### Page actions

<dl>
    <dt>OnBeginPageAction</dt>
    <dd>Called when a page action is found in the input. <code>actionID</code contains the unique ID for the action, <code>actionIndentation</code> contains the indentation level for the action (<code>null</code> implies the default value, i.c. 0) and <code>actionType</code> contains the type of the action (container, group, action or separator).</dd>
    <dt>OnEndPageAction</dt>
    <dd>Called when parsing of a page action is complete.</dd>
</dl>

### Request pages
<dl>
    <dt>OnBeginRequestPage</dt>
    <dd>Called when a request page is found in the input.</dd>
    <dt>OnEndRequestPage</dt>
    <dd>Called when parsing of a request page is complete.</dd>
</dl>

### Query elements

<dl>
    <dt>OnBeginQueryElement</dt>
    <dd>Called when a query elements is found in the input. <code>elementID</code> contains the unique ID for the element, <code>elementIndentation</code> contains the indentation level for the element (<code>null</code> implies the default value, i.c. 0), <code>elementName</code> contains the name of the element and <code>elementType</code> contains the type of the element (data item, column or filter).</dd>
    <dt>OnEndQueryElement</dt>
    <dd>Called when parsing of a query element is complete.</dd>
</dl>
    
### XMLport elements

<dl>
    <dt>OnBeginXmlPortElement</dt>
    <dd>Called when an XMLport element is found in the input. <code>elementID</code> contains the unique ID for the element, <code>elementIndentation</code> contains the indentation level for the element (<code>null</code> implies the default value, i.c. 0), <code>elementName</code> contains the name of the element, <code>elementNodeType</code> contains the node type (element or attribute) for the element and <code>elementSourceType</code> contains the source type (text, table or field) for the element.</dd>
    <dt>OnEndXmlPortElement</dt>
    <dd>Called when parsing of an XMLport element is complete.</dd>
</dl>

### Report elements

<dl>
    <dt>OnBeginReportElement</dt>
    <dd>Called when a report element is found in the input. <code>elementID</code> contains the unique ID for the element, <code>elementIndentation</code> contains the indentation level for the element (<code>null</code> implies the default value, i.c. 0), <code>elementName</code> contains the name of the element and <code>elementType</code> contains the type (dataitem or column) of the element.</dd> 
    <dt>OnEndReportElement</dt>
    <dd>Called when parsing of a report element is complete.</dd>
</dl>

### Report labels

<dl>
    <dt>OnBeginReportLabel</dt>
    <dd>Called when a report label is found in the input. <code>labelID</code> contains the unique ID for the label and <code>labelName</code> contains the name of the label.</dd>
    <dt>OnEndReportLabel</dt>
    <dd>Called when parsing of a report label is complete.</dd>
</dl>

### Menu suite nodes

<dl>
    <dt>OnBeginMenuSuiteNode</dt>
    <dd>Called when a menu suite node is found in the input. <code>nodeType</code> contains the type of the node (root, menu, menu group, menu item or delta) and <code>nodeID</code> contains the unique ID for the node.</dd>
    <dt>OnEndMenuSuiteNode</dt>
    <dd>Called when parsing of a menu suite node is complete.</dd>
</dl>

### Functions

<dl>
    <dt>OnBeginFunction</dt>
    <dd>Called when a C/AL function is found in the input. <code>functionID</code> contains the unique ID for the function, <code>functionName</code> contains the function's name and <code>functionLocal</code> indicates whether or not the function is local (i.e. only accessible from the object in which it is defined).</dd>
    <dt>OnFunctionAttribute</dt>
    <dd>Called when a function attribute is found in the input. <code>name</code> contains the name for the attribute and <code>values</code> contains an array that holds the attribute values.</dd>
    <dt>OnEndFunction</dt>
    <dd>Called when parsing of a C/AL function is complete.</dd>
</dl>

### Events

<dl>
    <dt>OnBeginEvent</dt>
    <dd>Called when an event is found in the input. <code>sourceID</code> and <code>sourceName</code> describe the source (variable) for the event, <code>eventID</code> contains the unique ID for the event and <code>eventName</code> contains the name for the event.</dd>
    <dt>OnEndEvent</dt>
    <dd>Called when parsing of an event is complete.</dd>
</dl>

### Parameters

<dl>
    <dt>OnParameter</dt>
    <dd>Called when a parameter is found in the input.  <code>parameterVar</code> indicates whether or not the parameter is passed by reference, <code>parameterID</code> contains the unique ID for the parameter, <code>parameterName</code> contains the parameter's name, <code>parameterType</code> contains the parameter's data type, <code>parameterSubType</code> contains the subtype for the parameter (where applicable), <code>parameterLength</code> contains the length for the parameter (where applicable), <code>parameterOptionString</code> contains the option string for the parameter (where applicable), <code>parameterTemporary</code> indicates whether or not a record variable is temporary, <code>parameterDimensions</code> contains the array dimensions for the parameter (if any), <code>parameterRunOnClient</code> indicates whether the parameter contains an object that lives on the client (as opposed to on the server), <code>parameterSecurityFiltering</code> describes the security filtering for the parameter and <code>parameterSuppressDispose</code> indicates whether the parameter should be kept alive when it goes out of scope.
</dl>

### Return values
<dl>
    <dt>OnReturnValue</dt>
    <dd>Called when a function return value is found in the input.<code>returnValueName</code> contains the name of the return value (if any), <code>returnValueType</code> contains the return value's data type, <code>returnValueLength</code> contains the return value's length (where applicable) and <code>returnValueDimensions</code> contains the return value's array dimensions (if any).</dd>
</dl>

### Variables
<dl>
    <dt>OnVariable</dt>
    <dd>Called when a (global or local) variable is found in the input. <code>variableID</code> contains the unique ID for the variable, <code>variableName</code> contains the variable's name, <code>variableType</code> contains the variable's data type, <code>variableSubType</code> contains the variable's subtype (where applicable), <code>variableLength</code> contains the variable's declared length (where applicable), <code>variableOptionString</code> contains the option string for the variable (where applicable), <code>variableConstValue</code> contains the value for text constants, <code>variableTemporary</code> indicates that a record variable is temporary, <code>variableDimensions</code> contains the variable's array dimensions (if any), <code>variableRunOnClient</code> indicates that the variable contains an object that lives on the client (as opposed to on the server), <code>variableWithEvents</code> indicates that events published by the variable should be subscribed to from C/AL, <code>variableSecurityFiltering</code> describes the security filtering for the variable and <code>variableInDataSet</code> indicates that the variable should be sent as part of dataset that the server sends to the client.</dd>
</dl>

### Code lines

<dl>
<dt>OnCodeLine</dt>
<dd>Called when C/AL code line is found in the input. <code>codeLine</code> contains the text of the code line, including any indentation.</dd>
</dl>








