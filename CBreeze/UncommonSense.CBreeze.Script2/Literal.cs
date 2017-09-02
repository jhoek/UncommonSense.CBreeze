using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public class Literal : Statement
    {
        public enum QuotesType
        {
            None,
            Single,
            Double
        }

        public Literal(string text, QuotesType quotes = QuotesType.Single)
        {
            Text = text;
            Quotes = quotes;
        }

        public QuotesType Quotes { get; protected set; }

        public string Text { get; protected set; }

        public override IEnumerable<ScriptLine> ToScriptLines(int indentation)
        {
            yield return new ScriptLine($"'{Text}'", indentation, false);
        }
    }
}