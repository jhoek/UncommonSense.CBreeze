using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class QueryOrderByLines : IEnumerable<QueryOrderByLine>
    {
        private List<QueryOrderByLine> innerList = new List<QueryOrderByLine>();

        internal QueryOrderByLines()
        {
        }

        public int FindIndex(Predicate<QueryOrderByLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<QueryOrderByLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<QueryOrderByLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<QueryOrderByLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<QueryOrderByLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<QueryOrderByLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public QueryOrderByLine Add(String column, QueryOrderByDirection direction)
        {
            QueryOrderByLine item = new QueryOrderByLine(column, direction);
            innerList.Add(item);
            return item;
        }

        public QueryOrderByLine Insert(int index, String column, QueryOrderByDirection direction)
        {
            QueryOrderByLine item = new QueryOrderByLine(column, direction);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<QueryOrderByLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
