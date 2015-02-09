using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder
{
    public class ObjectModel : ObjectModelNode
    {
        private string @namespace;
        private List<ObjectModelElement> elements = new List<ObjectModelElement>();

        public ObjectModel(string @namespace, params ObjectModelElement[] elements)
        {
            this.@namespace = @namespace;

            foreach (var element in elements)
            {
                element.ParentNode = this;
                this.elements.Add(element);
            }
        }

        public string Namespace
        {
            get
            {
                return this.@namespace;
            }
        }

        public IEnumerable<ObjectModelElement> Elements
        {
            get
            {
                foreach (var element in this.elements)
                {
                    yield return element;
                }
            }
        }
    }
}
