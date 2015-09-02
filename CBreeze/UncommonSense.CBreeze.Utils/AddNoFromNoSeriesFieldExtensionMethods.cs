using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public class AddNoFromNoSeriesFieldManifest
    {
        internal AddNoFromNoSeriesFieldManifest()
        {
        }

        public CodeTableField NoField
        {
            get;
            internal set;
        }

        public CodeTableField NoSeriesField
        {
            get;
            internal set;
        }

        public CodeTableField NoSeriesSetupField
        {
            get;
            internal set;
        }

        public FieldPageControl NoControl
        {
            get;
            internal set;
        }

        public FieldPageControl NoSeriesSetupControl
        {
            get;
            internal set;
        }
    }

    public static class AddNoFromNoSeriesFieldExtensionMethods
    {
        public static AddNoFromNoSeriesFieldManifest AddNoFromNoSeriesField(this Table table, IEnumerable<int> range, Page cardPage, Table setupTable, Page setupCard )
        {
            var manifest = new AddNoFromNoSeriesFieldManifest();

            manifest.NoField = table.Fields.Add(new CodeTableField(range.GetNextPrimaryKeyFieldNo(table), "No.", 20)).AutoCaption();

            manifest.NoSeriesField = table.Fields.Add(new CodeTableField(range.GetNextTableFieldNo(table), "No. Series", 10)).AutoCaption();
            manifest.NoSeriesField.Properties.Editable = false;
            manifest.NoSeriesField.Properties.TableRelation.Add("No. Series");

            manifest.NoSeriesSetupField = setupTable.Fields.Add(new CodeTableField(range.GetNextTableFieldNo(setupTable), string.Format("{0} Nos.", table.Name), 10));
            manifest.NoSeriesSetupField.Properties.TableRelation.Add(BaseApp.TableNames.NoSeries);

            var group = cardPage.GetOrCreateGeneralGroupControl(range, 0);

            manifest.NoControl = cardPage.Controls.Insert(cardPage.Controls.IndexOf(group) + 1, new FieldPageControl(range.GetNextPageControlID(cardPage), 2));
            manifest.NoControl.Properties.SourceExpr = manifest.NoField.Name.Quoted();
            manifest.NoControl.Properties.Importance = Importance.Promoted;
            manifest.NoControl.Properties.OnAssistEdit.CodeLines.Add("IF AssistEdit(xRec) THEN");
            manifest.NoControl.Properties.OnAssistEdit.CodeLines.Add("  CurrPage.UPDATE;");

            group = setupCard.GetOrCreateNumberingGroupControl(range, 0);
            var index = group.GetChildPageControls(setupCard).Any() ? setupCard.Controls.IndexOf(group.GetChildPageControls(setupCard).Last()) + 1 : setupCard.Controls.IndexOf(group) + 1;
            manifest.NoSeriesSetupControl = setupCard.Controls.Insert(index, new FieldPageControl(range.GetNextPageControlID(setupCard), 2));
            manifest.NoSeriesSetupControl.Properties.SourceExpr = manifest.NoSeriesSetupField.Name.Quoted();

            var primaryKey = table.Keys.Add();
            primaryKey.Fields.Add(manifest.NoField.Name);
            primaryKey.Properties.Clustered = true;

            var onValidate = manifest.NoField.Properties.OnValidate;
            var setupRecordVariable = onValidate.Variables.Add(new RecordVariable(1000, setupTable.Name.MakeVariableName(), setupTable.ID));
            var noSeriesMgtCodeunitVariable = onValidate.Variables.Add(new CodeunitVariable(1001, "NoSeriesMgt", 396));
            onValidate.CodeLines.Add(string.Format("IF {0} <> xRec.{0} THEN BEGIN", manifest.NoField.Name.Quoted()));
            onValidate.CodeLines.Add(string.Format("  {0}.GET;", setupRecordVariable.Name));
            onValidate.CodeLines.Add(string.Format("  {0}.TestManual({1}.\"{2} Nos.\");", noSeriesMgtCodeunitVariable.Name, setupRecordVariable.Name, table.Name));
            onValidate.CodeLines.Add("  \"No. Series\" := '';");
            onValidate.CodeLines.Add("END;");

            var onInsert = table.Properties.OnInsert;
            setupRecordVariable = onInsert.Variables.Add(new RecordVariable(1000, setupTable.Name.MakeVariableName(), setupTable.ID));
            noSeriesMgtCodeunitVariable = onInsert.Variables.Add(new CodeunitVariable(1001, "NoSeriesMgt", 396));
            onInsert.CodeLines.Add(string.Format("IF {0} = '' THEN BEGIN", manifest.NoField.Name.Quoted()));
            onInsert.CodeLines.Add(string.Format("  {0}.GET;", setupRecordVariable.Name));
            onInsert.CodeLines.Add(string.Format("  {0}.TESTFIELD(\"{1} Nos.\");", setupRecordVariable.Name, table.Name));
            onInsert.CodeLines.Add(string.Format("  {0}.InitSeries({1}.\"{2} Nos.\", xRec.{3}, 0D, {4}, {3});", noSeriesMgtCodeunitVariable.Name, setupRecordVariable.Name, table.Name, manifest.NoSeriesField.Name.Quoted(), manifest.NoField.Name.Quoted()));
            onInsert.CodeLines.Add("END;");

            var assistEdit = table.Code.Functions.Add(new Function(range.GetNextFunctionID(table), "AssistEdit"));
            var variableName = table.Name.MakeVariableName();
            var parameterName = string.Format("Old{0}", variableName);
            var parameter = assistEdit.Parameters.Add(new RecordParameter(false, 1000, parameterName, table.ID));
            assistEdit.Variables.Add(new RecordVariable(1001, variableName, table.ID));
            setupRecordVariable = assistEdit.Variables.Add(new RecordVariable(1002, setupTable.Name.MakeVariableName(), setupTable.ID));
            noSeriesMgtCodeunitVariable = assistEdit.Variables.Add(new CodeunitVariable(1003, "NoSeriesMgt", 396));
            assistEdit.ReturnValue.Type = FunctionReturnValueType.Boolean;
            assistEdit.CodeLines.Add(string.Format("WITH {0} DO BEGIN", variableName));
            assistEdit.CodeLines.Add(string.Format("  {0} := Rec;", variableName));
            assistEdit.CodeLines.Add(string.Format("  {0}.GET;", setupRecordVariable.Name));
            assistEdit.CodeLines.Add(string.Format("  {0}.TESTFIELD(\"{1} Nos.\");", setupRecordVariable.Name, table.Name));
            assistEdit.CodeLines.Add(string.Format("  IF {0}.SelectSeries({1}.\"{2} Nos.\", {3}.{4}, {4}) THEN BEGIN", noSeriesMgtCodeunitVariable.Name, setupRecordVariable.Name, table.Name, parameter.Name, manifest.NoSeriesField.Name.Quoted()));
            assistEdit.CodeLines.Add(string.Format("    {0}.GET;", setupRecordVariable.Name));
            assistEdit.CodeLines.Add(string.Format("    {0}.TESTFIELD(\"{1} Nos.\");", setupRecordVariable.Name, table.Name));
            assistEdit.CodeLines.Add(string.Format("    {0}.SetSeries({1});", noSeriesMgtCodeunitVariable.Name, manifest.NoField.Name.Quoted()));
            assistEdit.CodeLines.Add(string.Format("    Rec := {0};", variableName));
            assistEdit.CodeLines.Add("    EXIT(TRUE);");
            assistEdit.CodeLines.Add("  END;");
            assistEdit.CodeLines.Add("END;");

            return manifest;
        }
    }
}
