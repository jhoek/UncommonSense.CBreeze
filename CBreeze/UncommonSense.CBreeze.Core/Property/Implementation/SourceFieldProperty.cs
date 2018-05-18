using UncommonSense.CBreeze.Core.Code.Variable;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class SourceFieldProperty : ReferenceProperty<SourceField>
    {
        internal SourceFieldProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.TableVariableName != null || Value.FieldName != null;
            }
        }
    }
}
