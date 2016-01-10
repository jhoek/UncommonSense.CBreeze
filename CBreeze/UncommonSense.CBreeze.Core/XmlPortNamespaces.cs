using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
#if NAV2016
    public class XmlPortNamespaces : IEnumerable<XmlPortNamespace>
    {
        private Dictionary<string, XmlPortNamespace> innerList = new Dictionary<string, XmlPortNamespace>();

        public XmlPortNamespaces()
        {
        }

        public string this[string prefix]
        {
            get
            {
                return Get(prefix);
            }
            set
            {
                Set(prefix, value);
            }
        }

        public string Get(string prefix)
        {
            try
            {
                return innerList[prefix].Namespace;
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public void Set(string prefix, string @namespace)
        {
            if (@namespace == null)
            {
                Unset(prefix);
                return;
            }

            innerList[prefix] = new XmlPortNamespace(prefix, @namespace);
        }

        public void Reset()
        {
            innerList.Clear();
        }

        public bool Unset(string prefix)
        {
            return innerList.Remove(prefix);
        }

        public IEnumerator<XmlPortNamespace> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }
#endif
}
