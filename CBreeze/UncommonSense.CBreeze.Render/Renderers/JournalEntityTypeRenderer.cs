using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Model;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Render
{
    public static class JournalEntityTypeRenderer
    {
        internal static JournalEntityTypeManifest Allocate(this JournalEntityType entityType, RenderingContext renderingContext, Application application)
        {
            var manifest = new JournalEntityTypeManifest();

            manifest.TemplateTable = application.Tables.Add(renderingContext.GetNextTableID(), entityType.TemplateName).AutoObjectProperties(renderingContext).AutoCaption();
            manifest.BatchTable = application.Tables.Add(renderingContext.GetNextTableID(), entityType.BatchName).AutoObjectProperties(renderingContext).AutoCaption();
            manifest.LineTable = application.Tables.Add(renderingContext.GetNextTableID(), entityType.LineName).AutoObjectProperties(renderingContext).AutoCaption();
            manifest.TemplatesPage = application.Pages.Add(renderingContext.GetNextPageID(), entityType.TemplatePluralName).AutoObjectProperties(renderingContext).AutoCaption();
            manifest.TemplateListPage = application.Pages.Add(renderingContext.GetNextPageID(), string.Format("{0} List", entityType.TemplateName)).AutoObjectProperties(renderingContext).AutoCaption();
            manifest.BatchesPage = application.Pages.Add(renderingContext.GetNextPageID(), entityType.BatchPluralName).AutoObjectProperties(renderingContext).AutoCaption();
            manifest.JournalPage = application.Pages.Add(renderingContext.GetNextPageID(), entityType.BaseName).AutoObjectProperties(renderingContext).AutoCaption();
            manifest.RecurringJournalPage = application.Pages.Add(renderingContext.GetNextPageID(), string.Format("Recurring {0}", entityType.BaseName)).AutoObjectProperties(renderingContext).AutoCaption();
            manifest.JournalMgtCodeunit = application.Codeunits.Add(renderingContext.GetNextCodeunitID(), string.Format("{0} Mgt", entityType.BaseName)).AutoObjectProperties(renderingContext);

            var nextFieldNo = 1;
            var nextGlobalUID = 1000;
            manifest.TemplateTableNameField = manifest.TemplateTable.Fields.AddCodeTableField(nextFieldNo++, "Name", 10).AutoCaption();
            manifest.TemplateTableDescriptionField = manifest.TemplateTable.Fields.AddTextTableField(nextFieldNo++, "Description", 80).AutoCaption();
            manifest.TemplateTableTestReportIDField = entityType.HasTestReportIDField ? manifest.TemplateTable.Fields.AddIntegerTableField(nextFieldNo++, "Test Report ID").AutoCaption() : null;
            manifest.TemplateTableTestReportCaptionField = entityType.HasTestReportIDField ? manifest.TemplateTable.Fields.AddTextTableField(nextFieldNo++, "Test Report Caption", 250).AutoCaption() : null;
            manifest.TemplateTablePageIDField = manifest.TemplateTable.Fields.AddIntegerTableField(nextFieldNo++, "Page ID").AutoCaption();
            manifest.TemplateTablePageCaptionField = manifest.TemplateTable.Fields.AddTextTableField(nextFieldNo++, "Page Caption", 250).AutoCaption();
            manifest.TemplateTablePostingReportIDField = entityType.HasPostingReportIDField ? manifest.TemplateTable.Fields.AddIntegerTableField(nextFieldNo++, "Posting Report ID").AutoCaption() : null;
            manifest.TemplateTablePostingReportCaptionField = entityType.HasPostingReportIDField ? manifest.TemplateTable.Fields.AddTextTableField(nextFieldNo++, "Posting Report Caption", 250).AutoCaption() : null;
            manifest.TemplateTableForcePostingReportField = entityType.HasPostingReportIDField ? manifest.TemplateTable.Fields.AddBooleanTableField(nextFieldNo++, "Force Posting Report").AutoCaption() : null;
            manifest.TemplateTableSourceCodeField = entityType.HasSourceCodeField ? manifest.TemplateTable.Fields.AddCodeTableField(nextFieldNo++, "Source Code", 10).AutoCaption() : null;
            manifest.TemplateTableReasonCodeField = entityType.HasReasonCodeField ? manifest.TemplateTable.Fields.AddCodeTableField(nextFieldNo++, "Reason Code", 10).AutoCaption() : null;
            manifest.TemplateTableRecurringField = manifest.TemplateTable.Fields.AddBooleanTableField(nextFieldNo++, "Recurring").AutoCaption();
            manifest.TemplateTableNoSeriesField = manifest.TemplateTable.Fields.AddCodeTableField(nextFieldNo++, "No. Series", 10).AutoCaption();
            manifest.TemplateTablePostingNoSeriesField = manifest.TemplateTable.Fields.AddCodeTableField(nextFieldNo++, "Posting No. Series", 10).AutoCaption();
            manifest.TemplateTableText000 = manifest.TemplateTable.Code.Variables.AddTextConstant(nextGlobalUID++, "Text000");
            manifest.TemplateTableText001 = manifest.TemplateTable.Code.Variables.AddTextConstant(nextGlobalUID++, "Text001");

            nextFieldNo = 1;
            nextGlobalUID = 1000;
            var nextFunctionID = 1;
            manifest.BatchTableJournalTemplateNameField = manifest.BatchTable.Fields.AddCodeTableField(nextFieldNo++, "Journal Template Name", 10).AutoCaption();
            manifest.BatchTableNameField = manifest.BatchTable.Fields.AddCodeTableField(nextFieldNo++, "Name", 10).AutoCaption();
            manifest.BatchTableDescriptionField = manifest.BatchTable.Fields.AddTextTableField(nextFieldNo++, "Description", 50).AutoCaption();
            manifest.BatchTableReasonCodeField = entityType.HasReasonCodeField ? manifest.BatchTable.Fields.AddCodeTableField(nextFieldNo++, "Reason Code", 10).AutoCaption() : null;
            manifest.BatchTableNoSeriesField = manifest.BatchTable.Fields.AddCodeTableField(nextFieldNo++, "No. Series", 10).AutoCaption();
            manifest.BatchTablePostingNoSeriesField = manifest.BatchTable.Fields.AddCodeTableField(nextFieldNo++, "Posting No. Series", 10).AutoCaption();
            manifest.BatchTableRecurringField = manifest.BatchTable.Fields.AddBooleanTableField(nextFieldNo++, "Recurring").AutoCaption();
            manifest.BatchTableText000 = manifest.BatchTable.Code.Variables.AddTextConstant(nextGlobalUID++, "Text000");
            manifest.BatchTableSetupNewBatchFunction = manifest.BatchTable.Code.Functions.Add(nextFunctionID++, "SetupNewBatch");

            nextFieldNo = 1;
            manifest.LineTableJournalTemplateNameField = manifest.LineTable.Fields.AddCodeTableField(nextFieldNo++, "Journal Template Name", 10).AutoCaption();
            manifest.LineTableJournalBatchNameField = manifest.LineTable.Fields.AddCodeTableField(nextFieldNo++, "Journal Batch Name", 10).AutoCaption();
            manifest.LineTableLineNoField = manifest.LineTable.Fields.AddIntegerTableField(nextFieldNo++, "Line No.").AutoCaption();
            manifest.LineTablePostingDateField = manifest.LineTable.Fields.AddDateTableField(nextFieldNo++, "Posting Date").AutoCaption();
            manifest.LineTableMasterEntityTypeField = entityType.MasterEntityType != null ? manifest.LineTable.Fields.AddCodeTableField(nextFieldNo++, string.Format("{0} No.", entityType.MasterEntityType.Name), 20).AutoCaption() : null;
            manifest.LineTableDescriptionField = manifest.LineTable.Fields.AddTextTableField(nextFieldNo++, "Description", 50).AutoCaption();
            manifest.LineTableSourceCodeField = entityType.HasSourceCodeField ? manifest.LineTable.Fields.AddCodeTableField(nextFieldNo++, "Source Code", 10).AutoCaption() : null;
            manifest.LineTableReasonCodeField = entityType.HasReasonCodeField ? manifest.LineTable.Fields.AddCodeTableField(nextFieldNo++, "Reason Code", 10).AutoCaption() : null;
            manifest.LineTableDocumentDateField = manifest.LineTable.Fields.AddDateTableField(nextFieldNo++, "Document Date").AutoCaption();

            nextFunctionID = 1;
            manifest.TemplateSelectionFunction = manifest.JournalMgtCodeunit.Code.Functions.Add(nextFunctionID++, "TemplateSelection");
            manifest.TemplateSelectionFromBatchFunction = manifest.JournalMgtCodeunit.Code.Functions.Add(nextFunctionID++, "TemplateSelectionFromBatch");
            manifest.OpenJnlFunction = manifest.JournalMgtCodeunit.Code.Functions.Add(nextFunctionID++, "OpenJnl");
            manifest.OpenJnlBatchFunction = manifest.JournalMgtCodeunit.Code.Functions.Add(nextFunctionID++, "OpenJnlBatch");
            manifest.CheckTemplateNameFunction = manifest.JournalMgtCodeunit.Code.Functions.Add(nextFunctionID++, "CheckTemplateName");
            manifest.CheckNameFunction = manifest.JournalMgtCodeunit.Code.Functions.Add(nextFunctionID++, "CheckName");
            manifest.SetNameFunction = manifest.JournalMgtCodeunit.Code.Functions.Add(nextFunctionID++, "SetName");
            manifest.LookupNameFunction = manifest.JournalMgtCodeunit.Code.Functions.Add(nextFunctionID++, "LookupName");

            nextGlobalUID = 1000;
            manifest.OpenFromBatchVariable = manifest.JournalMgtCodeunit.Code.Variables.AddBooleanVariable(nextGlobalUID++, "OpenFromBatch");
            manifest.JournalMgtCodeunitText000 = manifest.JournalMgtCodeunit.Code.Variables.AddTextConstant(nextGlobalUID++, "Text000");
            manifest.JournalMgtCodeunitText001 = manifest.JournalMgtCodeunit.Code.Variables.AddTextConstant(nextGlobalUID++, "Text001");
            manifest.JournalMgtCodeunitText002 = manifest.JournalMgtCodeunit.Code.Variables.AddTextConstant(nextGlobalUID++, "Text002");
            manifest.JournalMgtCodeunitText003 = manifest.JournalMgtCodeunit.Code.Variables.AddTextConstant(nextGlobalUID++, "Text003");
            manifest.JournalMgtCodeunitText004 = manifest.JournalMgtCodeunit.Code.Variables.AddTextConstant(nextGlobalUID++, "Text004");
            manifest.JournalMgtCodeunitText005 = manifest.JournalMgtCodeunit.Code.Variables.AddTextConstant(nextGlobalUID++, "Text005");

            return manifest;
        }

        internal static void Finalize(this JournalEntityType entityType, RenderingContext renderingContext, JournalEntityTypeManifest manifest)
        {
            FinalizeTemplateTable(entityType, renderingContext, manifest);
            FinalizeBatchTable(entityType, renderingContext, manifest);
            FinalizeLineTable(entityType, renderingContext, manifest);
            FinalizeTemplatesPage(entityType, renderingContext, manifest);
            FinalizeTemplateListPage(entityType, renderingContext, manifest);
            FinalizeBatchesPage(entityType, renderingContext, manifest);
            FinalizeJournalPage(entityType, renderingContext, manifest);
            FinalizeJournalMgtCodeunit(entityType, renderingContext, manifest);
        }

        private static void FinalizeTemplateTable(JournalEntityType entityType, RenderingContext renderingContext, JournalEntityTypeManifest manifest)
        {
            TableRelationLine tableRelationLine = null;
            CodeLines codeLines = null;

            manifest.TemplateTablePrimaryKey = manifest.TemplateTable.Keys.Add();
            manifest.TemplateTablePrimaryKey.Fields.Add(manifest.TemplateTableNameField.Name);
            manifest.TemplateTablePrimaryKey.Properties.Clustered = true;

            manifest.TemplateTableNameField.Properties.NotBlank = true;

            manifest.TemplateTableText000.Values.Add("ENU", "Only the %1 field can be filled in on recurring journals.");
            manifest.TemplateTableText001.Values.Add("ENU", "must not be %1");

            if (entityType.HasTestReportIDField)
            {
                tableRelationLine = manifest.TemplateTableTestReportIDField.Properties.TableRelation.Add("Object");
                tableRelationLine.FieldName = "ID";
                tableRelationLine.TableFilter.Add("Type", TableRelationTableFilterLineType.Const, "Report");

                manifest.TemplateTableTestReportCaptionField.Properties.FieldClass = FieldClass.FlowField;
                manifest.TemplateTableTestReportCaptionField.Properties.Editable = false;
                manifest.TemplateTableTestReportCaptionField.Properties.CalcFormula.Method = CalcFormulaMethod.Lookup;
                manifest.TemplateTableTestReportCaptionField.Properties.CalcFormula.TableName = "AllObjWithCaption";
                manifest.TemplateTableTestReportCaptionField.Properties.CalcFormula.FieldName = "Object Caption";
                manifest.TemplateTableTestReportCaptionField.Properties.CalcFormula.TableFilter.Add("Object Type", CalcFormulaTableFilterType.Const, "Report");
                manifest.TemplateTableTestReportCaptionField.Properties.CalcFormula.TableFilter.Add("Object ID", CalcFormulaTableFilterType.Field, manifest.TemplateTableTestReportIDField.Name);
            }

            tableRelationLine = manifest.TemplateTablePageIDField.Properties.TableRelation.Add("Object");
            tableRelationLine.FieldName = "ID";
            tableRelationLine.TableFilter.Add("Type", TableRelationTableFilterLineType.Const, "Page");

            manifest.TemplateTablePageCaptionField.Properties.FieldClass = FieldClass.FlowField;
            manifest.TemplateTablePageCaptionField.Properties.Editable = false;
            manifest.TemplateTablePageCaptionField.Properties.CalcFormula.Method = CalcFormulaMethod.Lookup;
            manifest.TemplateTablePageCaptionField.Properties.CalcFormula.TableName = "AllObjWithCaption";
            manifest.TemplateTablePageCaptionField.Properties.CalcFormula.FieldName = "Object Caption";
            manifest.TemplateTablePageCaptionField.Properties.CalcFormula.TableFilter.Add("Object Type", CalcFormulaTableFilterType.Const, "Page");
            manifest.TemplateTablePageCaptionField.Properties.CalcFormula.TableFilter.Add("Object ID", CalcFormulaTableFilterType.Field, manifest.TemplateTablePageIDField.Name);

            if (entityType.HasPostingReportIDField)
            {
                tableRelationLine = manifest.TemplateTablePostingReportIDField.Properties.TableRelation.Add("Object");
                tableRelationLine.FieldName = "ID";
                tableRelationLine.TableFilter.Add("Type", TableRelationTableFilterLineType.Const, "Report");

                manifest.TemplateTablePostingReportCaptionField.Properties.FieldClass = FieldClass.FlowField;
                manifest.TemplateTablePostingReportCaptionField.Properties.Editable = false;
                manifest.TemplateTablePostingReportCaptionField.Properties.CalcFormula.Method = CalcFormulaMethod.Lookup;
                manifest.TemplateTablePostingReportCaptionField.Properties.CalcFormula.TableName = "AllObjWithCaption";
                manifest.TemplateTablePostingReportCaptionField.Properties.CalcFormula.FieldName = "Object Caption";
                manifest.TemplateTablePostingReportCaptionField.Properties.CalcFormula.TableFilter.Add("Object Type", CalcFormulaTableFilterType.Const, "Report");
                manifest.TemplateTablePostingReportCaptionField.Properties.CalcFormula.TableFilter.Add("Object ID", CalcFormulaTableFilterType.Field, manifest.TemplateTablePostingReportIDField.Name);
            }

            var nextUID = 1000;

            if (entityType.HasSourceCodeField)
            {
                manifest.TemplateTableSourceCodeField.Properties.TableRelation.Add("Source Code");
                var onValidate = manifest.TemplateTableSourceCodeField.Properties.OnValidate;
                onValidate.Variables.AddRecordVariable(nextUID++, manifest.LineTable.Name.MakeVariableName(), manifest.LineTable.ID);
                onValidate.CodeLines.Add("{0}.SETRANGE(\"Journal Template Name\",{1});", manifest.LineTable.Name.MakeVariableName(), manifest.TemplateTableNameField.Name.Quoted());
                onValidate.CodeLines.Add("{0}.MODIFYALL({1}, {2});", manifest.LineTable.Name.MakeVariableName(), manifest.LineTableSourceCodeField.Name.Quoted(), manifest.TemplateTableSourceCodeField.Name.Quoted());
                onValidate.CodeLines.Add("MODIFY;");
            }

            if (entityType.HasReasonCodeField)
            {
                manifest.TemplateTableReasonCodeField.Properties.TableRelation.Add("Reason Code");
            }

            codeLines = manifest.TemplateTableRecurringField.Properties.OnValidate.CodeLines;
            codeLines.Add("IF {0} THEN", manifest.TemplateTableRecurringField.Name.Quoted());
            codeLines.Add("  {0} := PAGE::{1}", manifest.TemplateTablePageIDField.Name.Quoted(), manifest.RecurringJournalPage.Name.Quoted());
            codeLines.Add("ELSE");
            codeLines.Add("  {0} := PAGE::{1};", manifest.TemplateTablePageIDField.Name.Quoted(), manifest.JournalPage.Name.Quoted());
            codeLines.Add("");
            codeLines.Add("// TODO: Assign a default value to {0}", manifest.TemplateTableTestReportIDField.Name.Quoted());
            codeLines.Add("// TODO: Assign a default value to {0}", manifest.TemplateTablePostingReportIDField.Name.Quoted());

            if (entityType.HasSourceCodeField)
            {
                codeLines.Add("");
                codeLines.Add("// TODO: SourceCodeSetup.GET;");
                codeLines.Add("// TODO: {0} := SourceCodeSetup.{1};", manifest.TemplateTableSourceCodeField.Name.Quoted(), entityType.BaseName);
            }

            codeLines.Add("");
            codeLines.Add("IF {0} THEN", manifest.TemplateTableRecurringField.Name.Quoted());
            codeLines.Add("  TESTFIELD({0}, '');", manifest.TemplateTableNoSeriesField.Name.Quoted());

            codeLines = manifest.TemplateTablePageIDField.Properties.OnValidate.CodeLines;
            codeLines.Add("IF {0} = 0 THEN", manifest.TemplateTablePageIDField.Name.Quoted());
            codeLines.Add("  VALIDATE({0});", manifest.TemplateTableRecurringField.Name.Quoted());

            manifest.TemplateTableNoSeriesField.Properties.TableRelation.Add("No. Series");
            codeLines = manifest.TemplateTableNoSeriesField.Properties.OnValidate.CodeLines;
            codeLines.Add("IF {0} <> '' THEN BEGIN", manifest.TemplateTableNoSeriesField.Name.Quoted());
            codeLines.Add("  IF {0} THEN", manifest.TemplateTableRecurringField.Name.Quoted());
            codeLines.Add("    ERROR(");
            codeLines.Add("      {0},", manifest.TemplateTableText000.Name);
            codeLines.Add("      FIELDCAPTION({0}));", manifest.TemplateTablePostingNoSeriesField.Name.Quoted());
            codeLines.Add("  IF {0} = {1} THEN", manifest.TemplateTableNoSeriesField.Name.Quoted(), manifest.TemplateTablePostingNoSeriesField.Name.Quoted()); 
            codeLines.Add("    {0} := '';", manifest.TemplateTablePostingNoSeriesField.Name.Quoted());
            codeLines.Add("END;");

            manifest.TemplateTablePostingNoSeriesField.Properties.TableRelation.Add("No. Series");
            codeLines = manifest.TemplateTablePostingNoSeriesField.Properties.OnValidate.CodeLines;
            codeLines.Add("IF ({0} = {1}) AND ({0} <> '') THEN", manifest.TemplateTablePostingNoSeriesField.Name.Quoted(), manifest.TemplateTableNoSeriesField.Name.Quoted());
            codeLines.Add("  FIELDERROR({0}, STRSUBSTNO({1}, {2}));", manifest.TemplateTablePostingNoSeriesField.Name.Quoted(), manifest.TemplateTableText001.Name, manifest.TemplateTablePostingNoSeriesField.Name.Quoted());

            manifest.TemplateTable.Properties.OnInsert.CodeLines.Add("VALIDATE({0});", manifest.TemplateTablePageIDField.Name.Quoted());

            nextUID = 1000;
            var onDelete = manifest.TemplateTable.Properties.OnDelete;
            onDelete.Variables.AddRecordVariable(nextUID++, manifest.LineTable.Name.MakeVariableName(), manifest.LineTable.ID);
            onDelete.Variables.AddRecordVariable(nextUID++, manifest.BatchTable.Name.MakeVariableName(), manifest.BatchTable.ID);
            onDelete.CodeLines.Add("{0}.SETRANGE(\"Journal Template Name\", Name);", manifest.LineTable.Name.MakeVariableName());
            onDelete.CodeLines.Add("{0}.DELETEALL(TRUE);", manifest.LineTable.Name.MakeVariableName());
            onDelete.CodeLines.Add("{0}.SETRANGE(\"Journal Template Name\", Name);", manifest.BatchTable.Name.MakeVariableName());
            onDelete.CodeLines.Add("{0}.DELETEALL(TRUE);", manifest.BatchTable.Name.MakeVariableName());

            manifest.TemplateTable.Properties.LookupPageID = manifest.TemplateListPage.ID;
            manifest.TemplateTable.Properties.DrillDownPageID = manifest.TemplateListPage.ID;
        }

        private static void FinalizeBatchTable(JournalEntityType entityType, RenderingContext renderingContext, JournalEntityTypeManifest manifest)
        {
            manifest.BatchTablePrimaryKey = manifest.BatchTable.Keys.Add();
            manifest.BatchTablePrimaryKey.Fields.Add(manifest.BatchTableJournalTemplateNameField.Name);
            manifest.BatchTablePrimaryKey.Fields.Add(manifest.BatchTableNameField.Name);
            manifest.BatchTablePrimaryKey.Properties.Clustered = true;

            manifest.BatchTable.Properties.DataCaptionFields.AddRange(manifest.BatchTableNameField.Name, manifest.BatchTableDescriptionField.Name);
            manifest.BatchTable.Properties.LookupPageID = manifest.BatchesPage.ID;

            var onInsert = manifest.BatchTable.Properties.OnInsert;
            var nextUID = 1000;
            var recordVariable = onInsert.Variables.AddRecordVariable(nextUID++, manifest.TemplateTable.Name.MakeVariableName(), manifest.TemplateTable.ID);
            onInsert.CodeLines.Add("LOCKTABLE;");
            onInsert.CodeLines.Add("{0}.GET({1});", recordVariable.Name, manifest.BatchTableJournalTemplateNameField.Name.Quoted());

            var onDelete = manifest.BatchTable.Properties.OnDelete;
            nextUID = 1000;
            recordVariable = onDelete.Variables.AddRecordVariable(nextUID++, manifest.LineTable.Name.MakeVariableName(), manifest.LineTable.ID);
            onDelete.CodeLines.Add("{0}.SETRANGE({1}, {2});", recordVariable.Name, manifest.LineTableJournalTemplateNameField.Name.Quoted(), manifest.BatchTableJournalTemplateNameField.Name.Quoted());
            onDelete.CodeLines.Add("{0}.SETRANGE({1}, {2});", recordVariable.Name, manifest.LineTableJournalBatchNameField.Name.Quoted(), manifest.BatchTableNameField.Name.Quoted());
            onDelete.CodeLines.Add("{0}.DELETEALL(TRUE);", recordVariable.Name);

            var onRename = manifest.BatchTable.Properties.OnRename;
            nextUID = 1000;
            recordVariable = onRename.Variables.AddRecordVariable(nextUID++, manifest.LineTable.Name.MakeVariableName(), manifest.LineTable.ID);
            onRename.CodeLines.Add("{0}.SETRANGE({1}, xRec.{2});", recordVariable.Name, manifest.LineTableJournalTemplateNameField.Name.Quoted(), manifest.BatchTableJournalTemplateNameField.Name.Quoted());
            onRename.CodeLines.Add("{0}.SETRANGE({1}, xRec.{2});", recordVariable.Name, manifest.LineTableJournalBatchNameField.Name.Quoted(), manifest.BatchTableNameField.Name.Quoted());
            onRename.CodeLines.Add("WHILE {0}.FINDFIRST DO", recordVariable.Name);
            onRename.CodeLines.Add("  {0}.RENAME({1}, {2}, {0}.{3});", recordVariable.Name, manifest.BatchTableJournalTemplateNameField.Name.Quoted(), manifest.BatchTableNameField.Name.Quoted(), manifest.LineTableLineNoField.Name.Quoted());

            manifest.BatchTableJournalTemplateNameField.Properties.TableRelation.Add(manifest.TemplateTable.Name);
            manifest.BatchTableNameField.Properties.NotBlank = true;

            manifest.BatchTableText000.Values.Add("ENU", "Only the %1 field can be filled in on recurring journals.");

            Trigger onValidate = null;

            if (entityType.HasReasonCodeField)
            {
                manifest.BatchTableReasonCodeField.Properties.TableRelation.Add("Reason Code");

                onValidate = manifest.BatchTableReasonCodeField.Properties.OnValidate;
                nextUID = 1000;
                recordVariable = onValidate.Variables.AddRecordVariable(nextUID++, manifest.LineTable.Name.MakeVariableName(), manifest.LineTable.ID);
                onValidate.CodeLines.Add("IF {0} <> xRec.{0} THEN BEGIN", manifest.BatchTableReasonCodeField.Name.Quoted());
                onValidate.CodeLines.Add("  {0}.SETRANGE({1}, {2});", recordVariable.Name, manifest.LineTableJournalTemplateNameField.Name.Quoted(), manifest.BatchTableJournalTemplateNameField.Name.Quoted());
                onValidate.CodeLines.Add("  {0}.SETRANGE({1}, {2});", recordVariable.Name, manifest.LineTableJournalBatchNameField.Name.Quoted(), manifest.BatchTableNameField.Name.Quoted());
                onValidate.CodeLines.Add("  {0}.MODIFYALL({1}, {2});", recordVariable.Name, manifest.LineTableReasonCodeField.Name.Quoted(), manifest.BatchTableReasonCodeField.Name.Quoted());
                onValidate.CodeLines.Add("  MODIFY;");
                onValidate.CodeLines.Add("END;");
            }

            manifest.BatchTableNoSeriesField.Properties.TableRelation.Add("No. Series");
            onValidate = manifest.BatchTableNoSeriesField.Properties.OnValidate;
            nextUID = 1000;
            var journalTemplateVariable = onValidate.Variables.AddRecordVariable(nextUID++, manifest.TemplateTable.Name.MakeVariableName(), manifest.TemplateTable.ID);
            onValidate.CodeLines.Add("IF {0} <> '' THEN BEGIN", manifest.BatchTableNoSeriesField.Name.Quoted());
            onValidate.CodeLines.Add("  {0}.GET({1});", journalTemplateVariable.Name, manifest.BatchTableJournalTemplateNameField.Name.Quoted());
            onValidate.CodeLines.Add("  IF {0}.{1} THEN", journalTemplateVariable.Name, manifest.TemplateTableRecurringField.Name.Quoted());
            onValidate.CodeLines.Add("    ERROR(");
            onValidate.CodeLines.Add("      {0},", manifest.BatchTableText000.Name.Quoted());
            onValidate.CodeLines.Add("      FIELDCAPTION({0}));", manifest.BatchTablePostingNoSeriesField.Name.Quoted());
            onValidate.CodeLines.Add("  IF {0} = {1} THEN", manifest.BatchTableNoSeriesField.Name.Quoted(), manifest.BatchTablePostingNoSeriesField.Name.Quoted());
            onValidate.CodeLines.Add("    VALIDATE({0},'');", manifest.BatchTablePostingNoSeriesField.Name.Quoted());
            onValidate.CodeLines.Add("END;");

            manifest.BatchTablePostingNoSeriesField.Properties.TableRelation.Add("No Series");

            //            IF ("Posting No. Series" = "No. Series") AND ("Posting No. Series" <> '') THEN
            //  FIELDERROR("Posting No. Series",STRSUBSTNO(Text001,"Posting No. Series"));
            //ResJnlLine.SETRANGE("Journal Template Name","Journal Template Name");
            //ResJnlLine.SETRANGE("Journal Batch Name",Name);
            //ResJnlLine.MODIFYALL("Posting No. Series","Posting No. Series");
            //MODIFY;

            manifest.BatchTableRecurringField.Properties.FieldClass = FieldClass.FlowField;
            manifest.BatchTableRecurringField.Properties.Editable = false;
            manifest.BatchTableRecurringField.Properties.CalcFormula.Method = CalcFormulaMethod.Lookup;
            manifest.BatchTableRecurringField.Properties.CalcFormula.TableName = manifest.TemplateTable.Name;
            manifest.BatchTableRecurringField.Properties.CalcFormula.FieldName = manifest.TemplateTableRecurringField.Name;
            manifest.BatchTableRecurringField.Properties.CalcFormula.TableFilter.Add(manifest.TemplateTableNameField.Name, CalcFormulaTableFilterType.Field, manifest.BatchTableJournalTemplateNameField.Name);

            nextUID = 1000;
            var templateTableVariable = manifest.BatchTableSetupNewBatchFunction.Variables.AddRecordVariable(nextUID++, manifest.TemplateTable.Name.MakeVariableName(), manifest.TemplateTable.ID);
            manifest.BatchTableSetupNewBatchFunction.CodeLines.Add("{0}.GET({1});", templateTableVariable.Name, manifest.BatchTableJournalTemplateNameField.Name.Quoted());
            manifest.BatchTableSetupNewBatchFunction.CodeLines.Add("{0} := {1}.{2};", manifest.BatchTableNoSeriesField.Name.Quoted(), templateTableVariable.Name, manifest.TemplateTableNoSeriesField.Name.Quoted());
            manifest.BatchTableSetupNewBatchFunction.CodeLines.Add("{0} := {1}.{2};", manifest.BatchTablePostingNoSeriesField.Name.Quoted(), templateTableVariable.Name, manifest.TemplateTablePostingNoSeriesField.Name.Quoted());
            manifest.BatchTableSetupNewBatchFunction.CodeLines.Add("{0} := {1}.{2};", manifest.BatchTableReasonCodeField.Name.Quoted(), templateTableVariable.Name, manifest.TemplateTableReasonCodeField.Name.Quoted());
        }

        private static void FinalizeLineTable(JournalEntityType entityType, RenderingContext renderingContext, JournalEntityTypeManifest manifest)
        {
            var nextUID = 1000;
            var onInsert = manifest.LineTable.Properties.OnInsert;
            var templateVariable = onInsert.Variables.AddRecordVariable(nextUID++, manifest.TemplateTable.Name.MakeVariableName(), manifest.TemplateTable.ID);
            var batchVariable = onInsert.Variables.AddRecordVariable(nextUID++, manifest.BatchTable.Name.MakeVariableName(), manifest.BatchTable.ID);
            onInsert.CodeLines.Add("LOCKTABLE;");
            onInsert.CodeLines.Add("{0}.GET({1});", templateVariable.Name, manifest.LineTableJournalTemplateNameField.Name.Quoted());
            onInsert.CodeLines.Add("{0}.GET({1},{2});", batchVariable.Name, manifest.LineTableJournalTemplateNameField.Name.Quoted(), manifest.LineTableJournalBatchNameField.Name.Quoted());

            manifest.LineTablePrimaryKey = manifest.LineTable.Keys.Add();
            manifest.LineTablePrimaryKey.Fields.Add(manifest.LineTableJournalTemplateNameField.Name);
            manifest.LineTablePrimaryKey.Fields.Add(manifest.LineTableJournalBatchNameField.Name);
            manifest.LineTablePrimaryKey.Fields.Add(manifest.LineTableLineNoField.Name);
            manifest.LineTablePrimaryKey.Properties.Clustered = true;

            manifest.LineTableJournalTemplateNameField.Properties.TableRelation.Add(manifest.TemplateTable.Name);

            var tableRelationLine = manifest.LineTableJournalBatchNameField.Properties.TableRelation.Add(manifest.BatchTable.Name);
            tableRelationLine.FieldName = manifest.BatchTableNameField.Name.Quoted();
            tableRelationLine.TableFilter.Add(manifest.BatchTableJournalTemplateNameField.Name.Quoted(), TableRelationTableFilterLineType.Field, manifest.LineTableJournalTemplateNameField.Name.Quoted());

            manifest.LineTablePostingDateField.Properties.OnValidate.CodeLines.Add("VALIDATE({0},{1});", manifest.LineTableDocumentDateField.Name.Quoted(), manifest.LineTablePostingDateField.Name.Quoted());

            if (entityType.MasterEntityType != null)
            {
                manifest.LineTableMasterEntityTypeField.Properties.TableRelation.Add(entityType.MasterEntityType.Name);

                nextUID = 1000;
                var onValidate = manifest.LineTableMasterEntityTypeField.Properties.OnValidate;
                var masterEntityTypeManifest = renderingContext.GetManifest(entityType.MasterEntityType) as MasterEntityTypeManifest;
                var recordVariable = onValidate.Variables.AddRecordVariable(nextUID++, entityType.MasterEntityType.Name.MakeVariableName(), masterEntityTypeManifest.Table.ID);
                onValidate.CodeLines.Add("IF NOT {0}.GET({1}) THEN", recordVariable.Name, manifest.LineTableMasterEntityTypeField.Name.Quoted());
                onValidate.CodeLines.Add("  {0}.INIT;", recordVariable.Name);
                onValidate.CodeLines.Add("");
                onValidate.CodeLines.Add("{0} := {1}.{2};", manifest.LineTableDescriptionField.Name.Quoted(), recordVariable.Name, masterEntityTypeManifest.DescriptionField.Name.Quoted());
            }

            if (entityType.HasSourceCodeField)
            {
                manifest.LineTableSourceCodeField.Properties.TableRelation.Add("Source Code");
                manifest.LineTableSourceCodeField.Properties.Editable = false;
            }

            if (entityType.HasReasonCodeField)
            {
                manifest.LineTableReasonCodeField.Properties.TableRelation.Add("Reason Code");
            }
        }

        private static void FinalizeTemplatesPage(JournalEntityType entityType, RenderingContext renderingContext, JournalEntityTypeManifest manifest)
        {
            manifest.TemplatesPage.Properties.SourceTable = manifest.TemplateTable.ID;
            manifest.TemplatesPage.Properties.PageType = PageType.List;

            var nextControlID = 1;
            var actions = manifest.TemplatesPage.Properties.ActionList;

            var container = actions.AddPageActionContainer(nextControlID++, 0).Properties.ActionContainerType = ActionContainerType.RelatedInformation;

            var group = actions.AddPageActionGroup(nextControlID++, 1);
            group.Properties.Image = "Template";
            group.Properties.CaptionML.Add("ENU", "Te&mplate");

            var action = actions.AddPageAction(nextControlID++, 2);
            action.Properties.CaptionML.Add("ENU", "Batches");
            action.Properties.RunObject.Type = RunObjectType.Page;
            action.Properties.RunObject.ID = manifest.BatchesPage.ID;
            action.Properties.RunPageLink.Add(manifest.BatchTableJournalTemplateNameField.Name.Quoted(), RunObjectLinkLineType.Field, manifest.TemplateTableNameField.Name.Quoted());
            action.Properties.Image = "Description";

            manifest.TemplatesPage.Controls.AddContainerPageControl(nextControlID++, 0).Properties.ContainerType = ContainerType.ContentArea;
            manifest.TemplatesPage.Controls.AddGroupPageControl(nextControlID++, 1).Properties.GroupType = GroupType.Repeater;
            manifest.TemplatesPage.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = manifest.TemplateTableNameField.Name.Quoted();
            manifest.TemplatesPage.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = manifest.TemplateTableDescriptionField.Name.Quoted();

            if (entityType.HasSourceCodeField)
            {
                manifest.TemplatesPage.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = manifest.TemplateTableSourceCodeField.Name.Quoted();
            }

            if (entityType.HasReasonCodeField)
            {
                manifest.TemplatesPage.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = manifest.TemplateTableReasonCodeField.Name.Quoted();
            }

            var fieldPageControl = manifest.TemplatesPage.Controls.AddFieldPageControl(nextControlID++, 2);
            fieldPageControl.Properties.Visible = false.ToString();
            fieldPageControl.Properties.SourceExpr = manifest.TemplateTablePageIDField.Name.Quoted();
            fieldPageControl.Properties.LookupPageID = "Objects";

            fieldPageControl = manifest.TemplatesPage.Controls.AddFieldPageControl(nextControlID++, 2);
            fieldPageControl.Properties.DrillDown = false;
            fieldPageControl.Properties.SourceExpr = manifest.TemplateTablePageCaptionField.Name.Quoted();
            fieldPageControl.Properties.Visible = false.ToString();

            if (entityType.HasTestReportIDField)
            {
                fieldPageControl = manifest.TemplatesPage.Controls.AddFieldPageControl(nextControlID++, 2);
                fieldPageControl.Properties.SourceExpr = manifest.TemplateTableTestReportIDField.Name.Quoted();
                fieldPageControl.Properties.Visible = false.ToString();
                fieldPageControl.Properties.LookupPageID = "Objects";

                fieldPageControl = manifest.TemplatesPage.Controls.AddFieldPageControl(nextControlID++, 2);
                fieldPageControl.Properties.DrillDown = false;
                fieldPageControl.Properties.SourceExpr = manifest.TemplateTableTestReportCaptionField.Name.Quoted();
                fieldPageControl.Properties.Visible = false.ToString();
            }

            if (entityType.HasPostingReportIDField)
            {
                fieldPageControl = manifest.TemplatesPage.Controls.AddFieldPageControl(nextControlID++, 2);
                fieldPageControl.Properties.SourceExpr = manifest.TemplateTablePostingReportIDField.Name.Quoted();
                fieldPageControl.Properties.Visible = false.ToString();
                fieldPageControl.Properties.LookupPageID = "Objects";

                fieldPageControl = manifest.TemplatesPage.Controls.AddFieldPageControl(nextControlID++, 2);
                fieldPageControl.Properties.DrillDown = false;
                fieldPageControl.Properties.SourceExpr = manifest.TemplateTablePostingReportCaptionField.Name.Quoted();
                fieldPageControl.Properties.Visible = false.ToString();

                fieldPageControl = manifest.TemplatesPage.Controls.AddFieldPageControl(nextControlID++, 2);
                fieldPageControl.Properties.SourceExpr = manifest.TemplateTableForcePostingReportField.Name.Quoted();
                fieldPageControl.Properties.Visible = false.ToString();
            }

            manifest.TemplatesPage.Controls.AddContainerPageControl(nextControlID++, 0).Properties.ContainerType = ContainerType.FactBoxArea;

            var partPageControl = manifest.TemplatesPage.Controls.AddPartPageControl(nextControlID++, 1);
            partPageControl.Properties.Visible = false.ToString();
            partPageControl.Properties.PartType = PartType.System;
            partPageControl.Properties.SystemPartID = SystemPartID.RecordLinks;

            partPageControl = manifest.TemplatesPage.Controls.AddPartPageControl(nextControlID++, 1);
            partPageControl.Properties.Visible = false.ToString();
            partPageControl.Properties.PartType = PartType.System;
            partPageControl.Properties.SystemPartID = SystemPartID.Notes;
        }

        private static void FinalizeTemplateListPage(JournalEntityType entityType, RenderingContext renderingContext, JournalEntityTypeManifest manifest)
        {
            manifest.TemplateListPage.Properties.Editable = false;
            manifest.TemplateListPage.Properties.SourceTable = manifest.TemplateTable.ID;
            manifest.TemplateListPage.Properties.PageType = PageType.List;
            manifest.TemplateListPage.Properties.RefreshOnActivate = true;

            var nextControlID = 1;
            manifest.TemplateListPage.Controls.AddContainerPageControl(nextControlID++, 0).Properties.ContainerType = ContainerType.ContentArea;
            manifest.TemplateListPage.Controls.AddGroupPageControl(nextControlID++, 1).Properties.GroupType = GroupType.Repeater;
            manifest.TemplateListPage.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = manifest.TemplateTableNameField.Name.Quoted();
            manifest.TemplateListPage.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = manifest.TemplateTableDescriptionField.Name.Quoted();

            var fieldPageControl = manifest.TemplateListPage.Controls.AddFieldPageControl(nextControlID++, 2);
            fieldPageControl.Properties.SourceExpr = manifest.TemplateTableRecurringField.Name.Quoted();
            fieldPageControl.Properties.Visible = false.ToString();

            if (entityType.HasSourceCodeField)
            {
                fieldPageControl = manifest.TemplateListPage.Controls.AddFieldPageControl(nextControlID++, 2);
                fieldPageControl.Properties.SourceExpr = manifest.TemplateTableSourceCodeField.Name.Quoted();
                fieldPageControl.Properties.Visible = false.ToString();
            }

            if (entityType.HasReasonCodeField)
            {
                fieldPageControl = manifest.TemplateListPage.Controls.AddFieldPageControl(nextControlID++, 2);
                fieldPageControl.Properties.SourceExpr = manifest.TemplateTableReasonCodeField.Name.Quoted();
                fieldPageControl.Properties.Visible = false.ToString();
            }

            fieldPageControl = manifest.TemplateListPage.Controls.AddFieldPageControl(nextControlID++, 2);
            fieldPageControl.Properties.SourceExpr = manifest.TemplateTablePageIDField.Name.Quoted();
            fieldPageControl.Properties.Visible = false.ToString();
            fieldPageControl.Properties.LookupPageID = "Objects";

            if (entityType.HasTestReportIDField)
            {
                fieldPageControl = manifest.TemplateListPage.Controls.AddFieldPageControl(nextControlID++, 2);
                fieldPageControl.Properties.SourceExpr = manifest.TemplateTableTestReportIDField.Name.Quoted();
                fieldPageControl.Properties.Visible = false.ToString();
                fieldPageControl.Properties.LookupPageID = "Objects";
            }

            if (entityType.HasPostingReportIDField)
            {
                fieldPageControl = manifest.TemplateListPage.Controls.AddFieldPageControl(nextControlID++, 2);
                fieldPageControl.Properties.SourceExpr = manifest.TemplateTablePostingReportIDField.Name.Quoted();
                fieldPageControl.Properties.Visible = false.ToString();
                fieldPageControl.Properties.LookupPageID = "Objects";

                fieldPageControl = manifest.TemplateListPage.Controls.AddFieldPageControl(nextControlID++, 2);
                fieldPageControl.Properties.SourceExpr = manifest.TemplateTableForcePostingReportField.Name.Quoted();
                fieldPageControl.Properties.Visible = false.ToString();
            }

            manifest.TemplateListPage.Controls.AddContainerPageControl(nextControlID++, 0).Properties.ContainerType = ContainerType.FactBoxArea;

            var partPageControl = manifest.TemplateListPage.Controls.AddPartPageControl(nextControlID++, 1);
            partPageControl.Properties.Visible = false.ToString();
            partPageControl.Properties.PartType = PartType.System;
            partPageControl.Properties.SystemPartID = SystemPartID.RecordLinks;

            partPageControl = manifest.TemplateListPage.Controls.AddPartPageControl(nextControlID++, 1);
            partPageControl.Properties.Visible = false.ToString();
            partPageControl.Properties.PartType = PartType.System;
            partPageControl.Properties.SystemPartID = SystemPartID.Notes;
        }

        private static void FinalizeBatchesPage(JournalEntityType entityType, RenderingContext renderingContext, JournalEntityTypeManifest manifest)
        {
            manifest.BatchesPage.Properties.SourceTable = manifest.BatchTable.ID;
        }

        private static void FinalizeJournalPage(JournalEntityType entityType, RenderingContext renderingContext, JournalEntityTypeManifest manifest)
        {
            manifest.JournalPage.Properties.SaveValues = true;
            manifest.JournalPage.Properties.SourceTable = manifest.LineTable.ID;
            manifest.JournalPage.Properties.DelayedInsert = true;
            manifest.JournalPage.Properties.DataCaptionFields.Add(manifest.LineTableJournalBatchNameField.Name);
            manifest.JournalPage.Properties.PageType = PageType.Worksheet;
            manifest.JournalPage.Properties.AutoSplitKey = true;

            var nextUID = 1000;
            var currentJnlBatchName = manifest.JournalPage.Code.Variables.AddCodeVariable(nextUID++, "CurrentJnlBatchName", 10);

            var onOpenPage = manifest.JournalPage.Properties.OnOpenPage;
            nextUID = 1000;
            var journalMgt = onOpenPage.Variables.AddCodeunitVariable(nextUID++, manifest.JournalMgtCodeunit.Name.MakeVariableName(), manifest.JournalMgtCodeunit.ID);
            var journalSelected = onOpenPage.Variables.AddBooleanVariable(nextUID++, "JnlSelected");
            var openedFromBatch = onOpenPage.Variables.AddBooleanVariable(nextUID++, "OpenedFromBatch");
            onOpenPage.CodeLines.Add("{0} := ({1} <> '') AND ({2} <> '');", openedFromBatch.Name, manifest.LineTableJournalBatchNameField.Name.Quoted(), manifest.LineTableJournalTemplateNameField.Name.Quoted());
            onOpenPage.CodeLines.Add("IF {0} THEN BEGIN", openedFromBatch.Name);
            onOpenPage.CodeLines.Add("  {0} := {1};", currentJnlBatchName.Name, manifest.LineTableJournalBatchNameField.Name.Quoted());
            onOpenPage.CodeLines.Add("  {0}.OpenJnl({1}, Rec);", journalMgt.Name, currentJnlBatchName.Name);
            onOpenPage.CodeLines.Add("  EXIT;");
            onOpenPage.CodeLines.Add("END;");
            onOpenPage.CodeLines.Add("{0}.TemplateSelection(PAGE::{1}, FALSE, Rec, JnlSelected);", journalMgt.Name, manifest.JournalPage.Name.Quoted());
            onOpenPage.CodeLines.Add("IF NOT {0} THEN", journalSelected.Name);
            onOpenPage.CodeLines.Add("  ERROR('');");
            onOpenPage.CodeLines.Add("{0}.OpenJnl({1}, Rec);", journalMgt.Name, currentJnlBatchName.Name);

            var onNewRecord = manifest.JournalPage.Properties.OnNewRecord;
            nextUID = 1000;
            onNewRecord.CodeLines.Add("// FIXME: SetUpNewLine(xRec);");

            var nextControlID = 1;

            if (entityType.MasterEntityType != null)
            {
                var masterEntityTypeManifest = renderingContext.GetManifest(entityType.MasterEntityType) as MasterEntityTypeManifest;
                var actions = manifest.JournalPage.Properties.ActionList;

                actions.AddPageActionContainer(nextControlID++, 0).Properties.ActionContainerType = ActionContainerType.RelatedInformation;
                actions.AddPageActionGroup(nextControlID++, 1).Properties.CaptionML.Add("ENU", entityType.MasterEntityType.Name);

                var action = actions.AddPageAction(nextControlID++, 2);
                action.Properties.ShortCutKey = "Shift+F7";
                action.Properties.CaptionML.Add("ENU", "Card");
                action.Properties.RunObject.Type = RunObjectType.Page;
                action.Properties.RunObject.ID = masterEntityTypeManifest.CardPage.ID;
                action.Properties.RunPageLink.Add(masterEntityTypeManifest.NoField.Name.Quoted(), RunObjectLinkLineType.Field, manifest.LineTableMasterEntityTypeField.Name.Quoted());
                action.Properties.Image = "EditLines";

                foreach (var ledgerEntityType in entityType.MasterEntityType.LedgerEntityTypes(renderingContext))
                {
                    var ledgerEntityTypeManifest = renderingContext.GetManifest(ledgerEntityType) as LedgerEntityTypeManifest;

                    action = actions.AddPageAction(nextControlID++, 2);
                    action.Properties.ShortCutKey = "Ctrl+F7";
                    action.Properties.CaptionML.Add("ENU", ledgerEntityType.PluralName);
                    action.Properties.RunObject.Type = RunObjectType.Page;
                    action.Properties.RunObject.ID = ledgerEntityTypeManifest.Page.ID;
                    action.Properties.RunPageLink.Add(ledgerEntityTypeManifest.MasterEntityTypeField.Name.Quoted(), RunObjectLinkLineType.Field, manifest.LineTableMasterEntityTypeField.Name.Quoted());
                    action.Properties.RunPageView.Key = ledgerEntityTypeManifest.MasterEntityTypeField.Name.Quoted();
                    action.Properties.Promoted = false;
                    action.Properties.PromotedCategory = PromotedCategory.Process;
                }
            }

            manifest.JournalPage.Controls.AddContainerPageControl(nextControlID++, 0).Properties.ContainerType = ContainerType.ContentArea;

            var batchNameField = manifest.JournalPage.Controls.AddFieldPageControl(nextControlID++, 1);
            batchNameField.Properties.Lookup = true;
            batchNameField.Properties.CaptionML.Add("ENU", "Batch Name");
            batchNameField.Properties.SourceExpr = currentJnlBatchName.Name;
            nextUID = 1000;
            journalMgt = batchNameField.Properties.OnValidate.Variables.AddCodeunitVariable(nextUID++, manifest.JournalMgtCodeunit.Name.MakeVariableName(), manifest.JournalMgtCodeunit.ID);
            batchNameField.Properties.OnValidate.CodeLines.Add("{0}.{1}({2}, Rec);", journalMgt.Name, manifest.CheckNameFunction.Name, currentJnlBatchName.Name);
            batchNameField.Properties.OnValidate.CodeLines.Add("// FIXME: CurrentJnlBatchNameOnAfterVali;");

            nextUID = 1000;
            journalMgt = batchNameField.Properties.OnLookup.Variables.AddCodeunitVariable(nextUID++, manifest.JournalMgtCodeunit.Name.MakeVariableName(), manifest.JournalMgtCodeunit.ID);
            batchNameField.Properties.OnLookup.CodeLines.Add("CurrPage.SAVERECORD;");
            batchNameField.Properties.OnLookup.CodeLines.Add("{0}.LookupName(CurrentJnlBatchName, Rec);", journalMgt.Name);
            batchNameField.Properties.OnLookup.CodeLines.Add("CurrPage.UPDATE(FALSE)");
        }

        private static void FinalizeJournalMgtCodeunit(JournalEntityType entityType, RenderingContext renderingContext, JournalEntityTypeManifest manifest)
        {
            manifest.JournalMgtCodeunit.Properties.Permissions.Add(manifest.TemplateTable.ID, false, true, true, true);
            manifest.JournalMgtCodeunit.Properties.Permissions.Add(manifest.BatchTable.ID, false, true, true, true);

            manifest.JournalMgtCodeunitText000.Values.Add("ENU", entityType.BasePluralName.MakeVariableName().ToUpperInvariant().Substring(0, 10));
            manifest.JournalMgtCodeunitText001.Values.Add("ENU", entityType.BasePluralName);
            manifest.JournalMgtCodeunitText002.Values.Add("ENU", "RECURRING");
            manifest.JournalMgtCodeunitText003.Values.Add("ENU", string.Format("Recurring {0}", entityType.BaseName));
            manifest.JournalMgtCodeunitText004.Values.Add("ENU", "DEFAULT");
            manifest.JournalMgtCodeunitText005.Values.Add("ENU", "Default Journal");

            FinalizeTemplateSelectionFunction(entityType, manifest);
            FinalizeOpenJnlFunction(entityType, manifest);
            FinalizeCheckTemplateNameFunction(entityType, manifest);
            FinalizeLookupNameFunction(entityType, manifest);
            FinalizeSetNameFunction(entityType, manifest);
            FinalizeCheckNameFunction(entityType, manifest);
            FinalizeTemplateSelectionFromBatchFunction(entityType, manifest);
            FinalizeOpenJnlBatchFunction(entityType, manifest);
        }

        private static void FinalizeTemplateSelectionFunction(JournalEntityType entityType, JournalEntityTypeManifest manifest)
        {
            var nextUID = 1000;
            var pageIDParameter = manifest.TemplateSelectionFunction.Parameters.AddIntegerParameter(false, nextUID++, "PageID");
            var recurringJnlParameter = manifest.TemplateSelectionFunction.Parameters.AddBooleanParameter(false, nextUID++, "RecurringJnl");
            var journalLineParameter = manifest.TemplateSelectionFunction.Parameters.AddRecordParameter(true, nextUID++, manifest.LineTable.Name.MakeVariableName(), manifest.LineTable.ID);
            var journalSelectedParameter = manifest.TemplateSelectionFunction.Parameters.AddBooleanParameter(true, nextUID++, "JnlSelected");
            var journalTemplateVariable = manifest.TemplateSelectionFunction.Variables.AddRecordVariable(nextUID++, manifest.TemplateTable.Name.MakeVariableName(), manifest.TemplateTable.ID);
            manifest.TemplateSelectionFunction.CodeLines.Add("JnlSelected := TRUE;");
            manifest.TemplateSelectionFunction.CodeLines.Add("");
            manifest.TemplateSelectionFunction.CodeLines.Add("{0}.RESET;", journalTemplateVariable.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("{0}.SETRANGE({1}, {2});", journalTemplateVariable.Name, manifest.TemplateTablePageIDField.Name.Quoted(), pageIDParameter.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("{0}.SETRANGE({1}, {2});", journalTemplateVariable.Name, manifest.TemplateTableRecurringField.Name.Quoted(), recurringJnlParameter.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("");
            manifest.TemplateSelectionFunction.CodeLines.Add("CASE {0}.COUNT OF", journalTemplateVariable.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("  0:");
            manifest.TemplateSelectionFunction.CodeLines.Add("    BEGIN");
            manifest.TemplateSelectionFunction.CodeLines.Add("      {0}.INIT;", journalTemplateVariable.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("      {0}.{1} := {2};", journalTemplateVariable.Name, manifest.TemplateTableRecurringField.Name.Quoted(), recurringJnlParameter.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("      IF NOT {0} THEN BEGIN", recurringJnlParameter.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("        {0}.{1} := {2};", journalTemplateVariable.Name, manifest.TemplateTableNameField.Name.Quoted(), manifest.JournalMgtCodeunitText000.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("        {0}.{1} := {2};", journalTemplateVariable.Name, manifest.TemplateTableDescriptionField.Name.Quoted(), manifest.JournalMgtCodeunitText001.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("      END ELSE BEGIN");
            manifest.TemplateSelectionFunction.CodeLines.Add("        {0}.{1} := {2};", journalTemplateVariable.Name, manifest.TemplateTableNameField.Name.Quoted(), manifest.JournalMgtCodeunitText002.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("        {0}.{1} := {2};", journalTemplateVariable.Name, manifest.TemplateTableDescriptionField.Name.Quoted(), manifest.JournalMgtCodeunitText003.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("      END;");
            manifest.TemplateSelectionFunction.CodeLines.Add("      {0}.VALIDATE({1});", journalTemplateVariable.Name, manifest.TemplateTablePageIDField.Name.Quoted());
            manifest.TemplateSelectionFunction.CodeLines.Add("      {0}.INSERT;", journalTemplateVariable.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("      COMMIT;");
            manifest.TemplateSelectionFunction.CodeLines.Add("    END;");
            manifest.TemplateSelectionFunction.CodeLines.Add("  1:");
            manifest.TemplateSelectionFunction.CodeLines.Add("    {0}.FINDFIRST;", journalTemplateVariable.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("  ELSE");
            manifest.TemplateSelectionFunction.CodeLines.Add("    JnlSelected := PAGE.RUNMODAL(0, {0}) = ACTION::LookupOK;", journalTemplateVariable.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("END;");
            manifest.TemplateSelectionFunction.CodeLines.Add("IF {0} THEN BEGIN", journalSelectedParameter.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("  {0}.FILTERGROUP := 2;", journalLineParameter.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("  {0}.SETRANGE({1}, {2}.{3});", journalLineParameter.Name, manifest.LineTableJournalTemplateNameField.Name.Quoted(), journalTemplateVariable.Name, manifest.TemplateTableNameField.Name.Quoted());
            manifest.TemplateSelectionFunction.CodeLines.Add("  {0}.FILTERGROUP := 0;", journalLineParameter.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("  IF {0} THEN BEGIN", manifest.OpenFromBatchVariable.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("    {0}.{1} := '';", journalLineParameter.Name, manifest.LineTableJournalTemplateNameField.Name.Quoted());
            manifest.TemplateSelectionFunction.CodeLines.Add("    PAGE.RUN({0}.{1}, {2});", journalTemplateVariable.Name, manifest.TemplateTablePageIDField.Name.Quoted(), journalLineParameter.Name);
            manifest.TemplateSelectionFunction.CodeLines.Add("  END;");
            manifest.TemplateSelectionFunction.CodeLines.Add("END;");
        }

        private static void FinalizeOpenJnlFunction(JournalEntityType entityType, JournalEntityTypeManifest manifest)
        {
            var nextUID = 1000;
            var currentJnlBatchName = manifest.OpenJnlFunction.Parameters.AddCodeParameter(true, nextUID++, "CurrentJnlBatchName", 10);
            var journalLineParameter = manifest.OpenJnlFunction.Parameters.AddRecordParameter(true, nextUID++, manifest.LineTable.Name.MakeVariableName(), manifest.LineTable.ID);
            manifest.OpenJnlFunction.CodeLines.Add("CheckTemplateName({0}.GETRANGEMAX({1}), {2});", journalLineParameter.Name, manifest.LineTableJournalTemplateNameField.Name.Quoted(), currentJnlBatchName.Name);
            manifest.OpenJnlFunction.CodeLines.Add("{0}.FILTERGROUP := 2;", journalLineParameter.Name);
            manifest.OpenJnlFunction.CodeLines.Add("{0}.SETRANGE({1}, {2});", journalLineParameter.Name, manifest.LineTableJournalBatchNameField.Name.Quoted(), currentJnlBatchName.Name);
            manifest.OpenJnlFunction.CodeLines.Add("{0}.FILTERGROUP := 0;", journalLineParameter.Name);
        }

        private static void FinalizeCheckTemplateNameFunction(JournalEntityType entityType, JournalEntityTypeManifest manifest)
        {
            var nextUID = 1000;
            var currentJnlTemplateName = manifest.CheckTemplateNameFunction.Parameters.AddCodeParameter(false, nextUID++, "CurrentJnlTemplateName", 10);
            var currentJnlBatchName = manifest.CheckTemplateNameFunction.Parameters.AddCodeParameter(true, nextUID++, "CurrentJnlBatchName", 10);
            var journalBatchVariable = manifest.CheckTemplateNameFunction.Variables.AddRecordVariable(nextUID++, manifest.BatchTable.Name.MakeVariableName(), manifest.BatchTable.ID);
            manifest.CheckTemplateNameFunction.CodeLines.Add("{0}.SETRANGE({1}, {2});", journalBatchVariable.Name, manifest.BatchTableJournalTemplateNameField.Name.Quoted(), currentJnlTemplateName.Name);
            manifest.CheckTemplateNameFunction.CodeLines.Add("IF NOT {0}.GET({1}, {2}) THEN BEGIN", journalBatchVariable.Name, currentJnlTemplateName.Name, currentJnlBatchName.Name);
            manifest.CheckTemplateNameFunction.CodeLines.Add("  IF NOT {0}.FINDFIRST THEN BEGIN", journalBatchVariable.Name);
            manifest.CheckTemplateNameFunction.CodeLines.Add("    {0}.INIT;", journalBatchVariable.Name);
            manifest.CheckTemplateNameFunction.CodeLines.Add("    {0}.{1} := {2};", journalBatchVariable.Name, manifest.BatchTableJournalTemplateNameField.Name.Quoted(), currentJnlTemplateName.Name);
            manifest.CheckTemplateNameFunction.CodeLines.Add("    // FIXME: {0}.SetupNewBatch;", journalBatchVariable.Name);
            manifest.CheckTemplateNameFunction.CodeLines.Add("    {0}.{1} := {2};", journalBatchVariable.Name, manifest.BatchTableNameField.Name.Quoted(), manifest.JournalMgtCodeunitText004.Name);
            manifest.CheckTemplateNameFunction.CodeLines.Add("    {0}.{1} := {2};", journalBatchVariable.Name, manifest.BatchTableDescriptionField.Name.Quoted(), manifest.JournalMgtCodeunitText005.Name);
            manifest.CheckTemplateNameFunction.CodeLines.Add("    {0}.INSERT(TRUE);", journalBatchVariable.Name);
            manifest.CheckTemplateNameFunction.CodeLines.Add("    COMMIT;");
            manifest.CheckTemplateNameFunction.CodeLines.Add("  END;");
            manifest.CheckTemplateNameFunction.CodeLines.Add("  {0} := {1}.{2};", currentJnlBatchName.Name, journalBatchVariable.Name, manifest.BatchTableNameField.Name.Quoted());
            manifest.CheckTemplateNameFunction.CodeLines.Add("END;");
        }

        private static void FinalizeLookupNameFunction(JournalEntityType entityType, JournalEntityTypeManifest manifest)
        {
            var nextUID = 1000;
            var currentJnlBatchName = manifest.LookupNameFunction.Parameters.AddCodeParameter(true, nextUID++, "CurrentJnlBatchName", 10);
            var journalLineParameter = manifest.LookupNameFunction.Parameters.AddRecordParameter(true, nextUID++, manifest.LineTable.Name.MakeVariableName(), manifest.LineTable.ID);
            var journalBatchVariable = manifest.LookupNameFunction.Variables.AddRecordVariable(nextUID++, manifest.BatchTable.Name.MakeVariableName(), manifest.BatchTable.ID);
            manifest.LookupNameFunction.ReturnValue.Type = FunctionReturnValueType.Boolean;
            manifest.LookupNameFunction.CodeLines.Add("COMMIT;");
            manifest.LookupNameFunction.CodeLines.Add("{0}.{1} := {2}.GETRANGEMAX({3});", journalBatchVariable.Name, manifest.BatchTableJournalTemplateNameField.Name.Quoted(), journalLineParameter.Name, manifest.LineTableJournalTemplateNameField.Name.Quoted());
            manifest.LookupNameFunction.CodeLines.Add("{0}.{1} := {2}.GETRANGEMAX({3});", journalBatchVariable.Name, manifest.BatchTableNameField.Name.Quoted(), journalLineParameter.Name, manifest.LineTableJournalBatchNameField.Name.Quoted());
            manifest.LookupNameFunction.CodeLines.Add("{0}.FILTERGROUP(2);", journalBatchVariable.Name);
            manifest.LookupNameFunction.CodeLines.Add("{0}.SETRANGE({1}, {2}.{3});", journalBatchVariable.Name, manifest.BatchTableJournalTemplateNameField.Name.Quoted(), journalBatchVariable.Name, manifest.BatchTableJournalTemplateNameField.Name.Quoted());
            manifest.LookupNameFunction.CodeLines.Add("{0}.FILTERGROUP(0);", journalBatchVariable.Name);
            manifest.LookupNameFunction.CodeLines.Add("IF PAGE.RUNMODAL(0, {0}) = ACTION::LookupOK THEN BEGIN", journalBatchVariable.Name);
            manifest.LookupNameFunction.CodeLines.Add("  {0} := {1}.{2};", currentJnlBatchName.Name, journalBatchVariable.Name, manifest.BatchTableNameField.Name.Quoted());
            manifest.LookupNameFunction.CodeLines.Add("  SetName({0}, {1});", currentJnlBatchName.Name, journalLineParameter.Name);
            manifest.LookupNameFunction.CodeLines.Add("END;");
        }

        private static void FinalizeSetNameFunction(JournalEntityType entityType, JournalEntityTypeManifest manifest)
        {
            var nextUID = 1000;
            var currentJnlBatchName = manifest.SetNameFunction.Parameters.AddCodeParameter(false, nextUID++, "CurrentJnlBatchName", 10);
            var journalLineParameter = manifest.SetNameFunction.Parameters.AddRecordParameter(true, nextUID++, manifest.LineTable.Name.MakeVariableName(), manifest.LineTable.ID);
            manifest.SetNameFunction.CodeLines.Add("{0}.FILTERGROUP := 2;", journalLineParameter.Name);
            manifest.SetNameFunction.CodeLines.Add("{0}.SETRANGE({1}, {2});", journalLineParameter.Name, manifest.LineTableJournalBatchNameField.Name.Quoted(), currentJnlBatchName.Name);
            manifest.SetNameFunction.CodeLines.Add("{0}.FILTERGROUP := 0;", journalLineParameter.Name);
            manifest.SetNameFunction.CodeLines.Add("IF {0}.FIND('-') THEN;", journalLineParameter.Name);
        }

        private static void FinalizeCheckNameFunction(JournalEntityType entityType, JournalEntityTypeManifest manifest)
        {
            var nextUID = 1000;
            var currentJnlBatchName = manifest.CheckNameFunction.Parameters.AddCodeParameter(false, nextUID++, "CurrentJnlBatchName", 10);
            var journalLineParameter = manifest.CheckNameFunction.Parameters.AddRecordParameter(true, nextUID++, manifest.LineTable.Name.MakeVariableName(), manifest.LineTable.ID);
            var journalBatchVariable = manifest.CheckNameFunction.Variables.AddRecordVariable(nextUID++, manifest.BatchTable.Name.MakeVariableName(), manifest.BatchTable.ID);
            manifest.CheckNameFunction.CodeLines.Add("{0}.GET({1}.GETRANGEMAX({2}), {3});", journalBatchVariable.Name, journalLineParameter.Name, manifest.LineTableJournalTemplateNameField.Name.Quoted(), currentJnlBatchName.Name);
        }

        private static void FinalizeTemplateSelectionFromBatchFunction(JournalEntityType entityType, JournalEntityTypeManifest manifest)
        {
            var nextUID = 1000;
            var journalBatchParameter = manifest.TemplateSelectionFromBatchFunction.Parameters.AddRecordParameter(true, nextUID++, manifest.BatchTable.Name.MakeVariableName(), manifest.BatchTable.ID);
            var journalLineVariable = manifest.TemplateSelectionFromBatchFunction.Variables.AddRecordVariable(nextUID++, manifest.LineTable.Name.MakeVariableName(), manifest.LineTable.ID);
            var journalTemplateVariable = manifest.TemplateSelectionFromBatchFunction.Variables.AddRecordVariable(nextUID++, manifest.TemplateTable.Name.MakeVariableName(), manifest.TemplateTable.ID);
            manifest.TemplateSelectionFromBatchFunction.CodeLines.Add("{0} := TRUE;", manifest.OpenFromBatchVariable.Name);
            manifest.TemplateSelectionFromBatchFunction.CodeLines.Add("{0}.GET({1}.{2});", journalTemplateVariable.Name, journalBatchParameter.Name, manifest.BatchTableJournalTemplateNameField.Name.Quoted());
            manifest.TemplateSelectionFromBatchFunction.CodeLines.Add("{0}.TESTFIELD({1});", journalTemplateVariable.Name, manifest.TemplateTablePageIDField.Name.Quoted());
            manifest.TemplateSelectionFromBatchFunction.CodeLines.Add("{0}.TESTFIELD({1});", journalBatchParameter.Name, manifest.BatchTableNameField.Name.Quoted());
            manifest.TemplateSelectionFromBatchFunction.CodeLines.Add("");
            manifest.TemplateSelectionFromBatchFunction.CodeLines.Add("{0}.FILTERGROUP := 2;", journalLineVariable.Name);
            manifest.TemplateSelectionFromBatchFunction.CodeLines.Add("{0}.SETRANGE({1}, {2}.{3});", journalLineVariable.Name, manifest.LineTableJournalTemplateNameField.Name.Quoted(), journalTemplateVariable.Name, manifest.TemplateTableNameField.Name.Quoted());
            manifest.TemplateSelectionFromBatchFunction.CodeLines.Add("{0}.FILTERGROUP := 0;", journalLineVariable.Name);
            manifest.TemplateSelectionFromBatchFunction.CodeLines.Add("");
            manifest.TemplateSelectionFromBatchFunction.CodeLines.Add("{0}.{1} := '';", journalLineVariable.Name, manifest.LineTableJournalTemplateNameField.Name.Quoted());
            manifest.TemplateSelectionFromBatchFunction.CodeLines.Add("{0}.{1} := {2}.{3};", journalLineVariable.Name, manifest.LineTableJournalBatchNameField.Name.Quoted(), journalBatchParameter.Name, manifest.BatchTableNameField.Name.Quoted());
            manifest.TemplateSelectionFromBatchFunction.CodeLines.Add("PAGE.RUN({0}.{1}, {2});", journalTemplateVariable.Name, manifest.TemplateTablePageIDField.Name.Quoted(), journalLineVariable.Name);
        }

        private static void FinalizeOpenJnlBatchFunction(JournalEntityType entityType, JournalEntityTypeManifest manifest)
        {
            var nextUID = 1000;
            var journalBatchParameter = manifest.OpenJnlBatchFunction.Parameters.AddRecordParameter(true, nextUID++, manifest.BatchTable.Name.MakeVariableName(), manifest.BatchTable.ID);
            var journalTemplateVariable = manifest.OpenJnlBatchFunction.Variables.AddRecordVariable(nextUID++, manifest.TemplateTable.Name.MakeVariableName(), manifest.TemplateTable.ID);
            var journalLineVariable = manifest.OpenJnlBatchFunction.Variables.AddRecordVariable(nextUID++, manifest.LineTable.Name.MakeVariableName(), manifest.LineTable.ID);
            var jnlSelectedVariable = manifest.OpenJnlBatchFunction.Variables.AddBooleanVariable(nextUID++, "JnlSelected");
            manifest.OpenJnlBatchFunction.CodeLines.Add("IF {0}.GETFILTER({1}) <> '' THEN", journalBatchParameter.Name, manifest.BatchTableJournalTemplateNameField.Name.Quoted());
            manifest.OpenJnlBatchFunction.CodeLines.Add("  EXIT;");
            manifest.OpenJnlBatchFunction.CodeLines.Add("{0}.FILTERGROUP(2);", journalBatchParameter.Name);
            manifest.OpenJnlBatchFunction.CodeLines.Add("IF {0}.GETFILTER({1}) <> '' THEN BEGIN", journalBatchParameter.Name, manifest.BatchTableJournalTemplateNameField.Name.Quoted());
            manifest.OpenJnlBatchFunction.CodeLines.Add("  {0}.FILTERGROUP(0);", journalBatchParameter.Name);
            manifest.OpenJnlBatchFunction.CodeLines.Add("  EXIT;");
            manifest.OpenJnlBatchFunction.CodeLines.Add("END;");
            manifest.OpenJnlBatchFunction.CodeLines.Add("{0}.FILTERGROUP(0);", journalBatchParameter.Name);
            manifest.OpenJnlBatchFunction.CodeLines.Add("");
            manifest.OpenJnlBatchFunction.CodeLines.Add("IF NOT {0}.FIND('-') THEN BEGIN", journalBatchParameter.Name);
            manifest.OpenJnlBatchFunction.CodeLines.Add("  IF NOT {0}.FINDFIRST THEN", journalTemplateVariable.Name);
            manifest.OpenJnlBatchFunction.CodeLines.Add("    {0}(0, FALSE, {1}, {2});", manifest.TemplateSelectionFunction.Name, journalLineVariable.Name, jnlSelectedVariable.Name);
            manifest.OpenJnlBatchFunction.CodeLines.Add("  IF {0}.FINDFIRST THEN", journalTemplateVariable.Name);
            manifest.OpenJnlBatchFunction.CodeLines.Add("    {0}({1}.{2}, {3}.{4});", manifest.CheckTemplateNameFunction.Name, journalTemplateVariable.Name, manifest.TemplateTableNameField.Name.Quoted(), journalBatchParameter.Name, manifest.BatchTableNameField.Name.Quoted());
            manifest.OpenJnlBatchFunction.CodeLines.Add("  {0}.SETRANGE({1}, TRUE);", journalTemplateVariable.Name, manifest.TemplateTableRecurringField.Name.Quoted());
            manifest.OpenJnlBatchFunction.CodeLines.Add("  IF NOT {0}.FINDFIRST THEN", journalTemplateVariable.Name);
            manifest.OpenJnlBatchFunction.CodeLines.Add("    {0}(0, TRUE, {1}, {2});", manifest.TemplateSelectionFunction.Name, journalLineVariable.Name, jnlSelectedVariable.Name);
            manifest.OpenJnlBatchFunction.CodeLines.Add("  IF {0}.FINDFIRST THEN", journalTemplateVariable.Name);
            manifest.OpenJnlBatchFunction.CodeLines.Add("    {0}({1}.{2},{3}.{4});", manifest.CheckTemplateNameFunction.Name, journalTemplateVariable.Name, manifest.TemplateTableNameField.Name.Quoted(), journalBatchParameter.Name, manifest.BatchTableNameField.Name.Quoted());
            manifest.OpenJnlBatchFunction.CodeLines.Add("  {0}.SETRANGE({1});", journalTemplateVariable.Name, manifest.TemplateTableRecurringField.Name.Quoted());
            manifest.OpenJnlBatchFunction.CodeLines.Add("END;");
            manifest.OpenJnlBatchFunction.CodeLines.Add("{0}.FIND('-');", journalBatchParameter.Name);
            manifest.OpenJnlBatchFunction.CodeLines.Add("{0} := TRUE;", jnlSelectedVariable.Name);
            manifest.OpenJnlBatchFunction.CodeLines.Add("{0}.CALCFIELDS({1});", journalBatchParameter.Name, manifest.BatchTableRecurringField.Name.Quoted());

            //  ResJnlBatch.CALCFIELDS(Recurring);
            //  ResJnlTemplate.SETRANGE(Recurring,ResJnlBatch.Recurring);
            //  IF ResJnlBatch.GETFILTER("Journal Template Name") <> '' THEN
            //    ResJnlTemplate.SETRANGE(Name,ResJnlBatch.GETFILTER("Journal Template Name"));
            //  CASE ResJnlTemplate.COUNT OF
            //    1:
            //      ResJnlTemplate.FINDFIRST;
            //    ELSE
            //      JnlSelected := PAGE.RUNMODAL(0,ResJnlTemplate) = ACTION::LookupOK;
            //  END;
            //  IF NOT JnlSelected THEN
            //    ERROR('');

            //  ResJnlBatch.FILTERGROUP(2);
            //  ResJnlBatch.SETRANGE("Journal Template Name",ResJnlTemplate.Name);
            //  ResJnlBatch.FILTERGROUP(0);
            //END;
        }
    }
}
