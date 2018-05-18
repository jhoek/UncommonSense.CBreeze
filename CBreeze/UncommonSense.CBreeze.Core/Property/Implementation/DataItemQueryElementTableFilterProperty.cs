using System.Linq;
using UncommonSense.CBreeze.Core.Table.Field.Properties;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class DataItemQueryElementTableFilterProperty : ReferenceProperty<TableFilter>
    {
        internal DataItemQueryElementTableFilterProperty(string name)
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