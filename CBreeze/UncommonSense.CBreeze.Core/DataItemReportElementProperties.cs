using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class DataItemReportElementProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

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

        internal DataItemReportElementProperties()
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
        }

        public Property this[string name]
        {
            get
            {
                return innerList.FirstOrDefault(p => p.Name == name);
            }
        }

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

      public System.String DataItemLinkReference
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

      public System.Int32? DataItemTable
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

      public System.Int32? MaxIteration
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

      public System.Boolean? PrintOnlyIfDetail
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }
}
