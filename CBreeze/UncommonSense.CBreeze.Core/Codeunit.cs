using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class Codeunit : Object, IHasCode
    {
        public Codeunit(int id, string name)
            : base(id, name)
        {
            Properties = new CodeunitProperties(this);
            Code = new Code(this);
        }

        public Codeunits Container { get; internal set; }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.Codeunit;
            }
        }

        public CodeunitProperties Properties
        {
            get; protected set;
        }

        public Code Code
        {
            get;
            protected set;
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public override INode ParentNode => Container;

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return Code;
            }
        }
    }
}
