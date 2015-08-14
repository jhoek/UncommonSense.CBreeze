using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ColumnFilter : IEnumerable<ColumnFilterLine>
    {
        private List<ColumnFilterLine> innerList = new List<ColumnFilterLine>();

        internal ColumnFilter()
        {
        }

        public int FindIndex(Predicate<ColumnFilterLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<ColumnFilterLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<ColumnFilterLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<ColumnFilterLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<ColumnFilterLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<ColumnFilterLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public ColumnFilterLine Add(String column, ColumnFilterLineType type, String value)
        {
            ColumnFilterLine item = new ColumnFilterLine(column, type, value);
            innerList.Add(item);
            return item;
        }

        public ColumnFilterLine Insert(int index, String column, ColumnFilterLineType type, String value)
        {
            ColumnFilterLine item = new ColumnFilterLine(column, type, value);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<ColumnFilterLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
