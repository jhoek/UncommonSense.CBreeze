using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class Codeunit : Object, IHasCode
    {
        public Codeunit(string name) : this(0, name)
        {
        }

        public Codeunit(int id, string name)
            : base(id, name)
        {
            Properties = new CodeunitProperties(this);
            Code = new Code(this);
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public Application Application => Container?.Application;

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return Code;
            }
        }

        public Code Code
        {
            get;
            protected set;
        }

        public Codeunits Container { get; internal set; }

        public override INode ParentNode => Container;

        public CodeunitProperties Properties
        {
            get; protected set;
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.Codeunit;
            }
        }
    }
}