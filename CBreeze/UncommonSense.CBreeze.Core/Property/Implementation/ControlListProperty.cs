using System.Linq;
using UncommonSense.CBreeze.Core.Page.Control;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class ControlListProperty : ReferenceProperty<ControlList>
    {
        internal ControlListProperty(string name)
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
