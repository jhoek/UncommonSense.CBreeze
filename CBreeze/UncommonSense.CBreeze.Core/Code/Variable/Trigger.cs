using System.Collections.Generic;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class Trigger : IHasCodeLines
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

        public INode ParentNode => null;

        public Variables Variables
        {
            get;
            protected set;
        }
    }
}