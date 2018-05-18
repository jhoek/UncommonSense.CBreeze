using System.Linq;
using UncommonSense.CBreeze.Core.Table.Relation;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class TableRelationProperty : ReferenceProperty<TableRelation>
    {
        internal TableRelationProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }
    }
}
