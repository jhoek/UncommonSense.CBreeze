using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class MultiLanguageValue : IEnumerable<MultiLanguageEntry>
    {
        private Dictionary<string, MultiLanguageEntry> innerList = new Dictionary<string, MultiLanguageEntry>();

        // Made ctor public to allow MultiLanguageProperty to new up an instance
        public MultiLanguageValue()
        {
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

        public IEnumerator<MultiLanguageEntry> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        public MultiLanguageValue Reset()
        {
            innerList.Clear();
            return this;
        }

        public Hashtable AsHashtable()
        {
            var result = new Hashtable();

            foreach (var item in innerList)
            {
                result.Add(item.Value.LanguageID, item.Value.Value);
            }

            return result;
        }

        public MultiLanguageValue Set(string languageID, string value)
        {
            // FIXME: Test validity of language ID

            if (value == null)
            {
                Unset(languageID);
                return this;
            }

            innerList[languageID] = new MultiLanguageEntry(languageID, value);
            return this;
        }

        public MultiLanguageValue Set(Hashtable hashTable)
        {
            hashTable = hashTable ?? new Hashtable();

            foreach (var key in hashTable.Keys)
            {
                Set(key.ToString(), hashTable[key].ToString());
            }

            return this;
        }

        public MultiLanguageValue Unset(string languageID)
        {
            innerList.Remove(languageID);
            return this;
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
    }
}