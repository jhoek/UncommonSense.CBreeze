using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Report;

namespace UncommonSense.CBreeze.Core.Contracts
{
    public interface IHasRequestPage : INode
    {
        int ID { get; }
        Application Application { get; }
        RequestPage RequestPage { get; }
    }
}
