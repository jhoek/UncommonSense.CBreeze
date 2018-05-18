﻿using System.Linq;
using System.Collections.Generic;
using UncommonSense.CBreeze.Core;
using System;
using UncommonSense.CBreeze.Parse;
using UncommonSense.CBreeze.Common;
using System.IO;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Code;
using UncommonSense.CBreeze.Core.Code.Function;
using UncommonSense.CBreeze.Core.Code.Parameter;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Codeunit;
using UncommonSense.CBreeze.Core.MenuSuite;
using UncommonSense.CBreeze.Core.Page;
using UncommonSense.CBreeze.Core.Page.Action;
using UncommonSense.CBreeze.Core.Page.Control;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Property.Type;
using UncommonSense.CBreeze.Core.Query;
using UncommonSense.CBreeze.Core.Report;
using UncommonSense.CBreeze.Core.Table;
using UncommonSense.CBreeze.Core.Table.Field;
using UncommonSense.CBreeze.Core.Table.Key;
using UncommonSense.CBreeze.Core.XmlPort;
using Object = UncommonSense.CBreeze.Core.Code.Variable.Object;

namespace UncommonSense.CBreeze.Read
{
    public partial class ApplicationBuilder : ListenerBase
    {
        private Application application;
        private string currentFileName;
        private Object currentObject;
        private SectionType? currentSectionType;
        private TableFields currentTableFields;
        private TableKeys currentTableKeys;
        private TableFieldGroups currentTableFieldGroups;
        private PageControls currentPageControls;
        private ActionList currentPageActionList;
        private QueryElements currentQueryElements;
        private XmlPortNodes currentXmlPortNodes;
        private ReportElements currentReportElements;
        private ReportLabels currentReportLabels;
        private RequestPage currentRequestPage;
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

        public static Application ReadFromFolder(string folderName) => ReadFromFiles(Directory.EnumerateFiles(folderName, "*.txt"));

        public static Application ReadFromFile(string fileName) => ReadFromFiles(fileName);

        public static Application ReadFromFiles(params string[] fileNames) => ReadFromFiles((IEnumerable<string>)fileNames);

        public static Application ReadFromFiles(IEnumerable<string> fileNames, Action<string> reportProgress = null)
        {
            var parser = new Parser();
            var application = new Application();
            var applicationBuilder = new ApplicationBuilder(application);

            parser.Listener = applicationBuilder;
            parser.ParseFiles(fileNames, reportProgress);

            return application;
        }

        public static Application ReadFromLines(IEnumerable<string> lines)
        {
            var parser = new Parser();
            var application = new Application();
            var applicationBuilder = new ApplicationBuilder(application);

            parser.Listener = applicationBuilder;
            parser.ParseLines(lines);

            return application;
        }

        public ApplicationBuilder(Application application)
        {
            this.application = application;
        }

        public override void OnBeginFile(string fileName)
        {
            currentFileName = fileName;
        }

        public override void OnEndFile()
        {
            currentFileName = null;
        }

        public override void OnBeginObject(ObjectType objectType, int objectID, string objectName)
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
                    currentRequestPage = newReport.RequestPage;
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
                    currentRequestPage = newXmlPort.RequestPage;
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

        public override void OnEndObject()
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
            currentRequestPage = null;
            currentCode = null;
            currentRdlData = null;
#if NAV2015
            currentWordLayout = null;
#endif
            currentMenuSuiteNodes = null;
        }

        public override void OnBeginSection(SectionType sectionType)
        {
            currentSectionType = sectionType;
        }

        public override void OnEndSection()
        {
            currentSectionType = null;
        }

        public override void OnObjectProperty(string propertyName, string propertyValue)
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

        public override void OnProperty(string propertyName, string propertyValue)
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
#if NAV2017
                TypeSwitch.Case<TagListProperty>(p => p.Value.AddRange(propertyValue.Split(",".ToCharArray()).Where(s => !string.IsNullOrEmpty(s)))),
#endif
#if NAV2016
                TypeSwitch.Case<TableTypeProperty>(p => p.Value = propertyValue.ToEnum<TableType>()),
#endif
                TypeSwitch.Case<PageActionContainerTypeProperty>(p => p.Value = propertyValue.ToEnum<PageActionContainerType>()),
                TypeSwitch.Case<AutoFormatTypeProperty>(p => p.Value = propertyValue.ToAutoFormatType()),
                TypeSwitch.Case<BlankNumbersProperty>(p => p.Value = propertyValue.ToEnum<BlankNumbers>()),
                TypeSwitch.Case<CalcFormulaProperty>(p => p.SetCalcFormulaProperty(propertyValue)),
                TypeSwitch.Case<CodeunitSubTypeProperty>(p => p.Value = propertyValue.ToEnum<CodeunitSubType>()),
                TypeSwitch.Case<ColumnFilterProperty>(p => p.SetColumnFilterProperty(propertyValue)),
                TypeSwitch.Case<PageControlContainerTypeProperty>(p => p.Value = propertyValue.ToEnum<PageControlContainerType>()),
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
                TypeSwitch.Case<GestureProperty>(p => p.Value = propertyValue.ToEnum<Gesture>()),
                TypeSwitch.Case<PageControlGroupTypeProperty>(p => p.Value = propertyValue.ToEnum<PageControlGroupType>()),
                TypeSwitch.Case<ImportanceProperty>(p => p.Value = propertyValue.ToEnum<Importance>()),
                TypeSwitch.Case<PageControlGroupLayoutProperty>(p => p.Value = propertyValue.ToEnum<PageControlGroupLayout>()),
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
                TypeSwitch.Case<PageControlPartTypeProperty>(p => p.Value = propertyValue.ToEnum<PageControlPartType>()),
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
#if NAV2017
                TypeSwitch.Case<TestPermissionsProperty>(p => p.Value = propertyValue.ToEnum<TestPermissions>()),
#endif
                TypeSwitch.Case<TextEncodingProperty>(p => p.Value = propertyValue.ToEnum<TextEncoding>()),
                TypeSwitch.Case<TextTypeProperty>(p => p.Value = propertyValue.ToEnum<TextType>()),
                TypeSwitch.Case<TotalsMethodProperty>(p => p.Value = propertyValue.ToEnum<TotalsMethod>()),
                TypeSwitch.Case<TransactionTypeProperty>(p => p.Value = propertyValue.ToEnum<TransactionType>()),
                TypeSwitch.Case<XmlPortEncodingProperty>(p => p.Value = propertyValue.ToEnum<XmlPortEncoding>()),
                TypeSwitch.Case<XmlPortNodeDataTypeProperty>(p => p.Value = propertyValue.ToEnum<XmlPortNodeDataType>()),
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

        public override void OnBeginTrigger(string triggerName)
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

        public override void OnEndTrigger()
        {
            currentTrigger = null;
        }

        public override void OnBeginTableField(int fieldNo, bool? fieldEnabled, string fieldName, TableFieldType fieldType, int fieldLength)
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

#if NAV2017
                case TableFieldType.Media:
                    var mediaTableField = fields.Add(new MediaTableField(fieldNo, fieldName));
                    currentProperties.Push(mediaTableField.Properties);
                    currentTableField = mediaTableField;
                    break;

                case TableFieldType.MediaSet:
                    var mediaSetTableField = fields.Add(new MediaSetTableField(fieldNo, fieldName));
                    currentProperties.Push(mediaSetTableField.Properties);
                    currentTableField = mediaSetTableField;
                    break;
#endif

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

            currentTableField.Container = currentTableFields;
            currentTableField.Enabled = fieldEnabled;
        }

        public override void OnEndTableField()
        {
            currentProperties.Pop();
            currentTableField = null;
        }

        public override void OnBeginTableKey(bool? keyEnabled, string[] keyFields)
        {
            currentTableKey = (currentObject as Table).Keys.Add(new TableKey(keyFields));
            currentTableKey.Enabled = keyEnabled;

            currentProperties.Push(currentTableKey.Properties);
        }

        public override void OnEndTableKey()
        {
            currentProperties.Pop();
            currentTableKey = null;
        }

        public override void OnBeginTableFieldGroup(int fieldGroupID, string fieldGroupName, string[] fieldGroupFields)
        {
            currentTableFieldGroup = (currentObject as Table).FieldGroups.Add(new TableFieldGroup(fieldGroupID, fieldGroupName));
            currentTableFieldGroup.Fields.AddRange(fieldGroupFields);
            currentProperties.Push(currentTableFieldGroup.Properties);
        }

        public override void OnEndTableFieldGroup()
        {
            currentProperties.Pop();
            currentTableFieldGroup = null;
        }

        public override void OnBeginFunction(int functionID, string functionName, bool functionLocal)
        {
            currentFunction = currentCode.Functions.Add(new Function(functionID, functionName));
            currentFunction.Local = functionLocal;
        }

        public override void OnEndFunction()
        {
            currentFunction = null;
        }

        public override void OnFunctionAttribute(string name, params string[] values)
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

#if NAV2017
                case "TestPermissions":
                    currentFunction.TestPermissions = values[0].ToNullableEnum<TestPermissions>();
                    break;
#endif

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
                case "HyperlinkHandler":
#if NAV2017
                case "SendNotificationHandler":
                case "RecallNotificationHandler":
#endif
                    currentFunction.TestFunctionType = name.ToNullableEnum<TestFunctionType>();
                    break;
#if NAV2015
                case "Upgrade":
                case "TableSyncSetup":
                case "CheckPrecondition":
#if NAV2016
                case "UpgradePerCompany":
                case "UpgradePerDatabase":
#endif
                    currentFunction.UpgradeFunctionType = name.ToNullableEnum<UpgradeFunctionType>();
                    break;
#endif
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Unknown function type {0}.", name));
            }
        }

        public override void OnVariable(int variableID, string variableName, VariableType variableType, string variableSubType, int? variableLength, string variableOptionString, string variableConstValue, bool variableTemporary, string variableDimensions, bool variableRunOnClient, bool variableWithEvents, string variableSecurityFiltering, bool variableInDataSet)
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
                    var binaryVariable = variables.Add(new BinaryVariable(variableID, variableName, variableLength));
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

#if NAV2017
                case VariableType.ClientType:
                    var clientTypeVariable = variables.Add(new ClientTypeVariable(variableID, variableName));
                    clientTypeVariable.Dimensions = variableDimensions;
                    break;
#endif

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

#if NAV2017
                case VariableType.DefaultLayout:
                    var defaultLayoutVariable = variables.Add(new DefaultLayoutVariable(variableID, variableName));
                    defaultLayoutVariable.Dimensions = variableDimensions;
                    break;
#endif

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

#if NAV2017
                case VariableType.Notification:
                    var notificationVariable = variables.Add(new NotificationVariable(variableID, variableName));
                    notificationVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.NotificationScope:
                    var notificationScopeVariable = variables.Add(new NotificationScopeVariable(variableID, variableName));
                    notificationScopeVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.ObjectType:
                    var objectTypeVariable = variables.Add(new ObjectTypeVariable(variableID, variableName));
                    objectTypeVariable.Dimensions = variableDimensions;
                    break;
#endif

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

#if NAV2017
                case VariableType.TestPermissions:
                    var testPermissionsVariable = variables.Add(new TestPermissionsVariable(variableID, variableName));
                    testPermissionsVariable.Dimensions = variableDimensions;
                    break;
#endif

                case VariableType.Text:
                    var textVariable = variables.Add(new TextVariable(variableID, variableName, variableLength));
                    textVariable.Dimensions = variableDimensions;
                    textVariable.IncludeInDataset = variableInDataSet;
                    break;

                case VariableType.TextConst:
                    var textConstant = variables.Add(new TextConstant(variableID, variableName));
                    textConstant.Values.SetMultiLanguageValue(variableConstValue ?? string.Empty);
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

        public override void OnCodeLine(string codeLine)
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
                        codeLines = currentCode.Documentation.CodeLines;
                    break;

                case SectionType.RdlData:
                    codeLines = currentRdlData.CodeLines;
                    break;
#if NAV2015
                case SectionType.WordLayout:
                    codeLines = currentWordLayout.CodeLines;
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

        public override void OnParameter(bool parameterVar, int parameterID, string parameterName, ParameterType parameterType, string parameterSubType, int? parameterLength, string parameterOptionString, bool parameterTemporary, string parameterDimensions, bool parameterRunOnClient, string parameterSecurityFiltering, bool parameterSuppressDispose)
        {
            Parameters parameters = null;

            if (currentFunction != null)
                parameters = currentFunction.Parameters;
            else
                parameters = currentEvent.Parameters;

            switch (parameterType)
            {
                case ParameterType.Action:
                    var actionParameter = parameters.Add(new ActionParameter(parameterName, parameterVar, parameterID));
                    actionParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.Automation:
                    var automationParameter = parameters.Add(new AutomationParameter(parameterName, parameterSubType, parameterVar, parameterID));
                    automationParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.BigInteger:
                    var bigIntegerParameter = parameters.Add(new BigIntegerParameter(parameterName, parameterVar, parameterID));
                    bigIntegerParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.BigText:
                    var bigTextParameter = parameters.Add(new BigTextParameter(parameterName, parameterVar, parameterID));
                    bigTextParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.Binary:
                    var binaryParameter = parameters.Add(new BinaryParameter(parameterName, parameterVar, parameterID, parameterLength.Value));
                    binaryParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.Boolean:
                    var booleanParameter = parameters.Add(new BooleanParameter(parameterName, parameterVar, parameterID));
                    booleanParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.Byte:
                    var byteParameter = parameters.Add(new ByteParameter(parameterName, parameterVar, parameterID));
                    byteParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.Char:
                    var charParameter = parameters.Add(new CharParameter(parameterName, parameterVar, parameterID));
                    charParameter.Dimensions = parameterDimensions;
                    break;

#if NAV2017
                case ParameterType.ClientType:
                    var clientTypeParameter = parameters.Add(new ClientTypeParameter(parameterName, parameterVar, parameterID));
                    clientTypeParameter.Dimensions = parameterDimensions;
                    break;
#endif

                case ParameterType.Code:
                    var codeParameter = parameters.Add(new CodeParameter(parameterName, parameterVar, parameterID, parameterLength));
                    codeParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.Codeunit:
                    var codeunitParameter = parameters.Add(new CodeunitParameter(parameterName, parameterSubType.ToInteger(), parameterVar, parameterID));
                    codeunitParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.Date:
                    var dateParameter = parameters.Add(new DateParameter(parameterName, parameterVar, parameterID));
                    dateParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.DateFormula:
                    var dateFormulaParameter = parameters.Add(new DateFormulaParameter(parameterName, parameterVar, parameterID));
                    dateFormulaParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.DateTime:
                    var dateTimeParameter = parameters.Add(new DateTimeParameter(parameterName, parameterVar, parameterID));
                    dateTimeParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.Decimal:
                    var decimalParameter = parameters.Add(new DecimalParameter(parameterName, parameterVar, parameterID));
                    decimalParameter.Dimensions = parameterDimensions;
                    break;

#if NAV2017
                case ParameterType.DefaultLayout:
                    var defaultLayoutParameter = parameters.Add(new DefaultLayoutParameter(parameterName, parameterVar, parameterID));
                    defaultLayoutParameter.Dimensions = parameterDimensions;
                    break;
#endif 

                case ParameterType.Dialog:
                    var dialogParameter = parameters.Add(new DialogParameter(parameterName, parameterVar, parameterID));
                    dialogParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.DotNet:
                    var dotnetParameter = parameters.Add(new DotNetParameter(parameterName, parameterSubType, parameterVar, parameterID));
                    dotnetParameter.Dimensions = parameterDimensions;
                    dotnetParameter.RunOnClient = parameterRunOnClient;
                    dotnetParameter.SuppressDispose = parameterSuppressDispose;
                    break;

                case ParameterType.Duration:
                    var durationParameter = parameters.Add(new DurationParameter(parameterName, parameterVar, parameterID));
                    durationParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.ExecutionMode:
                    var executionModeParameter = parameters.Add(new ExecutionModeParameter(parameterName, parameterVar, parameterID));
                    executionModeParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.FieldRef:
                    var fieldRefParameter = parameters.Add(new FieldRefParameter(parameterName, parameterVar, parameterID));
                    fieldRefParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.File:
                    var fileParameter = parameters.Add(new FileParameter(parameterName, parameterVar, parameterID));
                    fileParameter.Dimensions = parameterDimensions;
                    break;
#if NAV2016
                case ParameterType.FilterPageBuilder:
                    var filterPageBuilderParameter = parameters.Add(new FilterPageBuilderParameter(parameterName, parameterVar, parameterID));
                    filterPageBuilderParameter.Dimensions = parameterDimensions;
                    break;
#endif
                case ParameterType.GUID:
                    var guidParameter = parameters.Add(new GuidParameter(parameterName, parameterVar, parameterID));
                    guidParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.InStream:
                    var instreamParameter = parameters.Add(new InStreamParameter(parameterName, parameterVar, parameterID));
                    instreamParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.Integer:
                    var integerParameter = parameters.Add(new IntegerParameter(parameterName, parameterVar, parameterID));
                    integerParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.KeyRef:
                    var keyRefParameter = parameters.Add(new KeyRefParameter(parameterName, parameterVar, parameterID));
                    keyRefParameter.Dimensions = parameterDimensions;
                    break;

#if NAV2017
                case ParameterType.Notification:
                    var notificationParameter = parameters.Add(new NotificationParameter(parameterName, parameterVar, parameterID));
                    notificationParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.NotificationScope:
                    var notificationScopeParameter = parameters.Add(new NotificationScopeParameter(parameterName, parameterVar, parameterID));
                    notificationScopeParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.ObjectType:
                    var objectTypeParameter = parameters.Add(new ObjectTypeParameter(parameterName, parameterVar, parameterID));
                    objectTypeParameter.Dimensions = parameterDimensions;
                    break;
#endif

                case ParameterType.Ocx:
                    var ocxParameter = parameters.Add(new OcxParameter(parameterName, parameterSubType, parameterVar, parameterID));
                    ocxParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.Option:
                    var optionParameter = parameters.Add(new OptionParameter(parameterName, parameterVar, parameterID));
                    optionParameter.Dimensions = parameterDimensions;
                    optionParameter.OptionString = parameterOptionString;
                    break;

                case ParameterType.OutStream:
                    var outstreamParameter = parameters.Add(new OutStreamParameter(parameterName, parameterVar, parameterID));
                    outstreamParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.Page:
                    var pageParameter = parameters.Add(new PageParameter(parameterName, parameterSubType.ToInteger(), parameterVar, parameterID));
                    pageParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.Query:
                    var queryParameter = parameters.Add(new QueryParameter(parameterName, parameterSubType.ToInteger(), parameterVar, parameterID));
                    queryParameter.Dimensions = parameterDimensions;
                    queryParameter.SecurityFiltering = parameterSecurityFiltering.ToNullableEnum<QuerySecurityFiltering>();
                    break;

                case ParameterType.Record:
                    var recordParameter = parameters.Add(new RecordParameter(parameterName, parameterSubType.ToInteger(), parameterVar, parameterID));
                    recordParameter.Dimensions = parameterDimensions;
                    recordParameter.Temporary = parameterTemporary;
                    break;

                case ParameterType.RecordID:
                    var recordIDParameter = parameters.Add(new RecordIDParameter(parameterName, parameterVar, parameterID));
                    recordIDParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.RecordRef:
                    var recordRefParameter = parameters.Add(new RecordRefParameter(parameterName, parameterVar, parameterID));
                    recordRefParameter.Dimensions = parameterDimensions;
                    recordRefParameter.SecurityFiltering = parameterSecurityFiltering.ToNullableEnum<RecordSecurityFiltering>();
                    break;

                case ParameterType.Report:
                    var reportParameter = parameters.Add(new ReportParameter(parameterName, parameterSubType.ToInteger(), parameterVar, parameterID));
                    reportParameter.Dimensions = parameterDimensions;
                    break;
#if NAV2016
                case ParameterType.ReportFormat:
                    var reportFormatParameter = parameters.Add(new ReportFormatParameter(parameterName, parameterVar, parameterID));
                    reportFormatParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.TableConnectionType:
                    var tableConnectionTypeParameter = parameters.Add(new TableConnectionTypeParameter(parameterName, parameterVar, parameterID));
                    tableConnectionTypeParameter.Dimensions = parameterDimensions;
                    break;
#endif
                case ParameterType.TestPage:
                    var testPageParameter = parameters.Add(new TestPageParameter(parameterName, parameterSubType.ToInteger(), parameterVar, parameterID));
                    testPageParameter.Dimensions = parameterDimensions;
                    break;

#if NAV2017
                case ParameterType.TestPermissions:
                    var testPermissions = parameters.Add(new TestPermissionsParameter(parameterName, parameterVar, parameterID));
                    testPermissions.Dimensions = parameterDimensions;
                    break;
#endif

                case ParameterType.TestRequestPage:
                    var testRequestPageParameter = parameters.Add(new TestRequestPageParameter(parameterName, parameterSubType.ToInteger(), parameterVar, parameterID));
                    testRequestPageParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.Text:
                    var textParameter = parameters.Add(new TextParameter(parameterName, parameterVar, parameterID, parameterLength));
                    textParameter.Dimensions = parameterDimensions;
                    break;
#if NAV2016
                case ParameterType.TextEncoding:
                    var textEncodingParameter = parameters.Add(new TextEncodingParameter(parameterName, parameterVar, parameterID));
                    textEncodingParameter.Dimensions = parameterDimensions;
                    break;
#endif
                case ParameterType.Time:
                    var timeParameter = parameters.Add(new TimeParameter(parameterName, parameterVar, parameterID));
                    timeParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.TransactionType:
                    var transactionTypeParameter = parameters.Add(new TransactionTypeParameter(parameterName, parameterVar, parameterID));
                    transactionTypeParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.Variant:
                    var variantParameter = parameters.Add(new VariantParameter(parameterName, parameterVar, parameterID));
                    variantParameter.Dimensions = parameterDimensions;
                    break;

                case ParameterType.XmlPort:
                    var xmlPortParameter = parameters.Add(new XmlPortParameter(parameterName, parameterSubType.ToInteger(), parameterVar, parameterID));
                    xmlPortParameter.Dimensions = parameterDimensions;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("parameterType");
            }
        }

        public override void OnReturnValue(string returnValueName, FunctionReturnValueType? returnValueType, int? returnValueLength, string returnValueDimensions)
        {
            currentFunction.ReturnValue.Name = returnValueName;
            currentFunction.ReturnValue.Type = returnValueType;
            currentFunction.ReturnValue.DataLength = returnValueLength;
            currentFunction.ReturnValue.Dimensions = returnValueDimensions;
        }

        public override void OnBeginEvent(int sourceID, string sourceName, int eventID, string eventName)
        {
            currentEvent = currentCode.Events.Add(new Event(sourceID, sourceName, eventID, eventName));
        }

        public override void OnEndEvent()
        {
            currentEvent = null;
        }

        public override void OnBeginQueryElement(int elementID, int? elementIndentation, string elementName, QueryElementType elementType)
        {
            switch (elementType)
            {
                case QueryElementType.DataItem:
                    var newDataItemQueryElement = currentQueryElements.Add(new DataItemQueryElement(0, elementID, elementName, elementIndentation));
                    currentProperties.Push(newDataItemQueryElement.Properties);
                    break;

                case QueryElementType.Filter:
                    var newFilterQueryElement = currentQueryElements.Add(new FilterQueryElement(null, elementID, elementName, elementIndentation));
                    currentProperties.Push(newFilterQueryElement.Properties);
                    break;

                case QueryElementType.Column:
                    var newColumnQueryElement = currentQueryElements.Add(new ColumnQueryElement(null, elementID, elementName, elementIndentation));
                    currentProperties.Push(newColumnQueryElement.Properties);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("elementType");
            }
        }

        public override void OnEndQueryElement()
        {
            currentProperties.Pop();
        }

        public override void OnBeginPageControl(int controlID, int? controlIndentation, PageControlType controlType)
        {
            switch (controlType)
            {
                case PageControlType.Container:
                    var newContainerPageControl = currentPageControls.Add(new PageControlContainer(controlID, controlIndentation));
                    currentProperties.Push(newContainerPageControl.Properties);
                    break;

                case PageControlType.Group:
                    var newGroupPageControl = currentPageControls.Add(new PageControlGroup(controlID, controlIndentation));
                    currentPageActionList = newGroupPageControl.Properties.ActionList;
                    currentProperties.Push(newGroupPageControl.Properties);
                    break;

                case PageControlType.Field:
                    var newFieldPageControl = currentPageControls.Add(new PageControl(null, controlID, controlIndentation));
                    currentProperties.Push(newFieldPageControl.Properties);
                    break;

                case PageControlType.Part:
                    var newPartPageControl = currentPageControls.Add(new PageControlPart(controlID, controlIndentation));
                    currentProperties.Push(newPartPageControl.Properties);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("controlType");
            }
        }

        public override void OnEndPageControl()
        {
            currentPageActionList = null;
            currentProperties.Pop();
        }

        public override void OnBeginPageAction(int actionID, int? actionIndentation, PageActionType actionType)
        {
            switch (actionType)
            {
                case PageActionType.ActionContainer:
                    var newPageActionContainer = currentPageActionList.Add(new PageActionContainer(actionIndentation, actionID));
                    currentProperties.Push(newPageActionContainer.Properties);
                    break;

                case PageActionType.ActionGroup:
                    var newPageActionGroup = currentPageActionList.Add(new PageActionGroup(actionID, actionIndentation));
                    currentProperties.Push(newPageActionGroup.Properties);
                    break;

                case PageActionType.Action:
                    var newPageAction = currentPageActionList.Add(new PageAction(actionID, actionIndentation));
                    currentProperties.Push(newPageAction.Properties);
                    break;

                case PageActionType.Separator:
                    var newPageActionSeparator = currentPageActionList.Add(new PageActionSeparator(actionID, actionIndentation));
                    currentProperties.Push(newPageActionSeparator.Properties);
                    break;
            }
        }

        public override void OnEndPageAction()
        {
            currentProperties.Pop();
        }

        public override void OnBeginXmlPortElement(Guid elementID, int? elementIndentation, string elementName, UncommonSense.CBreeze.Common.XmlPortNodeType elementNodeType, XmlPortSourceType elementSourceType)
        {
            switch (elementSourceType)
            {
                case XmlPortSourceType.Text:
                    switch (elementNodeType)
                    {
                        case UncommonSense.CBreeze.Common.XmlPortNodeType.Element:
                            var newTextElementNode = currentXmlPortNodes.Add(new XmlPortTextElement(elementName, elementIndentation, elementID));
                            currentProperties.Push(newTextElementNode.Properties);
                            break;

                        case UncommonSense.CBreeze.Common.XmlPortNodeType.Attribute:
                            var newTextAttributeNode = currentXmlPortNodes.Add(new XmlPortTextAttribute(elementName, elementIndentation, elementID));
                            currentProperties.Push(newTextAttributeNode.Properties);
                            break;
                    }
                    break;

                case XmlPortSourceType.Table:
                    switch (elementNodeType)
                    {
                        case UncommonSense.CBreeze.Common.XmlPortNodeType.Element:
                            var newTableElementNode = currentXmlPortNodes.Add(new XmlPortTableElement(elementName, elementIndentation, elementID));
                            currentProperties.Push(newTableElementNode.Properties);
                            break;

                        case UncommonSense.CBreeze.Common.XmlPortNodeType.Attribute:
                            var newTableAttributeNode = currentXmlPortNodes.Add(new XmlPortTableAttribute(elementName, elementIndentation, elementID));
                            currentProperties.Push(newTableAttributeNode.Properties);
                            break;
                    }
                    break;

                case XmlPortSourceType.Field:
                    switch (elementNodeType)
                    {
                        case UncommonSense.CBreeze.Common.XmlPortNodeType.Element:
                            var newFieldElementNode = currentXmlPortNodes.Add(new XmlPortFieldElement(elementName, elementIndentation, elementID));
                            currentProperties.Push(newFieldElementNode.Properties);
                            break;

                        case UncommonSense.CBreeze.Common.XmlPortNodeType.Attribute:
                            var newFieldAttributeNode = currentXmlPortNodes.Add(new XmlPortFieldAttribute(elementName, elementIndentation, elementID));
                            currentProperties.Push(newFieldAttributeNode.Properties);
                            break;
                    }
                    break;
            }
        }

        public override void OnEndXmlPortElement()
        {
            currentProperties.Pop();
        }

        public override void OnBeginReportElement(int elementID, int? elementIndentation, string elementName, ReportElementType elementType)
        {
            switch (elementType)
            {
                case ReportElementType.DataItem:
                    var newDataItemElement = new DataItemReportElement(null, elementID, elementIndentation)
                    {
                        Name = elementName
                    };
                    currentReportElements.Add(newDataItemElement);
                    currentProperties.Push(newDataItemElement.Properties);
                    break;

                case ReportElementType.Column:
                    var newColumnElement = new ColumnReportElement(elementName, null, elementID, elementIndentation);
                    currentReportElements.Add(newColumnElement);
                    currentProperties.Push(newColumnElement.Properties);
                    break;
            }
        }

        public override void OnEndReportElement()
        {
            currentProperties.Pop();
        }

        public override void OnBeginRequestPage()
        {
            currentProperties.Push(currentRequestPage.Properties);
            currentPageControls = currentRequestPage.Controls;
            currentPageActionList = currentRequestPage.Actions;
        }

        public override void OnEndRequestPage()
        {
            currentProperties.Pop();
            currentPageControls = null;
            currentPageActionList = null;
        }

        public override void OnBeginReportLabel(int labelID, string labelName)
        {
            var newReportLabel = currentReportLabels.Add(new ReportLabel(labelID, labelName));
            currentProperties.Push(newReportLabel.Properties);
        }

        public override void OnEndReportLabel()
        {
            currentProperties.Pop();
        }

        public override void OnBeginMenuSuiteNode(MenuSuiteNodeType nodeType, Guid nodeID)
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

        public override void OnEndMenuSuiteNode()
        {
            currentProperties.Pop();
        }
    }
}