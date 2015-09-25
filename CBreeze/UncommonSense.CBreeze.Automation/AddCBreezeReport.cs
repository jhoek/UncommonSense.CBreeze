using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeReport")]
    public class AddCBreezeReport : AddCBreezeObject
    {
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
        public PaperSource PaperSourceDefaultPage
        {
            get;
            set;
        }

        [Parameter()]
        public PaperSource PaperSourceFirstPage
        {
            get;
            set;
        }

        [Parameter()]
        public PaperSource PaperSourceLastPage
        {
            get;
            set;
        }

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
        public TransactionType TransactionType
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

        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                var report = Application.Reports.Add(new Report(GetID(), Name));

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

                yield return report;
            }
        }

        protected override IEnumerable<int> GetExistingIDs()
        {
            return Application.Reports.Select(r => r.ID);
        }
    }
}
