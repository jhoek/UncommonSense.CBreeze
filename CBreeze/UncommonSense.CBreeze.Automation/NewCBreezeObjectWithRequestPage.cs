using System.Collections;
using System.Linq;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class NewCBreezeObjectWithRequestPage<T> : NewCBreezeObject<T> where T : IHasRequestPage
    {
        protected void ProcessRequestPage(IHasRequestPage @object)
        {
            @object.RequestPage.Properties.AutoSplitKey = NullableBooleanFromSwitch(nameof(RequestPageAutoSplitKey));
            @object.RequestPage.Properties.CaptionML.Set(RequestPageCaptionML);
            @object.RequestPage.Properties.CardPageID = RequestPageCardPageID;
            @object.RequestPage.Properties.DataCaptionExpr = RequestPageDataCaptionExpr;
            @object.RequestPage.Properties.DataCaptionFields.AddRange(RequestPageDataCaptionFields);
            @object.RequestPage.Properties.DeleteAllowed = NullableBooleanFromSwitch(nameof(RequestPageDeleteAllowed));
            @object.RequestPage.Properties.Description = RequestPageDescription;
            @object.RequestPage.Properties.Editable = NullableBooleanFromSwitch(nameof(RequestPageEditable));
            @object.RequestPage.Properties.InsertAllowed = NullableBooleanFromSwitch(nameof(RequestPageInsertAllowed));
            @object.RequestPage.Properties.InstructionalTextML.Set(RequestPageInstructionalTextML);
            @object.RequestPage.Properties.LinksAllowed = NullableBooleanFromSwitch(nameof(RequestPageLinksAllowed));
            @object.RequestPage.Properties.ModifyAllowed = NullableBooleanFromSwitch(nameof(RequestPageModifyAllowed));
            @object.RequestPage.Properties.MultipleNewLines = NullableBooleanFromSwitch(nameof(RequestPageMultipleNewLines));
            @object.RequestPage.Properties.OnAfterGetCurrRecord.Set(RequestPageOnAfterGetCurrRecord);
            @object.RequestPage.Properties.OnAfterGetRecord.Set(RequestPageOnAfterGetRecord);
            @object.RequestPage.Properties.OnClosePage.Set(RequestPageOnClosePage);
            @object.RequestPage.Properties.OnDeleteRecord.Set(RequestPageOnDeleteRecord);
            @object.RequestPage.Properties.OnFindRecord.Set(RequestPageOnFindRecord);
            @object.RequestPage.Properties.OnInit.Set(RequestPageOnInit);
            @object.RequestPage.Properties.OnInsertRecord.Set(RequestPageOnInsertRecord);
            @object.RequestPage.Properties.OnModifyRecord.Set(RequestPageOnModifyRecord);
            @object.RequestPage.Properties.OnNewRecord.Set(RequestPageOnNewRecord);
            @object.RequestPage.Properties.OnNextRecord.Set(RequestPageOnNextRecord);
            @object.RequestPage.Properties.OnOpenPage.Set(RequestPageOnOpenPage);
            @object.RequestPage.Properties.OnQueryClosePage.Set(RequestPageOnQueryClosePage);
            @object.RequestPage.Properties.Permissions.Set(RequestPagePermissions);
            @object.RequestPage.Properties.PopulateAllFields = NullableBooleanFromSwitch(nameof(RequestPagePopulateAllFields));
            @object.RequestPage.Properties.SaveValues = NullableBooleanFromSwitch(nameof(RequestPageSaveValues));
            @object.RequestPage.Properties.ShowFilter = NullableBooleanFromSwitch(nameof(RequestPageShowFilter));
            @object.RequestPage.Properties.SourceTable = RequestPageSourceTable;
            @object.RequestPage.Properties.SourceTableTemporary = NullableBooleanFromSwitch(nameof(RequestPageSourceTableTemporary));
            @object.RequestPage.Properties.SourceTableView.Key = RequestPageSourceTableViewKey;
            @object.RequestPage.Properties.SourceTableView.Order = RequestPageSourceTableViewOrder;

            var subObjects = RequestPageSubObjects.Invoke().Select(o => o.BaseObject);
            @object.RequestPage.Controls.AddRange(subObjects.OfType<PageControlBase>());
            @object.RequestPage.Properties.ActionList.AddRange(subObjects.OfType<PageActionBase>());
            @object.RequestPage.Properties.SourceTableView.TableFilter.AddRange(subObjects.OfType<TableFilterLine>());
        }

        [Parameter()] public SwitchParameter RequestPageAutoSplitKey { get; set; }
        [Parameter()] public Hashtable RequestPageCaptionML { get; set; }
        [Parameter()] public string RequestPageCardPageID { get; set; }
        [Parameter()] public string RequestPageDataCaptionExpr { get; set; }
        [Parameter()] public string[] RequestPageDataCaptionFields { get; set; }
        [Parameter()] public SwitchParameter RequestPageDeleteAllowed { get; set; }
        [Parameter()] public string RequestPageDescription { get; set; }
        [Parameter()] public SwitchParameter RequestPageEditable { get; set; }
        [Parameter()] public SwitchParameter RequestPageInsertAllowed { get; set; }
        [Parameter()] public Hashtable RequestPageInstructionalTextML { get; set; }
        [Parameter()] public SwitchParameter RequestPageLinksAllowed { get; set; }
        [Parameter()] public SwitchParameter RequestPageModifyAllowed { get; set; }
        [Parameter()] public SwitchParameter RequestPageMultipleNewLines { get; set; }
        [Parameter()] public ScriptBlock RequestPageOnAfterGetCurrRecord { get; set; }
        [Parameter()] public ScriptBlock RequestPageOnAfterGetRecord { get; set; }
        [Parameter()] public ScriptBlock RequestPageOnClosePage { get; set; }
        [Parameter()] public ScriptBlock RequestPageOnDeleteRecord { get; set; }
        [Parameter()] public ScriptBlock RequestPageOnFindRecord { get; set; }
        [Parameter()] public ScriptBlock RequestPageOnInit { get; set; }
        [Parameter()] public ScriptBlock RequestPageOnInsertRecord { get; set; }
        [Parameter()] public ScriptBlock RequestPageOnModifyRecord { get; set; }
        [Parameter()] public ScriptBlock RequestPageOnNewRecord { get; set; }
        [Parameter()] public ScriptBlock RequestPageOnNextRecord { get; set; }
        [Parameter()] public ScriptBlock RequestPageOnOpenPage { get; set; }
        [Parameter()] public ScriptBlock RequestPageOnQueryClosePage { get; set; }
        [Parameter()] public Permission[] RequestPagePermissions { get; set; }
        [Parameter()] public SwitchParameter RequestPagePopulateAllFields { get; set; }
        [Parameter()] public SwitchParameter RequestPageSaveValues { get; set; }
        [Parameter()] public SwitchParameter RequestPageShowFilter { get; set; }
        [Parameter()] [ValidateRange(1, int.MaxValue)] public int? RequestPageSourceTable { get; set; }
        [Parameter()] public SwitchParameter RequestPageSourceTableTemporary { get; set; }
        [Parameter()] public string RequestPageSourceTableViewKey { get; set; }
        [Parameter()] public Order? RequestPageSourceTableViewOrder { get; set; }

        [Parameter()] [ValidateNotNull()] public ScriptBlock RequestPageSubObjects { get; set; } = ScriptBlock.Create("");
    }
}