using System.Collections.Generic;
using System.Linq;

namespace UncommonSense.CBreeze.Script2
{
    public class Invocation : Statement
    {
        private List<Parameter> parameters = new List<Parameter>();

        public Invocation(string cmdletName, params Parameter[] parameters)
        {
            CmdletName = cmdletName;
            this.parameters.AddRange(parameters);
        }

        public string CmdletName { get; protected set; }
        public IEnumerable<Parameter> Parameters => parameters.AsEnumerable();
        public IEnumerable<Parameter> ParametersWithValues => parameters.Where(p => p.HasValue);
        protected string CmdletLine => string.Join(" ", CmdletLineElements);

        protected IEnumerable<string> CmdletLineElements
        {
            get
            {
                yield return CmdletName;

                foreach (var parameter in ParametersOnCmdletLine)
                {
                    yield return parameter.ToString();
                }
            }
        }

        protected IEnumerable<Parameter> ParametersOnCmdletLine => ParametersWithValues.Where(p => p.OnCmdletLine);
        protected IEnumerable<Parameter> ParametersOnOtherLines => ParametersWithValues.Where(p => !p.OnCmdletLine);

        public override IEnumerable<ScriptLine> ToScriptLines(int indentation)
        {
            yield return new ScriptLine(CmdletLine, indentation, ParametersOnOtherLines.Any());

            foreach (var parameter in ParametersOnOtherLines)
            {
                foreach (var scriptLine in parameter.ToScriptLines(indentation + 1, parameter == ParametersOnOtherLines.Last()))
                {
                    yield return scriptLine;
                }
            }
        }
    }
}