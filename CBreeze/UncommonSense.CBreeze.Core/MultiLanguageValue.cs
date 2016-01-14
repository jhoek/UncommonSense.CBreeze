using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class MultiLanguageValue : IEnumerable<MultiLanguageEntry>
    {
        private Dictionary<string, MultiLanguageEntry> innerList = new Dictionary<string, MultiLanguageEntry>();

        // Made ctor public to allow MultiLanguageProperty to new up an instance
        public MultiLanguageValue()
        {
        }

        public string this[string languageID]
        {
            get
            {
                return Get(languageID);
            }
            set
            {
                Set(languageID, value);
            }
        }

        public string Get(string languageID)
        {
            try
            {
                return innerList[languageID].Value;
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public void Set(string languageID, string value)
        {
            if (value == null)
            {
                Unset(languageID);
                return;
            }

            innerList[languageID] = new MultiLanguageEntry(languageID, value);
        }

        public void Reset()
        {
            innerList.Clear();
        }

        public bool Unset(string languageID)
        {
            return innerList.Remove(languageID);
        }

        public IEnumerator<MultiLanguageEntry> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }
}
