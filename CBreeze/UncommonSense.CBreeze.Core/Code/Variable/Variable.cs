using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Generic;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public abstract class Variable : KeyedItem<int>, IHasName
    {
        internal Variable(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public string Name { get; }
        public abstract VariableType Type { get; }
        public virtual string TypeName => Type.ToString();

        public string GetName() => Name;
    }
}