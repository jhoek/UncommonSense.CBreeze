using System.Linq;
using System.Collections.Generic;
using UncommonSense.CBreeze.Core;
using System;
using UncommonSense.CBreeze.Parse;

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
#if NAV2015
        private WordLayout currentWordLayout;
#endif
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
            var parser = new Parser();
            var application = new Application();
            var applicationBuilder = new ApplicationBuilder(application);

            parser.Listener = applicationBuilder;
            parser.Parse(fileName);

            return application;
        }

        public static Application FromLines(IEnumerable<string> lines)
        {
            var parser = new Parser();
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

        public void OnBeginObject(ObjectType objectType, int objectID, string objectName)
        {
            switch (objectType)
            {
                case ObjectType.Table:
                    var newTable = application.Tables.Add(new Table(objectID, objectName));

                    //currentObjectLevelProperties = newTable.Properties;
                    currentProperties.Push(newTable.Properties);
                    currentTableFields = newTable.Fields;
                    currentTableKeys = newTable.Keys;
                    currentTableFieldGroups = newTable.FieldGroups;
                    currentCode = newTable.Code;

                    currentObject = newTable;
                    break;
                case ObjectType.Page:
                    var newPage = application.Pages.Add(new Page(objectID, objectName));
                    // currentObjectLevelProperties = newPage.Properties;
                    currentProperties.Push(newPage.Properties);
                    currentPageControls = newPage.Controls;
                    currentPageActionList = newPage.Properties.ActionList;
                    currentCode = newPage.Code;
                    currentObject = newPage;
                    break;
                case ObjectType.Report:
                    var newReport = application.Reports.Add(new Report(objectID, objectName));
                    currentProperties.Push(newReport.Properties);
                    currentReportElements = newReport.Elements;
                    currentReportLabels = newReport.Labels;
                    currentReportRequestPage = newReport.RequestPage;
                    currentCode = newReport.Code;
                    currentRdlData = newReport.RdlData;
#if NAV2015
                    currentWordLayout = newReport.WordLayout;
#endif
                    currentObject = newReport;
                    break;
                case ObjectType.Codeunit:
                    var newCodeunit = application.Codeunits.Add(new Codeunit(objectID, objectName));
                    currentProperties.Push(newCodeunit.Properties);
                    //currentObjectLevelProperties = newCodeunit.Properties;
                    currentCode = newCodeunit.Code;
                    currentObject = newCodeunit;
                    break;
                case ObjectType.XmlPort:
                    var newXmlPort = application.XmlPorts.Add(new XmlPort(objectID, objectName));
                    currentProperties.Push(newXmlPort.Properties);
                    currentXmlPortRequestPage = newXmlPort.RequestPage;
                    currentCode = newXmlPort.Code;
                    currentXmlPortNodes = newXmlPort.Nodes;
                    currentObject = newXmlPort;
                    break;
                case ObjectType.MenuSuite:
                    var newMenuSuite = application.MenuSuites.Add(new MenuSuite(objectID, objectName));
                    currentProperties.Push(newMenuSuite.Properties);
                    currentMenuSuiteNodes = newMenuSuite.Nodes;
                    currentObject = newMenuSuite;
                    break;
                case ObjectType.Query:
                    var newQuery = application.Queries.Add(new Query(objectID, objectName));
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
#if NAV2015
            currentWordLayout = null;
#endif
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
                    currentObject.ObjectProperties.DateTime = currentObject.ObjectProperties.DateTime.SetDateComponent(propertyValue);
                    break;
                case "Time":
                    currentObject.ObjectProperties.DateTime = currentObject.ObjectProperties.DateTime.SetTimeComponent(propertyValue);
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
#if NAV2015
 TypeSwitch.Case<AccessByPermissionProperty>(p => p.SetAccessByPermission(propertyValue)),
                TypeSwitch.Case<PreviewModeProperty>(p => p.Value = propertyValue.ToEnum<PreviewMode>()),
                TypeSwitch.Case<PageActionScopeProperty>(p => p.Value = propertyValue.ToEnum<PageActionScope>()),
                TypeSwitch.Case<UpdatePropagationProperty>(p => p.Value = propertyValue.ToEnum<UpdatePropagation>()),
                TypeSwitch.Case<DefaultLayoutProperty>(p => p.Value = propertyValue.ToEnum<DefaultLayout>()),
#endif

#if NAV2016
 TypeSwitch.Case<TableTypeProperty>(p => p.Value = propertyValue.ToEnum<TableType>()),
#endif
 TypeSwitch.Case<ActionContainerTypeProperty>(p => p.Value = propertyValue.ToEnum<ActionContainerType>()),
                TypeSwitch.Case<AutoFormatTypeProperty>(p => p.Value = propertyValue.ToAutoFormatType()),
                TypeSwitch.Case<BlankNumbersProperty>(p => p.Value = propertyValue.ToEnum<BlankNumbers>()),
                TypeSwitch.Case<CalcFormulaProperty>(p => p.SetCalcFormulaProperty(propertyValue)),
                TypeSwitch.Case<CodeunitSubTypeProperty>(p => p.Value = propertyValue.ToEnum<CodeunitSubType>()),
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
#if NAV2016
 TypeSwitch.Case<ExternalAccessProperty>(p => p.Value = propertyValue.ToEnum<ExternalAccess>()),
 TypeSwitch.Case<EventSubscriberInstanceProperty>(p => p.Value = propertyValue.ToEnum<EventSubscriberInstance>()),
#endif
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
#if NAV2016
 TypeSwitch.Case<XmlPortNamespacesProperty>(p => p.Value.SetNamespacesValue(propertyValue)),
#endif
 TypeSwitch.Case<ObjectProperty>(p => p.Value = propertyValue),
                TypeSwitch.Case<RunObjectProperty>(p => p.SetObjectReferenceProperty(propertyValue)),
                TypeSwitch.Case<OccurrenceProperty>(p => p.Value = propertyValue.ToEnum<Occurrence>()),
                TypeSwitch.Case<OptionStringProperty>(p => p.Value = propertyValue),
                TypeSwitch.Case<PageReferenceProperty>(p => p.Value = propertyValue.ToPageReference()),
                TypeSwitch.Case<PageTypeProperty>(p => p.Value = propertyValue.ToEnum<PageType>()),
                TypeSwitch.Case<PaperSourceProperty>(p => p.Value = propertyValue.ToEnum<PaperSource>()),
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
                TypeSwitch.Case<TableRelationProperty>(p => p.SetTableRelationProperty(propertyValue)),
                TypeSwitch.Case<TableViewProperty>(p => p.SetTableViewProperty(propertyValue)),
                TypeSwitch.Case<TestIsolationProperty>(p => p.Value = propertyValue.ToEnum<TestIsolation>()),
                TypeSwitch.Case<TextEncodingProperty>(p => p.Value = propertyValue.ToEnum<TextEncoding>()),
                TypeSwitch.Case<TextTypeProperty>(p => p.Value = propertyValue.ToEnum<TextType>()),
                TypeSwitch.Case<TotalsMethodProperty>(p => p.Value = propertyValue.ToEnum<TotalsMethod>()),
                TypeSwitch.Case<TransactionTypeProperty>(p => p.Value = propertyValue.ToEnum<TransactionType>()),
                TypeSwitch.Case<XmlPortEncodingProperty>(p => p.Value = propertyValue.ToEnum<XmlPortEncoding>()),
                TypeSwitch.Case<XmlPortFormatProperty>(p => p.Value = propertyValue.ToEnum<XmlPortFormat>()),
                TypeSwitch.Case<NullableTimeProperty>(p => p.Value = propertyValue.ToNullableTime()),
                TypeSwitch.Case<NullableBooleanProperty>(p => p.Value = propertyValue.ToNullableBoolean()),
                TypeSwitch.Case<NullableDecimalProperty>(p => p.Value = propertyValue.ToNullableDecimal()),
                TypeSwitch.Case<NullableGuidProperty>(p => p.Value = propertyValue.ToNullableGuid()),
                TypeSwitch.Case<NullableBigIntegerProperty>(p => p.Value = propertyValue.ToNullableBigInteger()),
                TypeSwitch.Case<NullableIntegerProperty>(p => p.Value = propertyValue.ToNullableInteger()),
            TypeSwitch.Default(() => UnknownPropertyType()));
        }

        private void UnknownPropertyType()
        {
            throw new ArgumentOutOfRangeException("Unknown property type.");
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

        public void OnBeginTableField(int fieldNo, bool? fieldEnabled, string fieldName, TableFieldType fieldType, int fieldLength)
        {
            var fields = (currentObject as Table).Fields;

            switch (fieldType)
            {
                case TableFieldType.BigInteger:
                    var bigIntegerTableField = fields.Add(new BigIntegerTableField(fieldNo, fieldName));
                    currentProperties.Push(bigIntegerTableField.Properties);
                    currentTableField = bigIntegerTableField;
                    break;
                case TableFieldType.Binary:
                    var binaryTableField = fields.Add(new BinaryTableField(fieldNo, fieldName, fieldLength));
                    currentProperties.Push(binaryTableField.Properties);
                    currentTableField = binaryTableField;
                    break;
                case TableFieldType.BLOB:
                    var blobTableField = fields.Add(new BlobTableField(fieldNo, fieldName));
                    currentProperties.Push(blobTableField.Properties);
                    currentTableField = blobTableField;
                    break;
                case TableFieldType.Boolean:
                    var booleanTableField = fields.Add(new BooleanTableField(fieldNo, fieldName));
                    currentProperties.Push(booleanTableField.Properties);
                    currentTableField = booleanTableField;
                    break;
                case TableFieldType.Code:
                    var codeTableField = fields.Add(new CodeTableField(fieldNo, fieldName, fieldLength));
                    currentProperties.Push(codeTableField.Properties);
                    currentTableField = codeTableField;
                    break;
                case TableFieldType.Date:
                    var dateTableField = fields.Add(new DateTableField(fieldNo, fieldName));
                    currentProperties.Push(dateTableField.Properties);
                    currentTableField = dateTableField;
                    break;
                case TableFieldType.DateFormula:
                    var dateFormulaTableField = fields.Add(new DateFormulaTableField(fieldNo, fieldName));
                    currentProperties.Push(dateFormulaTableField.Properties);
                    currentTableField = dateFormulaTableField;
                    break;
                case TableFieldType.DateTime:
                    var dateTimeTableField = fields.Add(new DateTimeTableField(fieldNo, fieldName));
                    currentProperties.Push(dateTimeTableField.Properties);
                    currentTableField = dateTimeTableField;
                    break;
                case TableFieldType.Decimal:
                    var decimalTableField = fields.Add(new DecimalTableField(fieldNo, fieldName));
                    currentProperties.Push(decimalTableField.Properties);
                    currentTableField = decimalTableField;
                    break;
                case TableFieldType.Duration:
                    var durationTableField = fields.Add(new DurationTableField(fieldNo, fieldName));
                    currentProperties.Push(durationTableField.Properties);
                    currentTableField = durationTableField;
                    break;
                case TableFieldType.Guid:
                    var guidTableField = fields.Add(new GuidTableField(fieldNo, fieldName));
                    currentProperties.Push(guidTableField.Properties);
                    currentTableField = guidTableField;
                    break;
                case TableFieldType.Integer:
                    var integerTableField = fields.Add(new IntegerTableField(fieldNo, fieldName));
                    currentProperties.Push(integerTableField.Properties);
                    currentTableField = integerTableField;
                    break;
                case TableFieldType.Option:
                    var optionTableField = fields.Add(new OptionTableField(fieldNo, fieldName));
                    currentProperties.Push(optionTableField.Properties);
                    currentTableField = optionTableField;
                    break;
                case TableFieldType.RecordID:
                    var recordIDTableField = fields.Add(new RecordIDTableField(fieldNo, fieldName));
                    currentProperties.Push(recordIDTableField.Properties);
                    currentTableField = recordIDTableField;
                    break;
                case TableFieldType.TableFilter:
                    var tableFilterTableField = fields.Add(new TableFilterTableField(fieldNo, fieldName));
                    currentProperties.Push(tableFilterTableField.Properties);
                    currentTableField = tableFilterTableField;
                    break;
                case TableFieldType.Text:
                    var textTableField = fields.Add(new TextTableField(fieldNo, fieldName, fieldLength));
                    currentProperties.Push(textTableField.Properties);
                    currentTableField = textTableField;
                    break;
                case TableFieldType.Time:
                    var timeTableField = fields.Add(new TimeTableField(fieldNo, fieldName));
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
            currentTableKey = (currentObject as Table).Keys.Add(new TableKey(keyFields));
            currentTableKey.Enabled = keyEnabled;

            currentProperties.Push(currentTableKey.Properties);
        }

        public void OnEndTableKey()
        {
            currentProperties.Pop();
            currentTableKey = null;
        }

        public void OnBeginTableFieldGroup(int fieldGroupID, string fieldGroupName, string[] fieldGroupFields)
        {
            currentTableFieldGroup = (currentObject as Table).FieldGroups.Add(new TableFieldGroup(fieldGroupID, fieldGroupName));
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
            currentFunction = currentCode.Functions.Add(new Function(functionID, functionName));
            currentFunction.Local = functionLocal;
        }

        public void OnEndFunction()
        {
            currentFunction = null;
        }

        public void OnFunctionAttribute(string name, params string[] values)
        {
            switch (name)
            {
#if NAV2016
                case "TryFunction":
                    currentFunction.TryFunction = true;
                    break;
                case "Business":
                    currentFunction.Event = EventPublisherSubscriber.Publisher;
                    currentFunction.EventType = EventType.Business;
                    currentFunction.IncludeSender = values[0].ToNullableBoolean();
                    break;
                case "Integration":
                    currentFunction.Event = EventPublisherSubscriber.Publisher;
                    currentFunction.EventType = EventType.Integration;
                    currentFunction.IncludeSender = values[0].ToNullableBoolean();
                    currentFunction.GlobalVarAccess = values[1].ToNullableBoolean();
                    break;
                case "EventSubscriber":
                    currentFunction.Event = EventPublisherSubscriber.Subscriber;
                    currentFunction.EventPublisherObject.Type = values[0].ToNullableEnum<ObjectType>();
                    currentFunction.EventPublisherObject.ID = values[1].ToNullableInteger();
                    currentFunction.EventFunction = values[2];
                    currentFunction.EventPublisherElement = values[3];
                    currentFunction.OnMissingLicense = values[4].ToNullableEnum<MissingAction>();
                    currentFunction.OnMissingPermission = values[5].ToNullableEnum<MissingAction>();
                    break;
#endif
                case "TransactionModel":
                    currentFunction.TransactionModel = values[0].ToNullableEnum<TransactionModel>();
                    break;
                case "HandlerFunctions":
                    currentFunction.HandlerFunctions = values[0];
                    break;
                case "Normal":
                    switch ((currentObject as Codeunit).Properties.Subtype)
                    {
                        case CodeunitSubType.Test:
                            currentFunction.TestFunctionType = TestFunctionType.Normal;
                            break;
#if NAV2015
                        case CodeunitSubType.Upgrade:
                            currentFunction.UpgradeFunctionType = UpgradeFunctionType.Normal;
                            break;
#endif
                    }
                    break;
                case "Test":
                case "MessageHandler":
                case "ConfirmHandler":
                case "StrMenuHandler":
                case "PageHandler":
                case "ModalPageHandler":
                case "ReportHandler":
                case "RequestPageHandler":
                    currentFunction.TestFunctionType = name.ToNullableEnum<TestFunctionType>();
                    break;
#if NAV2015
                case "Upgrade":
                case "TableSyncSetup":
                case "CheckPrecondition":
                    currentFunction.UpgradeFunctionType = name.ToNullableEnum<UpgradeFunctionType>();
                    break;
#endif
            }
        }

        public void OnVariable(int variableID, string variableName, VariableType variableType, string variableSubType, int? variableLength, string variableOptionString, string variableConstValue, bool variableTemporary, string variableDimensions, bool variableRunOnClient, bool variableWithEvents, string variableSecurityFiltering, bool variableInDataSet)
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
                    if (currentFunction != null)
                    {
                        variables = currentFunction.Variables;
                    }
                    else if (currentEvent != null)
                    {
                        variables = currentEvent.Variables;
                    }
                    else
                    {
                        variables = currentCode.Variables;
                    }

                    break;
                default:
                    throw new ArgumentException(string.Format("No variables expected for {0} section.", currentSectionType));
            }

            switch (variableType)
            {
                case VariableType.Action:
                    var actionVariable = variables.Add(new ActionVariable(variableID, variableName));
                    actionVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.Automation:
                    var automationVariable = variables.Add(new AutomationVariable(variableID, variableName, variableSubType));
                    automationVariable.Dimensions = variableDimensions;
                    automationVariable.WithEvents = variableWithEvents;
                    break;
                case VariableType.BigInteger:
                    var bigIntegerVariable = variables.Add(new BigIntegerVariable(variableID, variableName));
                    bigIntegerVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.BigText:
                    var bigTextVariable = variables.Add(new BigTextVariable(variableID, variableName));
                    bigTextVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.Binary:
                    var binaryVariable = variables.Add(new BinaryVariable(variableID, variableName, variableLength.Value));
                    binaryVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.Boolean:
                    var booleanVariable = variables.Add(new BooleanVariable(variableID, variableName));
                    booleanVariable.Dimensions = variableDimensions;
                    booleanVariable.IncludeInDataset = variableInDataSet;
                    break;
                case VariableType.Byte:
                    var byteVariable = variables.Add(new ByteVariable(variableID, variableName));
                    byteVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.Char:
                    var charVariable = variables.Add(new CharVariable(variableID, variableName));
                    charVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.Code:
                    var codeVariable = variables.Add(new CodeVariable(variableID, variableName, variableLength));
                    codeVariable.Dimensions = variableDimensions;
                    codeVariable.IncludeInDataset = variableInDataSet;
                    break;
                case VariableType.Codeunit:
                    var codeunitVariable = variables.Add(new CodeunitVariable(variableID, variableName, variableSubType.ToInteger()));
                    codeunitVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.Date:
                    var dateVariable = variables.Add(new DateVariable(variableID, variableName));
                    dateVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.DateFormula:
                    var dateFormulaVariable = variables.Add(new DateFormulaVariable(variableID, variableName));
                    dateFormulaVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.DateTime:
                    var dateTimeVariable = variables.Add(new DateTimeVariable(variableID, variableName));
                    dateTimeVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.Decimal:
                    var decimalVariable = variables.Add(new DecimalVariable(variableID, variableName));
                    decimalVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.Dialog:
                    var dialogVariable = variables.Add(new DialogVariable(variableID, variableName));
                    dialogVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.DotNet:
                    var dotnetVariable = variables.Add(new DotNetVariable(variableID, variableName, variableSubType));
                    dotnetVariable.Dimensions = variableDimensions;
                    dotnetVariable.RunOnClient = variableRunOnClient;
                    dotnetVariable.WithEvents = variableWithEvents;
                    break;
                case VariableType.Duration:
                    var durationVariable = variables.Add(new DurationVariable(variableID, variableName));
                    durationVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.ExecutionMode:
                    var executionModeVariable = variables.Add(new ExecutionModeVariable(variableID, variableName));
                    executionModeVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.FieldRef:
                    var fieldRefVariable = variables.Add(new FieldRefVariable(variableID, variableName));
                    fieldRefVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.File:
                    var fileVariable = variables.Add(new FileVariable(variableID, variableName));
                    fileVariable.Dimensions = variableDimensions;
                    break;
#if NAV2016
                case VariableType.FilterPageBuilder:
                    var filterPageBuilderVariable = variables.Add(new FilterPageBuilderVariable(variableID, variableName));
                    filterPageBuilderVariable.Dimensions = variableDimensions;
                    break;
#endif
                case VariableType.Guid:
                    var guidVariable = variables.Add(new GuidVariable(variableID, variableName));
                    guidVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.InStream:
                    var instreamVariable = variables.Add(new InStreamVariable(variableID, variableName));
                    instreamVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.Integer:
                    var integerVariable = variables.Add(new IntegerVariable(variableID, variableName));
                    integerVariable.Dimensions = variableDimensions;
                    integerVariable.IncludeInDataset = variableInDataSet;
                    break;
                case VariableType.KeyRef:
                    var keyrefVariable = variables.Add(new KeyRefVariable(variableID, variableName));
                    keyrefVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.Ocx:
                    var ocxVariable = variables.Add(new OcxVariable(variableID, variableName, variableSubType));
                    ocxVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.Option:
                    var optionVariable = variables.Add(new OptionVariable(variableID, variableName));
                    optionVariable.Dimensions = variableDimensions;
                    optionVariable.OptionString = variableOptionString;
                    break;
                case VariableType.OutStream:
                    var outstreamVariable = variables.Add(new OutStreamVariable(variableID, variableName));
                    outstreamVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.Page:
                    var pageVariable = variables.Add(new PageVariable(variableID, variableName, variableSubType.ToInteger()));
                    pageVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.Query:
                    var queryVariable = variables.Add(new QueryVariable(variableID, variableName, variableSubType.ToInteger()));
                    queryVariable.Dimensions = variableDimensions;
                    queryVariable.SecurityFiltering = variableSecurityFiltering.ToNullableEnum<QuerySecurityFiltering>();
                    break;
                case VariableType.Record:
                    var recordVariable = variables.Add(new RecordVariable(variableID, variableName, variableSubType.ToInteger()));
                    recordVariable.Dimensions = variableDimensions;
                    recordVariable.SecurityFiltering = variableSecurityFiltering.ToNullableEnum<RecordSecurityFiltering>();
                    recordVariable.Temporary = variableTemporary;
                    break;
                case VariableType.RecordID:
                    var recordIDVariable = variables.Add(new RecordIDVariable(variableID, variableName));
                    recordIDVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.RecordRef:
                    var recordRefVariable = variables.Add(new RecordRefVariable(variableID, variableName));
                    recordRefVariable.Dimensions = variableDimensions;
                    recordRefVariable.SecurityFiltering = variableSecurityFiltering.ToNullableEnum<RecordSecurityFiltering>();
                    break;
                case VariableType.Report:
                    var reportVariable = variables.Add(new ReportVariable(variableID, variableName, variableSubType.ToInteger()));
                    reportVariable.Dimensions = variableDimensions;
                    break;
#if NAV2016
                case VariableType.ReportFormat:
                    var reportFormatVariable = variables.Add(new ReportFormatVariable(variableID, variableName));
                    reportFormatVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.TableConnectionType:
                    var tableConnectionTypeVariable = variables.Add(new TableConnectionTypeVariable(variableID, variableName));
                    tableConnectionTypeVariable.Dimensions = variableDimensions;
                    break;
#endif
                case VariableType.TestPage:
                    var testPageVariable = variables.Add(new TestPageVariable(variableID, variableName, variableSubType.ToInteger()));
                    testPageVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.Text:
                    var textVariable = variables.Add(new TextVariable(variableID, variableName, variableLength));
                    textVariable.Dimensions = variableDimensions;
                    textVariable.IncludeInDataset = variableInDataSet;
                    break;
                case VariableType.TextConstant:
                    var textConstant = variables.Add(new TextConstant(variableID, variableName));
                    textConstant.Values.SetMultiLanguageValue(variableConstValue);
                    break;
#if NAV2016
                case VariableType.TextEncoding:
                    var textEncodingVariable = variables.Add(new TextEncodingVariable(variableID, variableName));
                    textEncodingVariable.Dimensions = variableDimensions;
                    break;
#endif
                case VariableType.Time:
                    var timeVariable = variables.Add(new TimeVariable(variableID, variableName));
                    timeVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.TransactionType:
                    var transactionTypeVariable = variables.Add(new TransactionTypeVariable(variableID, variableName));
                    transactionTypeVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.Variant:
                    var variantVariable = variables.Add(new VariantVariable(variableID, variableName));
                    variantVariable.Dimensions = variableDimensions;
                    break;
                case VariableType.XmlPort:
                    var xmlportVariable = variables.Add(new XmlPortVariable(variableID, variableName, variableSubType.ToInteger()));
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
#if NAV2015
                case SectionType.WordLayout:
                    codeLines = currentWordLayout.Lines;
                    break;
#endif
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


        public void OnParameter(bool parameterVar, int parameterID, string parameterName, ParameterType parameterType, string parameterSubType, int? parameterLength, string parameterOptionString, bool parameterTemporary, string parameterDimensions, bool parameterRunOnClient, string parameterSecurityFiltering, bool parameterSuppressDispose)
        {
            Parameters parameters = null;

            if (currentFunction != null)
                parameters = currentFunction.Parameters;
            else
                parameters = currentEvent.Parameters;

            switch (parameterType)
            {
                case ParameterType.Action:
                    var actionParameter = parameters.Add(new ActionParameter(parameterVar, parameterID, parameterName));
                    actionParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.Automation:
                    var automationParameter = parameters.Add(new AutomationParameter(parameterVar, parameterID, parameterName, parameterSubType));
                    automationParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.BigInteger:
                    var bigIntegerParameter = parameters.Add(new BigIntegerParameter(parameterVar, parameterID, parameterName));
                    bigIntegerParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.BigText:
                    var bigTextParameter = parameters.Add(new BigTextParameter(parameterVar, parameterID, parameterName));
                    bigTextParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.Binary:
                    var binaryParameter = parameters.Add(new BinaryParameter(parameterVar, parameterID, parameterName, parameterLength.Value));
                    binaryParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.Boolean:
                    var booleanParameter = parameters.Add(new BooleanParameter(parameterVar, parameterID, parameterName));
                    booleanParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.Byte:
                    var byteParameter = parameters.Add(new ByteParameter(parameterVar, parameterID, parameterName));
                    byteParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.Char:
                    var charParameter = parameters.Add(new CharParameter(parameterVar, parameterID, parameterName));
                    charParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.Code:
                    var codeParameter = parameters.Add(new CodeParameter(parameterVar, parameterID, parameterName, parameterLength));
                    codeParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.Codeunit:
                    var codeunitParameter = parameters.Add(new CodeunitParameter(parameterVar, parameterID, parameterName, parameterSubType.ToInteger()));
                    codeunitParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.Date:
                    var dateParameter = parameters.Add(new DateParameter(parameterVar, parameterID, parameterName));
                    dateParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.DateFormula:
                    var dateFormulaParameter = parameters.Add(new DateFormulaParameter(parameterVar, parameterID, parameterName));
                    dateFormulaParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.DateTime:
                    var dateTimeParameter = parameters.Add(new DateTimeParameter(parameterVar, parameterID, parameterName));
                    dateTimeParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.Decimal:
                    var decimalParameter = parameters.Add(new DecimalParameter(parameterVar, parameterID, parameterName));
                    decimalParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.Dialog:
                    var dialogParameter = parameters.Add(new DialogParameter(parameterVar, parameterID, parameterName));
                    dialogParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.DotNet:
                    var dotnetParameter = parameters.Add(new DotNetParameter(parameterVar, parameterID, parameterName, parameterSubType));
                    dotnetParameter.Dimensions = parameterDimensions;
                    dotnetParameter.RunOnClient = parameterRunOnClient;
                    dotnetParameter.SuppressDispose = parameterSuppressDispose;
                    break;
                case ParameterType.Duration:
                    var durationParameter = parameters.Add(new DurationParameter(parameterVar, parameterID, parameterName));
                    durationParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.ExecutionMode:
                    var executionModeParameter = parameters.Add(new ExecutionModeParameter(parameterVar, parameterID, parameterName));
                    executionModeParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.FieldRef:
                    var fieldRefParameter = parameters.Add(new FieldRefParameter(parameterVar, parameterID, parameterName));
                    fieldRefParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.File:
                    var fileParameter = parameters.Add(new FileParameter(parameterVar, parameterID, parameterName));
                    fileParameter.Dimensions = parameterDimensions;
                    break;
#if NAV2016
                case ParameterType.FilterPageBuilder:
                    var filterPageBuilderParameter = parameters.Add(new FilterPageBuilderParameter(parameterVar, parameterID, parameterName));
                    filterPageBuilderParameter.Dimensions = parameterDimensions;
                    break;
#endif
                case ParameterType.Guid:
                    var guidParameter = parameters.Add(new GuidParameter(parameterVar, parameterID, parameterName));
                    guidParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.InStream:
                    var instreamParameter = parameters.Add(new InStreamParameter(parameterVar, parameterID, parameterName));
                    instreamParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.Integer:
                    var integerParameter = parameters.Add(new IntegerParameter(parameterVar, parameterID, parameterName));
                    integerParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.KeyRef:
                    var keyRefParameter = parameters.Add(new KeyRefParameter(parameterVar, parameterID, parameterName));
                    keyRefParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.Ocx:
                    var ocxParameter = parameters.Add(new OcxParameter(parameterVar, parameterID, parameterName, parameterSubType));
                    ocxParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.Option:
                    var optionParameter = parameters.Add(new OptionParameter(parameterVar, parameterID, parameterName));
                    optionParameter.Dimensions = parameterDimensions;
                    optionParameter.OptionString = parameterOptionString;
                    break;
                case ParameterType.OutStream:
                    var outstreamParameter = parameters.Add(new OutStreamParameter(parameterVar, parameterID, parameterName));
                    outstreamParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.Page:
                    var pageParameter = parameters.Add(new PageParameter(parameterVar, parameterID, parameterName, parameterSubType.ToInteger()));
                    pageParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.Query:
                    var queryParameter = parameters.Add(new QueryParameter(parameterVar, parameterID, parameterName, parameterSubType.ToInteger()));
                    queryParameter.Dimensions = parameterDimensions;
                    queryParameter.SecurityFiltering = parameterSecurityFiltering.ToNullableEnum<QuerySecurityFiltering>();
                    break;
                case ParameterType.Record:
                    var recordParameter = parameters.Add(new RecordParameter(parameterVar, parameterID, parameterName, parameterSubType.ToInteger()));
                    recordParameter.Dimensions = parameterDimensions;
                    recordParameter.Temporary = parameterTemporary;
                    break;
                case ParameterType.RecordID:
                    var recordIDParameter = parameters.Add(new RecordIDParameter(parameterVar, parameterID, parameterName));
                    recordIDParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.RecordRef:
                    var recordRefParameter = parameters.Add(new RecordRefParameter(parameterVar, parameterID, parameterName));
                    recordRefParameter.Dimensions = parameterDimensions;
                    recordRefParameter.SecurityFiltering = parameterSecurityFiltering.ToNullableEnum<RecordSecurityFiltering>();
                    break;
                case ParameterType.Report:
                    var reportParameter = parameters.Add(new ReportParameter(parameterVar, parameterID, parameterName, parameterSubType.ToInteger()));
                    reportParameter.Dimensions = parameterDimensions;
                    break;
#if NAV2016
                case ParameterType.ReportFormat:
                    var reportFormatParameter = parameters.Add(new ReportFormatParameter(parameterVar, parameterID, parameterName));
                    reportFormatParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.TableConnectionType:
                    var tableConnectionTypeParameter = parameters.Add(new TableConnectionTypeParameter(parameterVar, parameterID, parameterName));
                    tableConnectionTypeParameter.Dimensions = parameterDimensions;
                    break;
#endif
                case ParameterType.TestPage:
                    var testPageParameter = parameters.Add(new TestPageParameter(parameterVar, parameterID, parameterName, parameterSubType.ToInteger()));
                    testPageParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.TestRequestPage:
                    var testRequestPageParameter = parameters.Add(new TestRequestPageParameter(parameterVar, parameterID, parameterName, parameterSubType.ToInteger()));
                    testRequestPageParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.Text:
                    var textParameter = parameters.Add(new TextParameter(parameterVar, parameterID, parameterName, parameterLength));
                    textParameter.Dimensions = parameterDimensions;
                    break;
#if NAV2016
                case ParameterType.TextEncoding:
                    var textEncodingParameter = parameters.Add(new TextEncodingParameter(parameterVar, parameterID, parameterName));
                    textEncodingParameter.Dimensions = parameterDimensions;
                    break;
#endif
                case ParameterType.Time:
                    var timeParameter = parameters.Add(new TimeParameter(parameterVar, parameterID, parameterName));
                    timeParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.TransactionType:
                    var transactionTypeParameter = parameters.Add(new TransactionTypeParameter(parameterVar, parameterID, parameterName));
                    transactionTypeParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.Variant:
                    var variantParameter = parameters.Add(new VariantParameter(parameterVar, parameterID, parameterName));
                    variantParameter.Dimensions = parameterDimensions;
                    break;
                case ParameterType.XmlPort:
                    var xmlPortParameter = parameters.Add(new XmlPortParameter(parameterVar, parameterID, parameterName, parameterSubType.ToInteger()));
                    xmlPortParameter.Dimensions = parameterDimensions;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("parameterType");
            }
        }

        public void OnReturnValue(string returnValueName, FunctionReturnValueType? returnValueType, int? returnValueLength, string returnValueDimensions)
        {
            currentFunction.ReturnValue.Name = returnValueName;
            currentFunction.ReturnValue.Type = returnValueType;
            currentFunction.ReturnValue.DataLength = returnValueLength;
            currentFunction.ReturnValue.Dimensions = returnValueDimensions;
        }

        public void OnBeginEvent(int sourceID, string sourceName, int eventID, string eventName)
        {
            currentEvent = currentCode.Events.Add(new Event(sourceID, sourceName, eventID, eventName));
        }

        public void OnEndEvent()
        {
            currentEvent = null;
        }


        public void OnBeginQueryElement(int elementID, int? elementIndentation, string elementName, QueryElementType elementType)
        {
            switch (elementType)
            {
                case QueryElementType.DataItem:
                    var newDataItemQueryElement = currentQueryElements.Add(new DataItemQueryElement(elementID, elementName, elementIndentation));
                    currentProperties.Push(newDataItemQueryElement.Properties);
                    break;
                case QueryElementType.Filter:
                    var newFilterQueryElement = currentQueryElements.Add(new FilterQueryElement(elementID, elementName, elementIndentation));
                    currentProperties.Push(newFilterQueryElement.Properties);
                    break;
                case UncommonSense.CBreeze.Core.QueryElementType.Column:
                    var newColumnQueryElement = currentQueryElements.Add(new ColumnQueryElement(elementID, elementName, elementIndentation));
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

        public void OnBeginPageControl(int controlID, int? controlIndentation, PageControlType controlType)
        {
            switch (controlType)
            {
                case PageControlType.Container:
                    var newContainerPageControl = currentPageControls.Add(new ContainerPageControl(controlID, controlIndentation));
                    currentProperties.Push(newContainerPageControl.Properties);
                    break;
                case PageControlType.Group:
                    var newGroupPageControl = currentPageControls.Add(new GroupPageControl(controlID, controlIndentation));
                    currentPageActionList = newGroupPageControl.Properties.ActionList;
                    currentProperties.Push(newGroupPageControl.Properties);
                    break;
                case PageControlType.Field:
                    var newFieldPageControl = currentPageControls.Add(new FieldPageControl(controlID, controlIndentation));
                    currentProperties.Push(newFieldPageControl.Properties);
                    break;
                case PageControlType.Part:
                    var newPartPageControl = currentPageControls.Add(new PartPageControl(controlID, controlIndentation));
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

        public void OnBeginPageAction(int actionID, int? actionIndentation, PageActionBaseType actionType)
        {
            switch (actionType)
            {
                case PageActionBaseType.ActionContainer:
                    var newPageActionContainer = currentPageActionList.Add(new PageActionContainer(actionID, actionIndentation));
                    currentProperties.Push(newPageActionContainer.Properties);
                    break;
                case PageActionBaseType.ActionGroup:
                    var newPageActionGroup = currentPageActionList.Add(new PageActionGroup(actionID, actionIndentation));
                    currentProperties.Push(newPageActionGroup.Properties);
                    break;
                case PageActionBaseType.Action:
                    var newPageAction = currentPageActionList.Add(new PageAction(actionID, actionIndentation));
                    currentProperties.Push(newPageAction.Properties);
                    break;
                case PageActionBaseType.Separator:
                    var newPageActionSeparator = currentPageActionList.Add(new PageActionSeparator(actionID, actionIndentation));
                    currentProperties.Push(newPageActionSeparator.Properties);
                    break;
            }
        }

        public void OnEndPageAction()
        {
            currentProperties.Pop();
        }


        public void OnBeginXmlPortElement(Guid elementID, int? elementIndentation, string elementName, UncommonSense.CBreeze.Parse.XmlPortNodeType elementNodeType, XmlPortSourceType elementSourceType)
        {
            switch (elementSourceType)
            {
                case XmlPortSourceType.Text:
                    switch (elementNodeType)
                    {
                        case UncommonSense.CBreeze.Parse.XmlPortNodeType.Element:
                            var newTextElementNode = currentXmlPortNodes.Add(new XmlPortTextElement(elementID, elementName, elementIndentation));
                            currentProperties.Push(newTextElementNode.Properties);
                            break;
                        case UncommonSense.CBreeze.Parse.XmlPortNodeType.Attribute:
                            var newTextAttributeNode = currentXmlPortNodes.Add(new XmlPortTextAttribute(elementID, elementName, elementIndentation));
                            currentProperties.Push(newTextAttributeNode.Properties);
                            break;
                    }
                    break;
                case XmlPortSourceType.Table:
                    switch (elementNodeType)
                    {
                        case UncommonSense.CBreeze.Parse.XmlPortNodeType.Element:
                            var newTableElementNode = currentXmlPortNodes.Add(new XmlPortTableElement(elementID, elementName, elementIndentation));
                            currentProperties.Push(newTableElementNode.Properties);
                            break;
                        case UncommonSense.CBreeze.Parse.XmlPortNodeType.Attribute:
                            var newTableAttributeNode = currentXmlPortNodes.Add(new XmlPortTableAttribute(elementID, elementName, elementIndentation));
                            currentProperties.Push(newTableAttributeNode.Properties);
                            break;
                    }
                    break;
                case XmlPortSourceType.Field:
                    switch (elementNodeType)
                    {
                        case UncommonSense.CBreeze.Parse.XmlPortNodeType.Element:
                            var newFieldElementNode = currentXmlPortNodes.Add(new XmlPortFieldElement(elementID, elementName, elementIndentation));
                            currentProperties.Push(newFieldElementNode.Properties);
                            break;
                        case UncommonSense.CBreeze.Parse.XmlPortNodeType.Attribute:
                            var newFieldAttributeNode = currentXmlPortNodes.Add(new XmlPortFieldAttribute(elementID, elementName, elementIndentation));
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


        public void OnBeginReportElement(int elementID, int? elementIndentation, string elementName, UncommonSense.CBreeze.Parse.ReportElementType elementType)
        {
            switch (elementType)
            {
                case UncommonSense.CBreeze.Parse.ReportElementType.DataItem:
                    var newDataItemElement = new DataItemReportElement(elementID, elementIndentation);
                    newDataItemElement.Name = elementName;
                    currentReportElements.Add(newDataItemElement);
                    currentProperties.Push(newDataItemElement.Properties);
                    break;
                case UncommonSense.CBreeze.Parse.ReportElementType.Column:
                    var newColumnElement = new ColumnReportElement(elementID, elementIndentation);
                    newColumnElement.Name = elementName;
                    currentReportElements.Add(newColumnElement);
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
            var newReportLabel = currentReportLabels.Add(new ReportLabel(labelID, labelName));
            currentProperties.Push(newReportLabel.Properties);
        }

        public void OnEndReportLabel()
        {
            currentProperties.Pop();
        }


        public void OnBeginMenuSuiteNode(MenuSuiteNodeType nodeType, Guid nodeID)
        {
            switch (nodeType)
            {
                case MenuSuiteNodeType.Root:
                    var newRootNode = currentMenuSuiteNodes.Add(new RootNode(nodeID));
                    currentProperties.Push(newRootNode.Properties);
                    break;
                case MenuSuiteNodeType.Menu:
                    var newMenuNode = currentMenuSuiteNodes.Add(new MenuNode(nodeID));
                    currentProperties.Push(newMenuNode.Properties);
                    break;
                case MenuSuiteNodeType.MenuGroup:
                    var newGroupNode = currentMenuSuiteNodes.Add(new GroupNode(nodeID));
                    currentProperties.Push(newGroupNode.Properties);
                    break;
                case MenuSuiteNodeType.MenuItem:
                    var newItemNode = currentMenuSuiteNodes.Add(new ItemNode(nodeID));
                    currentProperties.Push(newItemNode.Properties);
                    break;
                case MenuSuiteNodeType.Delta:
                    var newDeltaNode = currentMenuSuiteNodes.Add(new DeltaNode(nodeID));
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
