using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Patterns
{
    public abstract class AddPrimaryKeyFieldsPattern : AddFieldsPattern
    {
        public AddPrimaryKeyFieldsPattern(IEnumerable<int> range, Table table, params Page[] pages)
            : base(range, table, pages)
        {
        }

        protected override void VerifyRequirements()
        {
            base.VerifyRequirements();

            if (Table.Keys.Any())
                throw new ArgumentException("Table already has a primary key.");
        }

        protected override void MakeChanges()
        {
            CreateFields();
            CreateKey();
            CreateControls();
        }

        protected virtual void CreateFields()
        {
        }

        protected virtual void CreateKey()
        {
        }

        protected virtual void CreateControls()
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

        public TableKey PrimaryKey
        {
            get;
            protected set;
        }
    }
}
