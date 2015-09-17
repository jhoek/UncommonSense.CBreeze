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
        public EntryNoPattern(IEnumerable<int> range, Table table, params Page[] pages)
            : base(range, table, pages)
        {
            EntryNoControls = new PatternResults<Page, FieldPageControl>();
        }

        protected override void CreateFields()
        {
            EntryNoField = Table.Fields.Add(new IntegerTableField(Range.GetNextPrimaryKeyFieldNo(Table), "Entry No.").AutoCaption());
        }

        protected override void CreateKey()
        {
            PrimaryKey = Table.Keys.Add();
            PrimaryKey.Fields.Add(EntryNoField.Name);
            PrimaryKey.Properties.Clustered = true;
        }

        protected override void CreateListPageControls(Page page)
        {
            var contentArea = page.GetContentArea(Range);
            var group = contentArea.GetGroupByType(GroupType.Repeater, Range, Position.FirstWithinContainer);
            var entryNoControl = group.AddFieldPageControl(Range.GetNextPageControlID(page), Position.LastWithinContainer, EntryNoField.Name.Quoted());

            EntryNoControls.Add(page, entryNoControl);
        }

        public IntegerTableField EntryNoField
        {
            get;
            protected set;
        }

        public PatternResults<Page, FieldPageControl> EntryNoControls
        {
            get;protected set;
        }
    }
}
