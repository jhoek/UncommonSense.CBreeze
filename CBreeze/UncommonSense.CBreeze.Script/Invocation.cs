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
        public Invocation(string cmdletName, string cmdletAlias, params Parameter[] parameters)
        {
            CmdletName = cmdletName;
            CmdletAlias = cmdletAlias;

            // FIXME: store parameters
        }

        public string CmdletAlias { get; protected set; }
        public string CmdletName { get; protected set; }
        public Collection<Parameter> Parameters => new Collection<Parameter>();

        public IEnumerable<string> ToScript(int indentation, bool useAlias, bool usePositionalParameters)
        {
            yield break; // FIXME
        }
    }
}