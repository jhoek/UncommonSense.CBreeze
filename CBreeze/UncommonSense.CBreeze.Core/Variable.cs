using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public abstract class Variable : KeyedItem<int>, IHasName, INode
    {
        internal Variable(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public string Name { get; }
        public abstract VariableType Type { get; }
        public virtual string TypeName => Type.ToString();
        public override string ToString() => $"{Type}Variable";

        public Variables Container { get; internal set; }

        public INode ParentNode => Container;

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield break;
            }
        }

        public string GetName() => Name;


    }
}