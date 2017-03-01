using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class Code : IHasVariables, INode
    {
        internal Code(Object @object)
        {
            Object = @object;
            Documentation = new Documentation(this);
            Events = new Events(this);
            Functions = new Functions(this);
            Variables = new Variables(this);
        }

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Documentation;
                yield return Events;
                yield return Functions;
                yield return Variables;
            }
        }

        public Documentation Documentation
        {
            get;
            protected set;
        }

        public Events Events
        {
            get;
            protected set;
        }

        public Functions Functions
        {
            get;
            protected set;
        }

        public Object Object
        {
            get;
            protected set;
        }

        public INode ParentNode => Object;

        public Variables Variables
        {
            get;
            protected set;
        }
    }
}