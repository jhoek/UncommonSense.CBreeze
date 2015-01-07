using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Write
{
    internal class IndentationLevels
    {
        private int defaultIndentation;
        private Stack<int> innerStack = new Stack<int>();

        public IndentationLevels()
            : this(2)
        {
        }

        public IndentationLevels(int defaultIndentation)
        {
            this.defaultIndentation = defaultIndentation;
        }

        public void Indent()
        {
            this.innerStack.Push(Current + defaultIndentation);
        }

        public void Indent(int indentationLevel)
        {
            this.innerStack.Push(indentationLevel);
        }

        public void Unindent()
        {
            if (this.innerStack.Count == 0)
                return;
            this.innerStack.Pop();
        }

        public int Current
        {
            get
            {
                if (this.innerStack.Count == 0)
                    return 0;
                return this.innerStack.Peek();
            }
        }
    }
}
