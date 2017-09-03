using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Script3
{
    public class Literal : Statement
    {
        public Literal(string text)
        {
            Text = text;
        }

        public string Text { get; }

        public override void WriteTo(ScriptWriter writer, bool lineBreak)
        {
            writer.Write(Text);
            writer.WriteLineIf(lineBreak);
        }
    }
}