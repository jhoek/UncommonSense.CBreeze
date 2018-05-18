using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class GlobalVariables : Variables
    {
        internal GlobalVariables(Code code)
        {
            Code = code;
        }

        public Code Code { get; protected set; }
        public override INode ParentNode => Code;
    }
}