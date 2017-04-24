using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public class FunctionParameters : Parameters
    {
        internal FunctionParameters(Function function)
        {
            Function = function;
        }

        public override IEnumerable<int> ExistingIDs => this.Select(p => p.ID).Concat(Function.Variables.Select(v => v.ID));

        public Function Function { get; protected set; }

        public override INode ParentNode => Function;
    }
}