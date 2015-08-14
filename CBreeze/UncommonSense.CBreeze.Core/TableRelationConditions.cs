using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class TableRelationConditions : IEnumerable<TableRelationCondition>
    {
        private List<TableRelationCondition> innerList = new List<TableRelationCondition>();

        internal TableRelationConditions()
        {
        }

        public int FindIndex(Predicate<TableRelationCondition> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<TableRelationCondition> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<TableRelationCondition> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<TableRelationCondition> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<TableRelationCondition> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<TableRelationCondition> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public TableRelationCondition Add(String fieldName, TableRelationConditionType type, String value)
        {
            TableRelationCondition item = new TableRelationCondition(fieldName, type, value);
            innerList.Add(item);
            return item;
        }

        public TableRelationCondition Insert(int index, String fieldName, TableRelationConditionType type, String value)
        {
            TableRelationCondition item = new TableRelationCondition(fieldName, type, value);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<TableRelationCondition> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
