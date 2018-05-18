using UncommonSense.CBreeze.Core.Page.Action;
using UncommonSense.CBreeze.Core.Page.Control;

namespace UncommonSense.CBreeze.Core.Contracts
{
    public interface IPage : INode
    {
        ActionList Actions { get; }

        PageControls Controls { get; }

        int ObjectID { get; }
    }
}