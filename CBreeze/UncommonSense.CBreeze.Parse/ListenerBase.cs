using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Parse
{
    public abstract class ListenerBase : IListener
    {
        public virtual void OnBeginApplication()
        {
        }

        public virtual void OnEndApplication()
        {
        }

        public virtual void OnBeginFile(string fileName)
        {
        }

        public virtual void OnEndFile()
        {
        }

        public virtual void OnBeginObject(Common.ObjectType objectType, int objectID, string objectName)
        {
        }

        public virtual void OnEndObject()
        {
        }

        public virtual void OnBeginSection(Common.SectionType sectionType)
        {
        }

        public virtual void OnEndSection()
        {
        }

        public virtual void OnObjectProperty(string propertyName, string propertyValue)
        {
        }

        public virtual void OnProperty(string propertyName, string propertyValue)
        {
        }

        public virtual void OnBeginTrigger(string triggerName)
        {
        }

        public virtual void OnEndTrigger()
        {
        }

        public virtual void OnBeginTableField(int fieldNo, bool? fieldEnabled, string fieldName, Common.TableFieldType fieldType, int fieldLength)
        {
        }

        public virtual void OnEndTableField()
        {
        }

        public virtual void OnBeginTableKey(bool? keyEnabled, string[] keyFields)
        {
        }

        public virtual void OnEndTableKey()
        {
        }

        public virtual void OnBeginTableFieldGroup(int fieldGroupID, string fieldGroupName, string[] fieldGroupFields)
        {
        }

        public virtual void OnEndTableFieldGroup()
        {
        }

        public virtual void OnBeginPageControl(int controlID, int? controlIndentation, Common.PageControlType controlType)
        {
        }

        public virtual void OnEndPageControl()
        {
        }

        public virtual void OnBeginPageAction(int actionID, int? actionIndentation, Common.PageActionBaseType actionType)
        {
        }

        public virtual void OnEndPageAction()
        {
        }

        public virtual void OnBeginQueryElement(int elementID, int? elementIndentation, string elementName, Common.QueryElementType elementType)
        {
        }

        public virtual void OnEndQueryElement()
        {
        }

        public virtual void OnBeginXmlPortElement(Guid elementID, int? elementIndentation, string elementName, Common.XmlPortNodeType elementNodeType, Common.XmlPortSourceType elementSourceType)
        {
        }

        public virtual void OnEndXmlPortElement()
        {
        }

        public virtual void OnBeginReportElement(int elementID, int? elementIndentation, string elementName, Common.ReportElementType elementType)
        {
        }

        public virtual void OnEndReportElement()
        {
        }

        public virtual void OnBeginRequestPage()
        {
        }

        public virtual void OnEndRequestPage()
        {
        }

        public virtual void OnBeginReportLabel(int labelID, string labelName)
        {
        }

        public virtual void OnEndReportLabel()
        {
        }

        public virtual void OnBeginMenuSuiteNode(Common.MenuSuiteNodeType nodeType, Guid nodeID)
        {
        }

        public virtual void OnEndMenuSuiteNode()
        {
        }

        public virtual void OnBeginFunction(int functionID, string functionName, bool functionLocal)
        {
        }

        public virtual void OnEndFunction()
        {
        }

        public virtual void OnFunctionAttribute(string name, params string[] values)
        {
        }

        public virtual void OnBeginEvent(int sourceID, string sourceName, int eventID, string eventName)
        {
        }

        public virtual void OnEndEvent()
        {
        }

        public virtual void OnParameter(bool parameterVar, int parameterID, string parameterName, Common.ParameterType parameterType, string parameterSubType, int? parameterLength, string parameterOptionString, bool parameterTemporary, string parameterDimensions, bool parameterRunOnClient, string parameterSecurityFiltering, bool parameterSuppressDispose)
        {
        }

        public virtual void OnReturnValue(string returnValueName, Common.FunctionReturnValueType? returnValueType, int? returnValueLength, string returnValueDimensions)
        {
        }

        public virtual void OnVariable(int variableID, string variableName, Common.VariableType variableType, string variableSubType, int? variableLength, string variableOptionString, string variableConstValue, bool variableTemporary, string variableDimensions, bool variableRunOnClient, bool variableWithEvents, string variableSecurityFiltering, bool variableInDataSet)
        {
        }

        public virtual void OnCodeLine(string codeLine)
        {
        }
    }
}
