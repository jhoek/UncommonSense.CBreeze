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
        private Dictionary<Page, FieldPageControl> noControls = new Dictionary<Page, FieldPageControl>();
        private Dictionary<Page, FieldPageControl> noSeriesControls = new Dictionary<Page, FieldPageControl>();

        public NoSeriesPattern(IEnumerable<int> range, Table table, params Page[] pages)
            : base(range, table, pages)
        {
        }

        protected override void VerifyRequirements()
        {
            base.VerifyRequirements();

            if (SetupTable == null)
                throw new ArgumentNullException("SetupTable");

            if (SetupPage == null)
                throw new ArgumentNullException("SetupPage");
        }

        protected override void MakeChanges()
        {
            CreateFields();
            CreateKey();
            SetFieldProperties();
            AddOnValidate();
            AddOnInsert();
            AddAssistEditFunction();
            CreateControls();
            CreateSetupControls();
        }

        protected void CreateFields()
        {
            NoField = Table.Fields.Add(new CodeTableField(Range.GetNextPrimaryKeyFieldNo(Table), "No.", 20).AutoCaption());
            NoSeriesField = Table.Fields.Add(new CodeTableField(Range.GetNextTableFieldNo(Table, 90), "No. Series", 10).AutoCaption());
            SetupField = SetupTable.Fields.Add(new CodeTableField(Range.GetNextTableFieldNo(SetupTable), string.Format("{0} Nos.", Table.Name), 10).AutoCaption());
        }

        protected void CreateKey()
        {
            var primaryKey = Table.Keys.Add();
            primaryKey.Fields.Add(NoField.Name);
            primaryKey.Properties.Clustered = true;
        }

        protected void SetFieldProperties()
        {
            NoSeriesField.Properties.Editable = false;
            NoSeriesField.Properties.TableRelation.Add(BaseApp.TableNames.NoSeries);

            SetupField.Properties.TableRelation.Add(BaseApp.TableNames.NoSeries);
        }

        protected void AddOnValidate()
        {
            var onValidate = NoField.Properties.OnValidate;
            var setupRecordVariable = onValidate.Variables.Add(new RecordVariable(1000, SetupTable.Name.MakeVariableName(), SetupTable.ID));
            var noSeriesMgtCodeunitVariable = onValidate.Variables.Add(new CodeunitVariable(1001, "NoSeriesMgt", 396));

            onValidate.CodeLines.Add(string.Format("IF {0} <> xRec.{0} THEN BEGIN", NoField.Name.Quoted()));
            onValidate.CodeLines.Add(string.Format("  {0}.GET;", setupRecordVariable.Name));
            onValidate.CodeLines.Add(string.Format("  {0}.TestManual({1}.\"{2} Nos.\");", noSeriesMgtCodeunitVariable.Name, setupRecordVariable.Name, Table.Name));
            onValidate.CodeLines.Add("  \"No. Series\" := '';");
            onValidate.CodeLines.Add("END;");
        }

        protected void AddOnInsert()
        {
            var onInsert = Table.Properties.OnInsert;
            var setupRecordVariable = onInsert.Variables.Add(new RecordVariable(1000, SetupTable.Name.MakeVariableName(), SetupTable.ID));
            var noSeriesMgtCodeunitVariable = onInsert.Variables.Add(new CodeunitVariable(1001, "NoSeriesMgt", 396));
            onInsert.CodeLines.Add(string.Format("IF {0} = '' THEN BEGIN", NoField.Name.Quoted()));
            onInsert.CodeLines.Add(string.Format("  {0}.GET;", setupRecordVariable.Name));
            onInsert.CodeLines.Add(string.Format("  {0}.TESTFIELD(\"{1} Nos.\");", setupRecordVariable.Name, Table.Name));
            onInsert.CodeLines.Add(string.Format("  {0}.InitSeries({1}.\"{2} Nos.\", xRec.{3}, 0D, {4}, {3});", noSeriesMgtCodeunitVariable.Name, setupRecordVariable.Name, Table.Name, NoSeriesField.Name.Quoted(), NoField.Name.Quoted()));
            onInsert.CodeLines.Add("END;");
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
            assistEdit.CodeLines.Add(string.Format("  IF {0}.SelectSeries({1}.\"{2} Nos.\", {3}.{4}, {4}) THEN BEGIN", noSeriesMgtCodeunitVariable.Name, setupRecordVariable.Name, Table.Name, parameter.Name, NoSeriesField.Name.Quoted()));
            assistEdit.CodeLines.Add(string.Format("    {0}.GET;", setupRecordVariable.Name));
            assistEdit.CodeLines.Add(string.Format("    {0}.TESTFIELD(\"{1} Nos.\");", setupRecordVariable.Name, Table.Name));
            assistEdit.CodeLines.Add(string.Format("    {0}.SetSeries({1});", noSeriesMgtCodeunitVariable.Name, NoField.Name.Quoted()));
            assistEdit.CodeLines.Add(string.Format("    Rec := {0};", variableName));
            assistEdit.CodeLines.Add("    EXIT(TRUE);");
            assistEdit.CodeLines.Add("  END;");
            assistEdit.CodeLines.Add("END;");
        }

        protected void CreateControls()
        {
            foreach (var page in Pages)
            {
                switch (page.Properties.PageType)
                {
                    case PageType.Card:
                        CreateCardPageControls(page);
                        break;
                    case PageType.List:
                        CreateListPageControls(page);
                        break;
                }
            }
        }

        protected void CreateCardPageControls(Page page)
        {
            var contentArea = page.GetContentArea(Range);
            var group = contentArea.GetGroupByCaption("General", Range, Position.FirstWithinContainer);
            var noControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.FirstWithinContainer);

            noControl.Properties.SourceExpr = NoField.Name.Quoted();
            noControl.Properties.Importance = Importance.Promoted;
            noControl.Properties.OnAssistEdit.CodeLines.Add("IF AssistEdit(xRec) THEN");
            noControl.Properties.OnAssistEdit.CodeLines.Add("  CurrPage.UPDATE;");

            noControls.Add(page, noControl);
        }

        protected void CreateListPageControls(Page page)
        {
            var contentArea = page.GetContentArea(Range);
            var group = contentArea.GetGroupByType(GroupType.Repeater, Range, Position.FirstWithinContainer);
            var noControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.FirstWithinContainer);

            noControl.Properties.SourceExpr = NoField.Name.Quoted();

            noControls.Add(page, noControl);
        }

        protected void CreateSetupControls()
        {
            var contentArea = SetupPage.GetContentArea(Range);
            var group = contentArea.GetGroupByCaption("Numbering", Range, Position.LastWithinContainer);

            SetupControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(SetupPage), 2), Position.LastWithinContainer);
            SetupControl.Properties.SourceExpr = SetupField.Name.Quoted();
        }

        public Table SetupTable
        {
            get;
            set;
        }

        public Page SetupPage
        {
            get;
            set;
        }

        public CodeTableField NoField
        {
            get;
            protected set;
        }

        public CodeTableField NoSeriesField
        {
            get;
            protected set;
        }

        public CodeTableField SetupField
        {
            get;
            protected set;
        }

        public ReadOnlyDictionary<Page, FieldPageControl> NoControls
        {
            get
            {
                return noControls.AsReadOnly();
            }
        }

        public ReadOnlyDictionary<Page, FieldPageControl> NoSeriesControls
        {
            get
            {
                return noSeriesControls.AsReadOnly();
            }
        }

        public FieldPageControl SetupControl
        {
            get;
            internal set;
        }
    }
}
