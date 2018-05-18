using System.Linq;
using UncommonSense.CBreeze.Core.Table.Field.Properties;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class ColumnFilterProperty : ReferenceProperty<TableFilter>
    {
        internal ColumnFilterProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue => Value.Any();
    }
}