using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezePageAction")]
    public class AddCBreezePageAction : NewCBreezePageAction
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
            get;
            set;
        }

        [Parameter()]
        public Position? Position
        {
            get;
            set;
        }

        protected override int GetIndentation() => GetParentIndentationLevel() + 1;

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

        protected override void ProcessRecord()
        {
            var pageAction = CreatePageAction();
            var position = Position.GetValueOrDefault(Core.Position.LastWithinContainer);

            TypeSwitch.Do(
                InputObject.BaseObject,
                TypeSwitch.Case<PageActionContainer>(i => i.AddChildPageAction(pageAction, position)),
                TypeSwitch.Case<PageActionGroup>(i => i.AddChildPageAction(pageAction, position)),
                TypeSwitch.Case<ActionList>(i => i.AddPageActionAtPosition(pageAction, position)),
                TypeSwitch.Case<IPage>(i => i.AddPageActionAtPosition(pageAction, position)),
                TypeSwitch.Default(() => UnknownInputObjectType())
            );

            if (PassThru)
                WriteObject(pageAction);
        }

        protected void UnknownInputObjectType()
        {
            throw new ArgumentOutOfRangeException("Don't know how to add a page action to an InputObject of this type.");
        }
    }
}