using UncommonSense.CBreeze.Core.Property.Type;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class SqlDataTypeProperty : NullableValueProperty<SqlDataType>
    {
        internal SqlDataTypeProperty(string name)
            : base(name)
        {
        }
    }
}
