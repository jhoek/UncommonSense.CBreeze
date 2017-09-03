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

        public override void WriteTo(ScriptWriter writer, bool lineBreak)
        {
            writer.Write($"{CmdletName} ");

            Parameters
                .Where(p => p.HasValue)
                .Where(p => p.OnCmdletLine)
                .Where(p => !p.IsMultiLine)
                .ForEach(p => p.WriteTo(writer, false, false));

            Parameters
                .Where(p => p.HasValue)
                .Where(p => p.OnCmdletLine)
                .SingleOrDefault(p => p.IsMultiLine)?
                .WriteTo(writer, false, false);

            var paramsNotOnCmdletLine = Parameters
                .Where(p => p.HasValue)
                .Where(p => !p.OnCmdletLine);

            writer.WriteIf(paramsNotOnCmdletLine.Any(), "`");

            writer.WriteLine();

            writer.Indent();

            paramsNotOnCmdletLine
                .ForEach(p => p.WriteTo(writer, p != paramsNotOnCmdletLine.Last(), true));

            writer.Unindent();
        }
    }
}