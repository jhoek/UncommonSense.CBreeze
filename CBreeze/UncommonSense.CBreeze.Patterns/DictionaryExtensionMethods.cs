using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Patterns
{
    public static class DictionaryExtensionMethods
    {
        public static ReadOnlyDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }

        public static void FromReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, ReadOnlyDictionary<TKey, TValue> readonlyDictionary)
        {
            dictionary.Clear();

            foreach (var keyValuePair in readonlyDictionary)
            {
                dictionary.Add(keyValuePair.Key, keyValuePair.Value);
            }
        }
    }
}
