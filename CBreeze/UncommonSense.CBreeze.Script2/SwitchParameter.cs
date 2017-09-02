using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public class SwitchParameter : Parameter
    {
        public SwitchParameter(string name, bool value, bool onCmdletLine = false) : base(name)
        {
            Value = value;
            OnCmdletLine = onCmdletLine;
        }

        public override bool HasValue => Value;
        public override bool OnCmdletLine { get; }
        public bool Value { get; protected set; }

        public override IEnumerable<ScriptLine> ToScriptLines(int indentation, bool lastParameter)
        {
            yield return new ScriptLine(this.ToString(), indentation, !lastParameter);
        }

        public override string ToString() => $"-{Name}";
    }
}