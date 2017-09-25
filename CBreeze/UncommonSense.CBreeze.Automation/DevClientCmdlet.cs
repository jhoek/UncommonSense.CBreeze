using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Automation
{
    public class DevClientCmdlet : PSCmdlet
    {
        public string DefaultDevClientPath => $@"C:\Program Files (x86)\Microsoft Dynamics NAV\{DevClientVersion}\RoleTailored Client\finsql.exe";

        public string DevClientVersion
        {
            get
            {
#if NAV2017
                return "100";
#elif NAV2016 
                return "90";
#elif NAV2015
                return "80";
#elif NAV2013R2
                return "71";
#else 
                return "70";
#endif
            }
        }
    }
}
