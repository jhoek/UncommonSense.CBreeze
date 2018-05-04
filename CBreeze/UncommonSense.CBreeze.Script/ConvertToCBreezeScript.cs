using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script
{
    [Cmdlet(VerbsData.ConvertTo, "CBreezeScript")]
    [OutputType(typeof(string))]
    public class ConvertToCBreezeScript : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline =true)]
        public Application Application { get; set; }

        protected override void EndProcessing()
        {
            WriteObject(Application.ToInvocation().ToString());
        }
    }
}
