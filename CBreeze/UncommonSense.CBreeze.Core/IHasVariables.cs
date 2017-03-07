using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public interface IHasVariables : INode
    {
        int ID
        {
            get;
        }

        Variables Variables
        {
            get;
        }
    }
}