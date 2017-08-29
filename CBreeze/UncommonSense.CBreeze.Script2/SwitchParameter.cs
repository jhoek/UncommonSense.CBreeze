using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public class SwitchParameter : ParameterBase
    {
        public SwitchParameter(string name)
            : base(name)
        {
        }

        public override bool OnCmdletLine => Invocation.Parameters.All(p => OnCmdletLine);

        public override void ScriptTo(IndentedTextWriter writer, bool useAliases, bool usePositionalParameters)
        {
            writer.Write($"-{Name} ");
        }
    }
}