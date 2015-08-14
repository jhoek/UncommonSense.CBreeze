using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class TableRelationLinesProperty : Property
    {
        private TableRelationLines value = new TableRelationLines();

        internal TableRelationLinesProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public TableRelationLines Value
        {
            get
            {
                return this.value;
            }
        }
    }

}
