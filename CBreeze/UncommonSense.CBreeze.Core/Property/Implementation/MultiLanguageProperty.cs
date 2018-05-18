using System.Linq;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class MultiLanguageProperty : ReferenceProperty<MultiLanguageValue>
    {
        internal MultiLanguageProperty(string name)
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
