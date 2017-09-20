using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Parse.Automation
{
    public partial class InvokeCBreezeParser
    {
        /// <summary>
        /// One or more literal paths to files that you want parsed. 
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [Alias("FullName", "PSPath")]
        public string[] LiteralPath
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called before a parsing run starts, regardless of the input type.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnBeginApplication
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called after a parsing run is complete.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnEndApplication
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called before parsing objects from a text file. This method is called only when parsing objects from text files. Receives the name of the file being loaded.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnBeginFile
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called after parsing a text file is complete. This method is called only when parsing objects from text files.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnEndFile
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when an object is found in the input. Receives the type, ID and name of the object found.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnBeginObject
        {
            get;
            set;
        }

        /// <summary>
        ///  <para type="description">Called when parsing of an object is complete.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnEndObject
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when an object section (object properties, table fields, C/AL code, etc.) is found in the input. Receives the type of the section found.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnBeginSection
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when parsing of a section is complete.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnEndSection
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when a trigger is found in the input. Receives the name of the trigger found.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnBeginTrigger
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when parsing of a trigger is complete.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnEndTrigger
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when an object property (Date, Time, Modified or Version List) is found in the input. Receives the name and value (as string) of the property found.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnObjectProperty
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when a property (Date, Time, Modified or Version List) is found in the input. Receives the name and value (as string) of the property found.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnProperty
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when a table field is found in the input. Receives the ID, whether or not the field is enabled (null implies the default value, i.c. true), the name, the type (Integer, Decimal, GUID, etc.) and the length (if applicable to fields of this type) of the table field found.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnBeginTableField
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when parsing of a table field is complete.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnEndTableField
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when a table key is found in the input. Receives whether or not the key is enabled (null implies the default value, i.c. true) and the names of the key fields.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnBeginTableKey
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when parsing of a table key is complete.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnEndTableKey
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when a table field group is found in the input. Receives the unique ID and name of the field group, and the names of the field group fields.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnBeginTableFieldGroup
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when parsing of a table field group is complete.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnEndTableFieldGroup
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when a page action is found in the input. Receives the indentation level (null implies the default value, i.c. 0) and the type of the action (container, group, action or separator).</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnBeginPageAction
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called when parsing of a page action is complete.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnEndPageAction
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called when a page control is found in the input. Receives the unique ID, the indentation level (null implies the default value, i.c. 0) and the type of the control (container, group, field or part).</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnBeginPageControl
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called when parsing of a page control is complete.</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnEndPageControl
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called when a request page is found in the input.</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnBeginRequestPage
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called when parsing of a request page is complete.</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnEndRequestPage
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called when a report element is found in the input. Receives the unique ID, indentation level (null implies the default value, i.c. 0), name and type (dataitem or column) of the element.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnBeginReportElement
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called when parsing of a report element is complete.</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnEndReportElement
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called when a report label is found in the input. Receives the unique ID and the name of the label.</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnBeginReportLabel
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called when parsing of a report label is complete.</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnEndReportLabel
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called when an event is found in the input. Receives sourceID and sourceName, which describe the source (variable) for the event, eventID (contains the unique ID for the event) and eventName )contains the name for the event).</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnBeginEvent
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when parsing of an event is complete.</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnEndEvent
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when a function attribute is found in the input. Receives the name for the attribute and an array that holds the attribute values.</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnFunctionAttribute
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when a C/AL function is found in the input. Receives the unique ID, name and whether or not the function is local (i.e. only accessible from the object in which it is defined).</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnBeginFunction
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when parsing of a C/AL function is complete.</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnEndFunction
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when a parameter is found in the input. Receives whether or not the parameter is passed by reference, its unique ID, name, data type, subtype (where applicable), length (where applicable), option string (where applicable), whether or not the parameter is temporary (applies to records parameters only), the array dimensions (if any), whether the parameter contains an object that lives on the client (as opposed to on the server), the security filtering and whether the parameter should be kept alive when it goes out of local scope.</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnParameter
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when a (global or local) variable is found in the input. Receives the unique ID, name, data type, subtype (where applicable), declared length (where applicable), option string (where applicable), text constant value(s) (applies only to text constants), whether or not the variable is temporary (applies to record variables only), the variable's array dimensions (if any), whether or not the variable contains an object that lives on the client (as opposed to on the server), whether or not events published by the variable should be subscribed to from C/AL, the security filtering and whether or not the variable should be sent as part of dataset that the server sends to the client.</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnVariable
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when a function return value is found in the input. Receives the name (if any), data type, declared length (where applicable) and array dimensions (if any) for the return value.</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnReturnValue
        {
            get;
            set;
        }

        /// <summary>
        /// <para type="description">Called when C/AL code line is found in the input. Receives the text of the code line, including any indentation.</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnCodeLine
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called when a query element is found in the input. Receives the unique ID, indentation level (null implies the default value, i.c. 0), name and type of the element (data item, column or filter).</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnBeginQueryElement
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called when parsing of a query element is complete.</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnEndQueryElement
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called when an XMLport element is found in the input. Receives the unique ID, indentation level (null implies the default value, i.c. 0), name, node type (element or attribute) and source type (text, table or field) for the element.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnBeginXmlPortElement
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called when parsing of an XMLport element is complete.</para>
        /// </summary>
        [Parameter()]
        public ScriptBlock OnEndXmlPortElement
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called when a menu suite node is found in the input. Receives the type (root, menu, menu group, menu item or delta) and unique ID for the node.</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnBeginMenuSuiteNode
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Called when parsing of a menu suite node is complete.</para> 
        /// </summary>
        [Parameter()]
        public ScriptBlock OnEndMenuSuiteNode
        {
            get; set;
        }
    }
}
