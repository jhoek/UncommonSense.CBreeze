using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public class Literal : Statement
    {
        public Literal(string text)
        {
            Text = text;
        }

        public override IEnumerable<ScriptLine> ToScriptLines(int indentation)
        {
            yield return new ScriptLine(Text, indentation, false);
        }

        public string Text { get; protected set; }
    }
}