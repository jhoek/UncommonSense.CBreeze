using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public class SimpleParameter : Parameter
    {
        public SimpleParameter(string name, object value, bool onCmdletLine = false, bool positional = false) : base(name)
        {
            Value = value;
            Positional = positional;
            OnCmdletLine = onCmdletLine;
        }

        public override bool HasValue => Value != null;
        public override bool OnCmdletLine { get; }
        public bool Positional { get; protected set; }
        public Object Value { get; protected set; }

        public override IEnumerable<ScriptLine> ToScriptLines(int indentation, bool lastParameter)
        {
            yield return new ScriptLine(this.ToString(), indentation, !lastParameter);
        }

        public override string ToString() => Positional ? Value.ToString() : $"-{Name} {Value}";
    }
}