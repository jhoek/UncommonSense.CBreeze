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
        public override bool OnSameLine => Positional;
        public bool Positional { get; set; }
        public IEnumerable<Statement> Statements => statements.AsEnumerable();
    }
}