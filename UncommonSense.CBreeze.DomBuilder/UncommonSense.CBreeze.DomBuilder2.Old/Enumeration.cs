using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder2
{
    public class Enumeration : DomChildNode
    {
        private Dom dom;
        private string name;
        private List<string> values = new List<string>();

        public Enumeration(string name, params string[] values)
        {
            this.name = name;
            this.values.AddRange(values);
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public IEnumerable<string> Values
        {
            get
            {
                return values;
            }
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield break;
            }
        }

        public Dom Dom
        {
            get
            {
                return this.dom;
            }
            set
            {
                this.dom = value;
            }
        }
    }
}
