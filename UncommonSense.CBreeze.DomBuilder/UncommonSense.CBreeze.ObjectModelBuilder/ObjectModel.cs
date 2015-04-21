using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public class ObjectModel 
    {
        public ObjectModel(string @namespace, params ObjectModelElement[] elements)
        {
            Namespace = @namespace;

            Elements = new ObjectModelElements(this);
            Elements.AddRange(elements);
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
