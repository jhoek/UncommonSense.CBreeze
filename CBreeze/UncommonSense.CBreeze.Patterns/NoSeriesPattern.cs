using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Patterns
{
    public class NoSeriesPattern : AddPrimaryKeyFieldsPattern
    {
        public NoSeriesPattern(IEnumerable<int> range, Table table, params Page[] pages)
            : base(range, table, pages)
        {
        }

        protected void AddAssistEditFunction()
        {
            var assistEdit = Table.Code.Functions.Add(new Function(Range.GetNextFunctionID(Table), "AssistEdit"));
            var variableName = Table.Name.MakeVariableName();
            var parameterName = string.Format("Old{0}", variableName);
            var parameter = assistEdit.Parameters.Add(new RecordParameter(false, 1000, parameterName, Table.ID));
            var recordVariable = assistEdit.Variables.Add(new RecordVariable(1001, variableName, Table.ID));
            var setupRecordVariable = assistEdit.Variables.Add(new RecordVariable(1002, SetupTable.Name.MakeVariableName(), SetupTable.ID));
            var noSeriesMgtCodeunitVariable = assistEdit.Variables.Add(new CodeunitVariable(1003, "NoSeriesMgt", 396));
            assistEdit.ReturnValue.Type = FunctionReturnValueType.Boolean;
            assistEdit.CodeLines.Add(string.Format("WITH {0} DO BEGIN", variableName));
            assistEdit.CodeLines.Add(string.Format("  {0} := Rec;", variableName));
            assistEdit.CodeLines.Add(string.Format("  {0}.GET;", setupRecordVariable.Name));
            assistEdit.CodeLines.Add(string.Format("  {0}.TESTFIELD(\"{1} Nos.\");", setupRecordVariable.Name, Table.Name));
            assistEdit.CodeLines.Add(string.Format("  IF {0}.SelectSeries({1}.\"{2} Nos.\", {3}.{4}, {4}) THEN BEGIN", noSeriesMgtCodeunitVariable.Name, setupRecordVariable.Name, Table.Name, parameter.Name, NoSeriesField.QuotedName));
            assistEdit.CodeLines.Add(string.Format("    {0}.GET;", setupRecordVariable.Name));
            assistEdit.CodeLines.Add(string.Format("    {0}.TESTFIELD(\"{1} Nos.\");", setupRecordVariable.Name, Table.Name));
            assistEdit.CodeLines.Add(string.Format("    {0}.SetSeries({1});", noSeriesMgtCodeunitVariable.Name, NoField.QuotedName));
            assistEdit.CodeLines.Add(string.Format("    Rec := {0};", variableName));
            assistEdit.CodeLines.Add("    EXIT(TRUE);");
            assistEdit.CodeLines.Add("  END;");
            assistEdit.CodeLines.Add("END;");
        }

        protected void CreateCardPageControls(Page page)
        {
            var contentArea = page.GetContentArea(Range);
            var group = contentArea.GetGroupByCaption("General", Range, Position.FirstWithinContainer);
            var noControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.FirstWithinContainer);

            noControl.Properties.SourceExpr = NoField.QuotedName;
            noControl.Properties.Importance = Importance.Promoted;
            noControl.Properties.OnAssistEdit.CodeLines.Add("IF AssistEdit(xRec) THEN");
            noControl.Properties.OnAssistEdit.CodeLines.Add("  CurrPage.UPDATE;");

            NoControls.Add(page, noControl);
        }

        protected void CreateListPageControls(Page page)
        {
            var contentArea = page.GetContentArea(Range);
            var group = contentArea.GetGroupByType(GroupType.Repeater, Range, Position.FirstWithinContainer);
            var noControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.FirstWithinContainer);

            noControl.Properties.SourceExpr = NoField.QuotedName;

            NoControls.Add(page, noControl);
        }

        protected void CreateSetupControls()
        {
            var contentArea = SetupPage.GetContentArea(Range);
            var group = contentArea.GetGroupByCaption("Numbering", Range, Position.LastWithinContainer);

            SetupControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(SetupPage), 2), Position.LastWithinContainer);
            SetupControl.Properties.SourceExpr = SetupField.QuotedName;
        }
    }
}
