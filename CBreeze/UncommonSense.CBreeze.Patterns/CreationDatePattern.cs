using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Patterns
{
    public class CreationDatePattern : AddFieldsPattern
    {
        public CreationDatePattern(IEnumerable<int> range, Table table, params Page[] pages)
            : base(range, table, pages)
        {
            CreationDateControls = new FieldPageControls();
        }

        protected override void VerifyRequirements()
        {
            base.VerifyRequirements();

            if (!Table.Keys.Any())
            {
                throw new ApplicationException("The table doesn't have a primary key yet.");
            }
        }

        protected override void MakeChanges()
        {
            base.MakeChanges();

            CreateKey();
        }

        protected override void CreateFields()
        {
            CreationDateField = Table.Fields.Add(new DateTableField(Range.GetNextTableFieldNo(Table), "Creation Date").AutoCaption());
        }

        protected override void CreateListPageControls(Page page)
        {
            CreationDateControls.Add(page, CreateListPageControl(page, Position.LastWithinContainer, CreationDateField.Name));
        }

        protected void CreateKey()
        {
            if (CreateKeyOnCreationDate)
            {
                KeyOnCreationDate = Table.Keys.Add();
                KeyOnCreationDate.Fields.Add(CreationDateField.Name);
            }
        }

        public bool CreateKeyOnCreationDate
        {
            get;
            set;
        }

        public DateTableField CreationDateField
        {
            get;
            protected set;
        }

        public FieldPageControls CreationDateControls
        {
            get;protected set;
        }

        public TableKey KeyOnCreationDate
        {
            get;
            protected set;
        }
    }
}
