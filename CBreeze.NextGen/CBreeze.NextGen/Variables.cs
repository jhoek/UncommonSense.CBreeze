using System;

namespace CBreeze.NextGen
{
    public class Variables : Container<string, Variable>
    {
        internal Variables(Node parentNode)
            : base(parentNode)
        {
        }

        public override string ToString()
        {
            return "Variables";
        }
    }
}

