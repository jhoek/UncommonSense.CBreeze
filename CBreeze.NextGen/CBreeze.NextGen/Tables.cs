using System;

namespace CBreeze.NextGen
{
    public class Tables : Container<int, Table>
    {
        internal Tables(Node parentNode)
            : base(parentNode)
        {
        }

        public override string ToString()
        {
            return "Tables";
        }
    }
}

