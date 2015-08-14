using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class RunObjectLink : IEnumerable<RunObjectLinkLine>
    {
        private List<RunObjectLinkLine> innerList = new List<RunObjectLinkLine>();

        internal RunObjectLink()
        {
        }

        public int FindIndex(Predicate<RunObjectLinkLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<RunObjectLinkLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<RunObjectLinkLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<RunObjectLinkLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<RunObjectLinkLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<RunObjectLinkLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public RunObjectLinkLine Add(String fieldName, RunObjectLinkLineType type, String value)
        {
            RunObjectLinkLine item = new RunObjectLinkLine(fieldName, type, value);
            innerList.Add(item);
            return item;
        }

        public RunObjectLinkLine Insert(int index, String fieldName, RunObjectLinkLineType type, String value)
        {
            RunObjectLinkLine item = new RunObjectLinkLine(fieldName, type, value);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<RunObjectLinkLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
