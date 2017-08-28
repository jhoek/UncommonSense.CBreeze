using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script
{
    public class Invocation
    {
        public Invocation(string cmdletName, string cmdletAlias, params ParameterBase[] parameters)
        {
            CmdletName = cmdletName;
            CmdletAlias = cmdletAlias;
            Parameters.AddRange(parameters);
        }

        public string CmdletAlias { get; protected set; }
        public string CmdletName { get; protected set; }
        public bool HasAlias => !string.IsNullOrEmpty(CmdletAlias);
        public Collection<ParameterBase> Parameters { get; } = new Collection<ParameterBase>();

        public string Indent(string text, int indentation) => indentation == 0 ? text : $"{ new string(' ', indentation * 2) }{text}";

        public IEnumerable<string> ToScript(int indentation = 0, bool useAlias = false, bool usePositionalParameters = false)
        {
            yield return Indent(useAlias && HasAlias ? CmdletAlias : CmdletName, indentation);
        }
    }
}