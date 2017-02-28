using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public interface IPage : INode
    {
        PageControls Controls
        {
            get;
        }

        ActionList Actions
        {
            get;
        }

        int ObjectID
        {
            get;
        }
    }
}
