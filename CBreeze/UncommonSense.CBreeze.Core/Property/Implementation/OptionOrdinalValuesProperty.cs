using System;
using System.Text.RegularExpressions;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class OptionOrdinalValuesProperty : StringProperty
    {
        private static Regex pattern = new Regex(@"^(-?\d+|\[-?\d+(;-?\d+)*\])$", RegexOptions.Compiled);

        internal OptionOrdinalValuesProperty(string name) 
            : base(name)
        {
        }

        public override string Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    if (!pattern.IsMatch(value))
                        throw new ArgumentOutOfRangeException(string.Format("{0} is not a valid OptionOrdinalValues value.", value));

                base.Value = value;
            }
        }
    }
}
