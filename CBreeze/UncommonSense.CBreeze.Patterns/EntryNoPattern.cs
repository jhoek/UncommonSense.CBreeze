using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Patterns
{
    public class EntryNoPattern : AddPrimaryKeyFieldsPattern
    {
        private Dictionary<Page, FieldPageControl> entryNoControls = new Dictionary<Page, FieldPageControl>();

        public EntryNoPattern(IEnumerable<int> range, Table table, params Page[] pages)
            : base(range, table, pages)
        {
        }

        protected override void MakeChanges()
        {
            CreateFields();
            CreateControls();

            // FIXME: Make primary key (also applies to other AddPrimaryKeyFields patterns)
        }

        protected void CreateFields()
        {
            EntryNoField = Table.Fields.Add(new IntegerTableField(Range.GetNextPrimaryKeyFieldNo(Table), "Entry No.").AutoCaption());
        }

        protected void CreateControls()
        {
            foreach (var page in Pages)
            {
                switch (page.Properties.PageType)
                {
                    case PageType.List:
                        CreateListPageControls(page);
                        break;
                }
            }
        }

        protected void CreateListPageControls(Page page)
        {
            var contentArea = page.GetContentArea(Range);
            var group = contentArea.GetGroupByType(GroupType.Repeater, Range, Position.FirstWithinContainer);
            var entryNoControl = group.AddFieldPageControl(Range.GetNextPageControlID(page), Position.LastWithinContainer, EntryNoField.Name.Quoted());
            entryNoControls.Add(page, entryNoControl);
        }

        public IntegerTableField EntryNoField
        {
            get;
            protected set;
        }

        public ReadOnlyDictionary<Page, FieldPageControl> EntryNoControls
        {
            get
            {
                return entryNoControls.AsReadOnly();
            }
        }
    }
}
