using UncommonSense.CBreeze.Core.Table.Field;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class CalcFormulaProperty : ReferenceProperty<CalcFormula>
    {
        internal CalcFormulaProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Method.HasValue;
            }
        }
    }
}
