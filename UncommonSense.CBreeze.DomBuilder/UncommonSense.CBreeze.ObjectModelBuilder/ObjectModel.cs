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
            Elements = new ObjectModelElements(this);
        }

        public override string ToString()
        {
            return Namespace;
        }        

        public string Namespace
        {
            get;
            internal set;
        }

        public ObjectModelElements Elements
        {
            get;
            internal set;
        }
    }
}
