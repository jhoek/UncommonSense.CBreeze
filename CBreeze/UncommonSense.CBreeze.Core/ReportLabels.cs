using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ReportLabels : IEnumerable<ReportLabel>
    {
        private Dictionary<Int32,ReportLabel> innerList = new Dictionary<Int32,ReportLabel>();

        internal ReportLabels()
        {
        }

        public ReportLabel Add(Int32 id, String name)
        {
            ReportLabel item = new ReportLabel(id, name);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<ReportLabel> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }
}
