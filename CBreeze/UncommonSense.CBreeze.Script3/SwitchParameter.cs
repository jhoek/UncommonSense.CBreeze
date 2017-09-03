using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Script3
{
    public class SwitchParameter : Parameter
    {
        public SwitchParameter(string name, bool value) : base(name)
        {
            Value = value;
        }

        public override bool HasValue => Value;
        public override bool IsMultiLine => false;
        public bool Value { get; }

        public override void WriteTo(ScriptWriter writer, bool continuation, bool lineBreak)
        {
            writer.Write($"-{Name} ");

            base.WriteTo(writer, continuation, lineBreak);
        }
    }
}