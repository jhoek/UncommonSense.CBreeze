using System;
using System.Text.RegularExpressions;

namespace UncommonSense.CBreeze.Parse
{
    public static class Patterns
    {
        // Object
        public static readonly Regex ObjectSignature = new Regex(@"^OBJECT\s(\w+)\s(\d+)\s(.*)$", RegexOptions.Compiled);
        public static readonly Regex BeginObject = new Regex(@"^{$", RegexOptions.Compiled);
        public static readonly Regex EndObject = new Regex(@"^}$", RegexOptions.Compiled);
        // Section
        public static readonly Regex SectionSignature = new Regex(@"^([A-Z-]+)$", RegexOptions.Compiled);
        public static readonly Regex BeginSection = new Regex(@"^{$", RegexOptions.Compiled);
        public static readonly Regex EndSection = new Regex(@"^}$", RegexOptions.Compiled);
        // RdlData
        public static readonly Regex RdlDataSectionSignature = new Regex(@"^  RDLDATA$", RegexOptions.Compiled);
        public static readonly Regex BeginRdlDataSection = new Regex(@"^  {$", RegexOptions.Compiled);
        public static readonly Regex EndRdlDataSection = new Regex(@"^  }$", RegexOptions.Compiled);
        // WordLayout
        public static readonly Regex EndWordLayoutSection = new Regex(@"^END_OF_WORDLAYOUT$", RegexOptions.Compiled);
        // Properties
        public static readonly Regex ObjectPropertySignature = new Regex(@"^([^=]+)=(.*);$", RegexOptions.Compiled);
        public static readonly Regex PropertySignature = new Regex(@"^(\w[^=]+)=(.*)$", RegexOptions.Compiled);
        public static readonly Regex TriggerSignature = new Regex(@"^((Import::|Export::)?On[^=]+)=(.*)$", RegexOptions.Compiled);
        public static readonly Regex DecimalPlaces = new Regex(@"^(\d*):(\d*)$", RegexOptions.Compiled);
        public static readonly Regex AccessByPermission = new Regex(@"^(TableData|Table|Report|Codeunit|XmlPort|Page|Query|System)\s(\d+)=([RIMDX]*)$", RegexOptions.Compiled);

        // Code
        public static readonly Regex Variables = new Regex(@"^VAR$", RegexOptions.Compiled);
        public static readonly Regex Variable = new Regex(@"^\s*([^@]+)@(\d+)\s:\s(.*);$", RegexOptions.Compiled);
        public static readonly Regex MultiLineTextConst = new Regex(@"^\s*([^@]+)@(\d+)\s:\sTextConst$", RegexOptions.Compiled);
        public static readonly Regex MultiLineTextConstValue = new Regex(@"^\s*'(.{3})=(.*)'([,;])$", RegexOptions.Compiled);
        public static readonly Regex VariableRunOnClient = new Regex(@"^(.*)\sRUNONCLIENT$", RegexOptions.Compiled);
        public static readonly Regex VariableWithEvents = new Regex(@"^(.*)\sWITHEVENTS$", RegexOptions.Compiled);
        public static readonly Regex VariableInDataSet = new Regex(@"^(.*)\sINDATASET$", RegexOptions.Compiled);
        public static readonly Regex VariableSecurityFiltering = new Regex(@"^(.*)\sSECURITYFILTERING\((.*)\)$", RegexOptions.Compiled);
        public static readonly Regex VariableDimensions = new Regex(@"^ARRAY\s\[(\d+)(,\d+)*\] OF ", RegexOptions.Compiled);
        public static readonly Regex VariableWithSubType = new Regex(@"^(\w+)\s+""?([^""]+)""?$", RegexOptions.Compiled);
        public static readonly Regex VariableWithLength = new Regex(@"^(\w+)\[(\d+)\]$", RegexOptions.Compiled);
        public static readonly Regex ParameterSuppressDispose = new Regex(@"^(.*)\sSUPPRESSDISPOSE$", RegexOptions.Compiled);
        public static readonly Regex TextConst = new Regex(@"^TextConst\s+'(.*)'$", RegexOptions.Compiled);
#if NAV2016
        public static readonly Regex TryFunctionAttribute = new Regex(@"^\[TryFunction\]$", RegexOptions.Compiled);
        public static readonly Regex BusinessEventPublisherAttribute = new Regex(@"^\[Business(\((FALSE|TRUE)\))?\]$", RegexOptions.Compiled);
        public static readonly Regex IntegrationEventPublisherAttribute = new Regex(@"^\[Integration(\((FALSE|TRUE|DEFAULT)(,(FALSE|TRUE|DEFAULT))?\))?\]$", RegexOptions.Compiled);
        public static readonly Regex EventSubscriberAttribute = new Regex(@"^\[EventSubscriber\((?<ObjectType>\w+),(?<ObjectID>\d+),(?<Function>\w+)(,(?<Element>(""[^""]*"")|([^""]\w+)))?(,(?<OnMissingLicense>Skip|Error|DEFAULT))?(,(?<OnMissingPermission>Skip|Error))?\)\]$", RegexOptions.Compiled);
#endif
#if NAV2017 
        public static readonly Regex FunctionTypeAttribute = new Regex(@"^\[(Normal|Test|MessageHandler|ConfirmHandler|StrMenuHandler|PageHandler|ModalPageHandler|ReportHandler|RequestPageHandler|FilterPageHandler|HyperlinkHandler|SendNotificationHandler|RecallNotificationHandler|UpgradePerDatabase|TableSyncSetup|CheckPrecondition|UpgradePerCompany)\]$", RegexOptions.Compiled);
#elif NAV2016
        public static readonly Regex FunctionTypeAttribute = new Regex(@"^\[(Normal|Test|MessageHandler|ConfirmHandler|StrMenuHandler|PageHandler|ModalPageHandler|ReportHandler|RequestPageHandler|FilterPageHandler|HyperlinkHandler|UpgradePerDatabase|TableSyncSetup|CheckPrecondition|UpgradePerCompany)\]$", RegexOptions.Compiled);
#elif NAV2015
        public static readonly Regex FunctionTypeAttribute = new Regex(@"^\[(Normal|Test|MessageHandler|ConfirmHandler|StrMenuHandler|PageHandler|ModalPageHandler|ReportHandler|RequestPageHandler|Upgrade|TableSyncSetup|CheckPrecondition)\]$", RegexOptions.Compiled);
#else
        public static readonly Regex FunctionTypeAttribute = new Regex(@"^\[(Normal|Test|MessageHandler|ConfirmHandler|StrMenuHandler|PageHandler|ModalPageHandler|ReportHandler|RequestPageHandler)\]$", RegexOptions.Compiled);
#endif
        public static readonly Regex HandlerFunctionsAttribute = new Regex(@"^\[HandlerFunctions\(([^)]*)\)]$", RegexOptions.Compiled);
        public static readonly Regex TransactionModelAttribute = new Regex(@"^\[TransactionModel\(([^)]*)\)]$", RegexOptions.Compiled);
        public static readonly Regex TestPermissionsAttribute = new Regex(@"^\[TestPermissions\(([^)]*)\)\]$", RegexOptions.Compiled);
        public static readonly Regex ProcedureAttribute = new Regex(@"^\[([^]]+)\]$", RegexOptions.Compiled);
        public static readonly Regex ProcedureSignature = new Regex(@"^\s*(LOCAL\s)?PROCEDURE\s([^@]+)@(\d+)", RegexOptions.Compiled);
        public static readonly Regex ProcedureParameters = new Regex(@"^\((.*)\)", RegexOptions.Compiled);
        public static readonly Regex ProcedureParameter = new Regex(@"^(VAR\s)?([^@]+)@(\d+)\s:\s(.*)$", RegexOptions.Compiled);
        public static readonly Regex ProcedureNoReturnValue = new Regex(@"^;$", RegexOptions.Compiled);
        public static readonly Regex ProcedureReturnValue = new Regex(@"^\s(\S+\s)?:\s(.*);$", RegexOptions.Compiled);
        public static readonly Regex EventSignature = new Regex(@"^EVENT\s([^@]+)@(-?\d+)::([^@]+)@(-?\d+)", RegexOptions.Compiled);
        public static readonly Regex BeginCodeBlock = new Regex(@"^BEGIN$", RegexOptions.Compiled);
        public static readonly Regex EndCodeBlock = new Regex(@"^END;$", RegexOptions.Compiled);
        public static readonly Regex BeginDocumentation = new Regex(@"^BEGIN$", RegexOptions.Compiled);
        public static readonly Regex EndDocumentation = new Regex(@"^END.$", RegexOptions.Compiled);
        // Field
        public static readonly Regex TableField = new Regex(@"^{\s*(\d+)\s*;([^;]*);([^;]+);([^;}]+)([;}])", RegexOptions.Compiled);
        public static readonly Regex EndTableField = new Regex(@"\s}$", RegexOptions.Compiled);
        // Key
        public static readonly Regex TableKey = new Regex(@"^{([^;]*);([^;]*)([;}])", RegexOptions.Compiled);
        // FieldGroup
        //                                                     { 1   ;DropDown            ;Code,Description,Due Date Calculation   ;CaptionML=[ENU=foo;
        public static readonly Regex FieldGroup = new Regex(@"^{([^;]+);([^;]+);([^;}]+)([;}])", RegexOptions.Compiled);
        public static readonly Regex EndFieldGroup = new Regex(@"\s}$", RegexOptions.Compiled);
        // Control
        public static readonly Regex PageControl = new Regex(@"^{\s*(\d+)\s*;([^;]*);([^;]*)([;}])$", RegexOptions.Compiled);
        public static readonly Regex EndPageControl = new Regex(@"\s}$", RegexOptions.Compiled);
        // Action
        public static readonly Regex PageAction = new Regex(@"^{\s*(\d+)\s*;([^;]*);([^;]*)([;}])$", RegexOptions.Compiled);
        public static readonly Regex EndPageAction = new Regex(@"\s}$", RegexOptions.Compiled);
        // QueryElement
        public static readonly Regex QueryElement = new Regex(@"^{\s*(\d+)\s*;([^;]*);([^;]+);([^;]+);$", RegexOptions.Compiled);
        public static readonly Regex EndQueryElement = new Regex(@"\s}$", RegexOptions.Compiled);
        // XmlPortElement
        public static readonly Regex XmlPortElement = new Regex(@"^{\s\[([^\]]+)\];([^;]*);([^;]*);([^;]*);([^;]*)([;}])$", RegexOptions.Compiled);
        public static readonly Regex EndXmlPortElement = new Regex(@"\s}$", RegexOptions.Compiled);
        // ReportElement
        public static readonly Regex ReportElement = new Regex(@"^{([^;]+);([^;]*);([^;]+);([^;}]+)([;}])$", RegexOptions.Compiled);
        public static readonly Regex EndReportElement = new Regex(@"\s}$", RegexOptions.Compiled);
        public static readonly Regex EndRdlData = new Regex("^    END_OF_RDLDATA$", RegexOptions.Compiled);
        /*     { 2   ;PostingDateCaption  ;CaptionML=[ENU=Posting Date;
                                           NLD=Boekingsdatum] }*/
        public static readonly Regex ReportLabel = new Regex(@"^{([^;]+);([^;]+)([;}])", RegexOptions.Compiled);
        public static readonly Regex EndReportLabel = new Regex(@"\s}$", RegexOptions.Compiled);
        // Menu
        public static readonly Regex MenuSuiteNode = new Regex(@"^{([^;]+);\[([^\]]+)\]\s([;}])", RegexOptions.Compiled);
        public static readonly Regex EndMenuSuiteNode = new Regex(@"\s}$", RegexOptions.Compiled);
        // Misc
        public static readonly Regex BlankLine = new Regex(@"^$", RegexOptions.Compiled);
        public static readonly Regex Whitespace = new Regex(@"^\s*", RegexOptions.Compiled);
        public static readonly Regex Any = new Regex(@"^(.*)$", RegexOptions.Compiled);
    }
}

