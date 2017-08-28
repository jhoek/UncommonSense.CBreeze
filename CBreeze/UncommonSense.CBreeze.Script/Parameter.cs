using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script
{
    public class Parameter : ParameterBase
    {
        public Parameter(string name, bool positional, object value) : base(name, positional)
        {
            Value = value;
        }

        public object Value { get; protected set; }
    }
}