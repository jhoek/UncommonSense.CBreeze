using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script
{
    public static class Convert
    {
        public static Invocation ToInvocation(this Application application)
        {
            return new Invocation("New-CBreezeApplication", "Application");
        }
    }
}