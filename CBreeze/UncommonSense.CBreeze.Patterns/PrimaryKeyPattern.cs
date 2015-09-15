using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Patterns
{
    public class PrimaryKeyPattern : AddPrimaryKeyFieldsPattern
    {
        public PrimaryKeyPattern(IEnumerable<int> range, Table table)
            : base(range, table)
        {
        }

        protected override void MakeChanges()
        {
            PrimaryKeyField = Table.Fields.Add(new CodeTableField(Range.GetNextPrimaryKeyFieldNo(Table), "Primary Key", 10).AutoCaption());
        }

        public CodeTableField PrimaryKeyField
        {
            get;
            protected set;
        }
    }
}
