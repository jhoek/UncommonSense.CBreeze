namespace UncommonSense.CBreeze.Core.XmlPort
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
