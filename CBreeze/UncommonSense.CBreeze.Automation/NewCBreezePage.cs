using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezePage", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(Page))]
    [Alias("Page", "Add-CBreezePage")]
    public class NewCBreezePage : NewCBreezeObject<Page>
    {
        protected override void AddItemToInputObject(Page item, Application inputObject)
        {
            inputObject.Pages.Add(item);
        }

        protected override IEnumerable<Page> CreateItems()
        {
            var page = new Page(ID, Name);
            SetObjectProperties(page);

            page.Properties.AutoSplitKey = NullableBooleanFromSwitch(nameof(AutoSplitKey));
            page.Properties.CaptionML.Set(CaptionML);
            page.Properties.CardPageID = CardPageID;
            page.Properties.DataCaptionExpr = DataCaptionExpr;
            page.Properties.DataCaptionFields.AddRange(DataCaptionFields ?? new string[] { });
            page.Properties.DelayedInsert = NullableBooleanFromSwitch(nameof(DelayedInsert));
            page.Properties.DeleteAllowed = NullableBooleanFromSwitch(nameof(DeleteAllowed));
            page.Properties.Description = Description;
            page.Properties.Editable = NullableBooleanFromSwitch(nameof(Editable));
            page.Properties.InsertAllowed = NullableBooleanFromSwitch(nameof(InsertAllowed));
            page.Properties.LinksAllowed = NullableBooleanFromSwitch(nameof(LinksAllowed));
            page.Properties.ModifyAllowed = NullableBooleanFromSwitch(nameof(ModifyAllowed));
            page.Properties.MultipleNewLines = NullableBooleanFromSwitch(nameof(MultipleNewLines));
            page.Properties.OnAfterGetCurrRecord.Set(OnAfterGetCurrRecord);
            page.Properties.OnAfterGetRecord.Set(OnAfterGetRecord);
            page.Properties.OnClosePage.Set(OnClosePage);
            page.Properties.OnDeleteRecord.Set(OnDeleteRecord);
            page.Properties.OnFindRecord.Set(OnFindRecord);
            page.Properties.OnInit.Set(OnInit);
            page.Properties.OnInsertRecord.Set(OnInsertRecord);
            page.Properties.OnModifyRecord.Set(OnModifyRecord);
            page.Properties.OnNewRecord.Set(OnNewRecord);
            page.Properties.OnNextRecord.Set(OnNextRecord);
            page.Properties.OnOpenPage.Set(OnOpenPage);
            page.Properties.OnQueryClosePage.Set(OnQueryClosePage);
            page.Properties.PageType = PageType;
            page.Properties.Permissions.Set(Permissions);
            page.Properties.PopulateAllFields = NullableBooleanFromSwitch(nameof(PopulateAllFields));
            page.Properties.PromotedActionCategoriesML.Set(PromotedActionCategoriesML);
            page.Properties.RefreshOnActivate = NullableBooleanFromSwitch(nameof(RefreshOnActivate));
            page.Properties.SaveValues = NullableBooleanFromSwitch(nameof(SaveValues));
            page.Properties.ShowFilter = NullableBooleanFromSwitch(nameof(ShowFilter));
            page.Properties.SourceTable = SourceTable;
            page.Properties.SourceTableTemporary = NullableBooleanFromSwitch(nameof(SourceTableTemporary));

            if (AutoCaption)
                page.AutoCaption();

            if (SubObjects != null)
            {
                var subObjects = SubObjects.Invoke().Select(o => o.BaseObject);
                page.Controls.AddRange(subObjects.OfType<PageControlBase>());
                page.Properties.ActionList.AddRange(subObjects.OfType<PageActionBase>());
                page.Properties.SourceTableView.TableFilter.AddRange(subObjects.OfType<TableFilterLine>());
                page.Code.Documentation.CodeLines.AddRange(subObjects.OfType<string>());
                page.Code.Functions.AddRange(subObjects.OfType<Function>());
                page.Code.Variables.AddRange(subObjects.OfType<Variable>());
                page.Code.Events.AddRange(subObjects.OfType<Event>());
            }

            yield return page;
        }

        [Parameter()] public SwitchParameter AutoSplitKey { get; set; }
        [Parameter()] public Hashtable CaptionML { get; set; }
        [Parameter()] public string CardPageID { get; set; }
        [Parameter()] public string DataCaptionExpr { get; set; }
        [Parameter()] public string[] DataCaptionFields { get; set; }
        [Parameter()] public SwitchParameter DelayedInsert { get; set; }
        [Parameter()] public SwitchParameter DeleteAllowed { get; set; }
        [Parameter()] public string Description { get; set; }
        [Parameter()] public SwitchParameter Editable { get; set; }
        [Parameter()] public SwitchParameter InsertAllowed { get; set; }
        [Parameter()] public SwitchParameter LinksAllowed { get; set; }
        [Parameter()] public SwitchParameter ModifyAllowed { get; set; }
        [Parameter()] public SwitchParameter MultipleNewLines { get; set; }
        [Parameter()] public ScriptBlock OnAfterGetCurrRecord { get; set; }
        [Parameter()] public ScriptBlock OnAfterGetRecord { get; set; }
        [Parameter()] public ScriptBlock OnClosePage { get; set; }
        [Parameter()] public ScriptBlock OnDeleteRecord { get; set; }
        [Parameter()] public ScriptBlock OnFindRecord { get; set; }
        [Parameter()] public ScriptBlock OnInit { get; set; }
        [Parameter()] public ScriptBlock OnInsertRecord { get; set; }
        [Parameter()] public ScriptBlock OnModifyRecord { get; set; }
        [Parameter()] public ScriptBlock OnNewRecord { get; set; }
        [Parameter()] public ScriptBlock OnNextRecord { get; set; }
        [Parameter()] public ScriptBlock OnOpenPage { get; set; }
        [Parameter()] public ScriptBlock OnQueryClosePage { get; set; }
        [Parameter()] public PageType? PageType { get; set; }
        [Parameter()] public Permission[] Permissions { get; set; }
        [Parameter()] public SwitchParameter PopulateAllFields { get; set; }
        [Parameter()] public Hashtable PromotedActionCategoriesML { get; set; }
        [Parameter()] public SwitchParameter RefreshOnActivate { get; set; }
        [Parameter()] public SwitchParameter SaveValues { get; set; }
        [Parameter()] public SwitchParameter ShowFilter { get; set; }
        [Parameter()] [ValidateRange(1, int.MaxValue)] public int? SourceTable { get; set; }
        [Parameter()] public SwitchParameter SourceTableTemporary { get; set; }
    }
}