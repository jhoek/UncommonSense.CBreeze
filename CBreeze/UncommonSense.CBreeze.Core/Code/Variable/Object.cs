using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Generic;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public abstract class Object : KeyedItem<int>, IHasName, IHasProperties, INode
    {
        internal Object(int id, string name)
        {
            ID = id;
            Name = name;
            ObjectProperties = new ObjectProperties();
        }

        public string Name { get; set; }
        public string VariableName => Name.MakeVariableName();
        public abstract ObjectType Type { get; }
        public ObjectProperties ObjectProperties { get; protected set; }
        public override string ToString() => string.Format("{0} {1} {2}", Type, ID, Name);
        public string GetName() => Name;
        public abstract Properties AllProperties { get; }
        public abstract INode ParentNode { get; }
        public abstract IEnumerable<INode> ChildNodes { get; }
    }
}
