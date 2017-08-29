using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public class ScriptBlockParameter : ParameterBase
    {
        public ScriptBlockParameter(string name, bool isPositional, params Invocation[] invocations)
            : this(name, isPositional, invocations.AsEnumerable())
        {
        }

        public ScriptBlockParameter(string name, bool isPositional, IEnumerable<Invocation> invocations)
            : base(name)
        {
            IsPositional = isPositional;
            Invocations = invocations;
        }

        public override bool HasValue => Invocations.Any();

        public IEnumerable<Invocation> Invocations { get; protected set; }
        public bool IsPositional { get; protected set; }

        public override bool OnCmdletLine => true;

        public override void ScriptTo(IndentedTextWriter writer, bool useAliases, bool usePositionalParameters)
        {
            writer.Write(IsPositional && usePositionalParameters ? "" : $"-{Name} ");
            writer.WriteLine("{");
            writer.Indent++;

            Invocations.ForEach(i => i.ScriptTo(writer, useAliases, usePositionalParameters));

            writer.Indent--;
            writer.WriteLine("}");
        }
    }
}