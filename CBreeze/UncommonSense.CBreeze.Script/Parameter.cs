using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script
{
    public class Parameter
    {
        public Parameter(string name, bool positional, object value)
        {
            Name = name;
            Positional = positional;
            Value = value;
        }

        public string Name { get; protected set; }
        public bool Positional { get; protected set; }
        public object Value { get; protected set; }
    }
}