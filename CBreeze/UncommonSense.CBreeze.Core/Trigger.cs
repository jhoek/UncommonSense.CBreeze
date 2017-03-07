using System;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class Trigger : IHasVariables, IHasCodeLines
    {
        public Trigger()
        {
            CodeLines = new CodeLines(this);
            Variables = new TriggerVariables(this);
        }

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return CodeLines;
                yield return Variables;
            }
        }

        public CodeLines CodeLines
        {
            get;
            protected set;
        }

        public int ID => 0; // FIXME

        public INode ParentNode => null; // FIXME

        public Variables Variables
        {
            get;
            protected set;
        }
    }
}