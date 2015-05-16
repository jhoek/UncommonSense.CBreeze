using System;

namespace CBreeze.NextGen
{
    public class Variables : KeyedContainer<string, Variable>
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

