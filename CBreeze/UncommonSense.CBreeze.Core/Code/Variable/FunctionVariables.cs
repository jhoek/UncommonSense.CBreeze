using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class FunctionVariables : LocalVariables
    {
        internal FunctionVariables(Function function)
        {
            Function = function;
        }

        public override IEnumerable<int> ExistingIDs => this.Select(v => v.ID).Concat(Function.Parameters.Select(p => p.ID));

        public Function Function { get; protected set; }
        public override INode ParentNode => Function;
    }
}