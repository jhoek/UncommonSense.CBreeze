using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class DataItemReportElementProperties : Properties
    {
        private FieldListProperty calcFields = new FieldListProperty("CalcFields");
        private ReportDataItemLinkProperty dataItemLink = new ReportDataItemLinkProperty("DataItemLink");
        private StringProperty dataItemLinkReference = new StringProperty("DataItemLinkReference");
        private TableReferenceProperty dataItemTable = new TableReferenceProperty("DataItemTable");
        private TableViewProperty dataItemTableView = new TableViewProperty("DataItemTableView");
        private NullableIntegerProperty maxIteration = new NullableIntegerProperty("MaxIteration");
        private TriggerProperty onAfterGetRecord = new TriggerProperty("OnAfterGetRecord");
        private TriggerProperty onPostDataItem = new TriggerProperty("OnPostDataItem");
        private TriggerProperty onPreDataItem = new TriggerProperty("OnPreDataItem");
        private NullableBooleanProperty printOnlyIfDetail = new NullableBooleanProperty("PrintOnlyIfDetail");
        private FieldListProperty reqFilterFields = new FieldListProperty("ReqFilterFields");
        private MultiLanguageProperty reqFilterHeadingML = new MultiLanguageProperty("ReqFilterHeadingML");
#if NAV2015
        private NullableBooleanProperty temporary = new NullableBooleanProperty("Temporary");
#endif

        internal DataItemReportElementProperties(DataItemReportElement dataItemReportElement)
        {
            innerList.Add(dataItemTable);
            innerList.Add(dataItemTableView);
            innerList.Add(maxIteration);
            innerList.Add(printOnlyIfDetail);
            innerList.Add(reqFilterHeadingML);
            innerList.Add(onPreDataItem);
            innerList.Add(onAfterGetRecord);
            innerList.Add(onPostDataItem);
            innerList.Add(reqFilterFields);
            innerList.Add(calcFields);
            innerList.Add(dataItemLinkReference);
            innerList.Add(dataItemLink);
#if NAV2015
            innerList.Add(temporary);
#endif
        }

        public DataItemReportElement DataItemReportElement { get; protected set; }

        public override INode ParentNode => DataItemReportElement;

        public FieldList CalcFields
        {
            get
            {
                return this.calcFields.Value;
            }
        }

        public ReportDataItemLink DataItemLink
        {
            get
            {
                return this.dataItemLink.Value;
            }
        }

        public string DataItemLinkReference
        {
            get
            {
                return this.dataItemLinkReference.Value;
            }
            set
            {
                this.dataItemLinkReference.Value = value;
            }
        }

        public int? DataItemTable
        {
            get
            {
                return this.dataItemTable.Value;
            }
            set
            {
                this.dataItemTable.Value = value;
            }
        }

        public TableView DataItemTableView
        {
            get
            {
                return this.dataItemTableView.Value;
            }
        }

        public int? MaxIteration
        {
            get
            {
                return this.maxIteration.Value;
            }
            set
            {
                this.maxIteration.Value = value;
            }
        }

        public Trigger OnAfterGetRecord
        {
            get
            {
                return this.onAfterGetRecord.Value;
            }
        }

        public Trigger OnPostDataItem
        {
            get
            {
                return this.onPostDataItem.Value;
            }
        }

        public Trigger OnPreDataItem
        {
            get
            {
                return this.onPreDataItem.Value;
            }
        }

        public bool? PrintOnlyIfDetail
        {
            get
            {
                return this.printOnlyIfDetail.Value;
            }
            set
            {
                this.printOnlyIfDetail.Value = value;
            }
        }

        public FieldList ReqFilterFields
        {
            get
            {
                return this.reqFilterFields.Value;
            }
        }

        public MultiLanguageValue ReqFilterHeadingML
        {
            get
            {
                return this.reqFilterHeadingML.Value;
            }
        }

#if NAV2015
        public bool? Temporary
        {
            get
            {
                return this.temporary.Value;
            }
            set
            {
                this.temporary.Value = value;
            }
        }
#endif
    }
}
