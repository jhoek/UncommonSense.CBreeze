using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Patterns
{
    public class NoPattern : AddPrimaryKeyFieldsPattern
    {
        public NoPattern(IEnumerable<int> range, Table table, params Page[] pages)
            : base(range, table, pages)
        {
            NoControls = new PatternResults<Page, FieldPageControl>();
        }

        protected override void CreateFields()        
        {
            NoField = Table.Fields.Add(new IntegerTableField(Range.GetNextTableFieldNo(Table), "No.").AutoCaption());
        }

        protected override void CreateKey()
        {
            PrimaryKey = Table.Keys.Add();
            PrimaryKey.Fields.Add(NoField.Name);
            PrimaryKey.Properties.Clustered = true;
        }

        protected override void CreateListPageControls(Page page)
        {
            var contentArea = page.GetContentArea(Range);
            var group = contentArea.GetGroupByType(GroupType.Repeater, Range, Position.FirstWithinContainer);

            NoControls.Add(page, group.AddFieldPageControl(Range.GetNextPageControlID(page), Position.FirstWithinContainer, NoField.Name));
        }

        public IntegerTableField NoField
        {
            get;
            protected set;
        }

        public PatternResults<Page, FieldPageControl> NoControls
        {
            get;protected set;
        }
    }
}
