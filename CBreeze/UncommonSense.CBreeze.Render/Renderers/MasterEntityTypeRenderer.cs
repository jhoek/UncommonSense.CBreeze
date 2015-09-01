using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Model;
using UncommonSense.CBreeze.Utils;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Render
{
    public static class MasterEntityTypeRenderer
    {
        internal static MasterEntityTypeManifest Allocate(this MasterEntityType entityType, IEnumerable<int> range, RenderingContext renderingContext, Application application)
        {
            var manifest = new MasterEntityTypeManifest();

            manifest.Table = application.Tables.Add(new Table(renderingContext.GetNextTableID(), entityType.Name)).AutoObjectProperties(renderingContext).AutoCaption();
            manifest.CardPage = application.Pages.Add(new Page(renderingContext.GetNextPageID(), string.Format("{0} Card", entityType.Name))).AutoObjectProperties(renderingContext).AutoCaption();
            manifest.ListPage = application.Pages.Add(new Page(renderingContext.GetNextPageID(), string.Format("{0} List", entityType.Name))).AutoObjectProperties(renderingContext).AutoCaption();
            manifest.StatisticsPage = entityType.HasStatisticsPage ? application.Pages.Add(new Page(renderingContext.GetNextPageID(), string.Format("{0} Statistics", entityType.Name))).AutoObjectProperties(renderingContext).AutoCaption() : null;

            var addNoFromNoSeriesManifest = manifest.Table.AddNoFromNoSeriesField(entityType.SetupEntityType, 
            manifest.NoField = addNoFromNoSeriesManifest.NoField;
            manifest.NoSeriesField = addNoFromNoSeriesManifest.NoSeriesField;

            var addDescriptionFieldsManifest = manifest.Table.AddDescriptionFields(entityType.DescriptionStyle, entityType.HasDescription2Field, entityType.HasSearchDescriptionField);
            manifest.DescriptionField = addDescriptionFieldsManifest.DescriptionField;
            manifest.Description2Field = addDescriptionFieldsManifest.Description2Field;
            manifest.SearchDescriptionField = addDescriptionFieldsManifest.SearchDescriptionField;

            if (entityType.HasLastDateModifiedField)
            {
                var lastDateModifiedManifest = manifest.Table.AddLastDateModifiedField(manifest.Table.NextFieldNo());
                manifest.LastDateModifiedField = lastDateModifiedManifest.LastDateModifiedField;
            }

            manifest.DateFilterField = entityType.NeedsDateFilterField() ? manifest.Table.Fields.Add(new DateTableField(manifest.Table.NextFieldNo(), "Date Filter")).AutoCaption() : null;

            return manifest;
        }

        internal static void Finalize(this MasterEntityType entityType, RenderingContext renderingContext, MasterEntityTypeManifest manifest)
        {
            FinalizeTable(entityType, renderingContext, manifest);
            FinalizeCardPage(entityType, renderingContext, manifest);
            FinalizeListPage(entityType, renderingContext, manifest);
            FinalizeStatisticsPage(entityType, renderingContext, manifest);
        }

        private static void FinalizeTable(MasterEntityType entityType, RenderingContext renderingContext, MasterEntityTypeManifest manifest)
        {
            var setupEntityTypeManifest = renderingContext.GetManifest(entityType.SetupEntityType) as SetupEntityTypeManifest;

            if (entityType.NeedsDateFilterField())
            {
                manifest.DateFilterField.Properties.FieldClass = FieldClass.FlowFilter;
            }

            var secundaryKey = manifest.Table.Keys.Add();
            secundaryKey.Fields.Add(manifest.SearchDescriptionField.Name);

            manifest.Table.FieldGroups.Add(new TableFieldGroup(1, "DropDown")).Fields.AddRange(manifest.NoField.Name, manifest.DescriptionField.Name);

            manifest.Table.Properties.DataCaptionFields.Add(manifest.NoField.Name);
            manifest.Table.Properties.DataCaptionFields.Add(manifest.DescriptionField.Name);
            manifest.Table.Properties.LookupPageID = manifest.ListPage.ID;
            manifest.Table.Properties.DrillDownPageID = manifest.ListPage.ID;
        }

        private static void FinalizeCardPage(MasterEntityType entityType, RenderingContext renderingContext, MasterEntityTypeManifest manifest)
        {
            var nextControlID = 1000;

            manifest.CardPage.Properties.SourceTable = manifest.Table.ID;
            manifest.CardPage.Properties.RefreshOnActivate = true;

            // FIXME: AddActions(masterEntityType, manifest, renderingContext, ref nextControlID, manifest.CardPage.Properties.ActionList);

            manifest.CardPage.Controls.Add(new ContainerPageControl(nextControlID++, null)).Properties.ContainerType = ContainerType.ContentArea;
            manifest.CardPage.Controls.Add(new GroupPageControl(nextControlID++, 1)).Properties.CaptionML.Set("ENU", "General");

            var noControl = manifest.CardPage.Controls.Add(new FieldPageControl(nextControlID++, 2));
            noControl.Properties.SourceExpr = manifest.NoField.Name.Quoted();
            noControl.Properties.Importance = Importance.Promoted;
            noControl.Properties.OnAssistEdit.CodeLines.Add("IF AssistEdit(xRec) THEN");
            noControl.Properties.OnAssistEdit.CodeLines.Add("  CurrPage.UPDATE;");

            manifest.CardPage.Controls.Add(new FieldPageControl(nextControlID++, 2)).Properties.SourceExpr = manifest.DescriptionField.Name.Quoted();

            if (entityType.HasDescription2Field)
            {
                manifest.CardPage.Controls.Add(new FieldPageControl(nextControlID++, 2)).Properties.SourceExpr = manifest.Description2Field.Name.Quoted();
            }

            if (entityType.HasSearchDescriptionField)
            {
                manifest.CardPage.Controls.Add(new FieldPageControl(nextControlID++, 2)).Properties.SourceExpr = manifest.SearchDescriptionField.Name.Quoted();
            }

            manifest.CardPage.Controls.Add(new FieldPageControl(nextControlID++, 2)).Properties.SourceExpr = manifest.LastDateModifiedField.Name.Quoted();

            manifest.CardPage.Controls.Add(new ContainerPageControl(nextControlID++, null)).Properties.ContainerType = ContainerType.FactBoxArea;

            var recordLinksPart = manifest.CardPage.Controls.Add(new PartPageControl(nextControlID++, 1));
            recordLinksPart.Properties.Visible = false.ToString();
            recordLinksPart.Properties.PartType = PartType.System;
            recordLinksPart.Properties.SystemPartID = SystemPartID.RecordLinks;

            var notesPart = manifest.CardPage.Controls.Add(new PartPageControl(nextControlID++, 1));
            notesPart.Properties.Visible = false.ToString();
            notesPart.Properties.PartType = PartType.System;
            notesPart.Properties.SystemPartID = SystemPartID.Notes;
        }

        private static void FinalizeListPage(MasterEntityType entityType, RenderingContext renderingContext, MasterEntityTypeManifest manifest)
        {
            manifest.ListPage.Properties.Editable = false;
            manifest.ListPage.Properties.SourceTable = manifest.Table.ID;
            manifest.ListPage.Properties.CardPageID = manifest.CardPage.Name;

            var nextControlID = 1000;

            AddActions(entityType, manifest, renderingContext, ref nextControlID, manifest.ListPage.Properties.ActionList);

            manifest.ListPage.Controls.Add(new ContainerPageControl(nextControlID++, 0)).Properties.ContainerType = ContainerType.ContentArea;
            manifest.ListPage.Controls.Add(new GroupPageControl(nextControlID++, 1)).Properties.GroupType = GroupType.Repeater;
            manifest.ListPage.Controls.Add(new FieldPageControl(nextControlID++, 2)).Properties.SourceExpr = manifest.NoField.Name.Quoted();
            manifest.ListPage.Controls.Add(new FieldPageControl(nextControlID++, 2)).Properties.SourceExpr = manifest.DescriptionField.Name.Quoted();
        }

        private static void FinalizeStatisticsPage(MasterEntityType entityType, RenderingContext renderingContext, MasterEntityTypeManifest manifest)
        {
            manifest.StatisticsPage.Properties.SourceTable = manifest.Table.ID;
        }

        private static void AddActions(MasterEntityType masterEntityType, MasterEntityTypeManifest manifest, RenderingContext renderingContext, ref int nextControlID, ActionList actionList)
        {
            // FIXME: Generate actions for all subsidiary entity types
            // FIXME: Generate actions for statistics page (if any)


            actionList.Add(new PageActionContainer(nextControlID++, null)).Properties.ActionContainerType = ActionContainerType.RelatedInformation;
            actionList.Add(new PageActionGroup(nextControlID++, 1)).Properties.CaptionML.Set("ENU", masterEntityType.Name);

            foreach (var keyValuePair in renderingContext.Manifests.OfType<KeyValuePair<LedgerEntityType, LedgerEntityTypeManifest>>())
            {
                if (keyValuePair.Key.MasterEntityType == masterEntityType)
                {
                    var action = actionList.Add(new PageAction(nextControlID++, 2));
                    action.Properties.CaptionML.Set("ENU", keyValuePair.Key.PluralName);
                    action.Properties.ShortCutKey = "Ctrl+F7";
                    action.Properties.RunObject.Type = RunObjectType.Page;
                    action.Properties.RunObject.ID = keyValuePair.Value.Page.ID;
                    action.Properties.RunPageView.Key = "Customer No.";
                    action.Properties.RunPageLink.Add("Customer No.", RunObjectLinkLineType.Field, "No.");
                    action.Properties.Promoted = false;
                    action.Properties.Image = "CustomerLedger";
                    action.Properties.PromotedCategory = PromotedCategory.Process;
                }
            }

            if (masterEntityType.HasStatisticsPage)
            {
                var action = actionList.Add(new PageAction(nextControlID++, 2));
                action.Properties.CaptionML.Set("ENU", "Statistics");
                action.Properties.ShortCutKey = "F7";
                action.Properties.RunObject.Type = RunObjectType.Page;
                action.Properties.RunObject.ID = manifest.StatisticsPage.ID;
                action.Properties.RunPageLink.Add("No.", RunObjectLinkLineType.Field, "No.");
                action.Properties.Image = "Statistics";
                action.Properties.Promoted = true;
                action.Properties.PromotedCategory = PromotedCategory.Process;
                // FIXME: RunPageLink: all FlowFilters
            }
            // FIXME: Actions for all subsidiary entity types
        }

        private static bool NeedsDateFilterField(this MasterEntityType masterEntityType)
        {
            return (masterEntityType.ApplicationDesign.OfType<LedgerEntityType>().Any(e => e.MasterEntityType == masterEntityType && e.HasPostingDateField));
        }
    }
}
