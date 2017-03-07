using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public class FunctionVariables : LocalVariables
    {
        internal FunctionVariables(Function function)
        {
            Function = function;
        }

        public Function Function { get; protected set; }
        public override INode ParentNode => Function;
        protected override bool UseAlternativeRange => (Range ?? DefaultRange).Contains(Function.ID);
    }
}