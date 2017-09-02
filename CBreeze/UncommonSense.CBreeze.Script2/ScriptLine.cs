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

        public bool Continuation { get; protected set; }

        public int Indentation { get; protected set; }

        public string Text { get; protected set; }

        protected string ContinuationText => Continuation ? " `" : "";

        protected string IndentationText => new string(' ', Indentation * 2);

        public override string ToString() => $"{IndentationText}{Text}{ContinuationText}";
    }
}