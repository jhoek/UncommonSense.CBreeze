using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class TableRelationLines : IEnumerable<TableRelationLine>
    {
        private List<TableRelationLine> innerList = new List<TableRelationLine>();

        internal TableRelationLines()
        {
        }

        public int FindIndex(Predicate<TableRelationLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<TableRelationLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<TableRelationLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<TableRelationLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<TableRelationLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<TableRelationLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public TableRelationLine Add(String tableName)
        {
            TableRelationLine item = new TableRelationLine(tableName);
            innerList.Add(item);
            return item;
        }

        public TableRelationLine Insert(int index, String tableName)
        {
            TableRelationLine item = new TableRelationLine(tableName);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<TableRelationLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
