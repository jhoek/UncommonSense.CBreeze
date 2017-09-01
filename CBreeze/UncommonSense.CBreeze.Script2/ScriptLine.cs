using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public class ScriptLine
    {
        public ScriptLine(string text, int indentation = 0, bool continuation = false)
        {
            Text = text;
            Indentation = indentation;
            Continuation = continuation;
        }

        public override string ToString() => $"{IndentationText}{Text}{ContinuationText}";

        public bool Continuation { get; protected set; }
        public string ContinuationText => Continuation ? " `" : "";
        public int Indentation { get; protected set; }
        public string IndentationText => new string(' ', Indentation * 2);
        public string Text { get; protected set; }
    }
}