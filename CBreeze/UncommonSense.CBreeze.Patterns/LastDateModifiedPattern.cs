using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Patterns
{
    public class LastDateModifiedPattern : AddFieldsPattern
    {
        public LastDateModifiedPattern(IEnumerable<int> range, Table table, params Page[] pages)
            : base(range, table, pages)
        {
            LastDateModifiedControls = new MappedResults<Page, FieldPageControl>();
        }

        protected override void MakeChanges()
        {
            AddField();
            AddTriggerCode();
            AddControls();
        }

        protected void AddField()
        {
            LastDateModifiedField = Table.Fields.Add(new DateTableField(Range.GetNextTableFieldNo(Table), "Last Date Modified").AutoCaption());
            LastDateModifiedField.Properties.Editable = false;
        }

        protected void AddTriggerCode()
        {
            var codeLine = string.Format("{0} := TODAY;", LastDateModifiedField.QuotedName);
            Table.Properties.OnModify.CodeLines.Add(codeLine);
            Table.Properties.OnRename.CodeLines.Add(codeLine);
        }

        protected void AddControls()
        {
            foreach (var page in Pages)
            {
                switch (page.Properties.PageType)
                {
                    case PageType.Card:
                        AddCardPageControls(page);
                        break;
                    case PageType.List:
                        AddListPageControls(page);
                        break;
                }
            }
        }

        protected void AddCardPageControls(Page page)
        {
            var contentArea = page.GetContentArea(Range);
            var group = contentArea.GetGroupByCaption(GroupCaption, Range, CardPageGroupPosition);

            LastDateModifiedControls.Add(page, group.AddFieldPageControl(Range.GetNextPageControlID(page), Position.LastWithinContainer, LastDateModifiedField.Name));
        }

        protected void AddListPageControls(Page page)
        {
            var contentArea = page.GetContentArea(Range);
            var group = contentArea.GetGroupByType(GroupType.Repeater, Range, ListPageGroupPosition);

            var lastDateModifiedControl = group.AddFieldPageControl(Range.GetNextPageControlID(page), Position.LastWithinContainer, LastDateModifiedField.Name);
            lastDateModifiedControl.Properties.Visible = false.ToString();
            LastDateModifiedControls.Add(page, lastDateModifiedControl);
        }

        public DateTableField LastDateModifiedField
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> LastDateModifiedControls
        {
            get;protected set;
        }
    }
}
