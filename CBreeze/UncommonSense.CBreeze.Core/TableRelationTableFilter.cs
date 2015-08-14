using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class TableRelationTableFilter : IEnumerable<TableRelationTableFilterLine>
    {
        private List<TableRelationTableFilterLine> innerList = new List<TableRelationTableFilterLine>();

        internal TableRelationTableFilter()
        {
        }

        public int FindIndex(Predicate<TableRelationTableFilterLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<TableRelationTableFilterLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<TableRelationTableFilterLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<TableRelationTableFilterLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<TableRelationTableFilterLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<TableRelationTableFilterLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public TableRelationTableFilterLine Add(String fieldName, TableRelationTableFilterLineType type, String value)
        {
            TableRelationTableFilterLine item = new TableRelationTableFilterLine(fieldName, type, value);
            innerList.Add(item);
            return item;
        }

        public TableRelationTableFilterLine Insert(int index, String fieldName, TableRelationTableFilterLineType type, String value)
        {
            TableRelationTableFilterLine item = new TableRelationTableFilterLine(fieldName, type, value);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<TableRelationTableFilterLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
