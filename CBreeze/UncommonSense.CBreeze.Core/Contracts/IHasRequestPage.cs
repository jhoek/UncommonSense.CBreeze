using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public interface IHasRequestPage : INode
    {
        int ID { get; }
        Application Application { get; }
        RequestPage RequestPage { get; }
    }
}
