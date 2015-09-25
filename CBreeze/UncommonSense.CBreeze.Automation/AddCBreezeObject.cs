using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeObject")]
    public class AddCBreezeObject : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Application[] Application
        {
            get;
            set;
        }

        // FIXME: DataCaptionFields etc. is niet mandatory!!!

        [Parameter(Mandatory = true, ParameterSetName = "TableByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "TableByID")]
        public SwitchParameter Table
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public SwitchParameter Page
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ReportByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "ReportByID")]
        public SwitchParameter Report
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "CodeunitByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "CodeunitByID")]
        public SwitchParameter Codeunit
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "QueryByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "QueryByID")]
        public SwitchParameter Query
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public SwitchParameter XmlPort
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "MenuSuiteByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "MenuSuiteByID")]
        public SwitchParameter MenuSuite
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "TableByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "ReportByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "CodeunitByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "QueryByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "MenuSuiteByRange")]
        public IEnumerable<int> Range
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "TableByID")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        [Parameter(Mandatory = true, ParameterSetName = "ReportByID")]
        [Parameter(Mandatory = true, ParameterSetName = "CodeunitByID")]
        [Parameter(Mandatory = true, ParameterSetName = "QueryByID")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        [Parameter(Mandatory = true, ParameterSetName = "MenuSuiteByID")]
        [ValidateRange(1, int.MaxValue)]
        public int ID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        [ValidateLength(1, 30)]
        public string Name
        {
            get;
            set;
        }

        [Parameter()]
        public DateTime? DateTime
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter Modified
        {
            get;
            set;
        }

        [Parameter()]
        public string VersionList
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter AutoCaption
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter PassThru
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "TableByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "TableByID")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public string[] DataCaptionFields
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "TableByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "TableByID")]
        public bool? DataPerCompany
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "TableByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "TableByID")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        [Parameter(Mandatory = true, ParameterSetName = "ReportByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "ReportByID")]
        [Parameter(Mandatory = true, ParameterSetName = "QueryByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "QueryByID")]
        public string Description
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "TableByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "TableByID")]
        public int? DrillDownPageID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "TableByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "TableByID")]
        public bool? LinkedInTransaction
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "TableByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "TableByID")]
        public bool? LinkedObject
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "TableByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "TableByID")]
        public int? LookupPageID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "TableByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "TableByID")]
        public bool? PasteIsValid
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public bool? AutoSplitKey
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public string CardPageID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public string DataCaptionExpr
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public bool? DelayedInsert
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public bool? DeleteAllowed
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public bool? Editable
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public bool? InsertAllowed
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public bool? LinksAllowed
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public bool? ModifyAllowed
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public bool? MultipleNewLines
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public PageType? PageType
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public bool? PopulateAllFields
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public bool? RefreshOnActivate
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public bool? SaveValues
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public bool? ShowFilter
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public int? SourceTable
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "PageByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "PageByID")]
        public bool? SourceTableTemporary
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ReportByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "ReportByID")]
        public bool? EnableExternalAssemblies
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ReportByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "ReportByID")]
        public bool? EnableExternalImages
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ReportByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "ReportByID")]
        public bool? EnableHyperlinks
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ReportByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "ReportByID")]
        public PaperSource? PaperSourceDefaultPage
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ReportByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "ReportByID")]
        public PaperSource? PaperSourceFirstPage
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ReportByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "ReportByID")]
        public PaperSource? PaperSourceLastPage
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ReportByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "ReportByID")]
        public bool? ProcessingOnly
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ReportByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "ReportByID")]
        public bool? ShowPrintStatus
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ReportByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "ReportByID")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public TransactionType? TransactionType
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ReportByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "ReportByID")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public bool? UseRequestPage
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ReportByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "ReportByID")]
        public bool? UseSystemPrinter
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "CodeunitByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "CodeunitByID")]
        public bool? CFrontMayUsePermissions
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "CodeunitByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "CodeunitByID")]
        public bool? SingleInstance
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "CodeunitByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "CodeunitByID")]
        public CodeunitSubType? SubType
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "CodeunitByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "CodeunitByID")]
        public int? TableNo
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "CodeunitByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "CodeunitByID")]
        public TestIsolation? TestIsolation
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "QueryByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "QueryByID")]
        public ReadState? ReadState
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "QueryByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "QueryByID")]
        public int? TopNumberOfRows
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public bool? DefaultFieldsValidation
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public string DefaultNamespace
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public Direction? Direction
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public XmlPortEncoding? Encoding
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public string FieldDelimiter
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public string FieldSeparator
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public string FileName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public XmlPortFormat? Format
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public FormatEvaluate? FormatEvaluate
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public bool? InlineSchema
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public bool? PreserveWhitespace
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public string RecordSeparator
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public string TableSeparator
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public TextEncoding? TextEncoding
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public bool? UseDefaultNamespace
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public bool? UseLax
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByRange")]
        [Parameter(Mandatory = true, ParameterSetName = "XmlPortByID")]
        public XmlVersionNo? XmlVersionNo
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            foreach (var application in Application)
            {
                switch (GetObjectType())
                {
                    case ObjectType.Table:
                        var table = application.Tables.Add(new Table(GetObjectID(application), Name));

                        table.ObjectProperties.DateTime = DateTime;
                        table.ObjectProperties.Modified = Modified;
                        table.ObjectProperties.VersionList = VersionList;

                        table.Properties.DataCaptionFields.AddRange(DataCaptionFields ?? new string[] { });
                        table.Properties.DataPerCompany = DataPerCompany;
                        table.Properties.Description = Description;
                        table.Properties.DrillDownPageID = DrillDownPageID;
                        table.Properties.LinkedInTransaction = LinkedInTransaction;
                        table.Properties.LookupPageID = LookupPageID;
                        table.Properties.LinkedObject = LinkedObject;
                        table.Properties.PasteIsValid = PasteIsValid;

                        if (AutoCaption)
                            table.AutoCaption();

                        if (PassThru)
                            WriteObject(table);

                        break;

                    case ObjectType.Page:
                        var page = application.Pages.Add(new Page(GetObjectID(application), Name));

                        page.ObjectProperties.DateTime = DateTime;
                        page.ObjectProperties.Modified = Modified;
                        page.ObjectProperties.VersionList = VersionList;

                        page.Properties.AutoSplitKey = AutoSplitKey;
                        page.Properties.CardPageID = CardPageID;
                        page.Properties.DataCaptionExpr = DataCaptionExpr;
                        page.Properties.DataCaptionFields.AddRange(DataCaptionFields);
                        page.Properties.DelayedInsert = DelayedInsert;
                        page.Properties.DeleteAllowed = DeleteAllowed;
                        page.Properties.Description = Description;
                        page.Properties.Editable = Editable;
                        page.Properties.InsertAllowed = InsertAllowed;
                        page.Properties.LinksAllowed = LinksAllowed;
                        page.Properties.ModifyAllowed = ModifyAllowed;
                        page.Properties.MultipleNewLines = MultipleNewLines;
                        page.Properties.PageType = PageType;
                        page.Properties.PopulateAllFields = PopulateAllFields;
                        page.Properties.RefreshOnActivate = RefreshOnActivate;
                        page.Properties.SaveValues = SaveValues;
                        page.Properties.ShowFilter = ShowFilter;
                        page.Properties.SourceTable = SourceTable;
                        page.Properties.SourceTableTemporary = SourceTableTemporary;

                        if (AutoCaption)
                            page.AutoCaption();

                        if (PassThru)
                            WriteObject(page);

                        break;

                    case ObjectType.Report:
                        var report = application.Reports.Add(new Report(GetObjectID(application), Name));

                        report.ObjectProperties.DateTime = DateTime;
                        report.ObjectProperties.Modified = Modified;
                        report.ObjectProperties.VersionList = VersionList;

                        report.Properties.Description = Description;
                        report.Properties.EnableExternalAssemblies = EnableExternalAssemblies;
                        report.Properties.EnableExternalImages = EnableExternalImages;
                        report.Properties.EnableHyperlinks = EnableHyperlinks;
                        report.Properties.PaperSourceDefaultPage = PaperSourceDefaultPage;
                        report.Properties.PaperSourceFirstPage = PaperSourceFirstPage;
                        report.Properties.PaperSourceLastPage = PaperSourceLastPage;
                        report.Properties.ProcessingOnly = ProcessingOnly;
                        report.Properties.ShowPrintStatus = ShowPrintStatus;
                        report.Properties.TransactionType = TransactionType;
                        report.Properties.UseRequestPage = UseRequestPage;
                        report.Properties.UseSystemPrinter = UseSystemPrinter;

                        if (AutoCaption)
                            report.AutoCaption();

                        if (PassThru)
                            WriteObject(report);

                        break;

                    case ObjectType.Codeunit:
                        var codeunit = application.Codeunits.Add(new Codeunit(GetObjectID(application), Name));

                        codeunit.ObjectProperties.DateTime = DateTime;
                        codeunit.ObjectProperties.Modified = Modified;
                        codeunit.ObjectProperties.VersionList = VersionList;

                        codeunit.Properties.CFRONTMayUsePermissions = CFrontMayUsePermissions;
                        codeunit.Properties.SingleInstance = SingleInstance;
                        codeunit.Properties.Subtype = SubType;
                        codeunit.Properties.TableNo = TableNo;
                        codeunit.Properties.TestIsolation = TestIsolation;

                        if (PassThru)
                            WriteObject(codeunit);

                        break;

                    case ObjectType.Query:
                        var query = application.Queries.Add(new Query(GetObjectID(application), Name));

                        query.ObjectProperties.DateTime = DateTime;
                        query.ObjectProperties.Modified = Modified;
                        query.ObjectProperties.VersionList = VersionList;

                        query.Properties.Description = Description;
                        query.Properties.ReadState = ReadState;
                        query.Properties.TopNumberOfRows = TopNumberOfRows;

                        if (AutoCaption)
                            query.AutoCaption();

                        if (PassThru)
                            WriteObject(query);

                        break;

                    case ObjectType.XmlPort:
                        var xmlport = application.XmlPorts.Add(new XmlPort(GetObjectID(application), Name));

                        xmlport.ObjectProperties.DateTime = DateTime;
                        xmlport.ObjectProperties.Modified = Modified;
                        xmlport.ObjectProperties.VersionList = VersionList;

                        xmlport.Properties.DefaultFieldsValidation = DefaultFieldsValidation;
                        xmlport.Properties.DefaultNamespace = DefaultNamespace;
                        xmlport.Properties.Direction = Direction;
                        xmlport.Properties.Encoding = Encoding;
                        xmlport.Properties.FieldDelimiter = FieldDelimiter;
                        xmlport.Properties.FieldSeparator = FieldSeparator;
                        xmlport.Properties.FileName = FileName;
                        xmlport.Properties.Format = Format;
                        xmlport.Properties.FormatEvaluate = FormatEvaluate;
                        xmlport.Properties.InlineSchema = InlineSchema;
                        xmlport.Properties.PreserveWhiteSpace = PreserveWhitespace;
                        xmlport.Properties.RecordSeparator = RecordSeparator;
                        xmlport.Properties.TableSeparator = TableSeparator;
                        xmlport.Properties.TextEncoding = TextEncoding;
                        xmlport.Properties.TransactionType = TransactionType;
                        xmlport.Properties.UseDefaultNamespace = UseDefaultNamespace;
                        xmlport.Properties.UseLax = UseLax;
                        xmlport.Properties.UseRequestPage = UseRequestPage;
                        xmlport.Properties.XmlVersionNo = XmlVersionNo;

                        if (AutoCaption)
                            xmlport.AutoCaption();

                        if (PassThru)
                            WriteObject(xmlport);

                        break;

                    case ObjectType.MenuSuite:
                        var menuSuite = application.MenuSuites.Add(new MenuSuite(GetObjectID(application), Name));

                        menuSuite.ObjectProperties.DateTime = DateTime;
                        menuSuite.ObjectProperties.Modified = Modified;
                        menuSuite.ObjectProperties.VersionList = VersionList;

                        if (PassThru)
                            WriteObject(menuSuite);

                        break;
                }
            }
        }

        protected ObjectType GetObjectType()
        {
            if (Table)
                return ObjectType.Table;
            if (Page)
                return ObjectType.Page;
            if (Report)
                return ObjectType.Report;
            if (Codeunit)
                return ObjectType.Codeunit;
            if (Query)
                return ObjectType.Query;
            if (XmlPort)
                return ObjectType.XmlPort;
            if (MenuSuite)
                return ObjectType.MenuSuite;

            throw new ArgumentOutOfRangeException("Unknown object type.");
        }

        protected int GetObjectID(Application application)
        {
            if (ID != 0)
                return ID;

            return Range.Except(GetExistingObjectIDs(application)).First();
        }

        protected IEnumerable<int> GetExistingObjectIDs(Application application)
        {
            switch (GetObjectType())
            {
                case ObjectType.Table:
                    return application.Tables.Select(t => t.ID);
                case ObjectType.Page:
                    return application.Pages.Select(p => p.ID);
                case ObjectType.Report:
                    return application.Reports.Select(r => r.ID);
                case ObjectType.Codeunit:
                    return application.Codeunits.Select(c => c.ID);
                case ObjectType.Query:
                    return application.Queries.Select(q => q.ID);
                case ObjectType.XmlPort:
                    return application.XmlPorts.Select(x => x.ID);
                case ObjectType.MenuSuite:
                    return application.MenuSuites.Select(m => m.ID);
                default:
                    throw new ArgumentOutOfRangeException("Unknown object type.");
            }
        }
    }
}
