using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public class SimpleParameter : Parameter
    {
        public SimpleParameter(string name, object value) : base(name)
        {
            Value = value;
        }

        public override bool HasValue => Value != null;
        public override bool OnSameLine => Positional;
        public bool Positional { get; set; }
        public Object Value { get; protected set; }
    }
}