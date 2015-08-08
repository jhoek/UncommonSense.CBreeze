using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    public static class ExtensionMethods
    {
        public static void WriteObjectIf(this Cmdlet cmdlet, bool condition, System.Object @object)
        {
            if (condition)
            {
                cmdlet.WriteObject(@object);
            }
        }

        public static void AutoCaptionIf(this Table table, bool condition)
        {
            if (condition)
            {
                table.Properties.CaptionML.Add("ENU", table.Name);
            }
        }
    }
}
