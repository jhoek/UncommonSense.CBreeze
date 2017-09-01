using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public class SwitchParameter : Parameter
    {
        public SwitchParameter(string name, bool value, bool onSameLine = false) : base(name)
        {
            Value = value;
            OnSameLine = onSameLine;
        }

        public override bool HasValue => Value;
        public override bool OnSameLine { get; }
        public bool Value { get; protected set; }
    }
}