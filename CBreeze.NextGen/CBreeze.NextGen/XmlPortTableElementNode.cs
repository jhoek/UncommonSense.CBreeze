using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class XmlPortTableElementNode : XmlPortNode
    {
        public XmlPortTableElementNode(int id, string name, int? indentationLevel)
            : base(id, name, indentationLevel)
        {
            Properties = new XmlPortTableElementNodeProperties(this);
        }

        public override XmlPortNodeType Type
        {
            get
            {
                return XmlPortNodeType.TableElement;
            }
        }

        public XmlPortTableElementNodeProperties Properties
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
