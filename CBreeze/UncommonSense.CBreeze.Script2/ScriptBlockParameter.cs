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
        public ScriptBlockParameter(string name, params Invocation[] invocations)
            : this(name, invocations.AsEnumerable())
        {
        }

        public ScriptBlockParameter(string name, IEnumerable<Invocation> invocations)
            : base(name)
        {
            Invocations = invocations;
        }

        public override bool HasValue => Invocations.Any();

        public IEnumerable<Invocation> Invocations { get; protected set; }

        public override string ToString(int indentation)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{Indentation(indentation)}-{Name} {{");
            Invocations.Select(i => i.ToString(indentation + 1)).ForEach(s => stringBuilder.Append(s));
            stringBuilder.Append($"{Indentation(indentation)}}}");

            return stringBuilder.ToString();
        }
    }
}