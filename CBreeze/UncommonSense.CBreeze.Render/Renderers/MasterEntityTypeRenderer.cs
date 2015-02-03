using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Model;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Render
{
    public static class MasterEntityTypeRenderer
    {
        internal static MasterEntityTypeManifest Allocate(this MasterEntityType entityType, RenderingContext renderingContext, Application application)
        {
            var manifest = new MasterEntityTypeManifest();

            manifest.Table = application.Tables.Add(renderingContext.GetNextTableID(), entityType.Name).AutoObjectProperties(renderingContext).AutoCaption();
            manifest.CardPage = application.Pages.Add(renderingContext.GetNextPageID(), string.Format("{0} Card", entityType.Name)).AutoObjectProperties(renderingContext).AutoCaption();
            manifest.ListPage = application.Pages.Add(renderingContext.GetNextPageID(), string.Format("{0} List", entityType.Name)).AutoObjectProperties(renderingContext).AutoCaption();
            manifest.StatisticsPage = entityType.HasStatisticsPage ? application.Pages.Add(renderingContext.GetNextPageID(), string.Format("{0} Statistics", entityType.Name)).AutoObjectProperties(renderingContext).AutoCaption() : null;

            var nextFieldNo = 1;

            manifest.NoField = manifest.Table.Fields.AddCodeTableField(nextFieldNo++, "No.", 20).AutoCaption();
            manifest.DescriptionField = manifest.Table.Fields.AddTextTableField(nextFieldNo++, entityType.DescriptionFieldName(), 50).AutoCaption();
            manifest.Description2Field = entityType.HasDescription2Field ? manifest.Table.Fields.AddTextTableField(nextFieldNo++, entityType.Description2FieldName(), 50).AutoCaption() : null;
            manifest.SearchDescriptionField = entityType.HasSearchDescriptionField ? manifest.Table.AddSearchDescription(nextFieldNo++, manifest.NoField, manifest.DescriptionField) : null;
            manifest.LastDateModifiedField = entityType.HasDateLastModifiedField ? manifest.Table.AddLastDateModified(nextFieldNo++) : null;
            manifest.DateFilterField = entityType.NeedsDateFilterField() ? manifest.Table.Fields.AddDateTableField(nextFieldNo++, "Date Filter").AutoCaption() : null;
            manifest.NoSeriesField = manifest.Table.Fields.AddCodeTableField(nextFieldNo++, "No. Series", 10).AutoCaption();

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

            //if (entityType.HasSearchDescriptionField)
            //{
            //    manifest.NoField.Properties.AltSearchField = manifest.SearchDescriptionField.Name;
            //    manifest.DescriptionField.Properties.OnValidate.CodeLines.Add(string.Format("IF ({0} = UPPERCASE(xRec.{1})) OR ({0} = '') THEN", manifest.SearchDescriptionField.Name.Quoted(), manifest.DescriptionField.Name.Quoted()));
            //    manifest.DescriptionField.Properties.OnValidate.CodeLines.Add(string.Format("  {0} := {1};", manifest.SearchDescriptionField.Name.Quoted(), manifest.DescriptionField.Name.Quoted()));
            //}

            if (entityType.NeedsDateFilterField())
            {
                manifest.DateFilterField.Properties.FieldClass = FieldClass.FlowFilter;
            }

            manifest.NoSeriesField.Properties.Editable = false;
            manifest.NoSeriesField.Properties.TableRelation.Add("No. Series");

            var onValidate = manifest.NoField.Properties.OnValidate;
            var setupRecordVariable = onValidate.Variables.AddRecordVariable(1000, setupEntityTypeManifest.Table.Name.MakeVariableName(), setupEntityTypeManifest.Table.ID);
            var noSeriesMgtCodeunitVariable = onValidate.Variables.AddCodeunitVariable(1001, "NoSeriesMgt", 396);
            onValidate.CodeLines.Add(string.Format("IF {0} <> xRec.{0} THEN BEGIN", manifest.NoField.Name.Quoted()));
            onValidate.CodeLines.Add(string.Format("  {0}.GET;", setupRecordVariable.Name));
            onValidate.CodeLines.Add(string.Format("  {0}.TestManual({1}.\"{2} Nos.\");", noSeriesMgtCodeunitVariable.Name, setupRecordVariable.Name, entityType.Name));
            onValidate.CodeLines.Add("  \"No. Series\" := '';");
            onValidate.CodeLines.Add("END;");

            var primaryKey = manifest.Table.Keys.Add();
            primaryKey.Fields.Add(manifest.NoField.Name);
            primaryKey.Properties.Clustered = true;

            var secundaryKey = manifest.Table.Keys.Add();
            secundaryKey.Fields.Add(manifest.SearchDescriptionField.Name);

            manifest.Table.FieldGroups.Add(1, "DropDown").Fields.AddRange(manifest.NoField.Name, manifest.DescriptionField.Name);

            var nextFunctionID = 1;

            var assistEdit = manifest.Table.Code.Functions.Add(nextFunctionID++, "AssistEdit");
            var variableName = entityType.Name.MakeVariableName();
            var parameterName = string.Format("Old{0}", variableName);
            var parameter = assistEdit.Parameters.AddRecordParameter(false, 1000, parameterName, manifest.Table.ID);
            assistEdit.Variables.AddRecordVariable(1001, variableName, manifest.Table.ID);
            setupRecordVariable = assistEdit.Variables.AddRecordVariable(1002, setupEntityTypeManifest.Table.Name.MakeVariableName(), setupEntityTypeManifest.Table.ID);
            noSeriesMgtCodeunitVariable = assistEdit.Variables.AddCodeunitVariable(1003, "NoSeriesMgt", 396);
            assistEdit.ReturnValue.Type = FunctionReturnValueType.Boolean;
            assistEdit.CodeLines.Add(string.Format("WITH {0} DO BEGIN", variableName));
            assistEdit.CodeLines.Add(string.Format("  {0} := Rec;", variableName));
            assistEdit.CodeLines.Add(string.Format("  {0}.GET;", setupRecordVariable.Name));
            assistEdit.CodeLines.Add(string.Format("  {0}.TESTFIELD(\"{1} Nos.\");", setupRecordVariable.Name, entityType.Name));
            assistEdit.CodeLines.Add(string.Format("  IF {0}.SelectSeries({1}.\"{2} Nos.\", {3}.{4}, {4}) THEN BEGIN", noSeriesMgtCodeunitVariable.Name, setupRecordVariable.Name, entityType.Name, parameter.Name, manifest.NoSeriesField.Name.Quoted()));
            assistEdit.CodeLines.Add(string.Format("    {0}.GET;", setupRecordVariable.Name));
            assistEdit.CodeLines.Add(string.Format("    {0}.TESTFIELD(\"{1} Nos.\");", setupRecordVariable.Name, entityType.Name));
            assistEdit.CodeLines.Add(string.Format("    {0}.SetSeries({1});", noSeriesMgtCodeunitVariable.Name, manifest.NoField.Name.Quoted()));
            assistEdit.CodeLines.Add(string.Format("    Rec := {0};", variableName));
            assistEdit.CodeLines.Add("    EXIT(TRUE);");
            assistEdit.CodeLines.Add("  END;");
            assistEdit.CodeLines.Add("END;");

            manifest.Table.Properties.DataCaptionFields.Add(manifest.NoField.Name);
            manifest.Table.Properties.DataCaptionFields.Add(manifest.DescriptionField.Name);
            manifest.Table.Properties.LookupPageID = manifest.ListPage.ID;
            manifest.Table.Properties.DrillDownPageID = manifest.ListPage.ID;

            var onInsert = manifest.Table.Properties.OnInsert;
            setupRecordVariable = onInsert.Variables.AddRecordVariable(1000, setupEntityTypeManifest.Table.Name.MakeVariableName(), setupEntityTypeManifest.Table.ID);
            noSeriesMgtCodeunitVariable = onInsert.Variables.AddCodeunitVariable(1001, "NoSeriesMgt", 396);
            onInsert.CodeLines.Add(string.Format("IF {0} = '' THEN BEGIN", manifest.NoField.Name.Quoted()));
            onInsert.CodeLines.Add(string.Format("  {0}.GET;", setupRecordVariable.Name));
            onInsert.CodeLines.Add(string.Format("  {0}.TESTFIELD(\"{1} Nos.\");", setupRecordVariable.Name, entityType.Name));
            onInsert.CodeLines.Add(string.Format("  {0}.InitSeries({1}.\"{2} Nos.\", xRec.{3}, 0D, {4}, {3});", noSeriesMgtCodeunitVariable.Name, setupRecordVariable.Name, entityType.Name, manifest.NoSeriesField.Name.Quoted(), manifest.NoField.Name.Quoted()));
            onInsert.CodeLines.Add("END;");
        }

        private static void FinalizeCardPage(MasterEntityType entityType, RenderingContext renderingContext, MasterEntityTypeManifest manifest)
        {
            var nextControlID = 1000;

            manifest.CardPage.Properties.SourceTable = manifest.Table.ID;
            manifest.CardPage.Properties.RefreshOnActivate = true;

            // FIXME: AddActions(masterEntityType, manifest, renderingContext, ref nextControlID, manifest.CardPage.Properties.ActionList);

            manifest.CardPage.Controls.AddContainerPageControl(nextControlID++, null).Properties.ContainerType = ContainerType.ContentArea;
            manifest.CardPage.Controls.AddGroupPageControl(nextControlID++, 1).Properties.CaptionML.Add("ENU", "General");

            var noControl = manifest.CardPage.Controls.AddFieldPageControl(nextControlID++, 2);
            noControl.Properties.SourceExpr = manifest.NoField.Name.Quoted();
            noControl.Properties.Importance = Importance.Promoted;
            noControl.Properties.OnAssistEdit.CodeLines.Add("IF AssistEdit(xRec) THEN");
            noControl.Properties.OnAssistEdit.CodeLines.Add("  CurrPage.UPDATE;");

            manifest.CardPage.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = manifest.DescriptionField.Name.Quoted();

            if (entityType.HasDescription2Field)
            {
                manifest.CardPage.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = manifest.Description2Field.Name.Quoted();
            }

            if (entityType.HasSearchDescriptionField)
            {
                manifest.CardPage.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = manifest.SearchDescriptionField.Name.Quoted();
            }

            manifest.CardPage.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = manifest.LastDateModifiedField.Name.Quoted();

            manifest.CardPage.Controls.AddContainerPageControl(nextControlID++, null).Properties.ContainerType = ContainerType.FactBoxArea;

            var recordLinksPart = manifest.CardPage.Controls.AddPartPageControl(nextControlID++, 1);
            recordLinksPart.Properties.Visible = false.ToString();
            recordLinksPart.Properties.PartType = PartType.System;
            recordLinksPart.Properties.SystemPartID = SystemPartID.RecordLinks;

            var notesPart = manifest.CardPage.Controls.AddPartPageControl(nextControlID++, 1);
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

            manifest.ListPage.Controls.AddContainerPageControl(nextControlID++, 0).Properties.ContainerType = ContainerType.ContentArea;
            manifest.ListPage.Controls.AddGroupPageControl(nextControlID++, 1).Properties.GroupType = GroupType.Repeater;
            manifest.ListPage.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = manifest.NoField.Name.Quoted();
            manifest.ListPage.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = manifest.DescriptionField.Name.Quoted();
        }

        private static void FinalizeStatisticsPage(MasterEntityType entityType, RenderingContext renderingContext, MasterEntityTypeManifest manifest)
        {
            manifest.StatisticsPage.Properties.SourceTable = manifest.Table.ID;
        }

        private static void AddActions(MasterEntityType masterEntityType, MasterEntityTypeManifest manifest, RenderingContext renderingContext, ref int nextControlID, ActionList actionList)
        {
            // FIXME: Generate actions for all subsidiary entity types
            // FIXME: Generate actions for statistics page (if any)


            actionList.AddPageActionContainer(nextControlID++, null).Properties.ActionContainerType = ActionContainerType.RelatedInformation;
            actionList.AddPageActionGroup(nextControlID++, 1).Properties.CaptionML.Add("ENU", masterEntityType.Name);

            foreach (var keyValuePair in renderingContext.Manifests.OfType<KeyValuePair<LedgerEntityType, LedgerEntityTypeManifest>>())
            {
                if (keyValuePair.Key.MasterEntityType == masterEntityType)
                {
                    var action = actionList.AddPageAction(nextControlID++, 2);
                    action.Properties.CaptionML.Add("ENU", keyValuePair.Key.PluralName);
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
                var action = actionList.AddPageAction(nextControlID++, 2);
                action.Properties.CaptionML.Add("ENU", "Statistics");
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

        private static string DescriptionFieldName(this MasterEntityType masterEntityType)
        {
            switch (masterEntityType.DescriptionStyle)
            {
                case DescriptionStyle.Name:
                    return "Name";
                default:
                    return "Description";
            }
        }

        private static string Description2FieldName(this MasterEntityType masterEntityType)
        {
            return string.Format("{0} 2", masterEntityType.DescriptionFieldName());
        }

        private static string SearchDescriptionFieldName(this MasterEntityType masterEntityType)
        {
            return string.Format("Search {0}", masterEntityType.DescriptionFieldName());
        }

        private static bool NeedsDateFilterField(this MasterEntityType masterEntityType)
        {
            return (masterEntityType.ApplicationDesign.OfType<LedgerEntityType>().Any(e => e.MasterEntityType == masterEntityType && e.HasPostingDateField));
        }
    }
}
