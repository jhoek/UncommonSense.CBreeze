using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UncommonSense.CBreeze.Core
{
    public class FieldList : Collection<string>
    {
        // Made ctor public so that FieldListProperty can new up an instance
        public FieldList() { }
        public FieldList(params string[] fieldNames) { AddRange(fieldNames); }

        protected override void InsertItem(int index, string item)
        {
            base.InsertItem(index, item);
        }
    }
}