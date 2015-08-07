using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    public static class CmdletExtensionMethods
    {
        public static void WriteObjectIf(this Cmdlet cmdlet, bool condition, Object @object)
        {
            if (condition)
            {
                cmdlet.WriteObject(@object);
            }
        }
    }
}
