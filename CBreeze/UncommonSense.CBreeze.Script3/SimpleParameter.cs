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

        public string ValueAsString => ValueNeedsQuotes ? $"'{Value}'" : Value.ToString();
        public bool ValueNeedsQuotes => (Value is string) && Value.ToString().Any(c => !Char.IsLetterOrDigit(c));
        protected string QuotedValue => $"'{Value}'";

        public override void WriteTo(ScriptWriter writer)
        {
            writer.WriteIf(!Positional, $"-{Name} ");
            writer.Write($"{ValueAsString} ");
        }
    }
}