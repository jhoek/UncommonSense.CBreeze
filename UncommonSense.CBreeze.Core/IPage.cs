using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public interface IPage : INode
    {
        ActionList Actions { get; }

        PageControls Controls { get; }

        int ObjectID { get; }
    }
}