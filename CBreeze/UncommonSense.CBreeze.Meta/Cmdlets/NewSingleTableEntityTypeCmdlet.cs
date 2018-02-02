using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Meta.Cmdlets
{
    public abstract class NewSingleTableEntityTypeCmdlet : NewEntityTypeCmdlet
    {
        [Parameter()]
        public string PluralName { get; set; }

    }
}
