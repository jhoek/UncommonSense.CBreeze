using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.XmlPort
{
        public class XmlPortTableElementProperties : Properties
    {
        private NullableBooleanProperty autoReplace = new NullableBooleanProperty("AutoReplace");
        private NullableBooleanProperty autoSave = new NullableBooleanProperty("AutoSave");
        private NullableBooleanProperty autoUpdate = new NullableBooleanProperty("AutoUpdate");
        private FieldListProperty calcFields = new FieldListProperty("CalcFields");
        private LinkFieldsProperty linkFields = new LinkFieldsProperty("LinkFields");
        private StringProperty linkTable = new StringProperty("LinkTable");
        private NullableBooleanProperty linkTableForceInsert = new NullableBooleanProperty("LinkTableForceInsert");
        private MaxOccursProperty maxOccurs = new MaxOccursProperty("MaxOccurs");
        private MinOccursProperty minOccurs = new MinOccursProperty("MinOccurs");
#if NAV2016
        private StringProperty namespacePrefix = new StringProperty("NamespacePrefix");
#endif
        private ScopedTriggerProperty onAfterGetRecord = new ScopedTriggerProperty("OnAfterGetRecord");
        private ScopedTriggerProperty onAfterInitRecord = new ScopedTriggerProperty("OnAfterInitRecord");
        private ScopedTriggerProperty onAfterInsertRecord = new ScopedTriggerProperty("OnAfterInsertRecord");
        private ScopedTriggerProperty onAfterModifyRecord = new ScopedTriggerProperty("OnAfterModifyRecord");
        private ScopedTriggerProperty onBeforeInsertRecord = new ScopedTriggerProperty("OnBeforeInsertRecord");
        private ScopedTriggerProperty onBeforeModifyRecord = new ScopedTriggerProperty("OnBeforeModifyRecord");
        private ScopedTriggerProperty onPreXMLItem = new ScopedTriggerProperty("OnPreXMLItem");
        private FieldListProperty reqFilterFields = new FieldListProperty("ReqFilterFields");
        private MultiLanguageProperty reqFilterHeadingML = new MultiLanguageProperty("ReqFilterHeadingML");
        private TableReferenceProperty sourceTable = new TableReferenceProperty("SourceTable");
        private TableViewProperty sourceTableView = new TableViewProperty("SourceTableView");
        private NullableBooleanProperty temporary = new NullableBooleanProperty("Temporary");
        private StringProperty variableName = new StringProperty("VariableName");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal XmlPortTableElementProperties(XmlPortTableElement xmlPortTableElement)
        {
            XmlPortTableElement = xmlPortTableElement;

            innerList.Add(reqFilterFields);
            innerList.Add(reqFilterHeadingML);
            innerList.Add(variableName);
            innerList.Add(sourceTable);
            innerList.Add(sourceTableView);
            innerList.Add(calcFields);
            innerList.Add(linkFields);
            innerList.Add(linkTable);
            innerList.Add(temporary);
            innerList.Add(linkTableForceInsert);
            innerList.Add(autoSave);
            innerList.Add(autoUpdate);
            innerList.Add(autoReplace);
#if NAV2016
            innerList.Add(namespacePrefix);
#endif
            innerList.Add(minOccurs);
            innerList.Add(maxOccurs);
            innerList.Add(onAfterInitRecord);
            innerList.Add(onBeforeInsertRecord);
            innerList.Add(onPreXMLItem);
            innerList.Add(onAfterGetRecord);
            innerList.Add(onAfterInsertRecord);
            innerList.Add(onBeforeModifyRecord);
            innerList.Add(onAfterModifyRecord);
            innerList.Add(width);
        }

        public XmlPortTableElement XmlPortTableElement
        {
            get;protected set;
        }

        public override INode ParentNode => XmlPortTableElement;

        public bool? AutoReplace
        {
            get
            {
                return this.autoReplace.Value;
            }
            set
            {
                this.autoReplace.Value = value;
            }
        }

      public bool? AutoSave
        {
            get
            {
                return this.autoSave.Value;
            }
            set
            {
                this.autoSave.Value = value;
            }
        }

      public bool? AutoUpdate
        {
            get
            {
                return this.autoUpdate.Value;
            }
            set
            {
                this.autoUpdate.Value = value;
            }
        }

        public FieldList CalcFields
        {
            get
            {
                return this.calcFields.Value;
            }
        }

        public LinkFields LinkFields
        {
            get
            {
                return this.linkFields.Value;
            }
        }

      public string LinkTable
        {
            get
            {
                return this.linkTable.Value;
            }
            set
            {
                this.linkTable.Value = value;
            }
        }

      public bool? LinkTableForceInsert
        {
            get
            {
                return this.linkTableForceInsert.Value;
            }
            set
            {
                this.linkTableForceInsert.Value = value;
            }
        }

        public MaxOccurs? MaxOccurs
        {
            get
            {
                return this.maxOccurs.Value;
            }
            set
            {
                this.maxOccurs.Value = value;
            }
        }

        public MinOccurs? MinOccurs
        {
            get
            {
                return this.minOccurs.Value;
            }
            set
            {
                this.minOccurs.Value = value;
            }
        }

#if NAV2016
        public string NamespacePrefix
        {
            get
            {
                return this.namespacePrefix.Value;
            }
            set
            {
                this.namespacePrefix.Value = value;
            }
        }
#endif

        public Trigger OnAfterGetRecord
        {
            get
            {
                return this.onAfterGetRecord.Value;
            }
        }

        public Trigger OnAfterInitRecord
        {
            get
            {
                return this.onAfterInitRecord.Value;
            }
        }

        public Trigger OnAfterInsertRecord
        {
            get
            {
                return this.onAfterInsertRecord.Value;
            }
        }

        public Trigger OnAfterModifyRecord
        {
            get
            {
                return this.onAfterModifyRecord.Value;
            }
        }

        public Trigger OnBeforeInsertRecord
        {
            get
            {
                return this.onBeforeInsertRecord.Value;
            }
        }

        public Trigger OnBeforeModifyRecord
        {
            get
            {
                return this.onBeforeModifyRecord.Value;
            }
        }

        public Trigger OnPreXMLItem
        {
            get
            {
                return this.onPreXMLItem.Value;
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

      public int? SourceTable
        {
            get
            {
                return this.sourceTable.Value;
            }
            set
            {
                this.sourceTable.Value = value;
            }
        }

        public TableView SourceTableView
        {
            get
            {
                return this.sourceTableView.Value;
            }
        }

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

      public string VariableName
        {
            get
            {
                return this.variableName.Value;
            }
            set
            {
                this.variableName.Value = value;
            }
        }

      public int? Width
        {
            get
            {
                return this.width.Value;
            }
            set
            {
                this.width.Value = value;
            }
        }
    }
}
