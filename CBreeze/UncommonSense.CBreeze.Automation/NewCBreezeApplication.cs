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
        [Parameter(Position=0)]
        public ScriptBlock Objects
        {
            get;
            set;
        }

        protected override void EndProcessing()
        {
            var application = new Application();

            if (Objects != null)
            {
                application.Add(Objects.Invoke().Select(o=>o.BaseObject).Cast<Core.Object>());
            }

            WriteObject( application);
        }
    }
}
