using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Patterns
{
    public class LedgerEntityTypePattern : EntityTypePattern
    {
        private string pluralName;

        public LedgerEntityTypePattern(Application application, IEnumerable<int> range)
            : base(application, range)
        {
        }

        protected override void MakeChanges()
        {
            Table = Application.Tables.Add(new Table(Range.GetNextTableID(Application), Name).AutoCaption());
            Page = Application.Pages.Add(new Page(Range.GetNextPageID(Application), PluralName).AutoCaption());

            var entryNoPattern = new EntryNoPattern(Range, Table, Page);
            entryNoPattern.Apply();

            if (MasterEntityTypeTable != null)
            {
                MasterEntityTypeField = Table.Fields.Add(new CodeTableField(Range.GetNextTableFieldNo(Table), string.Format("{0} No.", MasterEntityTypeTable.Name), 20).AutoCaption());
                MasterEntityTypeField.Properties.TableRelation.Add(MasterEntityTypeTable.Name);

                // FIXME: add to page(s)
            }

            AddDescription();

            // FIXME: Expose pattern results as properties
        }

        protected void AddDescription()
        {
            var descriptionPattern = new DescriptionPattern(Range, Table, Page);
            descriptionPattern.HasDescription2 = false;
            descriptionPattern.HasSearchDescription = false;
            descriptionPattern.Apply();

            DescriptionField = descriptionPattern.DescriptionField;
        }

        public string Name
        {
            get;
            set;
        }

        public string PluralName
        {
            get
            {
                return this.pluralName ?? string.Format("{0}s", Name);
            }
            set
            {
                this.pluralName = value;
            }
        }

        public Table MasterEntityTypeTable
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

        // FIXME: Replace internal set with protected set in this project

        public CodeTableField MasterEntityTypeField
        {
            get;
            protected set;
        }

        public TextTableField DescriptionField
        {
            get;
            protected set;
        }
    }
}
