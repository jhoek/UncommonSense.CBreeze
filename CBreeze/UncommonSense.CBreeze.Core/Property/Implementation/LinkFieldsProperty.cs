using System.Linq;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class LinkFieldsProperty : ReferenceProperty<LinkFields>
    {
        internal LinkFieldsProperty(string name)
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
