using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Meta
{
    public class SupplementalEntityTypePattern : EntityTypePattern
    {
        private string pluralName;

        public SupplementalEntityTypePattern(Application application, IEnumerable<int> range, string name)
            : base(application, range, name)
        {
        }

        protected override void CreateObjects()
        {
            Table = Application.Tables.Add(new Table(Range.GetNextTableID(Application), Name).AutoCaption());
            Page = Application.Pages.Add(new Page(Range.GetNextPageID(Application), PluralName).AutoCaption());
        }

        protected override void SetObjectProperties()
        {
            Page.Properties.PageType = PageType.List;
        }

        protected override void LinkObjects()
        {
            Table.Properties.LookupPageID = Page.ID;
            Table.Properties.DrillDownPageID = Page.ID;

            Page.Properties.SourceTable = Table.ID;
        }

        protected override void CreateFields()
        {
            CodeField = Table.Fields.Add(new CodeTableField(Range.GetNextPrimaryKeyFieldNo(Table), "Code", 10).AutoCaption());
            DescriptionField = Table.Fields.Add(new TextTableField(Range.GetNextTableFieldNo(Table), "Description", 50).AutoCaption());
        }

        protected override void SetFieldProperties()
        {
            CodeField.Properties.NotBlank = true;
        }

        protected override void CreateControls()
        {
            CodeControl = CreateListPageControl(Page, Position.LastWithinContainer, CodeField.Name);
            DescriptionControl = CreateListPageControl(Page, Position.LastWithinContainer, DescriptionField.Name);

            var factboxArea = Page.GetFactboxArea(Range);
            factboxArea.AddSystemPartPageControl(Range.GetNextPageControlID(Page), Position.LastWithinContainer, SystemPartID.RecordLinks).Hide();
            factboxArea.AddSystemPartPageControl(Range.GetNextPageControlID(Page), Position.LastWithinContainer, SystemPartID.Notes).Hide();
        }

        public string PluralName
        {
            get
            {
                return this.pluralName ?? Name.MakePlural();
            }
            set
            {
                this.pluralName = value;
            }
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

        public CodeTableField CodeField
        {
            get;
            protected set;
        }

        public TextTableField DescriptionField
        {
            get;
            protected set;
        }

        public FieldPageControl CodeControl
        {
            get;
            protected set;
        }

        public FieldPageControl DescriptionControl
        {
            get;
            protected set;
        }
    }
}
