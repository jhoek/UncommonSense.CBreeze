using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public class ObjectModel : ObjectModelNode
    {
        public ObjectModel(string @namespace)
        {
            Namespace = @namespace;
            Elements = new List<ObjectModelElement>();
        }

        public string Namespace
        {
            get;
            internal set;
        }

        public List<ObjectModelElement> Elements
        {
            get;
            internal set;
        }
    }
}
