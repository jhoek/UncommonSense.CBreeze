using UncommonSense.CBreeze.Core.Table;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
#if NAV2016
        public class TableTypeProperty : NullableValueProperty<TableType>
    {
        internal TableTypeProperty(string name)
            : base(name)
        {
        }
    }
#endif
}
