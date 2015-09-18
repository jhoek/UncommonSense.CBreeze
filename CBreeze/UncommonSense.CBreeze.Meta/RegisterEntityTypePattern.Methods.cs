using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Patterns;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Meta
{
    public partial class RegisterEntityTypePattern : EntityTypePattern
    {
        private List<Table> ledgerEntryTables = new List<Table>();

        public RegisterEntityTypePattern(Application application, IEnumerable<int> range, string name, params Table[] ledgerEntryTables)
            : base(application, range, name)
        {
            NoControls = new MappedResults<Page, FieldPageControl>();
            FromEntryNoFields = new MappedResults<Core.Table, IntegerTableField>();
            FromEntryNoControls = new MappedResults<Core.Table, FieldPageControl>();
            ToEntryNoFields = new MappedResults<Core.Table, IntegerTableField>();
            ToEntryNoControls = new MappedResults<Core.Table, FieldPageControl>();
            CreationDateControls = new MappedResults<Page, FieldPageControl>();
            UserIDControls = new MappedResults<Page, FieldPageControl>();
            SourceCodeControls = new MappedResults<Page, FieldPageControl>();

            this.ledgerEntryTables.AddRange(ledgerEntryTables);

            HasCreationDate = true;
            HasSourceCode = true;
            HasUserID = true;
            HasJournalBatchName = true;
        }

        protected override void CreateObjects()
        {
            Table = Application.Tables.Add(new Table(Range.GetNextTableID(Application), Name).AutoCaption());
            Page = Application.Pages.Add(new Page(Range.GetNextPageID(Application), Name).AutoCaption());

            Page.Properties.PageType = PageType.List;
            Page.Properties.Editable = false;
        }

        protected override void LinkObjects()
        {
            Table.Properties.DrillDownPageID = Page.ID;
            Table.Properties.LookupPageID = Page.ID;
            Page.Properties.SourceTable = Table.ID;
        }

        protected override void CreateFields()
        {
            var noPattern = new NoPattern(Range, Table, Page);
            noPattern.Apply();
            NoField = noPattern.NoField;
            NoControls.AddRange(noPattern.NoControls);

            var contentArea = Page.GetContentArea(Range);
            var repeater = contentArea.GetGroupByType(GroupType.Repeater, Range, Position.FirstWithinContainer);

            foreach (var ledgerEntryTable in LedgerEntryTables)
            {
                var fromEntryNoField = Table.Fields.Add(new IntegerTableField(Range.GetNextTableFieldNo(Table), string.Format("From {0} No.", ledgerEntryTable.Name)).AutoCaption());
                fromEntryNoField.Properties.TableRelation.Add(ledgerEntryTable.Name);
                fromEntryNoField.Properties.TestTableRelation = false;
                FromEntryNoFields.Add(ledgerEntryTable, fromEntryNoField);

                var fromEntryNoControl = repeater.AddFieldPageControl(Range.GetNextPageControlID(Page), Position.LastWithinContainer, fromEntryNoField.Name);
                FromEntryNoControls.Add(ledgerEntryTable, fromEntryNoControl);

                var toEntryNoField = Table.Fields.Add(new IntegerTableField(Range.GetNextTableFieldNo(Table), string.Format("To {0} No.", ledgerEntryTable.Name)).AutoCaption());
                toEntryNoField.Properties.TableRelation.Add(ledgerEntryTable.Name);
                toEntryNoField.Properties.TestTableRelation = false;
                ToEntryNoFields.Add(ledgerEntryTable, toEntryNoField);

                var toEntryNoControl = repeater.AddFieldPageControl(Range.GetNextPageControlID(Page), Position.LastWithinContainer, toEntryNoField.Name);
                ToEntryNoControls.Add(ledgerEntryTable, toEntryNoControl);
            }

            if (HasCreationDate)
            {
                var creationDatePattern = new CreationDatePattern(Range, Table, Page);
                creationDatePattern.Apply();
                CreationDateField = creationDatePattern.CreationDateField;
                CreationDateControls.AddRange(creationDatePattern.CreationDateControls);
            }

            if (HasUserID)
            {
                var userIDPattern = new UserIDPattern(Range, Table, Page);
                userIDPattern.Apply();
                UserIDField = userIDPattern.UserIDField;
                UserIDControls.AddRange(userIDPattern.UserIDControls);
            }

            if (HasSourceCode)
            {
                var sourceCodePattern = new SourceCodePattern(Range, Table, Page);
                sourceCodePattern.Apply();
                SourceCodeField = sourceCodePattern.SourceCodeField;
                SourceCodeControls.AddRange(sourceCodePattern.SourceCodeControls);
            }

            // FIXME: other fields
        }

        protected override void CreateControls()
        {
            base.CreateControls();

            var factboxArea = Page.GetFactboxArea(Range);
            factboxArea.AddSystemPartPageControl(Range.GetNextPageControlID(Page), Position.LastWithinContainer, SystemPartID.RecordLinks, true);
            factboxArea.AddSystemPartPageControl(Range.GetNextPageControlID(Page), Position.LastWithinContainer, SystemPartID.Notes, true);
        }
    }
}
