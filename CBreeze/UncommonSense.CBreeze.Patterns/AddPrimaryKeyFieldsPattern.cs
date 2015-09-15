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
    }
}
