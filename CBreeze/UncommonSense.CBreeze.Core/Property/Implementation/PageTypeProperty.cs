using UncommonSense.CBreeze.Core.Page;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class PageTypeProperty : NullableValueProperty<PageType>
    {
        internal PageTypeProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }
    }
}
