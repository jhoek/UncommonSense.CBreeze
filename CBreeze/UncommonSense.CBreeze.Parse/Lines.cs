using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace UncommonSense.CBreeze.Parse
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    internal class Lines : IEnumerable<string>
    {
        private List<string> innerList;

        internal Lines(IEnumerable<string> lines)
        {
            this.innerList = lines.ToList<string>();
        }

        internal Lines(List<string> lines)
        {
            this.innerList = lines;
        }

        protected string DebuggerDisplay
        {
            get
            {
                return string.Format("'{0}' .. '{1}' [{2}]", this.FirstOrDefault(), this.LastOrDefault(), this.Count());
            }
        }

        internal IEnumerable<Lines> Chunks(Regex regex)
        {
            var start = 0;
            var offsets = Offsets(regex);

            foreach (var offset in offsets)
            {
                yield return new Lines(innerList.GetRange(start, offset - start));
                //yield return new Lines(innerList.Skip(start).Take(offset - start));
                start = offset;
            }
        }

        internal IEnumerable<int> Offsets(Regex regex)
        {
            if (!innerList.Any())
                yield break;

            var count = innerList.Count();

            for (var i = 1; i < count; i++)
            {
                if (regex.IsMatch(innerList[i]))
                    yield return i;
            }

            yield return count;
        }

        internal void Consume(int lineNo, int offset, int length)
        {
            innerList[lineNo] = innerList[lineNo].Remove(offset, length);

            if (string.IsNullOrEmpty(innerList[lineNo]))
                innerList.RemoveAt(lineNo);
        }

        internal void Unindent(int unindent)
        {
            for (var i = 0; i < innerList.Count(); i++)
            {
                var indentation = innerList[i].Length - innerList[i].TrimStart().Length;

                if (indentation >= unindent)
                    innerList[i] = innerList[i].Substring(unindent);
            }
        }

        internal Lines Extract(string fromLine, string toLine)
        {
            var fromIndex = innerList.IndexOf(fromLine);

            if (fromIndex == -1)
                return null;

            var toIndex = innerList.IndexOf(toLine, fromIndex);

            if (toIndex == -1)
                return null;

            var count = toIndex - fromIndex + 1;
            var result = innerList.GetRange(fromIndex, count);

            innerList.RemoveRange(fromIndex, count);
            return new Lines(result);
        }

        public string this[int index]
        {
            get
            {
                return innerList[index];
            }
        }

        [DebuggerStepThrough()]
        public IEnumerator<string> GetEnumerator()
        {
            return this.innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.innerList.GetEnumerator();
        }
    }
}

