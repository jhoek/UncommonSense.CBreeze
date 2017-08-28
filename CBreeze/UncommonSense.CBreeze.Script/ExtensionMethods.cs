using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script
{
    public static class ExtensionMethods
    {
        public static Collection<T> AddRange<T>(this Collection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }

            return collection;
        }

        public static IEnumerable<T> WriteTo<T>(this IEnumerable<T> items, TextWriter textWriter)
        {
            foreach (var item in items)
            {
                textWriter.WriteLine(item.ToString());
            }

            return items;
        }
    }
}