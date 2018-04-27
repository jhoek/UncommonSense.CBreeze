using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script
{
    public class LiteralParameter : ParameterBase
    {
        public LiteralParameter(string name, object value) : base(name)
        {
            Value = value;
        }

        public override bool HasValue => Value != null;

        public System.Object Value { get; protected set; }

        public override string ToString(int indentation) => $"{Indentation(indentation)}-{Name} {Value}";
    }
}
