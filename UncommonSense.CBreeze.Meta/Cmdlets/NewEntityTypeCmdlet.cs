using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Meta.Cmdlets
{
    public abstract class NewEntityTypeCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string Name { get; set; }

        [Parameter()]
        public ScriptBlock Pages { get; set; } 
    }
}
