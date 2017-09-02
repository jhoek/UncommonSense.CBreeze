using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public class ScriptBlockParameter : Parameter
    {
        private List<Statement> statements = new List<Statement>();

        public ScriptBlockParameter(string name, params Statement[] statements) : base(name)
        {
            this.statements.AddRange(statements);
        }

        public override bool HasValue => Statements.Any();
        public override bool OnCmdletLine => false;
        public IEnumerable<Statement> Statements => statements.AsEnumerable();

        public override IEnumerable<ScriptLine> ToScriptLines(int indentation, bool lastParameter)
        {
            yield return new ScriptLine($"-{Name} {{", indentation, false);

            foreach (var statement in Statements)
            {
                foreach (var scriptLine in statement.ToScriptLines(indentation + 1))
                {
                    yield return scriptLine;
                }
            }

            yield return new ScriptLine("}", indentation, !lastParameter);
        }
    }
}