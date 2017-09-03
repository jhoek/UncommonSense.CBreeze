using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Script3
{
    public class SimpleParameter : Parameter
    {
        public SimpleParameter(string name, object value) : base(name)
        {
            Value = value;
        }

        public override bool HasValue => Value != null;
        public override bool IsMultiLine => false;
        public bool Positional { get; set; }
        public object Value { get; }

        public string ValueAsString
        {
            get
            {
                switch (Value)
                {
                    case string s:
                        return Quoted(s);

                    case IEnumerable<string> e:
                        return string.Join(", ", e.Select(s => Quoted(s)));

                    default:
                        return Value.ToString();
                }
            }
        }

        public bool NeedsQuotes(string text) => text.Any(c => !Char.IsLetterOrDigit(c));

        public override void WriteTo(ScriptWriter writer, bool continuation, bool lineBreak)
        {
            writer.WriteIf(!Positional, $"-{Name} ");
            writer.Write($"{ValueAsString} ");

            base.WriteTo(writer, continuation, lineBreak);
        }

        protected string Quoted(string text) => NeedsQuotes(text) ? $"'{text}'" : text;
    }
}