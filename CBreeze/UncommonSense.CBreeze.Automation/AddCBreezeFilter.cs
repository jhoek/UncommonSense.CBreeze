using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeFilter")]
    public class AddCBreezeFilter : CmdletWithDynamicParams
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
        {
            get;
            set;
        }





        public override IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get
            {
                
            }
        }
    }
}
