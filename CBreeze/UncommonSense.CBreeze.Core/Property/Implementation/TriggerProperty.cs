using System.Linq;
using UncommonSense.CBreeze.Core.Code.Variable;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class TriggerProperty : ReferenceProperty<Trigger>
    {
        internal TriggerProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.CodeLines.Any() || Value.Variables.Any();
            }
        }
    }
}
