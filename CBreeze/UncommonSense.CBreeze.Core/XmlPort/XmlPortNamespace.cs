using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
#if NAV2016
    public class XmlPortNamespace
    {
        internal XmlPortNamespace(string prefix, string @namespace)
        {
            Prefix = prefix;
            Namespace = @namespace;
        }

        public string Prefix
        {
            get;
            protected set;
        }

        public string Namespace
        {
            get;
            protected set;
        }
    }
#endif
}
