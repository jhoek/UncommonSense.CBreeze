using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public class Pipeline : Statement
    {
        protected List<Statement> steps = new List<Statement>();

        public Pipeline(params Statement[] steps)
        {
            this.steps.AddRange(steps);
        }

        public override IEnumerable<ScriptLine> ToScriptLines(int indentation)
        {
            yield break; // FIXME
        }

        public IEnumerable<Statement> Steps => steps.AsEnumerable();
    }
}