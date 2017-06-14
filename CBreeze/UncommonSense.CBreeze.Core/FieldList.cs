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
        public FieldList()
        {
        }

        public FieldList(string[] fieldNames)
        {
            AddRange(fieldNames);
        }

        public void AddRange(params string[] fieldNames)
        {
            if (fieldNames == null)
                return;

            foreach (var item in fieldNames)
            {
                Add(item);
            }
        }
    }
}