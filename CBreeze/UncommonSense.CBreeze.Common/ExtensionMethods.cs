using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Common
{
    public static class ExtensionMethods
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items ?? Enumerable.Empty<T>())
            {
                action(item);
            }

            return items;
        }
    }
}
