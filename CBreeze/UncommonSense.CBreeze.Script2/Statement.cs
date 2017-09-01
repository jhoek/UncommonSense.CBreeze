using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public abstract class Statement
    {
        public abstract IEnumerable<ScriptLine> ToScriptLines(int indentation);

        public override string ToString() => ToString(0);

        public string ToString(int indentation) => string.Join(Environment.NewLine, ToScriptLines(indentation).Select(l => l.ToString()));
    }
}