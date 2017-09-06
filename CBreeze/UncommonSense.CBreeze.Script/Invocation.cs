using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script
{
    public class Invocation : Statement
    {
        private List<ParameterBase> parameters = new List<ParameterBase>();

        internal Invocation(string cmdletName, params ParameterBase[] parameters)
            : this(cmdletName, parameters.AsEnumerable())
        {
        }

        internal Invocation(string cmdletName, IEnumerable<ParameterBase> parameters)
        {
            CmdletName = cmdletName;
            this.parameters.AddRange(parameters);
        }

        public override string ToString(int indentation)
        {
            var elements = new List<string>();

            elements.Add($"{Indentation(indentation)}{CmdletName}");
            elements.AddRange(ParametersWithValue.Select(p => p.ToString(indentation + 1)));

            var newLine = SuppressTrailingNewLine ? "" : Environment.NewLine;

            return $"{string.Join($" `{Environment.NewLine}", elements)}{newLine}";
        }

        public string CmdletName { get; protected set; }
        public IEnumerable<ParameterBase> Parameters => parameters.AsEnumerable();
        public IEnumerable<ParameterBase> ParametersWithValue => Parameters.Where(p => p.HasValue);
        public bool SuppressTrailingNewLine { get; set; }
    }
}