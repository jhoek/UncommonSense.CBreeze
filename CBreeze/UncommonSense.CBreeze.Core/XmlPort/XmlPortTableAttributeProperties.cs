using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.XmlPort
{
    public class XmlPortTableAttributeProperties : Properties
    {
        private NullableBooleanProperty autoReplace = new NullableBooleanProperty("AutoReplace");
        private NullableBooleanProperty autoSave = new NullableBooleanProperty("AutoSave");
        private NullableBooleanProperty autoUpdate = new NullableBooleanProperty("AutoUpdate");
        private FieldListProperty calcFields = new FieldListProperty("CalcFields");
        private LinkFieldsProperty linkFields = new LinkFieldsProperty("LinkFields");
        private StringProperty linkTable = new StringProperty("LinkTable");
        private NullableBooleanProperty linkTableForceInsert = new NullableBooleanProperty("LinkTableForceInsert");
        private OccurrenceProperty occurrence = new OccurrenceProperty("Occurrence");
        private ScopedTriggerProperty onAfterGetRecord = new ScopedTriggerProperty("OnAfterGetRecord");
        private TriggerProperty onAfterInitRecord = new TriggerProperty("OnAfterInitRecord");
        private TriggerProperty onAfterInsertRecord = new TriggerProperty("OnAfterInsertRecord");
        private TriggerProperty onAfterModifyRecord = new TriggerProperty("OnAfterModifyRecord");
        private TriggerProperty onBeforeInsertRecord = new TriggerProperty("OnBeforeInsertRecord");
        private TriggerProperty onBeforeModifyRecord = new TriggerProperty("OnBeforeModifyRecord");
        private TriggerProperty onPreXmlItem = new TriggerProperty("OnPreXmlItem");
        private FieldListProperty reqFilterFields = new FieldListProperty("ReqFilterFields");
        private MultiLanguageProperty reqFilterHeadingML = new MultiLanguageProperty("ReqFilterHeadingML");
        private NullableIntegerProperty sourceTable = new NullableIntegerProperty("SourceTable");
        private TableViewProperty sourceTableView = new TableViewProperty("SourceTableView");
        private NullableBooleanProperty temporary = new NullableBooleanProperty("Temporary");
        private StringProperty variableName = new StringProperty("VariableName");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal XmlPortTableAttributeProperties(XmlPortTableAttribute xmlPortTableAttribute)
        {
            XmlPortTableAttribute = xmlPortTableAttribute;

            innerList.Add(autoReplace);
            innerList.Add(autoSave);
            innerList.Add(autoUpdate);
            innerList.Add(calcFields);
            innerList.Add(linkFields);
            innerList.Add(linkTable);
            innerList.Add(linkTableForceInsert);
            innerList.Add(occurrence);
            innerList.Add(onAfterGetRecord);
            innerList.Add(onAfterInitRecord);
            innerList.Add(onAfterInsertRecord);
            innerList.Add(onAfterModifyRecord);
            innerList.Add(onBeforeInsertRecord);
            innerList.Add(onBeforeModifyRecord);
            innerList.Add(onPreXmlItem);
            innerList.Add(reqFilterFields);
            innerList.Add(reqFilterHeadingML);
            innerList.Add(sourceTable);
            innerList.Add(sourceTableView);
            innerList.Add(temporary);
            innerList.Add(variableName);
            innerList.Add(width);
        }

        public XmlPortTableAttribute XmlPortTableAttribute
        {
            get; protected set;
        }

        public override INode ParentNode => XmlPortTableAttribute;

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

        public Occurrence? Occurrence
        {
            get
            {
                return this.occurrence.Value;
            }
            set
            {
                this.occurrence.Value = value;
            }
        }

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

        public Trigger OnPreXmlItem
        {
            get
            {
                return this.onPreXmlItem.Value;
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
