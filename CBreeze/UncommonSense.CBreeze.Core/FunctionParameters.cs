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

        public Function Function { get; protected set; }

        public override INode ParentNode => Function;
    }
}