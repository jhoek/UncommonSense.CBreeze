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

        public IEnumerable<string> ToScript(int indentation = 0, bool useAlias = false, bool usePositionalParameters = false)
        {
            return
                (useAlias && HasAlias ? CmdletAlias : CmdletName)
                    .Indent(indentation)
                    .Concatenate(Parameters.SelectMany(p => p.ToScript(indentation + 1, useAlias, usePositionalParameters)));
        }
    }
}