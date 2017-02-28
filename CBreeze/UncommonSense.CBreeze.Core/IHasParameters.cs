using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public interface IHasParameters : INode
    {
        int ID
        {
            get;
        }

        Parameters Parameters
        {
            get;
        }
    }
}
