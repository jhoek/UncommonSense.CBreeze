using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
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