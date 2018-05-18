using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Generic;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
    public abstract class Parameter : KeyedItem<int>, IHasName
    {
        internal Parameter(string name, bool var = false, int id = 0)
        {
            ID = id;
            Name = name;
            Var = var;
        }

        public string Dimensions
        {
            get;
            set;
        }

        public string Name
        {
            get;
            protected set;
        }

        public abstract ParameterType Type
        {
            get;
        }

        public virtual string TypeName => Type.ToString();

        public bool Var
        {
            get;
            protected set;
        }

        public string GetName()
        {
            return Name;
        }
    }
}