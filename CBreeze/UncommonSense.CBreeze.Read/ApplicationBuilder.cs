using System.Linq;
using System.Collections.Generic;
using UncommonSense.CBreeze.Core;
using System;
using UncommonSense.Nav.Parser;

namespace UncommonSense.CBreeze.Read
{
    public partial class ApplicationBuilder : IListener
    {
        private Application application;
        private UncommonSense.CBreeze.Core.Object currentObject;
        private SectionType? currentSectionType;
        private TableFields currentTableFields;
        private TableKeys currentTableKeys;
        private TableFieldGroups currentTableFieldGroups;
        private PageControls currentPageControls;
        private ActionList currentPageActionList;
        private QueryElements currentQueryElements;
        private XmlPortNodes currentXmlPortNodes;
        private XmlPortRequestPage currentXmlPortRequestPage;
        private ReportElements currentReportElements;
        private ReportLabels currentReportLabels;
        private ReportRequestPage currentReportRequestPage;
        private RdlData currentRdlData;
        private MenuSuiteNodes currentMenuSuiteNodes;
        private Code currentCode;
        private Trigger currentTrigger;
        private TableField currentTableField;
        private TableKey currentTableKey;
        private TableFieldGroup currentTableFieldGroup;
        private Function currentFunction;
        private Event currentEvent;

        private Stack<IEnumerable<Property>> currentProperties = new Stack<IEnumerable<Property>>();

        public static Application FromFile(string fileName)
        {
            var parser = new UncommonSense.Nav.Parser.Parser();
            var application = new Application();
            var applicationBuilder= new ApplicationBuilder(application);

            parser.Listener = applicationBuilder;
            parser.Parse(fileName);

            return application;
        }

        public static Application FromLines(IEnumerable<string> lines)
        {
            var parser = new UncommonSense.Nav.Parser.Parser();
            var application = new Application();
            var applicationBuilder = new ApplicationBuilder(application);

            parser.Listener = applicationBuilder;
            parser.Parse(lines);

            return application;
        }

        public ApplicationBuilder(Application application)
        {
            this.application = application;
        }

        public void OnBeginObject(UncommonSense.Nav.Parser.ObjectType objectType, int objectID, string objectName)
        {
            switch (objectType)
            {
                case UncommonSense.Nav.Parser.ObjectType.Table:
                    var newTable = application.Tables.Add(objectID, objectName);

                    //currentObjectLevelProperties = newTable.Properties;
                    currentProperties.Push(newTable.Properties);
                    currentTableFields = newTable.Fields;
                    currentTableKeys = newTable.Keys;
                    currentTableFieldGroups = newTable.FieldGroups;
                    currentCode = newTable.Code;

                    currentObject = newTable;
                    break;
                case UncommonSense.Nav.Parser.ObjectType.Page:
                    var newPage = application.Pages.Add(objectID, objectName);
                    // currentObjectLevelProperties = newPage.Properties;
                    currentProperties.Push(newPage.Properties);
                    currentPageControls = newPage.Controls;
                    currentPageActionList = newPage.Properties.ActionList;
                    currentCode = newPage.Code;
                    currentObject = newPage;
                    break;
                case UncommonSense.Nav.Parser.ObjectType.Report:
                    var newReport = application.Reports.Add(objectID, objectName);
                    currentProperties.Push(newReport.Properties);
                    currentReportElements = newReport.Elements;
                    currentReportLabels = newReport.Labels;
                    currentReportRequestPage = newReport.RequestPage;
                    currentCode = newReport.Code;
                    currentRdlData = newReport.RdlData;
                    currentObject = newReport;
                    break;
                case UncommonSense.Nav.Parser.ObjectType.Codeunit:
                    var newCodeunit = application.Codeunits.Add(objectID, objectName);
                    currentProperties.Push(newCodeunit.Properties);
                    //currentObjectLevelProperties = newCodeunit.Properties;
                    currentCode = newCodeunit.Code;
                    currentObject = newCodeunit;
                    break;
                case UncommonSense.Nav.Parser.ObjectType.XmlPort:
                    var newXmlPort = application.XmlPorts.Add(objectID, objectName);
                    currentProperties.Push(newXmlPort.Properties);
                    currentXmlPortRequestPage = newXmlPort.RequestPage;
                    currentCode = newXmlPort.Code;
                    currentXmlPortNodes = newXmlPort.Nodes;
                    currentObject = newXmlPort;
                    break;
                case UncommonSense.Nav.Parser.ObjectType.MenuSuite:
                    var newMenuSuite = application.MenuSuites.Add(objectID, objectName);
                    currentProperties.Push(newMenuSuite.Properties);
                    currentMenuSuiteNodes = newMenuSuite.Nodes;
                    currentObject = newMenuSuite;
                    break;
                case UncommonSense.Nav.Parser.ObjectType.Query:
                    var newQuery = application.Queries.Add(objectID, objectName);
                    // currentObjectLevelProperties = newQuery.Properties;
                    currentProperties.Push(newQuery.Properties);
                    currentQueryElements = newQuery.Elements;
                    currentCode = newQuery.Code;
                    currentObject = newQuery;
                    break;
            }
        }

        public void OnEndObject()
        {
            currentObject = null;
            currentProperties.Pop();
            //currentObjectLevelProperties = null;
            currentTableFields = null;
            currentTableKeys = null;
            currentTableFieldGroups = null;
            currentPageControls = null;
            currentPageActionList = null;
            currentQueryElements = null;
            currentXmlPortNodes = null;
            currentReportElements = null;
            currentReportLabels = null;
            currentReportRequestPage = null;
            currentXmlPortRequestPage = null;
            currentCode = null;
            currentRdlData = null;
            currentMenuSuiteNodes = null;
        }

        public void OnBeginSection(SectionType sectionType)
        {
            currentSectionType = sectionType;
        }

        public void OnEndSection()
        {
            currentSectionType = null;
        }

        public void OnObjectProperty(string propertyName, string propertyValue)
        {
            switch (propertyName)
            {
                case "Date":
                    currentObject.ObjectProperties.DateTime = currentObject.ObjectProperties.DateTime.GetValueOrDefault(DateTime.MinValue).SetDateComponent(propertyValue);
                    break;
                case "Time":
                    currentObject.ObjectProperties.DateTime = currentObject.ObjectProperties.DateTime.GetValueOrDefault(DateTime.MinValue).SetTimeComponent(propertyValue);
                    break;
                case "Modified":
                    currentObject.ObjectProperties.Modified = propertyValue.ToBoolean();
                    break;
                case "Version List":
                    currentObject.ObjectProperties.VersionList = propertyValue;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("propertyName");
            }
        }

        public void OnProperty(string propertyName, string propertyValue)
        {
            var properties = currentProperties.Peek();

            if (propertyName == "Method")
            {
                var methodType = (properties.First(p => p.Name == "MethodType") as MethodTypeProperty).Value;

                switch (methodType)
                {
                    case MethodType.Date:
                        propertyName = "DateMethod";
                        break;
                    case MethodType.Totals:
                        propertyName = "TotalsMethod";
                        break;
                }
            }

            if (propertyName == "Format/Evaluate")
                propertyName = "FormatEvaluate";

            Parsing.TryMatch(ref propertyName, @"^Import::");
            Parsing.TryMatch(ref propertyName, @"^Export::");

            var property = properties.First(p => p.Name == propertyName);

            TypeSwitch.Do(
                property,
                TypeSwitch.Case<ActionContainerTypeProperty>(p => p.Value = propertyValue.ToEnum<ActionContainerType>()),
                TypeSwitch.Case<AutoFormatTypeProperty>(p => p.Value = propertyValue.ToAutoFormatType()),
                TypeSwitch.Case<BlankNumbersProperty>(p => p.Value = propertyValue.ToEnum<BlankNumbers>()),
                TypeSwitch.Case<CalcFormulaProperty>(p => p.SetCalcFormulaProperty(propertyValue)),
                TypeSwitch.Case<ColumnFilterProperty>(p => p.SetColumnFilterProperty(propertyValue)),
                TypeSwitch.Case<ContainerTypeProperty>(p => p.Value = propertyValue.ToEnum<ContainerType>()),
                TypeSwitch.Case<ControlListProperty>(p => p.Value.AddRange(propertyValue.Split(",".ToCharArray()))),
                TypeSwitch.Case<QueryDataItemLinkProperty>(p => p.SetDataItemLinkProperty(propertyValue)),
                TypeSwitch.Case<DataItemLinkTypeProperty>(p => p.Value = propertyValue.ToEnum<DataItemLinkType>()),
                TypeSwitch.Case<DataItemQueryElementTableFilterProperty>(p => p.SetDataItemQueryElementTableFilter(propertyValue)),
                TypeSwitch.Case<DateMethodProperty>(p => p.Value = propertyValue.ToEnum<DateMethod>()),
                TypeSwitch.Case<DecimalPlacesProperty>(p => p.SetDecimalPlacesProperty(propertyValue)),
                TypeSwitch.Case<MenuItemDepartmentCategoryProperty>(p => p.Value = propertyValue.ToEnum<MenuItemDepartmentCategory>()),
                TypeSwitch.Case<DirectionProperty>(p => p.Value = propertyValue.ToEnum<Direction>()),
                TypeSwitch.Case<ExtendedDataTypeProperty>(p => p.Value = propertyValue.ToEnum<ExtendedDataType>()),
                TypeSwitch.Case<FieldClassProperty>(p => p.Value = propertyValue.ToEnum<FieldClass>()),
                TypeSwitch.Case<FieldListProperty>(p => p.Value.AddRange(propertyValue.Split(",".ToCharArray()))),
                TypeSwitch.Case<FormatEvaluateProperty>(p => p.Value = propertyValue.ToFormatEvaluate()),
                TypeSwitch.Case<GroupTypeProperty>(p => p.Value = propertyValue.ToEnum<GroupType>()),
                TypeSwitch.Case<ImportanceProperty>(p => p.Value = propertyValue.ToEnum<Importance>()),
                TypeSwitch.Case<GroupPageControlLayoutProperty>(p => p.Value = propertyValue.ToEnum<GroupPageControlLayout>()),
                TypeSwitch.Case<LinkFieldsProperty>(p => p.SetLinkFieldsProperty(propertyValue)),
                TypeSwitch.Case<MethodTypeProperty>(p => p.Value = propertyValue.ToEnum<MethodType>()),
                TypeSwitch.Case<MaxOccursProperty>(p => p.Value = propertyValue.ToEnum<MaxOccurs>()),
                TypeSwitch.Case<MenuItemRunObjectTypeProperty>(p => p.Value = propertyValue.ToEnum<MenuItemRunObjectType>()),
                TypeSwitch.Case<MinOccursProperty>(p => p.Value = propertyValue.ToEnum<MinOccurs>()),
                TypeSwitch.Case<MultiLanguageProperty>(p => p.Value.SetMultiLanguageValue(propertyValue)),
                TypeSwitch.Case<NullableBooleanProperty>(p => p.Value = propertyValue.ToNullableBoolean()),
                TypeSwitch.Case<NullableDecimalProperty>(p => p.Value = propertyValue.ToNullableDecimal()),
                TypeSwitch.Case<NullableGuidProperty>(p => p.Value = propertyValue.ToNullableGuid()),
                TypeSwitch.Case<NullableIntegerProperty>(p => p.Value = propertyValue.ToNullableInteger()),
                TypeSwitch.Case<ObjectProperty>(p => p.Value = propertyValue),
                TypeSwitch.Case<ObjectReferenceProperty>(p => p.SetObjectReferenceProperty(propertyValue)),
                TypeSwitch.Case<OccurrenceProperty>(p => p.Value = propertyValue.ToEnum<Occurrence>()),
                TypeSwitch.Case<OptionStringProperty>(p => p.Value = propertyValue),
                TypeSwitch.Case<PageReferenceProperty>(p => p.Value = propertyValue.ToPageReference()),
                TypeSwitch.Case<PageTypeProperty>(p => p.Value = propertyValue.ToEnum<PageType>()),
                TypeSwitch.Case<PartTypeProperty>(p => p.Value = propertyValue.ToEnum<PartType>()),
                TypeSwitch.Case<PermissionsProperty>(p => p.SetPermissionProperty(propertyValue)),
                TypeSwitch.Case<PromotedCategoryProperty>(p => p.Value = propertyValue.ToEnum<PromotedCategory>()),
                TypeSwitch.Case<QueryOrderByLinesProperty>(p => p.SetQueryOrderByLinesProperty(propertyValue)),
                TypeSwitch.Case<ReportDataItemLinkProperty>(p => p.SetReportDataItemLinkProperty(propertyValue)),
                TypeSwitch.Case<RunObjectLinkProperty>(p => p.SetObjectLinkProperty(propertyValue)),
                TypeSwitch.Case<RunPageModeProperty>(p => p.Value = propertyValue.ToEnum<RunPageMode>()),
                TypeSwitch.Case<SemiColonSeparatedStringProperty>(p => p.SetSemiColonSeparatedStringProperty(propertyValue)),
                TypeSwitch.Case<SIFTLevelsProperty>(p => p.SetSIFTLevelsProperty(propertyValue)),
                TypeSwitch.Case<SourceFieldProperty>(p => p.SetSourceFieldProperty(propertyValue)),
                TypeSwitch.Case<SqlJoinTypeProperty>(p => p.Value = propertyValue.ToEnum<SqlJoinType>()),
                TypeSwitch.Case<StringProperty>(p => p.Value = propertyValue),
                TypeSwitch.Case<StyleProperty>(p => p.Value = propertyValue.ToEnum<Style>()),
                TypeSwitch.Case<SystemPartIDProperty>(p => p.Value = propertyValue.ToEnum<SystemPartID>()),
                TypeSwitch.Case<BlobSubTypeProperty>(p => p.Value = propertyValue.ToEnum<BlobSubType>()),
                TypeSwitch.Case<TableFieldTypeProperty>(p => p.Value = propertyValue.ToEnum<TableFieldType>()),
                TypeSwitch.Case<TableReferenceProperty>(p => p.Value = propertyValue.ToTableReference()),
                TypeSwitch.Case<TableRelationLinesProperty>(p => p.SetTableRelationProperty(propertyValue)),
                TypeSwitch.Case<TableViewProperty>(p => p.SetTableViewProperty(propertyValue)),
                TypeSwitch.Case<TextTypeProperty>(p => p.Value = propertyValue.ToEnum<TextType>()),
                TypeSwitch.Case<TotalsMethodProperty>(p => p.Value = propertyValue.ToEnum<TotalsMethod>()),
                TypeSwitch.Case<TransactionTypeProperty>(p => p.Value = propertyValue.ToEnum<TransactionType>()),
                TypeSwitch.Case<XmlPortFormatProperty>(p => p.Value = propertyValue.ToEnum<XmlPortFormat>()));
        }

        public void OnBeginTrigger(string triggerName)
        {
            Parsing.TryMatch(ref triggerName, @"^Import::");
            Parsing.TryMatch(ref triggerName, @"^Export::");

            switch (currentSectionType)
            {
                case SectionType.ObjectProperties:
                    throw new System.ApplicationException("No variables expected in object properties section.");
                case SectionType.Properties:
                case SectionType.Fields:
                case SectionType.Controls:
                case SectionType.Dataset:
                    currentTrigger = (currentProperties.Peek().First(p => p.Name == triggerName) as TriggerProperty).Value;
                    break;
                case SectionType.Elements:
                    currentTrigger = (currentProperties.Peek().First(p => p.Name == triggerName) as ScopedTriggerProperty).Value;
                    break;
                default:
                    throw new ArgumentException(string.Format("No triggers expected in {0} section.", currentSectionType));
            }
        }

        public void OnEndTrigger()
        {
            currentTrigger = null;
        }

        public void OnBeginTableField(int fieldNo, bool? fieldEnabled, string fieldName, FieldType fieldType, int fieldLength)
        {
            var fields = (currentObject as Table).Fields;

            switch (fieldType)
            {
                case FieldType.BigInteger:
                    var bigIntegerTableField = fields.AddBigIntegerTableField(fieldNo, fieldName);
                    currentProperties.Push(bigIntegerTableField.Properties);
                    currentTableField = bigIntegerTableField;
                    break;
                case FieldType.Binary:
                    var binaryTableField = fields.AddBinaryTableField(fieldNo, fieldName, fieldLength);
                    currentProperties.Push(binaryTableField.Properties);
                    currentTableField = binaryTableField;
                    break;
                case FieldType.Blob:
                    var blobTableField = fields.AddBlobTableField(fieldNo, fieldName);
                    currentProperties.Push(blobTableField.Properties);
                    currentTableField = blobTableField;
                    break;
                case FieldType.Boolean:
                    var booleanTableField = fields.AddBooleanTableField(fieldNo, fieldName);
                    currentProperties.Push(booleanTableField.Properties);
                    currentTableField = booleanTableField;
                    break;
                case FieldType.Code:
                    var codeTableField = fields.AddCodeTableField(fieldNo, fieldName, fieldLength);
                    currentProperties.Push(codeTableField.Properties);
                    currentTableField = codeTableField;
                    break;
                case FieldType.Date:
                    var dateTableField = fields.AddDateTableField(fieldNo, fieldName);
                    currentProperties.Push(dateTableField.Properties);
                    currentTableField = dateTableField;
                    break;
                case FieldType.DateFormula:
                    var dateFormulaTableField = fields.AddDateFormulaTableField(fieldNo, fieldName);
                    currentProperties.Push(dateFormulaTableField.Properties);
                    currentTableField = dateFormulaTableField;
                    break;
                case FieldType.DateTime:
                    var dateTimeTableField = fields.AddDateTimeTableField(fieldNo, fieldName);
                    currentProperties.Push(dateTimeTableField.Properties);
                    currentTableField = dateTimeTableField;
                    break;
                case FieldType.Decimal:
                    var decimalTableField = fields.AddDecimalTableField(fieldNo, fieldName);
                    currentProperties.Push(decimalTableField.Properties);
                    currentTableField = decimalTableField;
                    break;
                case FieldType.Duration:
                    var durationTableField = fields.AddDurationTableField(fieldNo, fieldName);
                    currentProperties.Push(durationTableField.Properties);
                    currentTableField = durationTableField;
                    break;
                case FieldType.Guid:
                    var guidTableField = fields.AddGuidTableField(fieldNo, fieldName);
                    currentProperties.Push(guidTableField.Properties);
                    currentTableField = guidTableField;
                    break;
                case FieldType.Integer:
                    var integerTableField = fields.AddIntegerTableField(fieldNo, fieldName);
                    currentProperties.Push(integerTableField.Properties);
                    currentTableField = integerTableField;
                    break;
                case FieldType.Option:
                    var optionTableField = fields.AddOptionTableField(fieldNo, fieldName);
                    currentProperties.Push(optionTableField.Properties);
                    currentTableField = optionTableField;
                    break;
                case FieldType.RecordID:
                    var recordIDTableField = fields.AddRecordIDTableField(fieldNo, fieldName);
                    currentProperties.Push(recordIDTableField.Properties);
                    currentTableField = recordIDTableField;
                    break;
                case FieldType.TableFilter:
                    var tableFilterTableField = fields.AddTableFilterTableField(fieldNo, fieldName);
                    currentProperties.Push(tableFilterTableField.Properties);
                    currentTableField = tableFilterTableField;
                    break;
                case FieldType.Text:
                    var textTableField = fields.AddTextTableField(fieldNo, fieldName, fieldLength);
                    currentProperties.Push(textTableField.Properties);
                    currentTableField = textTableField;
                    break;
                case FieldType.Time:
                    var timeTableField = fields.AddTimeTableField(fieldNo, fieldName);
                    currentProperties.Push(timeTableField.Properties);
                    currentTableField = timeTableField;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("fieldType");
            }
        }

        public void OnEndTableField()
        {
            currentProperties.Pop();
            currentTableField = null;
        }

        public void OnBeginTableKey(bool? keyEnabled, string[] keyFields)
        {
            currentTableKey = (currentObject as Table).Keys.Add();
            currentTableKey.Enabled = keyEnabled;
            currentTableKey.Fields.AddRange(keyFields);

            currentProperties.Push(currentTableKey.Properties);
        }

        public void OnEndTableKey()
        {
            currentProperties.Pop();
            currentTableKey = null;
        }

        public void OnBeginTableFieldGroup(int fieldGroupID, string fieldGroupName, string[] fieldGroupFields)
        {
            currentTableFieldGroup = (currentObject as Table).FieldGroups.Add(fieldGroupID, fieldGroupName);
            currentTableFieldGroup.Fields.AddRange(fieldGroupFields);
            currentProperties.Push(currentTableFieldGroup.Properties);
        }

        public void OnEndTableFieldGroup()
        {
            currentProperties.Pop();
            currentTableFieldGroup = null;
        }

        public void OnBeginFunction(int functionID, string functionName, bool functionLocal)
        {
            currentFunction = currentCode.Functions.Add(functionID, functionName);
            currentFunction.Properties.Local = functionLocal;
        }

        public void OnEndFunction()
        {
            currentFunction = null;
        }

        public void OnVariable(int variableID, string variableName, UncommonSense.Nav.Parser.VariableType variableType, string variableSubType, int? variableLength, string variableOptionString, string variableConstValue, bool variableTemporary, string variableDimensions, bool variableRunOnClient, bool variableWithEvents, string variableSecurityFiltering, bool variableInDataSet)
        {
            Variables variables = null;

            switch (currentSectionType)
            {
                case SectionType.ObjectProperties:
                    throw new System.ApplicationException("No variables expected in object properties section.");
                case SectionType.Properties: // Object-level trigger variable
                case SectionType.Fields: // Field trigger variable
                case SectionType.Controls: // Page control trigger variable
                case SectionType.Elements: // XMLport element trigger variable
                case SectionType.Dataset: // Report element trigger variable
                    variables = currentTrigger.Variables;
                    break;
                case SectionType.Code:
                    if (currentFunction == null)
                        variables = currentCode.Variables;
                    else
                        variables = currentFunction.Variables;
                    break;
                default:
                    throw new ArgumentException(string.Format("No variables expected for {0} section.", currentSectionType));
            }

            switch (variableType)
            {
                case UncommonSense.Nav.Parser.VariableType.Action:
                    var actionVariable = variables.AddActionVariable(variableID, variableName);
                    actionVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Automation:
                    var automationVariable = variables.AddAutomationVariable(variableID, variableName, variableSubType);
                    automationVariable.Dimensions = variableDimensions;
                    automationVariable.WithEvents = variableWithEvents;
                    break;
                case UncommonSense.Nav.Parser.VariableType.BigInteger:
                    var bigIntegerVariable = variables.AddBigIntegerVariable(variableID, variableName);
                    bigIntegerVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.BigText:
                    var bigTextVariable = variables.AddBigTextVariable(variableID, variableName);
                    bigTextVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Binary:
                    var binaryVariable = variables.AddBinaryVariable(variableID, variableName, variableLength.Value);
                    binaryVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Boolean:
                    var booleanVariable = variables.AddBooleanVariable(variableID, variableName);
                    booleanVariable.Dimensions = variableDimensions;
                    booleanVariable.IncludeInDataset = variableInDataSet;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Byte:
                    var byteVariable = variables.AddByteVariable(variableID, variableName);
                    byteVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Char:
                    var charVariable = variables.AddCharVariable(variableID, variableName);
                    charVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Code:
                    var codeVariable = variables.AddCodeVariable(variableID, variableName, variableLength);
                    codeVariable.Dimensions = variableDimensions;
                    codeVariable.IncludeInDataset = variableInDataSet;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Codeunit:
                    var codeunitVariable = variables.AddCodeunitVariable(variableID, variableName, variableSubType.ToInteger());
                    codeunitVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Date:
                    var dateVariable = variables.AddDateVariable(variableID, variableName);
                    dateVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.DateFormula:
                    var dateFormulaVariable = variables.AddDateFormulaVariable(variableID, variableName);
                    dateFormulaVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.DateTime:
                    var dateTimeVariable = variables.AddDateTimeVariable(variableID, variableName);
                    dateTimeVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Decimal:
                    var decimalVariable = variables.AddDecimalVariable(variableID, variableName);
                    decimalVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Dialog:
                    var dialogVariable = variables.AddDialogVariable(variableID, variableName);
                    dialogVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.DotNet:
                    var dotnetVariable = variables.AddDotNetVariable(variableID, variableName, variableSubType);
                    dotnetVariable.Dimensions = variableDimensions;
                    dotnetVariable.RunOnClient = variableRunOnClient;
                    dotnetVariable.WithEvents = variableWithEvents;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Duration:
                    var durationVariable = variables.AddDurationVariable(variableID, variableName);
                    durationVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.ExecutionMode:
                    var executionModeVariable = variables.AddExecutionModeVariable(variableID, variableName);
                    executionModeVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.FieldRef:
                    var fieldRefVariable = variables.AddFieldRefVariable(variableID, variableName);
                    fieldRefVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.File:
                    var fileVariable = variables.AddFileVariable(variableID, variableName);
                    fileVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Guid:
                    var guidVariable = variables.AddGuidVariable(variableID, variableName);
                    guidVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.InStream:
                    var instreamVariable = variables.AddInStreamVariable(variableID, variableName);
                    instreamVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Integer:
                    var integerVariable = variables.AddIntegerVariable(variableID, variableName);
                    integerVariable.Dimensions = variableDimensions;
                    integerVariable.IncludeInDataset = variableInDataSet;
                    break;
                case UncommonSense.Nav.Parser.VariableType.KeyRef:
                    var keyrefVariable = variables.AddKeyRefVariable(variableID, variableName);
                    keyrefVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Ocx:
                    var ocxVariable = variables.AddOcxVariable(variableID, variableName, variableSubType);
                    ocxVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Option:
                    var optionVariable = variables.AddOptionVariable(variableID, variableName);
                    optionVariable.Dimensions = variableDimensions;
                    optionVariable.OptionString = variableOptionString;
                    break;
                case UncommonSense.Nav.Parser.VariableType.OutStream:
                    var outstreamVariable = variables.AddOutStreamVariable(variableID, variableName);
                    outstreamVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Page:
                    var pageVariable = variables.AddPageVariable(variableID, variableName, variableSubType.ToInteger());
                    pageVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Query:
                    var queryVariable = variables.AddQueryVariable(variableID, variableName, variableSubType.ToInteger());
                    queryVariable.Dimensions = variableDimensions;
                    queryVariable.SecurityFiltering = variableSecurityFiltering.ToNullableEnum<QuerySecurityFiltering>();
                    break;
                case UncommonSense.Nav.Parser.VariableType.Record:
                    var recordVariable = variables.AddRecordVariable(variableID, variableName, variableSubType.ToInteger());
                    recordVariable.Dimensions = variableDimensions;
                    recordVariable.SecurityFiltering = variableSecurityFiltering.ToNullableEnum<RecordSecurityFiltering>();
                    recordVariable.Temporary = variableTemporary;
                    break;
                case UncommonSense.Nav.Parser.VariableType.RecordID:
                    var recordIDVariable = variables.AddRecordIDVariable(variableID, variableName);
                    recordIDVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.RecordRef:
                    var recordRefVariable = variables.AddRecordRefVariable(variableID, variableName);
                    recordRefVariable.Dimensions = variableDimensions;
                    recordRefVariable.SecurityFiltering = variableSecurityFiltering.ToNullableEnum<RecordSecurityFiltering>();
                    break;
                case UncommonSense.Nav.Parser.VariableType.Report:
                    var reportVariable = variables.AddReportVariable(variableID, variableName, variableSubType.ToInteger());
                    reportVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.TestPage:
                    var testPageVariable = variables.AddTestPageVariable(variableID, variableName, variableSubType.ToInteger());
                    testPageVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Text:
                    var textVariable = variables.AddTextVariable(variableID, variableName, variableLength);
                    textVariable.Dimensions = variableDimensions;
                    textVariable.IncludeInDataset = variableInDataSet;
                    break;
                case UncommonSense.Nav.Parser.VariableType.TextConst:
                    var textConstant = variables.AddTextConstant(variableID, variableName);
                    textConstant.Values.SetMultiLanguageValue(variableConstValue);
                    break;
                case UncommonSense.Nav.Parser.VariableType.Time:
                    var timeVariable = variables.AddTimeVariable(variableID, variableName);
                    timeVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.TransactionType:
                    var transactionTypeVariable = variables.AddTransactionTypeVariable(variableID, variableName);
                    transactionTypeVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Variant:
                    var variantVariable = variables.AddVariantVariable(variableID, variableName);
                    variantVariable.Dimensions = variableDimensions;
                    break;
                case UncommonSense.Nav.Parser.VariableType.Xmlport:
                    var xmlportVariable = variables.AddXmlPortVariable(variableID, variableName, variableSubType.ToInteger());
                    xmlportVariable.Dimensions = variableDimensions;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("variableType");
            }
        }

        public void OnCodeLine(string codeLine)
        {
            CodeLines codeLines = null;

            switch (currentSectionType)
            {
                case SectionType.ObjectProperties:
                    throw new System.ApplicationException("No codelines expected in object properties section.");
                case SectionType.Properties:
                case SectionType.Fields:
                case SectionType.Controls:
                case SectionType.Elements:
                case SectionType.Dataset:
                    codeLines = currentTrigger.CodeLines;
                    break;
                case SectionType.Code:
                    if (currentFunction != null)
                        codeLines = currentFunction.CodeLines;
                    else
                        if (currentEvent != null)
                            codeLines = currentEvent.CodeLines;
                        else
                            codeLines = currentCode.Documentation.Lines;
                    break;
                case SectionType.RdlData:
                    codeLines = currentRdlData.Lines;
                    break;
                default:
                    throw new ArgumentException(string.Format("No code lines expected for section {0}.", currentSectionType));
            }

            codeLines.Add(codeLine);
        }

        public Application Application
        {
            get
            {
                return this.application;
            }
        }


        public void OnParameter(bool parameterVar, int parameterID, string parameterName, UncommonSense.Nav.Parser.ParameterType parameterType,  string parameterSubType, int? parameterLength, string parameterOptionString, bool parameterTemporary, string parameterDimensions, bool parameterRunOnClient, string parameterSecurityFiltering, bool parameterSuppressDispose)
        {
            Parameters parameters = null;

            if (currentFunction != null)
                parameters = currentFunction.Parameters;
            else
                parameters = currentEvent.Parameters;

            switch (parameterType)
            {
                case UncommonSense.Nav.Parser.ParameterType.Action:
                    var actionParameter = parameters.AddActionParameter(parameterVar, parameterID, parameterName);
                    actionParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Automation:
                    var automationParameter = parameters.AddAutomationParameter(parameterVar, parameterID, parameterName, parameterSubType);
                    automationParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.BigInteger:
                    var bigIntegerParameter = parameters.AddBigIntegerParameter(parameterVar, parameterID, parameterName);
                    bigIntegerParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.BigText:
                    var bigTextParameter = parameters.AddBigTextParameter(parameterVar, parameterID, parameterName);
                    bigTextParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Binary:
                    var binaryParameter = parameters.AddBinaryParameter(parameterVar, parameterID, parameterName, parameterLength.Value);
                    binaryParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Boolean:
                    var booleanParameter = parameters.AddBooleanParameter(parameterVar, parameterID, parameterName);
                    booleanParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Byte:
                    var byteParameter = parameters.AddByteParameter(parameterVar, parameterID, parameterName);
                    byteParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Char:
                    var charParameter = parameters.AddCharParameter(parameterVar, parameterID, parameterName);
                    charParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Code:
                    var codeParameter = parameters.AddCodeParameter(parameterVar, parameterID, parameterName, parameterLength);
                    codeParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Codeunit:
                    var codeunitParameter = parameters.AddCodeunitParameter(parameterVar, parameterID, parameterName, parameterSubType.ToInteger());
                    codeunitParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Date:
                    var dateParameter = parameters.AddDateParameter(parameterVar, parameterID, parameterName);
                    dateParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.DateFormula:
                    var dateFormulaParameter = parameters.AddDateFormulaParameter(parameterVar, parameterID, parameterName);
                    dateFormulaParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.DateTime:
                    var dateTimeParameter = parameters.AddDateTimeParameter(parameterVar, parameterID, parameterName);
                    dateTimeParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Decimal:
                    var decimalParameter = parameters.AddDecimalParameter(parameterVar, parameterID, parameterName);
                    decimalParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Dialog:
                    var dialogParameter = parameters.AddDialogParameter(parameterVar, parameterID, parameterName);
                    dialogParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.DotNet:
                    var dotnetParameter = parameters.AddDotNetParameter(parameterVar, parameterID, parameterName, parameterSubType);
                    dotnetParameter.Dimensions = parameterDimensions;
                    dotnetParameter.RunOnClient = parameterRunOnClient;
                    dotnetParameter.SuppressDispose = parameterSuppressDispose;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Duration:
                    var durationParameter = parameters.AddDurationParameter(parameterVar, parameterID, parameterName);
                    durationParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.ExecutionMode:
                    var executionModeParameter = parameters.AddExecutionModeParameter(parameterVar, parameterID, parameterName);
                    executionModeParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.FieldRef:
                    var fieldRefParameter = parameters.AddFieldRefParameter(parameterVar, parameterID, parameterName);
                    fieldRefParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.File:
                    var fileParameter = parameters.AddFileParameter(parameterVar, parameterID, parameterName);
                    fileParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Guid:
                    var guidParameter = parameters.AddGuidParameter(parameterVar, parameterID, parameterName);
                    guidParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.InStream:
                    var instreamParameter = parameters.AddInStreamParameter(parameterVar, parameterID, parameterName);
                    instreamParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Integer:
                    var integerParameter = parameters.AddIntegerParameter(parameterVar, parameterID, parameterName);
                    integerParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.KeyRef:
                    var keyRefParameter = parameters.AddKeyRefParameter(parameterVar, parameterID, parameterName);
                    keyRefParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Ocx:
                    var ocxParameter = parameters.AddOcxParameter(parameterVar, parameterID, parameterName, parameterSubType);
                    ocxParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Option:
                    var optionParameter = parameters.AddOptionParameter(parameterVar, parameterID, parameterName);
                    optionParameter.Dimensions = parameterDimensions;
                    optionParameter.OptionString = parameterOptionString;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.OutStream:
                    var outstreamParameter = parameters.AddOutStreamParameter(parameterVar, parameterID, parameterName);
                    outstreamParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Page:
                    var pageParameter = parameters.AddPageParameter(parameterVar, parameterID, parameterName, parameterSubType.ToInteger());
                    pageParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Query:
                    var queryParameter = parameters.AddQueryParameter(parameterVar, parameterID, parameterName, parameterSubType.ToInteger());
                    queryParameter.Dimensions = parameterDimensions;
                    queryParameter.SecurityFiltering = parameterSecurityFiltering.ToNullableEnum<QuerySecurityFiltering>();
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Record:
                    var recordParameter = parameters.AddRecordParameter(parameterVar, parameterID, parameterName, parameterSubType.ToInteger());
                    recordParameter.Dimensions = parameterDimensions;
                    recordParameter.Temporary = parameterTemporary;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.RecordID:
                    var recordIDParameter = parameters.AddRecordIDParameter(parameterVar, parameterID, parameterName);
                    recordIDParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.RecordRef:
                    var recordRefParameter = parameters.AddRecordRefParameter(parameterVar, parameterID, parameterName);
                    recordRefParameter.Dimensions = parameterDimensions;
                    recordRefParameter.SecurityFiltering = parameterSecurityFiltering.ToNullableEnum<RecordSecurityFiltering>();
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Report:
                    var reportParameter = parameters.AddReportParameter(parameterVar, parameterID, parameterName, parameterSubType.ToInteger());
                    reportParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.TestPage:
                    var testPageParameter = parameters.AddTestPageParameter(parameterVar, parameterID, parameterName, parameterSubType.ToInteger());
                    testPageParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.TestRequestPage:
                    var testRequestPageParameter = parameters.AddTestRequestPageParameter(parameterVar, parameterID, parameterName, parameterSubType.ToInteger());
                    testRequestPageParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Text:
                    var textParameter = parameters.AddTextParameter(parameterVar, parameterID, parameterName, parameterLength);
                    textParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Time:
                    var timeParameter = parameters.AddTimeParameter(parameterVar, parameterID, parameterName);
                    timeParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.TransactionType:
                    var transactionTypeParameter = parameters.AddTransactionTypeParameter(parameterVar, parameterID, parameterName);
                    transactionTypeParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.Variant:
                    var variantParameter = parameters.AddVariantParameter(parameterVar, parameterID, parameterName);
                    variantParameter.Dimensions = parameterDimensions;
                    break;
                case UncommonSense.Nav.Parser.ParameterType.XmlPort:
                    var xmlPortParameter = parameters.AddXmlPortParameter(parameterVar, parameterID, parameterName, parameterSubType.ToInteger());
                    xmlPortParameter.Dimensions = parameterDimensions;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("parameterType");
            }
        }

        public void OnReturnValue(string returnValueName, ReturnValueType? returnValueType, int? returnValueLength, string returnValueDimensions)
        {
            currentFunction.ReturnValue.Name = returnValueName;

            switch (returnValueType)
            {
                case null:
                    break;
                case ReturnValueType.BigInteger:
                    currentFunction.ReturnValue.Type = FunctionReturnValueType.BigInteger;
                    break;
                case ReturnValueType.Binary:
                    currentFunction.ReturnValue.Type = FunctionReturnValueType.Binary;
                    break;
                case ReturnValueType.Boolean:
                    currentFunction.ReturnValue.Type = FunctionReturnValueType.Boolean;
                    break;
                case ReturnValueType.Byte:
                    currentFunction.ReturnValue.Type = FunctionReturnValueType.Byte;
                    break;
                case ReturnValueType.Char:
                    currentFunction.ReturnValue.Type = FunctionReturnValueType.Char;
                    break;
                case ReturnValueType.Code:
                    currentFunction.ReturnValue.Type = FunctionReturnValueType.Code;
                    break;
                case ReturnValueType.Date:
                    currentFunction.ReturnValue.Type = FunctionReturnValueType.Date;
                    break;
                case ReturnValueType.DateTime:
                    currentFunction.ReturnValue.Type = FunctionReturnValueType.DateTime;
                    break;
                case ReturnValueType.Decimal:
                    currentFunction.ReturnValue.Type = FunctionReturnValueType.Decimal;
                    break;
                case ReturnValueType.Duration:
                    currentFunction.ReturnValue.Type = FunctionReturnValueType.Duration;
                    break;
                case ReturnValueType.Guid:
                    currentFunction.ReturnValue.Type = FunctionReturnValueType.Guid;
                    break;
                case ReturnValueType.Integer:
                    currentFunction.ReturnValue.Type = FunctionReturnValueType.Integer;
                    break;
                case ReturnValueType.Option:
                    currentFunction.ReturnValue.Type = FunctionReturnValueType.Option;
                    break;
                case ReturnValueType.Text:
                    currentFunction.ReturnValue.Type = FunctionReturnValueType.Text;
                    break;
                case ReturnValueType.Time:
                    currentFunction.ReturnValue.Type = FunctionReturnValueType.Time;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("returnValueType");
            }

            currentFunction.ReturnValue.DataLength = returnValueLength;
            currentFunction.ReturnValue.Dimensions = returnValueDimensions;
        }

        public void OnBeginEvent(int sourceID, string sourceName, int eventID, string eventName)
        {
            currentEvent = currentCode.Events.Add(sourceID, sourceName, eventID, eventName);
        }

        public void OnEndEvent()
        {
            currentEvent = null;
        }


        public void OnBeginQueryElement(int elementID, int? elementIndentation, string elementName, UncommonSense.Nav.Parser.QueryElementType elementType)
        {
            switch (elementType)
            {
                case UncommonSense.Nav.Parser.QueryElementType.DataItem:
                    var newDataItemQueryElement = currentQueryElements.AddDataItemQueryElement(elementID, elementName, elementIndentation);
                    currentProperties.Push(newDataItemQueryElement.Properties);
                    break;
                case UncommonSense.Nav.Parser.QueryElementType.Filter:
                    var newFilterQueryElement = currentQueryElements.AddFilterQueryElement(elementID, elementName, elementIndentation);
                    currentProperties.Push(newFilterQueryElement.Properties);
                    break;
                case UncommonSense.Nav.Parser.QueryElementType.Column:
                    var newColumnQueryElement = currentQueryElements.AddColumnQueryElement(elementID, elementName, elementIndentation);
                    currentProperties.Push(newColumnQueryElement.Properties);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("elementType");
            }
        }

        public void OnEndQueryElement()
        {
            currentProperties.Pop();
        }

        public void OnBeginPageControl(int controlID, int? controlIndentation, UncommonSense.Nav.Parser.PageControlType controlType)
        {
            switch (controlType)
            {
                case UncommonSense.Nav.Parser.PageControlType.Container:
                    var newContainerPageControl = currentPageControls.AddContainerPageControl(controlID, controlIndentation);
                    currentProperties.Push(newContainerPageControl.Properties);
                    break;
                case UncommonSense.Nav.Parser.PageControlType.Group:
                    var newGroupPageControl = currentPageControls.AddGroupPageControl(controlID, controlIndentation);
                    currentPageActionList = newGroupPageControl.Properties.ActionList;
                    currentProperties.Push(newGroupPageControl.Properties);
                    break;
                case UncommonSense.Nav.Parser.PageControlType.Field:
                    var newFieldPageControl = currentPageControls.AddFieldPageControl(controlID, controlIndentation);
                    currentProperties.Push(newFieldPageControl.Properties);
                    break;
                case UncommonSense.Nav.Parser.PageControlType.Part:
                    var newPartPageControl = currentPageControls.AddPartPageControl(controlID, controlIndentation);
                    currentProperties.Push(newPartPageControl.Properties);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("controlType");
            }
        }

        public void OnEndPageControl()
        {
            currentPageActionList = null;
            currentProperties.Pop();
        }

        public void OnBeginPageAction(int actionID, int? actionIndentation, PageActionType actionType)
        {
            switch (actionType)
            {
                case PageActionType.ActionContainer:
                    var newPageActionContainer = currentPageActionList.AddPageActionContainer(actionID, actionIndentation);
                    currentProperties.Push(newPageActionContainer.Properties);
                    break;
                case PageActionType.ActionGroup:
                    var newPageActionGroup = currentPageActionList.AddPageActionGroup(actionID, actionIndentation);
                    currentProperties.Push(newPageActionGroup.Properties);
                    break;
                case PageActionType.Action:
                    var newPageAction = currentPageActionList.AddPageAction(actionID, actionIndentation);
                    currentProperties.Push(newPageAction.Properties);
                    break;
                case PageActionType.Separator:
                    var newPageActionSeparator = currentPageActionList.AddPageActionSeparator(actionID, actionIndentation);
                    currentProperties.Push(newPageActionSeparator.Properties);
                    break;
            }
        }

        public void OnEndPageAction()
        {
            currentProperties.Pop();
        }


        public void OnBeginXmlPortElement(Guid elementID, int? elementIndentation, string elementName, UncommonSense.Nav.Parser.XmlPortNodeType elementNodeType, XmlPortSourceType elementSourceType)
        {
            switch (elementSourceType)
            {
                case XmlPortSourceType.Text:
                    switch (elementNodeType)
                    {
                        case UncommonSense.Nav.Parser.XmlPortNodeType.Element:
                            var newTextElementNode = currentXmlPortNodes.AddXmlPortTextElement(elementID, elementName, elementIndentation);
                            currentProperties.Push(newTextElementNode.Properties);
                            break;
                        case UncommonSense.Nav.Parser.XmlPortNodeType.Attribute:
                            var newTextAttributeNode = currentXmlPortNodes.AddXmlPortTextAttribute(elementID, elementName, elementIndentation);
                            currentProperties.Push(newTextAttributeNode.Properties);
                            break;
                    }
                    break;
                case XmlPortSourceType.Table:
                    switch (elementNodeType)
                    {
                        case UncommonSense.Nav.Parser.XmlPortNodeType.Element:
                            var newTableElementNode = currentXmlPortNodes.AddXmlPortTableElement(elementID, elementName, elementIndentation);
                            currentProperties.Push(newTableElementNode.Properties);
                            break;
                        case UncommonSense.Nav.Parser.XmlPortNodeType.Attribute:
                            var newTableAttributeNode = currentXmlPortNodes.AddXmlPortTableAttribute(elementID, elementName, elementIndentation);
                            currentProperties.Push(newTableAttributeNode.Properties);
                            break;
                    }
                    break;
                case XmlPortSourceType.Field:
                    switch (elementNodeType)
                    {
                        case UncommonSense.Nav.Parser.XmlPortNodeType.Element:
                            var newFieldElementNode = currentXmlPortNodes.AddXmlPortFieldElement(elementID, elementName, elementIndentation);
                            currentProperties.Push(newFieldElementNode.Properties);
                            break;
                        case UncommonSense.Nav.Parser.XmlPortNodeType.Attribute:
                            var newFieldAttributeNode = currentXmlPortNodes.AddXmlPortFieldAttribute(elementID, elementName, elementIndentation);
                            currentProperties.Push(newFieldAttributeNode.Properties);
                            break;
                    }
                    break;
            }
        }

        public void OnEndXmlPortElement()
        {
            currentProperties.Pop();
        }


        public void OnBeginReportElement(int elementID, int? elementIndentation, string elementName, UncommonSense.Nav.Parser.ReportElementType elementType)
        {
            switch (elementType)
            {
                case UncommonSense.Nav.Parser.ReportElementType.DataItem:
                    var newDataItemElement = currentReportElements.AddDataItemReportElement(elementID, elementIndentation);
                    newDataItemElement.Name = elementName;
                    currentProperties.Push(newDataItemElement.Properties);
                    break;
                case UncommonSense.Nav.Parser.ReportElementType.Column:
                    var newColumnElement = currentReportElements.AddColumnReportElement(elementID, elementIndentation);
                    newColumnElement.Name = elementName;
                    currentProperties.Push(newColumnElement.Properties);
                    break;
            }
        }

        public void OnEndReportElement()
        {
            currentProperties.Pop();
        }

        public void OnBeginRequestPage()
        {
            TypeSwitch.Do(
                currentObject,
                TypeSwitch.Case<Report>(r =>
                {
                    currentProperties.Push(currentReportRequestPage.Properties);
                    currentPageControls = currentReportRequestPage.Controls;
                }),
                TypeSwitch.Case<XmlPort>(x =>
                {
                    currentProperties.Push(currentXmlPortRequestPage.Properties);
                    currentPageControls = currentXmlPortRequestPage.Controls;
                }));
        }

        public void OnEndRequestPage()
        {
            currentProperties.Pop();
            currentPageControls = null;
        }


        public void OnBeginReportLabel(int labelID, string labelName)
        {
            var newReportLabel = currentReportLabels.Add(labelID, labelName);
            currentProperties.Push(newReportLabel.Properties);
        }

        public void OnEndReportLabel()
        {
            currentProperties.Pop();
        }


        public void OnBeginMenuSuiteNode(UncommonSense.Nav.Parser.MenuSuiteNodeType nodeType, Guid nodeID)
        {
            switch (nodeType)
            {
                case UncommonSense.Nav.Parser.MenuSuiteNodeType.Root:
                    var newRootNode = currentMenuSuiteNodes.AddRootNode(nodeID);
                    currentProperties.Push(newRootNode.Properties);
                    break;
                case UncommonSense.Nav.Parser.MenuSuiteNodeType.Menu:
                    var newMenuNode = currentMenuSuiteNodes.AddMenuNode(nodeID);
                    currentProperties.Push(newMenuNode.Properties);
                    break;
                case UncommonSense.Nav.Parser.MenuSuiteNodeType.MenuGroup:
                    var newGroupNode = currentMenuSuiteNodes.AddGroupNode(nodeID);
                    currentProperties.Push(newGroupNode.Properties);
                    break;
                case UncommonSense.Nav.Parser.MenuSuiteNodeType.MenuItem:
                    var newItemNode = currentMenuSuiteNodes.AddItemNode(nodeID);
                    currentProperties.Push(newItemNode.Properties);
                    break;
                case UncommonSense.Nav.Parser.MenuSuiteNodeType.Delta:
                    var newDeltaNode = currentMenuSuiteNodes.AddDeltaNode(nodeID);
                    currentProperties.Push(newDeltaNode.Properties);
                    break;
            }
        }

        public void OnEndMenuSuiteNode()
        {
            currentProperties.Pop();
        }
    }
}
