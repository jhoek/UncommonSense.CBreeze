using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class XmlPortTextElementNode : XmlPortNode
    {
        public XmlPortTextElementNode(int id, string name, int? indentationLevel) : base(id, name, indentationLevel)
        {
            Properties = new XmlPortTextElementNodeProperties(this);
        }

        public override XmlPortNodeType Type
        {
            get
            {
                return XmlPortNodeType.TextElement;
            }
        }

        public XmlPortTextElementNodeProperties Properties
        {
            get;
            internal set;
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }
    }
}
