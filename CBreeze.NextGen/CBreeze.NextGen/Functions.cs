using System;

namespace CBreeze.NextGen
{
    public class Functions : KeyedContainer<string, Function>
    {
        internal Functions(Node parentNode)
            : base(parentNode)
        {
        }

        public override string ToString()
        {
            return "Functions";
        }
    }
}

