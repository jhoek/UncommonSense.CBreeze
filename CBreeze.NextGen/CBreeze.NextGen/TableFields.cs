using System;

namespace CBreeze.NextGen
{
    public class TableFields : KeyedContainer<int, TableField>
    {
        internal TableFields(Node parentNode)
            : base(parentNode)
        {
        }

        public override string ToString()
        {
            return "Fields";
        }
    }
}

