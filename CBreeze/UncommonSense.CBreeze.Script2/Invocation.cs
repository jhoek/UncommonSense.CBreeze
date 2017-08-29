using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public class Invocation
    {
        private List<ParameterBase> parameters = new List<ParameterBase>();

        internal Invocation(string cmdletName, string cmdletAlias, params ParameterBase[] parameters)
        {
            CmdletName = cmdletName;
            CmdletAlias = cmdletAlias;

            parameters.ForEach(p => p.Invocation = this);
            this.parameters.AddRange(parameters);
        }

        public string CmdletAlias { get; protected set; }
        public string CmdletName { get; protected set; }
        public bool HasCmdletAlias => !string.IsNullOrEmpty(CmdletAlias);
        public bool HasParameters => Parameters.Any();
        public IEnumerable<ParameterBase> Parameters => parameters.AsEnumerable();

        public void ScriptTo(IndentedTextWriter writer, bool useAliases, bool usePositionalParameters)
        {
            writer.Write(usePositionalParameters && HasCmdletAlias ? CmdletAlias : CmdletName);
            writer.WriteIf(HasParameters, " ");
            Parameters.Where(p => p.OnCmdletLine).ForEach(p => p.ScriptTo(writer, useAliases, usePositionalParameters));
            writer.WriteIf(Parameters.Any(p => !p.OnCmdletLine), "`");
            writer.WriteLine();

            writer.Indent++;
            Parameters.ForEach(p => p.ScriptTo(writer, useAliases, usePositionalParameters));
            writer.Indent--;
        }
    }
}