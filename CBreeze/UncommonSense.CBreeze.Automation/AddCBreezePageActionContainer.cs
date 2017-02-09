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

        [Parameter(Mandatory = true, Position = 1)]
        [Alias("Range")]
        public new PSObject ID
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

        protected override int GetID()
        {
            var page = InputObject.GetIPage();
            return ID.GetID(page.GetPageUIDsInUse(), page.ObjectID);
        }

        protected override int GetIndentation() => 0;

        protected override void ProcessRecord()
        {
            var pageActionContainer = CreatePageActionContainer();
            var position = Position.GetValueOrDefault(Core.Position.LastWithinContainer);

            TypeSwitch.Do(
                InputObject.BaseObject,
                TypeSwitch.Case<IPage>(i => i.AddPageActionAtPosition(pageActionContainer, position)),
                TypeSwitch.Case<ActionList>(i=>i.AddPageActionAtPosition(pageActionContainer,position))
                );

            if (PassThru)
                WriteObject(pageActionContainer);
        }
    }
}
