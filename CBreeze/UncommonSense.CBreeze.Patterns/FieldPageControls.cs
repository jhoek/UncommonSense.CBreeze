using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Patterns
{
    public class FieldPageControls : IEnumerable<KeyValuePair<Page,FieldPageControl>>
    {
        private Dictionary<Page, FieldPageControl> innerDictionary = new Dictionary<Page, FieldPageControl>();

        public FieldPageControls()
        {
        }

        public void Add(Page page, FieldPageControl fieldPageControl)
        {
            innerDictionary.Add(page, fieldPageControl);
        }

        public void AddRange(IEnumerable<KeyValuePair<Page, FieldPageControl>> values)
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

        public FieldPageControl Get(Page page)
        {
            return innerDictionary[page];
        }

        public FieldPageControl this[Page page]
        {
            get
            {
                return Get(page);
            }
        }

        public IEnumerator<KeyValuePair<Page, FieldPageControl>> GetEnumerator()
        {
            return innerDictionary.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerDictionary.GetEnumerator();
        }
    }
}
