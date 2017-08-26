using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezePageActionContainer")]
    public class AddCBreezePageActionContainer : NewCBreezePageActionContainer
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter PassThru
        {
            get; set;
        }

        [Parameter()]
        public Position? Position
        {
            get; set;
        }

        protected override int GetIndentation() => 0;

        protected override void ProcessRecord()
        {
            var pageActionContainer = CreatePageActionContainer();
            var position = Position.GetValueOrDefault(Core.Position.LastWithinContainer);

            switch (InputObject.BaseObject)
            {
                case IPage p: p.AddPageActionAtPosition(pageActionContainer, position); break;
                case ActionList a: a.AddPageActionAtPosition(pageActionContainer, position); break;
            }

            if (PassThru)
                WriteObject(pageActionContainer);
        }
    }
}