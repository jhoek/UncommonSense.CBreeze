using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script
{
    public class ScriptBlockParameter : ParameterBase
    {
        public ScriptBlockParameter(string name, params Statement[] statements)
            : this(name, statements.AsEnumerable())
        {
        }

        public ScriptBlockParameter(string name, IEnumerable<Statement> statements)
            : base(name)
        {
            Statements = statements;
        }

        public override string ToString(int indentation)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{Indentation(indentation)}-{Name} {{");
            Statements.Select(i => i.ToString(indentation + 1)).ForEach(s => stringBuilder.Append(s));
            stringBuilder.Append($"{Indentation(indentation)}}}");

            return stringBuilder.ToString();
        }

        public override bool HasValue => Statements.Any();

        public IEnumerable<Statement> Statements { get; protected set; }
    }
}