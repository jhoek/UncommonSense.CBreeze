using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public abstract class ParameterBase
    {
        public ParameterBase(string name)
        {
            Name = name;
        }

        public abstract bool HasValue { get; }
        public Invocation Invocation { get; internal set; }
        public string Name { get; protected set; }
        public abstract bool OnCmdletLine { get; }

        public abstract void ScriptTo(IndentedTextWriter writer, bool useAliases, bool usePositionalParameters);
    }
}