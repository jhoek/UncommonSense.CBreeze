using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class CodeLines : IEnumerable<CodeLine>
    {
        private List<CodeLine> innerList = new List<CodeLine>();

        internal CodeLines()
        {
        }

        public int FindIndex(Predicate<CodeLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<CodeLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<CodeLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<CodeLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<CodeLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<CodeLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public CodeLine Add(String text)
        {
            CodeLine item = new CodeLine(text);
            innerList.Add(item);
            return item;
        }

        public CodeLine Add(string format, params object[] args)
        {
            CodeLine item = new CodeLine(string.Format(format, args));
            innerList.Add(item);
            return item;
        }

        public CodeLine Insert(int index, String text)
        {
            CodeLine item = new CodeLine(text);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<CodeLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
