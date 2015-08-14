using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class DataItemQueryElementTableFilter : IEnumerable<DataItemQueryElementTableFilterLine>
    {
        private List<DataItemQueryElementTableFilterLine> innerList = new List<DataItemQueryElementTableFilterLine>();

        internal DataItemQueryElementTableFilter()
        {
        }

        public int FindIndex(Predicate<DataItemQueryElementTableFilterLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<DataItemQueryElementTableFilterLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<DataItemQueryElementTableFilterLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<DataItemQueryElementTableFilterLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<DataItemQueryElementTableFilterLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<DataItemQueryElementTableFilterLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public DataItemQueryElementTableFilterLine Add(String fieldName, DataItemQueryElementTableFilterLineType type, String value)
        {
            DataItemQueryElementTableFilterLine item = new DataItemQueryElementTableFilterLine(fieldName, type, value);
            innerList.Add(item);
            return item;
        }

        public DataItemQueryElementTableFilterLine Insert(int index, String fieldName, DataItemQueryElementTableFilterLineType type, String value)
        {
            DataItemQueryElementTableFilterLine item = new DataItemQueryElementTableFilterLine(fieldName, type, value);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<DataItemQueryElementTableFilterLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
