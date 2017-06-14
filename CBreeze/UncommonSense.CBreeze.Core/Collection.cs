using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public abstract class Collection<T> : System.Collections.ObjectModel.Collection<T>
    {
        public new T Add(T value)
        {
            base.Add(value);
            return value;
        }

        public void AddRange(IEnumerable<T> values)
        {
            if (values == null)
                return;

            foreach (var value in values)
            {
                base.Add(value);
            }
        }

        public new T Insert(int index, T value)
        {
            base.Insert(index, value);
            return value;
        }
    }
}