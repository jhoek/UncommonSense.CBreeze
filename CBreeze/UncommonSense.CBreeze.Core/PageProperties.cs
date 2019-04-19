namespace UncommonSense.CBreeze.Core
{
    public class PageProperties : Properties
    {
#if NAVBC
        private AccessByPermissionProperty accessByPermission = new AccessByPermissionProperty("AccessByPermission");
#endif
        private ActionListProperty actionList = new ActionListProperty("ActionList");
#if NAVBC
        private StringProperty apiPublisher = new StringProperty("APIPublisher");
        private StringProperty apiGroup = new StringProperty("APIGroup");
#endif
#if NAV2018
        private StringProperty apiVersion = new StringProperty("APIVersion");
#endif
#if NAVBC
        private TagListProperty applicationArea = new TagListProperty("ApplicationArea");
#endif
        private NullableBooleanProperty autoSplitKey = new NullableBooleanProperty("AutoSplitKey");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty cardPageID = new StringProperty("CardPageID");
#if NAVBC
        private NullableBooleanProperty changeTrackingAllowed = new NullableBooleanProperty("ChangeTrackingAllowed");
#endif
        private StringProperty dataCaptionExpr = new StringProperty("DataCaptionExpr");
        private FieldListProperty dataCaptionFields = new FieldListProperty("DataCaptionFields");
        private NullableBooleanProperty delayedInsert = new NullableBooleanProperty("DelayedInsert");
        private NullableBooleanProperty deleteAllowed = new NullableBooleanProperty("DeleteAllowed");
        private StringProperty description = new StringProperty("Description");
#if NAV2018
        private StringProperty entityName = new StringProperty("EntityName");
        private StringProperty entitySetName = new StringProperty("EntitySetName");
#endif
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private NullableBooleanProperty insertAllowed = new NullableBooleanProperty("InsertAllowed");
        private MultiLanguageProperty instructionalTextML = new MultiLanguageProperty("InstructionalTextML");
        private NullableBooleanProperty linksAllowed = new NullableBooleanProperty("LinksAllowed");
        private NullableBooleanProperty modifyAllowed = new NullableBooleanProperty("ModifyAllowed");
        private NullableBooleanProperty multipleNewLines = new NullableBooleanProperty("MultipleNewLines");
#if NAV2018
        private FieldListProperty odataKeyFields = new FieldListProperty("ODataKeyFields");
#endif
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
        private PageTypeProperty pageType = new PageTypeProperty("PageType");
        private PermissionsProperty permissions = new PermissionsProperty("Permissions");
        private NullableBooleanProperty populateAllFields = new NullableBooleanProperty("PopulateAllFields");
        private MultiLanguageProperty promotedActionCategoriesML = new MultiLanguageProperty("PromotedActionCategoriesML");
        private NullableBooleanProperty refreshOnActivate = new NullableBooleanProperty("RefreshOnActivate");
        private NullableBooleanProperty saveValues = new NullableBooleanProperty("SaveValues");
        private NullableBooleanProperty showFilter = new NullableBooleanProperty("ShowFilter");
        private TableReferenceProperty sourceTable = new TableReferenceProperty("SourceTable");
        private NullableBooleanProperty sourceTableTemporary = new NullableBooleanProperty("SourceTableTemporary");
        private TableViewProperty sourceTableView = new TableViewProperty("SourceTableView");
#if NAVBC
        private UsageCategoryProperty usageCategory = new UsageCategoryProperty("UsageCategory");
#endif

        internal PageProperties(Page page)
        {
            Page = page;

            innerList.Add(permissions);
#if NAVBC
            innerList.Add(accessByPermission);
#endif
            innerList.Add(editable);
            innerList.Add(captionML);
#if NAVBC
            innerList.Add(applicationArea);
#endif
            innerList.Add(description);
            innerList.Add(saveValues);
            innerList.Add(multipleNewLines);
            innerList.Add(insertAllowed);
            innerList.Add(deleteAllowed);
            innerList.Add(modifyAllowed);
            innerList.Add(linksAllowed);
            innerList.Add(sourceTable);
            innerList.Add(dataCaptionExpr);
            innerList.Add(delayedInsert);
            innerList.Add(populateAllFields);
            innerList.Add(sourceTableView);
            innerList.Add(dataCaptionFields);
            innerList.Add(pageType);
#if NAVBC
            innerList.Add(usageCategory);
#endif
            innerList.Add(sourceTableTemporary);
#if NAVBC
            innerList.Add(changeTrackingAllowed);
            innerList.Add(apiPublisher);
            innerList.Add(apiGroup);
#endif
#if NAV2018
            innerList.Add(entitySetName);
            innerList.Add(entityName);
#endif
            innerList.Add(cardPageID);
            innerList.Add(instructionalTextML);
            innerList.Add(autoSplitKey);
            innerList.Add(refreshOnActivate);
            innerList.Add(promotedActionCategoriesML);
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
#if NAV2018
            innerList.Add(odataKeyFields);
            innerList.Add(apiVersion);
#endif
            innerList.Add(actionList);
        }

        public Page Page { get; protected set; }

        public override INode ParentNode => Page;

#if NAVBC
        public AccessByPermission AccessByPermission => accessByPermission.Value;
#endif

        public ActionList ActionList
        {
            get
            {
                return actionList.Value;
            }
        }

#if NAVBC
        public string APIPublisher
        {
            get => apiPublisher.Value;
            set => apiPublisher.Value = value;
        }

        public string APIGroup
        {
            get => apiGroup.Value;
            set => apiGroup.Value = value;
        }
#endif

#if NAV2018

        public string APIVersion
        {
            get => apiVersion.Value;
            set => apiVersion.Value = value;
        }

#endif
#if NAVBC
        public TagList ApplicationArea => applicationArea.Value;
#endif
        public bool? AutoSplitKey
        {
            get
            {
                return autoSplitKey.Value;
            }
            set
            {
                autoSplitKey.Value = value;
            }
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return captionML.Value;
            }
        }

        public string CardPageID
        {
            get
            {
                return cardPageID.Value;
            }
            set
            {
                cardPageID.Value = value;
            }
        }

#if NAVBC
        public bool? ChangeTrackingAllowed
        {
            get => changeTrackingAllowed.Value;
            set => changeTrackingAllowed.Value = value;
        }
#endif

        public string DataCaptionExpr
        {
            get
            {
                return dataCaptionExpr.Value;
            }
            set
            {
                dataCaptionExpr.Value = value;
            }
        }

        public FieldList DataCaptionFields
        {
            get
            {
                return dataCaptionFields.Value;
            }
        }

        public bool? DelayedInsert
        {
            get
            {
                return delayedInsert.Value;
            }
            set
            {
                delayedInsert.Value = value;
            }
        }

        public bool? DeleteAllowed
        {
            get
            {
                return deleteAllowed.Value;
            }
            set
            {
                deleteAllowed.Value = value;
            }
        }

        public string Description
        {
            get
            {
                return description.Value;
            }
            set
            {
                description.Value = value;
            }
        }

        public bool? Editable
        {
            get
            {
                return editable.Value;
            }
            set
            {
                editable.Value = value;
            }
        }

#if NAV2018

        public string EntityName
        {
            get => entityName.Value;
            set => entityName.Value = value;
        }

        public string EntitySetName
        {
            get => entitySetName.Value;
            set => entitySetName.Value = value;
        }

#endif

        public bool? InsertAllowed
        {
            get
            {
                return insertAllowed.Value;
            }
            set
            {
                insertAllowed.Value = value;
            }
        }

        public MultiLanguageValue InstructionalTextML
        {
            get
            {
                return instructionalTextML.Value;
            }
        }

        public bool? LinksAllowed
        {
            get
            {
                return linksAllowed.Value;
            }
            set
            {
                linksAllowed.Value = value;
            }
        }

        public bool? ModifyAllowed
        {
            get
            {
                return modifyAllowed.Value;
            }
            set
            {
                modifyAllowed.Value = value;
            }
        }

        public bool? MultipleNewLines
        {
            get
            {
                return multipleNewLines.Value;
            }
            set
            {
                multipleNewLines.Value = value;
            }
        }

#if NAV2018
        public FieldList ODataKeyFields => odataKeyFields.Value;
#endif

        public Trigger OnAfterGetCurrRecord
        {
            get
            {
                return onAfterGetCurrRecord.Value;
            }
        }

        public Trigger OnAfterGetRecord
        {
            get
            {
                return onAfterGetRecord.Value;
            }
        }

        public Trigger OnClosePage
        {
            get
            {
                return onClosePage.Value;
            }
        }

        public Trigger OnDeleteRecord
        {
            get
            {
                return onDeleteRecord.Value;
            }
        }

        public Trigger OnFindRecord
        {
            get
            {
                return onFindRecord.Value;
            }
        }

        public Trigger OnInit
        {
            get
            {
                return onInit.Value;
            }
        }

        public Trigger OnInsertRecord
        {
            get
            {
                return onInsertRecord.Value;
            }
        }

        public Trigger OnModifyRecord
        {
            get
            {
                return onModifyRecord.Value;
            }
        }

        public Trigger OnNewRecord
        {
            get
            {
                return onNewRecord.Value;
            }
        }

        public Trigger OnNextRecord
        {
            get
            {
                return onNextRecord.Value;
            }
        }

        public Trigger OnOpenPage
        {
            get
            {
                return onOpenPage.Value;
            }
        }

        public Trigger OnQueryClosePage
        {
            get
            {
                return onQueryClosePage.Value;
            }
        }

        public PageType? PageType
        {
            get
            {
                return pageType.Value;
            }
            set
            {
                pageType.Value = value;
            }
        }

        public Permissions Permissions
        {
            get
            {
                return permissions.Value;
            }
        }

        public bool? PopulateAllFields
        {
            get
            {
                return populateAllFields.Value;
            }
            set
            {
                populateAllFields.Value = value;
            }
        }

        public MultiLanguageValue PromotedActionCategoriesML
        {
            get
            {
                return promotedActionCategoriesML.Value;
            }
        }

        public bool? RefreshOnActivate
        {
            get
            {
                return refreshOnActivate.Value;
            }
            set
            {
                refreshOnActivate.Value = value;
            }
        }

        public bool? SaveValues
        {
            get
            {
                return saveValues.Value;
            }
            set
            {
                saveValues.Value = value;
            }
        }

        public bool? ShowFilter
        {
            get
            {
                return showFilter.Value;
            }
            set
            {
                showFilter.Value = value;
            }
        }

        public int? SourceTable
        {
            get
            {
                return sourceTable.Value;
            }
            set
            {
                sourceTable.Value = value;
            }
        }

        public bool? SourceTableTemporary
        {
            get
            {
                return sourceTableTemporary.Value;
            }
            set
            {
                sourceTableTemporary.Value = value;
            }
        }

        public TableView SourceTableView
        {
            get
            {
                return sourceTableView.Value;
            }
        }

#if NAVBC
        public UsageCategory? UsageCategory
        {
            get => usageCategory.Value;
            set => usageCategory.Value = value;
        }
#endif
    }
}