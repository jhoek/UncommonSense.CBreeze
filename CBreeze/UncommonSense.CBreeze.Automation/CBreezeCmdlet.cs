using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class CBreezeCmdlet : PSCmdlet
    {
        public bool? InterpretSwitch(string switchParameterName)
        {
            if (!MyInvocation.BoundParameters.ContainsKey(switchParameterName))
            {
                return null;
            }
            else
            {
                return ((SwitchParameter)MyInvocation.BoundParameters[switchParameterName]).IsPresent;
            }
        }
    }
}
