using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ReportDataItemLink : IEnumerable<ReportDataItemLinkLine>
    {
        private List<ReportDataItemLinkLine> innerList = new List<ReportDataItemLinkLine>();

        internal ReportDataItemLink()
        {
        }

        public int FindIndex(Predicate<ReportDataItemLinkLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<ReportDataItemLinkLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<ReportDataItemLinkLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<ReportDataItemLinkLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<ReportDataItemLinkLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<ReportDataItemLinkLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public ReportDataItemLinkLine Add(String fieldName, String referenceFieldName)
        {
            ReportDataItemLinkLine item = new ReportDataItemLinkLine(fieldName, referenceFieldName);
            innerList.Add(item);
            return item;
        }

        public ReportDataItemLinkLine Insert(int index, String fieldName, String referenceFieldName)
        {
            ReportDataItemLinkLine item = new ReportDataItemLinkLine(fieldName, referenceFieldName);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<ReportDataItemLinkLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
