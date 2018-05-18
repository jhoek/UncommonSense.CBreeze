using UncommonSense.CBreeze.Core.Code;

namespace UncommonSense.CBreeze.Core.Contracts
{
    public interface IHasCodeLines : INode
    {
        CodeLines CodeLines
        {
            get;
        }
    }
}
