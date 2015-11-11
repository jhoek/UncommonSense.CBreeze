using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Parse
{
    public class NullListener : IListener
    {
        public void OnBeginObject(ObjectType objectType, int objectID, string objectName)
        {
        }

        public void OnEndObject()
        {
        }

        public void OnBeginSection(SectionType sectionType)
        {
        }

        public void OnEndSection()
        {
        }

        public void OnProperty(string propertyName, string propertyValue)
        {
        }


        public void OnBeginFunction(int functionID, string functionName, bool functionLocal, string functionType, string handlerFunctions, string transactionModel)
        {
        }

        public void OnEndFunction()
        {
        }

        public void OnBeginTableFieldGroup(int fieldGroupID, string fieldGroupName, string[] fieldGroupFields)
        {
        }

        public void OnEndTableFieldGroup()
        {
        }

        public void OnBeginTableKey(bool? keyEnabled, string[] keyFields)
        {
        }

        public void OnEndTableKey()
        {
        }

        public void OnBeginTableField(int fieldNo, bool? fieldEnabled, string fieldName, TableFieldType fieldType, int fieldLength)
        {
        }

        public void OnEndTableField()
        {
        }

        public void OnCodeLine(string codeLine)
        {
        }

        public void OnBeginTrigger(string triggerName)
        {
        }

        public void OnEndTrigger()
        {
        }

        public void OnObjectProperty(string propertyName, string propertyValue)
        {
        }

        public void OnReturnValue(string returnValueName, FunctionReturnValueType? returnValueType, int? returnValueLength, string returnValueDimensions)
        {
        }

        public void OnParameter(bool parameterVar, int parameterID, string parameterName, ParameterType parameterType, string parameterSubType, int? parameterLength, string parameterOptionString, bool parameterTemporary, string parameterDimensions, bool parameterRunOnClient, string parameterSecurityFiltering, bool parameterSuppressDispose)
        {
        }

        public void OnVariable(int variableID, string variableName, VariableType variableType, string variableSubType, int? variableLength, string variableOptionString, string variableConstValue, bool variableTemporary, string variableDimensions, bool variableRunOnClient, bool variableWithEvents, string variableSecurityFiltering, bool variableInDataSet)
        {
        }

        public void OnBeginEvent(int sourceID, string sourceName, int eventID, string eventName)
        {
        }

        public void OnEndEvent()
        {
        }


        public void OnBeginQueryElement(int elementID, int? elementIndentation, string elementName, QueryElementType elementType)
        {
        }

        public void OnEndQueryElement()
        {
        }


        public void OnBeginPageControl(int controlID, int? controlIndentation, PageControlType controlType)
        {
        }

        public void OnEndPageControl()
        {
        }

        public void OnBeginPageAction(int actionID, int? actionIndentation, PageActionBaseType actionType)
        {
        }

        public void OnEndPageAction()
        {
        }

        public void OnBeginXmlPortElement(Guid elementID, int? elementIndentation, string elementName, XmlPortNodeType elementNodeType, XmlPortSourceType elementSourceType)
        {
        }

        public void OnEndXmlPortElement()
        {
        }


        public void OnBeginReportElement(int elementID, int? elementIndentation, string elementName, ReportElementType elementType)
        {
        }

        public void OnEndReportElement()
        {
        }


        public void OnRdlData(System.Xml.XmlDocument data)
        {
        }

        public void OnBeginRequestPage()
        {
        }

        public void OnEndRequestPage()
        {
        }

        public void OnBeginReportLabel(int labelID, string labelName)
        {
        }

        public void OnEndReportLabel()
        {
        }

        public void OnBeginMenuSuiteNode(MenuSuiteNodeType nodeType, Guid nodeID)
        {
        }

        public void OnEndMenuSuiteNode()
        {
        }
    }
}
