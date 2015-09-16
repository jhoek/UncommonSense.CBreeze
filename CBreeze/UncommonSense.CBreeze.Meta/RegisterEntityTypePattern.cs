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
        public RegisterEntityTypePattern(Application application, IEnumerable<int> range, string name)
            : base(application, range, name)
        {
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

            // FIXME: other fields
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
    }
}
