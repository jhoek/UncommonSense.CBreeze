using System.Linq;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class FieldListProperty : ReferenceProperty<FieldList>
    {
        internal FieldListProperty(string name)
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
