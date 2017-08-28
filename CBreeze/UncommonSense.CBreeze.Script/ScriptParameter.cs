using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script
{
    public class ScriptParameter : ParameterBase
    {
        public ScriptParameter(string name, bool positional, params Invocation[] invocations)
            : this(name, positional, invocations.AsEnumerable())
        {
        }

        public ScriptParameter(string name, bool positional, IEnumerable<Invocation> invocations)
            : base(name, positional)
        {
        }

        public Collection<Invocation> Invocations { get; } = new Collection<Invocation>();

        public override IEnumerable<string> ToScriptLines(int indentation = 0, bool useAlias = false, bool usePositionalParameters = false)
        {
            var parameterName = (IsPositional && usePositionalParameters) ? "" : $"-{Name}";

            yield return $"{parameterName}".Indent(indentation);
        }
    }
}