using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class TableKey
    {
        public TableKey(params string[] fieldNames)
        {
            Fields = new FieldList();
            Properties = new TableKeyProperties();

            Fields.AddRange(fieldNames);
        }

        public override string ToString()
        {
            return string.Join(",", Fields);
        }

        public bool? Enabled
        {
            get;
            set;
        }

        public FieldList Fields
        {
            get;
            protected set;
        }

        public TableKeyProperties Properties
        {
            get;
            protected set;
        }

    }
}
