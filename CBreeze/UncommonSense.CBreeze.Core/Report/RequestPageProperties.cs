using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Page.Action;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Report
{
    public class RequestPageProperties : Properties
    {
        private ActionListProperty actionList = new ActionListProperty("ActionList");
        private NullableBooleanProperty autoSplitKey = new NullableBooleanProperty("AutoSplitKey");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty cardPageID = new StringProperty("CardPageID");
        private StringProperty dataCaptionExpr = new StringProperty("DataCaptionExpr");
        private FieldListProperty dataCaptionFields = new FieldListProperty("DataCaptionFields");
        private NullableBooleanProperty deleteAllowed = new NullableBooleanProperty("DeleteAllowed");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private NullableBooleanProperty insertAllowed = new NullableBooleanProperty("InsertAllowed");
        private MultiLanguageProperty instructionalTextML = new MultiLanguageProperty("InstructionalTextML");
        private NullableBooleanProperty linksAllowed = new NullableBooleanProperty("LinksAllowed");
        private NullableBooleanProperty modifyAllowed = new NullableBooleanProperty("ModifyAllowed");
        private NullableBooleanProperty multipleNewLines = new NullableBooleanProperty("MultipleNewLines");
        private TriggerProperty onAfterGetCurrRecord = new TriggerProperty("OnAfterGetCurrRecord");
        private TriggerProperty onAfterGetRecord = new TriggerProperty("OnAfterGetRecord");
        private TriggerProperty onClosePage = new TriggerProperty("OnClosePage");
        private TriggerProperty onDeleteRecord = new TriggerProperty("OnDeleteRecord");
        private TriggerProperty onFindRecord = new TriggerProperty("OnFindRecord");
        private TriggerProperty onInit = new TriggerProperty("OnInit");
        private TriggerProperty onInsertRecord = new TriggerProperty("OnInsertRecord");
        private TriggerProperty onModifyRecord = new TriggerProperty("OnModifyRecord");
        private TriggerProperty onNewRecord = new TriggerProperty("OnNewRecord");
        private TriggerProperty onNextRecord = new TriggerProperty("OnNextRecord");
        private TriggerProperty onOpenPage = new TriggerProperty("OnOpenPage");
        private TriggerProperty onQueryClosePage = new TriggerProperty("OnQueryClosePage");
        private PermissionsProperty permissions = new PermissionsProperty("Permissions");
        private NullableBooleanProperty populateAllFields = new NullableBooleanProperty("PopulateAllFields");
        private NullableBooleanProperty saveValues = new NullableBooleanProperty("SaveValues");
        private NullableBooleanProperty showFilter = new NullableBooleanProperty("ShowFilter");
        private TableReferenceProperty sourceTable = new TableReferenceProperty("SourceTable");
        private NullableBooleanProperty sourceTableTemporary = new NullableBooleanProperty("SourceTableTemporary");
        private TableViewProperty sourceTableView = new TableViewProperty("SourceTableView");

        internal RequestPageProperties(RequestPage requestPage)
        {
            RequestPage = requestPage;

            innerList.Add(permissions);
            innerList.Add(editable);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(saveValues);
            innerList.Add(multipleNewLines);
            innerList.Add(insertAllowed);
            innerList.Add(deleteAllowed);
            innerList.Add(modifyAllowed);
            innerList.Add(linksAllowed);
            innerList.Add(sourceTable);
            innerList.Add(dataCaptionExpr);
            innerList.Add(populateAllFields);
            innerList.Add(sourceTableView);
            innerList.Add(dataCaptionFields);
            innerList.Add(sourceTableTemporary);
            innerList.Add(cardPageID);
            innerList.Add(instructionalTextML);
            innerList.Add(autoSplitKey);
            innerList.Add(showFilter);
            innerList.Add(onInit);
            innerList.Add(onOpenPage);
            innerList.Add(onClosePage);
            innerList.Add(onFindRecord);
            innerList.Add(onNextRecord);
            innerList.Add(onAfterGetRecord);
            innerList.Add(onNewRecord);
            innerList.Add(onInsertRecord);
            innerList.Add(onModifyRecord);
            innerList.Add(onDeleteRecord);
            innerList.Add(onQueryClosePage);
            innerList.Add(onAfterGetCurrRecord);
            innerList.Add(actionList);
        }

        public ActionList ActionList
        {
            get
            {
                return this.actionList.Value;
            }
        }

        public bool? AutoSplitKey
        {
            get
            {
                return this.autoSplitKey.Value;
            }
            set
            {
                this.autoSplitKey.Value = value;
            }
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public string CardPageID
        {
            get
            {
                return this.cardPageID.Value;
            }
            set
            {
                this.cardPageID.Value = value;
            }
        }

        public string DataCaptionExpr
        {
            get
            {
                return this.dataCaptionExpr.Value;
            }
            set
            {
                this.dataCaptionExpr.Value = value;
            }
        }

        public FieldList DataCaptionFields
        {
            get
            {
                return this.dataCaptionFields.Value;
            }
        }

        public bool? DeleteAllowed
        {
            get
            {
                return this.deleteAllowed.Value;
            }
            set
            {
                this.deleteAllowed.Value = value;
            }
        }

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

        public bool? Editable
        {
            get
            {
                return this.editable.Value;
            }
            set
            {
                this.editable.Value = value;
            }
        }

        public bool? InsertAllowed
        {
            get
            {
                return this.insertAllowed.Value;
            }
            set
            {
                this.insertAllowed.Value = value;
            }
        }

        public MultiLanguageValue InstructionalTextML
        {
            get
            {
                return this.instructionalTextML.Value;
            }
        }

        public bool? LinksAllowed
        {
            get
            {
                return this.linksAllowed.Value;
            }
            set
            {
                this.linksAllowed.Value = value;
            }
        }

        public bool? ModifyAllowed
        {
            get
            {
                return this.modifyAllowed.Value;
            }
            set
            {
                this.modifyAllowed.Value = value;
            }
        }

        public bool? MultipleNewLines
        {
            get
            {
                return this.multipleNewLines.Value;
            }
            set
            {
                this.multipleNewLines.Value = value;
            }
        }

        public Trigger OnAfterGetCurrRecord
        {
            get
            {
                return this.onAfterGetCurrRecord.Value;
            }
        }

        public Trigger OnAfterGetRecord
        {
            get
            {
                return this.onAfterGetRecord.Value;
            }
        }

        public Trigger OnClosePage
        {
            get
            {
                return this.onClosePage.Value;
            }
        }

        public Trigger OnDeleteRecord
        {
            get
            {
                return this.onDeleteRecord.Value;
            }
        }

        public Trigger OnFindRecord
        {
            get
            {
                return this.onFindRecord.Value;
            }
        }

        public Trigger OnInit
        {
            get
            {
                return this.onInit.Value;
            }
        }

        public Trigger OnInsertRecord
        {
            get
            {
                return this.onInsertRecord.Value;
            }
        }

        public Trigger OnModifyRecord
        {
            get
            {
                return this.onModifyRecord.Value;
            }
        }

        public Trigger OnNewRecord
        {
            get
            {
                return this.onNewRecord.Value;
            }
        }

        public Trigger OnNextRecord
        {
            get
            {
                return this.onNextRecord.Value;
            }
        }

        public Trigger OnOpenPage
        {
            get
            {
                return this.onOpenPage.Value;
            }
        }

        public Trigger OnQueryClosePage
        {
            get
            {
                return this.onQueryClosePage.Value;
            }
        }

        public override INode ParentNode => RequestPage;

        public Permissions Permissions
        {
            get
            {
                return this.permissions.Value;
            }
        }

        public bool? PopulateAllFields
        {
            get
            {
                return this.populateAllFields.Value;
            }
            set
            {
                this.populateAllFields.Value = value;
            }
        }

        public RequestPage RequestPage { get; protected set; }

        public bool? SaveValues
        {
            get
            {
                return this.saveValues.Value;
            }
            set
            {
                this.saveValues.Value = value;
            }
        }

        public bool? ShowFilter
        {
            get
            {
                return this.showFilter.Value;
            }
            set
            {
                this.showFilter.Value = value;
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

        public bool? SourceTableTemporary
        {
            get
            {
                return this.sourceTableTemporary.Value;
            }
            set
            {
                this.sourceTableTemporary.Value = value;
            }
        }

        public TableView SourceTableView
        {
            get
            {
                return this.sourceTableView.Value;
            }
        }
    }
}