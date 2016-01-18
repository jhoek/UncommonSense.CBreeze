using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class ReportProperties : Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
#if NAV2015
        private DefaultLayoutProperty defaultLayout = new DefaultLayoutProperty("DefaultLayout");
#endif
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty enableExternalAssemblies = new NullableBooleanProperty("EnableExternalAssemblies");
        private NullableBooleanProperty enableExternalImages = new NullableBooleanProperty("EnableExternalImages");
        private NullableBooleanProperty enableHyperlinks = new NullableBooleanProperty("EnableHyperlinks");
        private TriggerProperty onInitReport = new TriggerProperty("OnInitReport");
        private TriggerProperty onPostReport = new TriggerProperty("OnPostReport");
        private TriggerProperty onPreReport = new TriggerProperty("OnPreReport");
        private PaperSourceProperty paperSourceDefaultPage = new PaperSourceProperty("PaperSourceDefaultPage");
        private PaperSourceProperty paperSourceFirstPage = new PaperSourceProperty("PaperSourceFirstPage");
        private PaperSourceProperty paperSourceLastPage = new PaperSourceProperty("PaperSourceLastPage");
        private PermissionsProperty permissions = new PermissionsProperty("Permissions");
#if NAV2015
        private PreviewModeProperty previewMode = new PreviewModeProperty("PreviewMode");
#endif
        private NullableBooleanProperty processingOnly = new NullableBooleanProperty("ProcessingOnly");
        private NullableBooleanProperty showPrintStatus = new NullableBooleanProperty("ShowPrintStatus");
        private TransactionTypeProperty transactionType = new TransactionTypeProperty("TransactionType");
        private NullableBooleanProperty useRequestPage = new NullableBooleanProperty("UseRequestPage");
        private NullableBooleanProperty useSystemPrinter = new NullableBooleanProperty("UseSystemPrinter");
#if NAV2015
        private StringProperty wordMergeDataItem = new StringProperty("WordMergeDataItem");
#endif

        internal ReportProperties()
        {
            innerList.Add(permissions);
            innerList.Add(transactionType);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(showPrintStatus);
            innerList.Add(useSystemPrinter);
            innerList.Add(processingOnly);
            innerList.Add(enableExternalImages);
            innerList.Add(enableHyperlinks);
            innerList.Add(enableExternalAssemblies);
            innerList.Add(onInitReport);
            innerList.Add(onPreReport);
            innerList.Add(onPostReport);
            innerList.Add(paperSourceDefaultPage);
            innerList.Add(paperSourceFirstPage);
            innerList.Add(paperSourceLastPage);
#if NAV2015
            innerList.Add(previewMode);
            innerList.Add(defaultLayout);
            innerList.Add(wordMergeDataItem);
#endif
            innerList.Add(useRequestPage);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

#if NAV2015
        public DefaultLayout? DefaultLayout
        {
            get
            {
                return this.defaultLayout.Value;
            }
            set
            {
                this.defaultLayout.Value = value;
            }
        }
#endif 

        public string Description
        {
            get
            {
                return this.description.Value;
            }
            set
            {
                this.description.Value = value;
            }
        }

        public bool? EnableExternalAssemblies
        {
            get
            {
                return this.enableExternalAssemblies.Value;
            }
            set
            {
                this.enableExternalAssemblies.Value = value;
            }
        }

        public bool? EnableExternalImages
        {
            get
            {
                return this.enableExternalImages.Value;
            }
            set
            {
                this.enableExternalImages.Value = value;
            }
        }

        public bool? EnableHyperlinks
        {
            get
            {
                return this.enableHyperlinks.Value;
            }
            set
            {
                this.enableHyperlinks.Value = value;
            }
        }

        public Trigger OnInitReport
        {
            get
            {
                return this.onInitReport.Value;
            }
        }

        public Trigger OnPostReport
        {
            get
            {
                return this.onPostReport.Value;
            }
        }

        public Trigger OnPreReport
        {
            get
            {
                return this.onPreReport.Value;
            }
        }

        public PaperSource? PaperSourceDefaultPage
        {
            get
            {
                return this.paperSourceDefaultPage.Value;
            }
            set
            {
                this.paperSourceDefaultPage.Value = value;
            }
        }

        public PaperSource? PaperSourceFirstPage
        {
            get
            {
                return this.paperSourceFirstPage.Value;
            }
            set
            {
                this.paperSourceFirstPage.Value = value;
            }
        }

        public PaperSource? PaperSourceLastPage
        {
            get
            {
                return this.paperSourceLastPage.Value;
            }
            set
            {
                this.paperSourceLastPage.Value = value;
            }
        }

        public Permissions Permissions
        {
            get
            {
                return this.permissions.Value;
            }
        }

#if NAV2015
        public PreviewMode? PreviewMode
        {
            get
            {
                return this.previewMode.Value;
            }
            set
            {
                this.previewMode.Value = value;
            }
        }
#endif

        public bool? ProcessingOnly
        {
            get
            {
                return this.processingOnly.Value;
            }
            set
            {
                this.processingOnly.Value = value;
            }
        }

        public bool? ShowPrintStatus
        {
            get
            {
                return this.showPrintStatus.Value;
            }
            set
            {
                this.showPrintStatus.Value = value;
            }
        }

        public TransactionType? TransactionType
        {
            get
            {
                return this.transactionType.Value;
            }
            set
            {
                this.transactionType.Value = value;
            }
        }

        public bool? UseRequestPage
        {
            get
            {
                return this.useRequestPage.Value;
            }
            set
            {
                this.useRequestPage.Value = value;
            }
        }

        public bool? UseSystemPrinter
        {
            get
            {
                return this.useSystemPrinter.Value;
            }
            set
            {
                this.useSystemPrinter.Value = value;
            }
        }

#if NAV2015
        public string WordMergeDataItem
        {
            get
            {
                return this.wordMergeDataItem.Value;
            }
            set
            {
                this.wordMergeDataItem.Value = value;
            }
        }
#endif
    }
}
