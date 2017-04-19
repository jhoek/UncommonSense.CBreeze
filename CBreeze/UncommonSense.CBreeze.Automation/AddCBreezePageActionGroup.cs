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
    [Cmdlet(VerbsCommon.Add, "CBreezePageActionGroup")]
    public class AddCBreezePageActionGroup : NewCBreezePageActionGroup
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

        protected override int GetIndentation() => GetParentIndentationLevel() + 1;

        protected override void ProcessRecord()
        {
            var pageActionSeparator = CreatePageActionGroup();
            var position = Position.GetValueOrDefault(Core.Position.LastWithinContainer);

            TypeSwitch.Do(
                InputObject.BaseObject,
                TypeSwitch.Case<PageActionContainer>(i => i.AddChildPageAction(pageActionSeparator, position)),
                TypeSwitch.Case<PageActionGroup>(i => i.AddChildPageAction(pageActionSeparator, position)),
                TypeSwitch.Case<ActionList>(i => i.AddPageActionAtPosition(pageActionSeparator, position)),
                TypeSwitch.Case<IPage>(i => i.AddPageActionAtPosition(pageActionSeparator, position)),
                TypeSwitch.Default(() => UnknownInputObjectType())
            );

            if (PassThru)
                WriteObject(pageActionSeparator);
        }

        protected void UnknownInputObjectType()
        {
            throw new ArgumentOutOfRangeException("Don't know how to add a page action to an InputObject of this type.");
        }

        protected int GetParentIndentationLevel()
        {
            var result = 0;

            TypeSwitch.Do(
                InputObject.BaseObject,
                TypeSwitch.Case<PageActionContainer>(i => result = i.IndentationLevel.GetValueOrDefault(0)),
                TypeSwitch.Case<PageActionGroup>(i => result = i.IndentationLevel.GetValueOrDefault(0))
                );

            return result;
        }
    }
}
