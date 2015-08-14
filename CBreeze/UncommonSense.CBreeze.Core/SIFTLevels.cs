using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class SIFTLevels : IEnumerable<SIFTLevel>
    {
        private List<SIFTLevel> innerList = new List<SIFTLevel>();

        internal SIFTLevels()
        {
        }

        public SIFTLevel Add()
        {
            SIFTLevel item = new SIFTLevel();
            innerList.Add(item);
            return item;
        }

        public SIFTLevel Insert(int index)
        {
            SIFTLevel item = new SIFTLevel();
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<SIFTLevel> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
