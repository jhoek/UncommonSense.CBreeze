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
        public AddCBreezePageAction()
        {
            Position = new DynamicParameter<Position?>("Position");
        }

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
            get;
            set;
        }

        protected DynamicParameter<Position?> Position
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            var pageAction = CreatePageAction(GetID(), GetParentIndentationLevel() + 1);
            var position = Position.Value.GetValueOrDefault(Core.Position.LastWithinContainer);

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

        protected int GetID()
        {
            var page = InputObject.GetIPage();
            return ID.GetID(page.GetPageUIDsInUse(), page.ObjectID);
        }

        public override IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get
            {
                switch (Type.Value)
                {
                    case PageActionBaseType.ActionContainer:
                        yield return ContainerType.RuntimeDefinedParameter;
                        yield return Description.RuntimeDefinedParameter;
                        yield return Name.RuntimeDefinedParameter;
                        break;

                    case PageActionBaseType.ActionGroup:
                        yield return Position.RuntimeDefinedParameter;
                        yield return Caption.RuntimeDefinedParameter;
                        yield return Description.RuntimeDefinedParameter;
                        yield return Enabled.RuntimeDefinedParameter;
                        yield return Image.RuntimeDefinedParameter;
                        yield return Name.RuntimeDefinedParameter;
                        yield return Visible.RuntimeDefinedParameter;
                        break;

                    case PageActionBaseType.Action:
                        yield return Position.RuntimeDefinedParameter;
                        yield return Caption.RuntimeDefinedParameter;
                        yield return Description.RuntimeDefinedParameter;
                        yield return Ellipsis.RuntimeDefinedParameter;
                        yield return Enabled.RuntimeDefinedParameter;
                        yield return Image.RuntimeDefinedParameter;
                        yield return InFooterBar.RuntimeDefinedParameter;
                        yield return Name.RuntimeDefinedParameter;
                        yield return Promoted.RuntimeDefinedParameter;
                        yield return PromotedCategory.RuntimeDefinedParameter;
                        yield return PromotedIsBig.RuntimeDefinedParameter;
                        yield return RunObjectType.RuntimeDefinedParameter;
                        yield return RunObjectID.RuntimeDefinedParameter;
                        yield return RunPageMode.RuntimeDefinedParameter;
                        yield return RunPageOnRec.RuntimeDefinedParameter;
                        yield return RunPageViewKey.RuntimeDefinedParameter;
                        yield return RunPageViewOrder.RuntimeDefinedParameter;
#if NAV2015
                        yield return Scope.RuntimeDefinedParameter;
#endif
                        yield return ShortcutKey.RuntimeDefinedParameter;
                        yield return Visible.RuntimeDefinedParameter;
                        break;

                    case PageActionBaseType.Separator:
                        yield return Position.RuntimeDefinedParameter;
                        yield return Caption.RuntimeDefinedParameter;
                        yield return IsHeader.RuntimeDefinedParameter;
                        break;
                }
            }
        }
    }
}
