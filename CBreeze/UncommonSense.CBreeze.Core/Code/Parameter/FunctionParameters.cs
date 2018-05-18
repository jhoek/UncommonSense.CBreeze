using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
    public class FunctionParameters : Parameters
    {
        internal FunctionParameters(Variable.Function function)
        {
            Function = function;
        }

        public override IEnumerable<int> ExistingIDs => this.Select(p => p.ID).Concat(Function.Variables.Select(v => v.ID));

        public Variable.Function Function { get; protected set; }

        public override INode ParentNode => Function;
    }
}