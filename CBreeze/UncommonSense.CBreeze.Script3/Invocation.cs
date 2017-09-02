using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script3
{
    public class Invocation : Statement
    {
        private List<Parameter> parameters = new List<Parameter>();

        public Invocation(string cmdletName, params Parameter[] parameters)
        {
            CmdletName = cmdletName;
            this.parameters.AddRange(parameters);
        }

        public string CmdletName { get; }

        public IEnumerable<Parameter> Parameters => parameters.AsEnumerable();
        public IEnumerable<Parameter> ParametersWithValue => Parameters.Where(p => p.HasValue);

        public override void WriteTo(ScriptWriter writer)
        {
            writer.Write($"{CmdletName} ");

            ParametersWithValue
                .Where(p => p.OnCmdletLine)
                .Where(p => !p.IsMultiLine)
                .ForEach(p => p.WriteTo(writer));

            ParametersWithValue
                   .Where(p => p.OnCmdletLine)
                   .SingleOrDefault(p => p.IsMultiLine)?
                   .WriteTo(writer);

            writer.WriteLine();
        }
    }
}