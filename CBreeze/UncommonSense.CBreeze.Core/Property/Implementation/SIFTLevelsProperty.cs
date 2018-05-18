using System.Linq;
using UncommonSense.CBreeze.Core.Table.Key;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class SIFTLevelsProperty : ReferenceProperty<SIFTLevels>
    {
        internal SIFTLevelsProperty(string name)
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
