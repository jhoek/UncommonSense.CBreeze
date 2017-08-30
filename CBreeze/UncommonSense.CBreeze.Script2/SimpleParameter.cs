using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public class SimpleParameter : ParameterBase
    {
        public SimpleParameter(string name, object value)
            : base(name)
        {
            Value = value;
        }

        public override bool HasValue => Value != null;

        public Object Value { get; protected set; }

        public string ValueAsString {
            get
            {
                switch (Value)
                {
                    case bool b: return (b ? "$true" : "$false");
                    case string s: return $"'{s}'";
                    case DateTime d: return $"'{d}'";
                    case IEnumerable<string> e: return string.Join(", ", e.Select(s => $"'{s}'"));
                    default: return Value.ToString();
                }
            }
        }
        
        public override string ToString(int indentation) => $"{Indentation(indentation)}-{Name} {ValueAsString}";
    }
}