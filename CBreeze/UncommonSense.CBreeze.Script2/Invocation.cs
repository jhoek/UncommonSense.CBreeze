using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public class Invocation : Statement
    {
        private List<Parameter> parameters = new List<Parameter>();

        public Invocation(string cmdletName, params Parameter[] parameters)
        {
            CmdletName = cmdletName;
            this.parameters.AddRange(parameters);
        }

        public override IEnumerable<ScriptLine> ToScriptLines(int indentation)
        {
            yield return new ScriptLine(CmdletName, indentation, Parameters.Where(p => p.HasValue).Any(p => !p.OnSameLine));
        }

        public string CmdletName { get; protected set; }
        public IEnumerable<Parameter> Parameters => parameters.AsEnumerable();
    }
}