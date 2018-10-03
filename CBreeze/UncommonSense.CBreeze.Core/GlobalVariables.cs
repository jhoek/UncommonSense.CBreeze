using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public class GlobalVariables : Variables
    {
        internal GlobalVariables(Code code)
        {
            Code = code;
        }

        public Code Code { get; protected set; }
        public override INode ParentNode => Code;
        public override string ToString() => "GlobalVariables";
    }
}