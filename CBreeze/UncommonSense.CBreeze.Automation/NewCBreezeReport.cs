using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeReport", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(Report))]
    [Alias("Report")]
    public class NewCBreezeReport : NewCBreezeObject<Report>
    {
#if NAV2015

        [Parameter()]
        public DefaultLayout? DefaultLayout
        {
            get;
            set;
        }

#endif

        [Parameter()]
        public string Description
        {
            get;
            set;
        }

        [Parameter()]
        public bool? EnableExternalAssemblies
        {
            get;
            set;
        }

        [Parameter()]
        public bool? EnableExternalImages
        {
            get;
            set;
        }

        [Parameter()]
        public bool? EnableHyperlinks
        {
            get;
            set;
        }

        [Parameter()]
        public PaperSource? PaperSourceDefaultPage
        {
            get;
            set;
        }

        [Parameter()]
        public PaperSource? PaperSourceFirstPage
        {
            get;
            set;
        }

        [Parameter()]
        public PaperSource? PaperSourceLastPage
        {
            get;
            set;
        }

        [Parameter()]
        public Permission[] Permissions { get; set; }

#if NAV2015

        [Parameter()]
        public PreviewMode? PreviewMode
        {
            get;
            set;
        }

#endif

        [Parameter()]
        public bool? ProcessingOnly
        {
            get;
            set;
        }

        [Parameter()]
        public bool? ShowPrintStatus
        {
            get;
            set;
        }

        [Parameter()]
        public TransactionType? TransactionType
        {
            get;
            set;
        }

        [Parameter()]
        public bool? UseRequestPage
        {
            get;
            set;
        }

        [Parameter()]
        public bool? UseSystemPrinter
        {
            get;
            set;
        }

#if NAV2015

        [Parameter()]
        public string WordMergeDataItem
        {
            get;
            set;
        }

#endif

        protected override void AddItemToInputObject(Report item, Application inputObject)
        {
            inputObject.Reports.Add(item);
        }

        protected override IEnumerable<Report> CreateItems()
        {
            var report = new Report(ID, Name);
            SetObjectProperties(report);

#if NAV2015
            report.Properties.DefaultLayout = DefaultLayout;
#endif
            report.Properties.Description = Description;
            report.Properties.EnableExternalAssemblies = EnableExternalAssemblies;
            report.Properties.EnableExternalImages = EnableExternalImages;
            report.Properties.EnableHyperlinks = EnableHyperlinks;
            report.Properties.PaperSourceDefaultPage = PaperSourceDefaultPage;
            report.Properties.PaperSourceFirstPage = PaperSourceFirstPage;
            report.Properties.PaperSourceLastPage = PaperSourceLastPage;
            report.Properties.Permissions.Set(Permissions);
#if NAV2015
            report.Properties.PreviewMode = PreviewMode;
#endif
            report.Properties.ProcessingOnly = ProcessingOnly;
            report.Properties.ShowPrintStatus = ShowPrintStatus;
            report.Properties.TransactionType = TransactionType;
            report.Properties.UseRequestPage = UseRequestPage;
            report.Properties.UseSystemPrinter = UseSystemPrinter;
#if NAV2015
            report.Properties.WordMergeDataItem = WordMergeDataItem;
#endif

            if (AutoCaption)
                report.AutoCaption();

            if (SubObjects != null)
            {
                // FIXME: How to define the request page?

                var subObjects = SubObjects.Invoke().Select(o => o.BaseObject);
                report.Code.Documentation.CodeLines.AddRange(subObjects.OfType<string>());
                report.Labels.AddRange(subObjects.OfType<ReportLabel>());
                report.Elements.AddRange(subObjects.OfType<ReportElement>());
                report.Code.Functions.AddRange(subObjects.OfType<Function>());
                report.Code.Variables.AddRange(subObjects.OfType<Variable>());
                report.Code.Events.AddRange(subObjects.OfType<Event>());
            }

            yield return report;
        }
    }
}