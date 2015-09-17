using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Patterns
{
    public abstract class AddFieldsPattern : Pattern
    {
        public AddFieldsPattern(IEnumerable<int> range, Table table, params Page[] pages)
        {
            Range = range;
            Table = table;
            Pages = new List<Page>();

            Pages.AddRange(pages);
        }

        protected override void VerifyRequirements()
        {
            if (Range == null)
                throw new ArgumentNullException("Range");

            if (Table == null)
                throw new ArgumentNullException("Table");
        }

        protected override void MakeChanges()
        {
            CreateFields();
            CreateControls();
        }

        protected virtual void CreateFields()
        {
        }

        protected void CreateControls()
        {
            foreach (var page in Pages)
            {
                switch (page.Properties.PageType)
                {
                    case PageType.Card:
                        CreateCardPageControls(page);
                        break;
                    case PageType.List:
                        CreateListPageControls(page);
                        break;
                }
            }
        }

        protected virtual void CreateCardPageControls(Page page)
        {
        }

        protected virtual void CreateListPageControls(Page page)
        {
        }

        protected virtual FieldPageControl CreateListPageControl(Page page, Position position, string sourceExpr)
        {
            var contentArea = page.GetContentArea(Range);
            var repeater = contentArea.GetGroupByType(GroupType.Repeater, Range, Position.FirstWithinContainer);
            return repeater.AddFieldPageControl(Range.GetNextPageControlID(page), position, sourceExpr);
        }

        public IEnumerable<int> Range
        {
            get;
            set;
        }

        public Table Table
        {
            get;
            set;
        }

        public List<Page> Pages
        {
            get;
            protected set;
        }

        public string Prefix
        {
            get;
            set;
        }

        public string GroupCaption
        {
            get;
            set;
        }

        public Position CardPageGroupPosition
        {
            get;
            set;
        }

        public Position ListPageGroupPosition
        {
            get;
            set;
        }
    }
}
