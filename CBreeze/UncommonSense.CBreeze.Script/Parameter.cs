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

        public override IEnumerable<string> ToScriptLines(int indentation = 0, bool useAlias = false, bool usePositionalParameters = false)
        {
            var parameterName = (IsPositional && usePositionalParameters) ? "" : $"-{Name}";

            yield return $"{parameterName} {Value}";
        }

        public object Value { get; protected set; }
    }
}