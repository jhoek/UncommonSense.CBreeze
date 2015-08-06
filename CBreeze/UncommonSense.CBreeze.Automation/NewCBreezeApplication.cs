using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeApplication")]
    public class NewCBreezeApplication : Cmdlet
    {
        protected override void EndProcessing()
        {
            WriteObject(new Application());
        }
    }
}
