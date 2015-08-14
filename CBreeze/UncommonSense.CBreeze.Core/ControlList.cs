using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ControlList : IEnumerable<ControlReference>
    {
        private List<ControlReference> innerList = new List<ControlReference>();

        internal ControlList()
        {
        }

        public int FindIndex(Predicate<ControlReference> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<ControlReference> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<ControlReference> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<ControlReference> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<ControlReference> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<ControlReference> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public ControlReference Add(String controlName)
        {
            ControlReference item = new ControlReference(controlName);
            innerList.Add(item);
            return item;
        }

        public void AddRange(params String[] controlNames)
        {
            foreach(var item in controlNames)
            {
               innerList.Add(new ControlReference(item));
             }
        }

        public ControlReference Insert(int index, String controlName)
        {
            ControlReference item = new ControlReference(controlName);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<ControlReference> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
