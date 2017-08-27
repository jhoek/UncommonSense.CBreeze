using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script
{
    public static class Cmdlets
    {
        public static readonly CmdletInfo NewCBreezeApplication = new CmdletInfo("New-CBreezeApplication", "Application");
        public static readonly CmdletInfo NewCBreezeTable = new CmdletInfo("New-CBreezeTable", "Table");
    }
}