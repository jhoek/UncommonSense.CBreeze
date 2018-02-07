using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
#if NAV2016
    [Cmdlet(VerbsCommon.Set, "CBreezeXmlPortNamespace")]
    [OutputType(typeof(XmlPort))]
    public class SetCBreezeXmlPortNamespace : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public XmlPort InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1)]
        public string Prefix
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 2)]
        public string Namespace
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter PassThru
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            InputObject.Properties.Namespaces.Set(Prefix, Namespace);

            if (PassThru)
                WriteObject(InputObject);
        }
    }
#endif
}
