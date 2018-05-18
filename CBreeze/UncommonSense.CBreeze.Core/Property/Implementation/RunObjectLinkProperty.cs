using System.Linq;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class RunObjectLinkProperty : ReferenceProperty<RunObjectLink>
    {
        internal RunObjectLinkProperty(string name)
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
