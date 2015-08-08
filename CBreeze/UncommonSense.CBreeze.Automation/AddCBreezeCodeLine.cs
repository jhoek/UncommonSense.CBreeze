using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeCodeLine")]
    public class AddCBreezeCodeLine : Cmdlet
    {
        [Parameter(Mandatory=true,ValueFromPipeline=true)]
        public dynamic InputObject
        {
            get;
            set;
        }

        [Parameter(Position=0)]
        public string Line
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            InputObject.CodeLines.Add(Line);
        }
    }
}
