using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace UncommonSense.Nav.Parser
{
    public interface IListener
    {
        // General
        void OnBeginObject(ObjectType objectType, int objectID, string objectName);
        void OnEndObject();

        void OnBeginSection(SectionType sectionType);
        void OnEndSection();

        void OnObjectProperty(string propertyName, string propertyValue);
        void OnProperty(string propertyName, string propertyValue);

        void OnBeginTrigger(string triggerName);
        void OnEndTrigger();

        // Table
        void OnBeginTableField(int fieldNo, bool? fieldEnabled, string fieldName, FieldType fieldType, int fieldLength);
        void OnEndTableField();

        void OnBeginTableKey(bool? keyEnabled, string[] keyFields);
        void OnEndTableKey();

        void OnBeginTableFieldGroup(int fieldGroupID, string fieldGroupName, string[] fieldGroupFields);
        void OnEndTableFieldGroup();

        // Page
        void OnBeginPageControl(int controlID, int? controlIndentation, PageControlType controlType);
        void OnEndPageControl();

        void OnBeginPageAction(int actionID, int? actionIndentation, PageActionType actionType);
        void OnEndPageAction();

        // Query
        void OnBeginQueryElement(int elementID, int? elementIndentation, string elementName, QueryElementType elementType);
        void OnEndQueryElement();

        // XmlPort
        void OnBeginXmlPortElement(Guid elementID, int? elementIndentation, string elementName, XmlPortNodeType elementNodeType, XmlPortSourceType elementSourceType);
        void OnEndXmlPortElement();

        // Report
        void OnBeginReportElement(int elementID, int? elementIndentation, string elementName, ReportElementType elementType);
        void OnEndReportElement();

        void OnBeginRequestPage();
        void OnEndRequestPage();
        
        void OnBeginReportLabel(int labelID, string labelName);
        void OnEndReportLabel();

        // Menusuite
        void OnBeginMenuSuiteNode(MenuSuiteNodeType nodeType, Guid nodeID);
        void OnEndMenuSuiteNode();

        // Code
        void OnBeginFunction(int functionID, string functionName, bool functionLocal);
        void OnEndFunction();

        void OnBeginEvent(int sourceID, string sourceName, int eventID, string eventName);
        void OnEndEvent();

        void OnParameter(bool parameterVar, int parameterID, string parameterName, ParameterType parameterType, string parameterSubType, int? parameterLength, string parameterOptionString, bool parameterTemporary, string parameterDimensions, bool parameterRunOnClient, string parameterSecurityFiltering, bool parameterSuppressDispose);

        void OnReturnValue(string returnValueName, ReturnValueType? returnValueType, int? returnValueLength, string returnValueDimensions);

        void OnVariable(int variableID, string variableName, VariableType variableType, string variableSubType, int? variableLength, string variableOptionString, string variableConstValue, bool variableTemporary, string variableDimensions, bool variableRunOnClient, bool variableWithEvents, string variableSecurityFiltering, bool variableInDataSet);

        void OnCodeLine(string codeLine);
    }
}
