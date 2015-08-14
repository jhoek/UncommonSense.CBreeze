using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class TableKeys : IEnumerable<TableKey>
    {
        private List<TableKey> innerList = new List<TableKey>();

        internal TableKeys()
        {
        }

        public int FindIndex(Predicate<TableKey> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<TableKey> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<TableKey> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<TableKey> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<TableKey> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<TableKey> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public TableKey Add()
        {
            TableKey item = new TableKey();
            innerList.Add(item);
            return item;
        }

        public TableKey Insert(int index)
        {
            TableKey item = new TableKey();
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<TableKey> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
