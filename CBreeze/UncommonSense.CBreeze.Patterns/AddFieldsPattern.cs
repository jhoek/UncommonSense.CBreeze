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

        public override void VerifyRequirements()
        {
            if (Range == null)
                throw new ArgumentNullException("Range");

            if (Table == null)
                throw new ArgumentNullException("Table");
        }

        protected abstract void CreateFields();

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

        protected abstract void CreateCardPageControls(Page page);

        protected abstract void CreateListPageControls(Page page);

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
            internal set;
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
