using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
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