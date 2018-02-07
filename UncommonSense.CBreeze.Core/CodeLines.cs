using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UncommonSense.CBreeze.Core
{
    public class CodeLines : Collection<string>, INode
    {
        internal CodeLines(IHasCodeLines container)
        {
            Container = container;
        }

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield break;
            }
        }

        public IHasCodeLines Container { get; protected set; }

        public INode ParentNode => Container;

        public new void Add(string text)
        {
            base.Add(text);
        }

        public void Add(string format, params object[] args)
        {
            base.Add(string.Format(format, args));
        }

        public void Insert(int index, string format, params object[] args)
        {
            Insert(index, string.Format(format, args));
        }
    }
}
