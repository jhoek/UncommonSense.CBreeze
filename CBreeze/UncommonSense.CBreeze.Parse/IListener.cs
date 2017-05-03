using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
    public interface IListener
    {
        // Applications
        void OnBeginApplication();
        void OnEndApplication();

        // Files
        void OnBeginFile(string fileName);
        void OnEndFile();

        // Objects
        void OnBeginObject(ObjectType objectType, int objectID, string objectName);
        void OnEndObject();

        // Sections
        void OnBeginSection(SectionType sectionType);
        void OnEndSection();

        // Properties
        void OnObjectProperty(string propertyName, string propertyValue);
        void OnProperty(string propertyName, string propertyValue);

        // Triggers
        void OnBeginTrigger(string triggerName);
        void OnEndTrigger();

        // Table fields
        void OnBeginTableField(int fieldNo, bool? fieldEnabled, string fieldName, TableFieldType fieldType, int fieldLength);
        void OnEndTableField();

        // Table keys
        void OnBeginTableKey(bool? keyEnabled, string[] keyFields);
        void OnEndTableKey();

        // Table field groups
        void OnBeginTableFieldGroup(int fieldGroupID, string fieldGroupName, string[] fieldGroupFields);
        void OnEndTableFieldGroup();

        // Pages
        void OnBeginPageControl(int controlID, int? controlIndentation, PageControlType controlType);
        void OnEndPageControl();

        // Page actions
        void OnBeginPageAction(int actionID, int? actionIndentation, PageActionBaseType actionType);
        void OnEndPageAction();

        // Query elements
        void OnBeginQueryElement(int elementID, int? elementIndentation, string elementName, QueryElementType elementType);
        void OnEndQueryElement();

        // XmlPort elements
        void OnBeginXmlPortElement(Guid elementID, int? elementIndentation, string elementName, XmlPortNodeType elementNodeType, XmlPortSourceType elementSourceType);
        void OnEndXmlPortElement();

        // Report elements
        void OnBeginReportElement(int elementID, int? elementIndentation, string elementName, ReportElementType elementType);
        void OnEndReportElement();

        // Request pages
        void OnBeginRequestPage();
        void OnEndRequestPage();

        // Report labels
        void OnBeginReportLabel(int labelID, string labelName);
        void OnEndReportLabel();

        // Menusuites
        void OnBeginMenuSuiteNode(MenuSuiteNodeType nodeType, Guid nodeID);
        void OnEndMenuSuiteNode();

        // Functions
        void OnBeginFunction(int functionID, string functionName, bool functionLocal);
        void OnEndFunction();
        void OnFunctionAttribute(string name, params string[] values);

        // Events
        void OnBeginEvent(int sourceID, string sourceName, int eventID, string eventName);
        void OnEndEvent();

        // Parameters
        void OnParameter(bool parameterVar, int parameterID, string parameterName, ParameterType parameterType, string parameterSubType, int? parameterLength, string parameterOptionString, bool parameterTemporary, string parameterDimensions, bool parameterRunOnClient, string parameterSecurityFiltering, bool parameterSuppressDispose);

        // Function return values
        void OnReturnValue(string returnValueName, FunctionReturnValueType? returnValueType, int? returnValueLength, string returnValueDimensions);

        // Variables
        void OnVariable(int variableID, string variableName, VariableType variableType, string variableSubType, int? variableLength, string variableOptionString, string variableConstValue, bool variableTemporary, string variableDimensions, bool variableRunOnClient, bool variableWithEvents, string variableSecurityFiltering, bool variableInDataSet);

        // Code lines
        void OnCodeLine(string codeLine);
    }
}
