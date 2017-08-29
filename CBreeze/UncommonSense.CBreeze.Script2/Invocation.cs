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
            : this(cmdletName, cmdletAlias, parameters.AsEnumerable())
        {
        }

        internal Invocation(string cmdletName, string cmdletAlias, IEnumerable<ParameterBase> parameters)
        {
            CmdletName = cmdletName;
            CmdletAlias = cmdletAlias;

            parameters.ForEach(p => p.Invocation = this);
            this.parameters.AddRange(parameters);
        }

        public string CmdletAlias { get; protected set; }
        public string CmdletName { get; protected set; }
        public bool HasCmdletAlias => !string.IsNullOrEmpty(CmdletAlias);
        public IEnumerable<ParameterBase> Parameters => parameters.AsEnumerable();
        public IEnumerable<ParameterBase> ParametersWithValue => Parameters.Where(p => p.HasValue);

        public void ScriptTo(IndentedTextWriter writer, bool useAliases, bool usePositionalParameters)
        {
            writer.Write(usePositionalParameters && HasCmdletAlias ? CmdletAlias : CmdletName);
            writer.WriteIf(ParametersWithValue.Any(), " ");
            ParametersWithValue.Where(p => p.OnCmdletLine).ForEach(p => p.ScriptTo(writer, useAliases, usePositionalParameters));
            writer.WriteIf(ParametersWithValue.Any(p => !p.OnCmdletLine), "`");
            writer.WriteLine();

            writer.Indent++;
            ParametersWithValue.Where(p => !p.OnCmdletLine).ForEach(p => p.ScriptTo(writer, useAliases, usePositionalParameters));
            writer.Indent--;
        }
    }
}