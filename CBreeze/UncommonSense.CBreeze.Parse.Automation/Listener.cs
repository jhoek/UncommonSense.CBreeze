using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse.Automation
{
    internal class Listener : ListenerBase
    {
        public InvokeCBreezeParser InvokeCBreezeParser
        {
            get;
            protected set;
        }

        internal Listener(InvokeCBreezeParser invokeCBreezeParser)
        {
            InvokeCBreezeParser = invokeCBreezeParser;
        }

        public override void OnBeginApplication() => InvokeCBreezeParser.OnBeginApplication?.Invoke();
        public override void OnEndApplication() => InvokeCBreezeParser.OnEndApplication?.Invoke();

        public override void OnBeginFile(string fileName) => InvokeCBreezeParser.OnBeginFile?.Invoke(fileName);
        public override void OnEndFile() => InvokeCBreezeParser.OnEndFile?.Invoke();

        public override void OnBeginObject(ObjectType objectType, int objectID, string objectName) => InvokeCBreezeParser.OnBeginObject?.Invoke(objectType, objectID, objectName);
        public override void OnEndObject() => InvokeCBreezeParser.OnEndObject?.Invoke();

        public override void OnBeginSection(SectionType sectionType) => InvokeCBreezeParser.OnBeginSection?.Invoke(sectionType);
        public override void OnEndSection() => InvokeCBreezeParser.OnEndSection?.Invoke();

        public override void OnObjectProperty(string propertyName, string propertyValue) => InvokeCBreezeParser.OnObjectProperty?.Invoke(propertyName, propertyValue);
        public override void OnProperty(string propertyName, string propertyValue) => InvokeCBreezeParser.OnProperty?.Invoke(propertyName, propertyValue);

        public override void OnBeginTableField(int fieldNo, bool? fieldEnabled, string fieldName, TableFieldType fieldType, int fieldLength) => InvokeCBreezeParser.OnBeginTableField?.Invoke(fieldNo, fieldEnabled, fieldName, fieldType, fieldLength);
        public override void OnEndTableField() => InvokeCBreezeParser.OnEndTableField?.Invoke();

        public override void OnBeginTableKey(bool? keyEnabled, string[] keyFields) => InvokeCBreezeParser.OnBeginTableKey?.Invoke(keyEnabled, keyFields);
        public override void OnEndTableKey() => InvokeCBreezeParser.OnEndTableKey?.Invoke();

        public override void OnBeginTableFieldGroup(int fieldGroupID, string fieldGroupName, string[] fieldGroupFields) => InvokeCBreezeParser.OnBeginTableFieldGroup?.Invoke(fieldGroupID, fieldGroupName, fieldGroupFields);
        public override void OnEndTableFieldGroup() => InvokeCBreezeParser.OnEndTableFieldGroup?.Invoke();

        public override void OnBeginPageAction(int actionID, int? actionIndentation, PageActionType actionType) => InvokeCBreezeParser.OnBeginPageAction?.Invoke(actionID, actionIndentation, actionType);
        public override void OnEndPageAction() => InvokeCBreezeParser.OnEndPageAction?.Invoke();

        public override void OnBeginPageControl(int controlID, int? controlIndentation, PageControlType controlType) => InvokeCBreezeParser.OnBeginPageControl?.Invoke(controlID, controlIndentation, controlType);
        public override void OnEndPageControl() => InvokeCBreezeParser.OnEndPageControl?.Invoke();

        public override void OnBeginTrigger(string triggerName) => InvokeCBreezeParser.OnBeginTrigger?.Invoke(triggerName);
        public override void OnEndTrigger() => InvokeCBreezeParser.OnEndTrigger?.Invoke();

        public override void OnBeginEvent(int sourceID, string sourceName, int eventID, string eventName) => InvokeCBreezeParser.OnBeginEvent?.Invoke(sourceID, sourceName, eventID, eventName);
        public override void OnEndEvent() => InvokeCBreezeParser.OnEndEvent?.Invoke();

        public override void OnFunctionAttribute(string name, params string[] values) => InvokeCBreezeParser.OnFunctionAttribute?.Invoke(name, values);
        public override void OnBeginFunction(int functionID, string functionName, bool functionLocal) => InvokeCBreezeParser.OnBeginFunction?.Invoke(functionID, functionName, functionLocal);
        public override void OnEndFunction() => InvokeCBreezeParser.OnEndFunction?.Invoke();

        public override void OnParameter(bool parameterVar, int parameterID, string parameterName, ParameterType parameterType, string parameterSubType, int? parameterLength, string parameterOptionString, bool parameterTemporary, string parameterDimensions, bool parameterRunOnClient, string parameterSecurityFiltering, bool parameterSuppressDispose) => InvokeCBreezeParser.OnParameter?.Invoke(parameterVar, parameterID, parameterName, parameterType, parameterSubType, parameterLength, parameterOptionString, parameterTemporary, parameterDimensions, parameterRunOnClient, parameterSecurityFiltering, parameterSuppressDispose);
        public override void OnVariable(int variableID, string variableName, VariableType variableType, string variableSubType, int? variableLength, string variableOptionString, string variableConstValue, bool variableTemporary, string variableDimensions, bool variableRunOnClient, bool variableWithEvents, string variableSecurityFiltering, bool variableInDataSet) => InvokeCBreezeParser.OnVariable?.Invoke(variableID, variableName, variableType, variableSubType, variableLength, variableOptionString, variableConstValue, variableTemporary, variableDimensions, variableRunOnClient, variableWithEvents, variableSecurityFiltering, variableInDataSet);
        public override void OnReturnValue(string returnValueName, FunctionReturnValueType? returnValueType, int? returnValueLength, string returnValueDimensions) => InvokeCBreezeParser.OnReturnValue?.Invoke(returnValueName, returnValueType, returnValueLength, returnValueDimensions);
        public override void OnCodeLine(string codeLine) => InvokeCBreezeParser.OnCodeLine?.Invoke(codeLine);

        public override void OnBeginRequestPage() => InvokeCBreezeParser.OnBeginRequestPage?.Invoke();
        public override void OnEndRequestPage() => InvokeCBreezeParser.OnEndRequestPage?.Invoke();

        public override void OnBeginReportElement(int elementID, int? elementIndentation, string elementName, ReportElementType elementType) => InvokeCBreezeParser.OnBeginReportElement?.Invoke(elementID, elementIndentation, elementName, elementType);
        public override void OnEndReportElement() => InvokeCBreezeParser.OnEndReportElement?.Invoke();

        public override void OnBeginReportLabel(int labelID, string labelName) => InvokeCBreezeParser.OnBeginReportLabel?.Invoke(labelID, labelName);
        public override void OnEndReportLabel() => InvokeCBreezeParser.OnEndReportLabel?.Invoke();

        public override void OnBeginQueryElement(int elementID, int? elementIndentation, string elementName, QueryElementType elementType) => InvokeCBreezeParser.OnBeginQueryElement?.Invoke(elementID, elementIndentation, elementName, elementType);
        public override void OnEndQueryElement() => InvokeCBreezeParser.OnEndQueryElement?.Invoke();

        public override void OnBeginXmlPortElement(Guid elementID, int? elementIndentation, string elementName, XmlPortNodeType elementNodeType, XmlPortSourceType elementSourceType) => InvokeCBreezeParser.OnBeginXmlPortElement?.Invoke(elementID, elementIndentation, elementName, elementNodeType, elementSourceType);
        public override void OnEndXmlPortElement() => InvokeCBreezeParser.OnEndXmlPortElement?.Invoke();

        public override void OnBeginMenuSuiteNode(MenuSuiteNodeType nodeType, Guid nodeID) => InvokeCBreezeParser.OnBeginMenuSuiteNode?.Invoke(nodeType, nodeID);
        public override void OnEndMenuSuiteNode() => InvokeCBreezeParser.OnEndMenuSuiteNode?.Invoke();
    }
}
