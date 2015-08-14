using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class TableFieldGroups : IEnumerable<TableFieldGroup>
    {
        private Dictionary<Int32,TableFieldGroup> innerList = new Dictionary<Int32,TableFieldGroup>();

        internal TableFieldGroups()
        {
        }

        public TableFieldGroup Add(Int32 id, String name)
        {
            TableFieldGroup item = new TableFieldGroup(id, name);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<TableFieldGroup> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }
}
