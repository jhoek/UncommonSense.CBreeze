using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Patterns
{
    public class SourceCodePattern : AddFieldsPattern
    {
        public SourceCodePattern(IEnumerable<int> range, Table table, params Page[] pages)
            : base(range, table, pages)
        {
            SourceCodeControls = new MappedResults<Page, FieldPageControl>();
        }

        protected override void CreateFields()
        {
            SourceCodeField = Table.Fields.Add(new CodeTableField(Range.GetNextTableFieldNo(Table), "Source Code", 10).AutoCaption());
            SourceCodeField.Properties.TableRelation.Add(BaseApp.TableNames.Source_Code);
        }

        protected override void CreateListPageControls(Page page)
        {
            var contentArea = page.GetContentArea(Range);
            var group = contentArea.GetGroupByType(GroupType.Repeater, Range, Position.FirstWithinContainer);

            SourceCodeControls.Add(page, group.AddFieldPageControl(Range.GetNextPageControlID(page), Position.LastWithinContainer, SourceCodeField.Name));
        }

        public CodeTableField SourceCodeField
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> SourceCodeControls
        {
            get;
            protected set;
        }
    }
}
