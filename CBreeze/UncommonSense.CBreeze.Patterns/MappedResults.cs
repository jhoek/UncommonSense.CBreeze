using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Patterns
{
    public class MappedResults<TKey, TValue> : IEnumerable<KeyValuePair<TKey,TValue>>
    {
        private Dictionary<TKey, TValue> innerDictionary = new Dictionary<TKey, TValue>();

        public MappedResults()
        {
        }

        public void Add(TKey key, TValue value)
        {
            innerDictionary.Add(key, value);
        }

        public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> values)
        {
            foreach (var value in values)
            {
                Add(value.Key, value.Value);
            }
        }

        public void Clear()
        {
            innerDictionary.Clear();
        }

        public TValue Get(TKey key)
        {
            return innerDictionary[key];
        }

        public TValue this[TKey key]
        {
            get
            {
                return Get(key);
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return innerDictionary.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerDictionary.GetEnumerator();
        }
    }
}
