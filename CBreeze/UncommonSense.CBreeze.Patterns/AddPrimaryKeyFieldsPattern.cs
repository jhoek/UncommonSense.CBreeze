using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Patterns
{
    public abstract class AddPrimaryKeyFieldsPattern
    {
        public AddPrimaryKeyFieldsPattern(IEnumerable<int> range, Table table, params Page[] pages)
            : base(range, table, pages)
        {
        }

        protected void VerifyRequirements()
        {
            if (Table.Keys.Any())
                throw new ArgumentException("Table already has a primary key.");
        }

        protected void MakeChanges()
        {
            CreateKey();
        }

        protected virtual void CreateKey()
        {
        }

        public TableKey PrimaryKey
        {
            get;
            protected set;
        }
    }
}
