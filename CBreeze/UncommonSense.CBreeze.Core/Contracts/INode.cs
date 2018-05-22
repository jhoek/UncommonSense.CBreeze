using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core.Contracts
{
    public interface INode
    {
        INode ParentNode { get; }
        IEnumerable<INode> ChildNodes { get; }
    }
}