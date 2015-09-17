using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Patterns;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Meta
{
    public class RegisterEntityTypePattern : EntityTypePattern
    {
        private List<Table> ledgerEntryTables = new List<Table>();

        public RegisterEntityTypePattern(Application application, IEnumerable<int> range, string name, params Table[] ledgerEntryTables)
            : base(application, range, name)
        {
            CreationDateControls = new PatternResults<Page, FieldPageControl>();
            UserIDControls = new PatternResults<Page, FieldPageControl>();
            SourceCodeControls = new PatternResults<Page,FieldPageControl>();

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

            foreach (var ledgerEntryTable in LedgerEntryTables)
            {

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

        public IEnumerable<Table> LedgerEntryTables
        {
            get
            {
                return this.ledgerEntryTables.AsEnumerable();
            }
        }

        public bool HasCreationDate
        {
            get;
            set;
        }

        public bool HasSourceCode
        {
            get;
            set;
        }

        public bool HasUserID
        {
            get;
            set;
        }

        public bool HasJournalBatchName
        {
            get;
            set;
        }

        public Table Table
        {
            get;
            protected set;
        }

        public Page Page
        {
            get;
            protected set;
        }

        public IntegerTableField NoField
        {
            get;
            protected set;
        }

        public DateTableField CreationDateField
        {
            get;
            protected set;
        }

        public PatternResults<Page, FieldPageControl> CreationDateControls
        {
            get;
            protected set;
        }

        public CodeTableField UserIDField
        {
            get;
            protected set;
        }

        public PatternResults<Page,FieldPageControl> UserIDControls
        {
            get;
            protected set;
        }

        public CodeTableField SourceCodeField
        {
            get;
            protected set;
        }

        public PatternResults<Page, FieldPageControl> SourceCodeControls
        {
            get;
            protected set;
        }
    }
}
