using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Script3
{
    public class ScriptBlockParameter : Parameter
    {
        private List<Statement> statements = new List<Statement>();

        public ScriptBlockParameter(string name, params Statement[] statements) : base(name)
        {
            this.statements.AddRange(statements);
        }

        public override bool HasValue => Statements.Any();
        public override bool IsMultiLine => true;
        public bool Positional { get; set; }
        public IEnumerable<Statement> Statements => statements.AsEnumerable();

        public override void WriteTo(ScriptWriter writer, bool continuation, bool lineBreak)
        {
            writer.WriteIf(!Positional, $"-{Name} ");
            writer.WriteLine("{");
            writer.Indent();
            Statements.ForEach(s => s.WriteTo(writer, true));
            writer.Unindent();
            writer.Write("} ");

            base.WriteTo(writer, continuation, lineBreak);
        }
    }
}