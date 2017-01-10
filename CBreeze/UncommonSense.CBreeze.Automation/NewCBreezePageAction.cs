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
    [Cmdlet(VerbsCommon.New, "CBreezePageAction")]
    public class NewCBreezePageAction : PSCmdletWithDynamicParams
    {
        public NewCBreezePageAction()
        {
            Caption = new DynamicParameter<string>("Caption");
            ContainerType = new DynamicParameter<ActionContainerType?>("ContainerType");
            Description = new DynamicParameter<string>("Description");
            Ellipsis = new DynamicParameter<bool?>("Ellipsis");
            Enabled = new DynamicParameter<string>("Enabled");
            Image = new DynamicParameter<string>("Image");
            InFooterBar = new DynamicParameter<bool?>("InFooterBar");
            IsHeader = new DynamicParameter<bool?>("IsHeader");
            Name = new DynamicParameter<string>("Name");
            Promoted = new DynamicParameter<bool?>("Promoted");
            PromotedCategory = new DynamicParameter<Core.PromotedCategory?>("PromotedCategory");
            PromotedIsBig = new DynamicParameter<bool?>("PromotedIsBig");
            RunObjectType = new DynamicParameter<Core.RunObjectType?>("RunObjectType");
            RunObjectID = new DynamicParameter<int?>("RunObjectID");
            RunPageMode = new DynamicParameter<Core.RunPageMode?>("RunPageMode");
            RunPageOnRec = new DynamicParameter<bool?>("RunPageOnRec");
            RunPageViewKey = new DynamicParameter<string>("RunPageViewKey");
            RunPageViewOrder = new DynamicParameter<Order?>("RunPageViewOrder");
#if NAV2015
            Scope = new DynamicParameter<PageActionScope?>("Scope");
#endif
            ShortcutKey = new DynamicParameter<string>("ShortcutKey");
            Visible = new DynamicParameter<string>("Visible");
        }

        [Parameter(Mandatory = true, Position = 0)]
        public PageActionBaseType? Type
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1)]
        public int ID
        {
            get;
            set;
        }

        protected DynamicParameter<string> Caption
        {
            get;
            set;
        }

        protected DynamicParameter<ActionContainerType?> ContainerType
        {
            get;
            set;
        }

        protected DynamicParameter<string> Description
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> Ellipsis
        {
            get;
            set;
        }

        protected DynamicParameter<string> Enabled
        {
            get;
            set;
        }

        protected DynamicParameter<string> Image
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> InFooterBar
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> IsHeader
        {
            get;
            set;
        }

        protected DynamicParameter<string> Name
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> Promoted
        {
            get;
            set;
        }

        protected DynamicParameter<PromotedCategory?> PromotedCategory
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> PromotedIsBig
        {
            get;
            set;
        }

        protected DynamicParameter<RunObjectType?> RunObjectType
        {
            get;
            set;
        }

        protected DynamicParameter<int?> RunObjectID
        {
            get;
            set;
        }

        protected DynamicParameter<RunPageMode?> RunPageMode
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> RunPageOnRec
        {
            get;
            set;
        }

        protected DynamicParameter<string> RunPageViewKey
        {
            get;
            set;
        }

        protected DynamicParameter<Order?> RunPageViewOrder
        {
            get;
            set;
        }

#if NAV2015
        protected DynamicParameter<PageActionScope?> Scope
        {
            get;
            set;
        }
#endif

        protected DynamicParameter<string> ShortcutKey
        {
            get;
            set;
        }

        protected DynamicParameter<string> Visible
        {
            get;
            set;
        }

        [Parameter(Position = 2)]
        public ScriptBlock ChildActions
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            var indentation = (int)GetVariableValue("Indentation", 0);
            WriteObject(CreatePageAction(ID, indentation));

            if (ChildActions != null)
            {
                var variables = new List<PSVariable>() { new PSVariable("Indentation", indentation + 1) };
                WriteObject(ChildActions.InvokeWithContext(null, variables), true);
            }
        }

        protected PageActionBase CreatePageAction(int id, int indentation)
        {
            switch (Type.Value)
            {
                case PageActionBaseType.ActionContainer:
                    var pageActionContainer = new PageActionContainer(id, 0);
                    pageActionContainer.Properties.ActionContainerType = ContainerType.Value;
                    pageActionContainer.Properties.Description = Description.Value;
                    pageActionContainer.Properties.Name = Name.Value;
                    return pageActionContainer;

                case PageActionBaseType.ActionGroup:
                    var pageActionGroup = new PageActionGroup(id, indentation);
                    pageActionGroup.Properties.CaptionML.Set("ENU", Caption.Value);
                    pageActionGroup.Properties.Description = Description.Value;
                    pageActionGroup.Properties.Enabled = Enabled.Value;
                    pageActionGroup.Properties.Image = Image.Value;
                    pageActionGroup.Properties.Name = Name.Value;
                    pageActionGroup.Properties.Visible = Visible.Value;
                    return pageActionGroup;

                case PageActionBaseType.Action:
                    var pageAction = new PageAction(id, indentation);
                    pageAction.Properties.CaptionML.Set("ENU", Caption.Value);
                    pageAction.Properties.Description = Description.Value;
                    pageAction.Properties.Ellipsis = Ellipsis.Value;
                    pageAction.Properties.Enabled = Enabled.Value;
                    pageAction.Properties.Image = Image.Value;
                    pageAction.Properties.InFooterBar = InFooterBar.Value;
                    pageAction.Properties.Name = Name.Value;
                    pageAction.Properties.Promoted = Promoted.Value;
                    pageAction.Properties.PromotedCategory = PromotedCategory.Value;
                    pageAction.Properties.PromotedIsBig = PromotedIsBig.Value;
                    pageAction.Properties.RunObject.Type = RunObjectType.Value;
                    pageAction.Properties.RunObject.ID = RunObjectID.Value;
                    pageAction.Properties.RunPageMode = RunPageMode.Value;
                    pageAction.Properties.RunPageOnRec = RunPageOnRec.Value;
                    pageAction.Properties.RunPageView.Key = RunPageViewKey.Value;
                    pageAction.Properties.RunPageView.Order = RunPageViewOrder.Value;
#if NAV2015
                    pageAction.Properties.Scope = Scope.Value;
#endif
                    pageAction.Properties.ShortCutKey = ShortcutKey.Value;
                    pageAction.Properties.Visible = Visible.Value;
                    return pageAction;

                case PageActionBaseType.Separator:
                    var pageActionSeparator = new PageActionSeparator(id, indentation);
                    pageActionSeparator.Properties.CaptionML.Set("ENU", Caption.Value);
                    pageActionSeparator.Properties.IsHeader = IsHeader.Value;
                    return pageActionSeparator;

                default:
                    throw new ArgumentOutOfRangeException("Unknown action type.");
            }
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
                        yield return Caption.RuntimeDefinedParameter;
                        yield return Description.RuntimeDefinedParameter;
                        yield return Enabled.RuntimeDefinedParameter;
                        yield return Image.RuntimeDefinedParameter;
                        yield return Name.RuntimeDefinedParameter;
                        yield return Visible.RuntimeDefinedParameter;
                        break;

                    case PageActionBaseType.Action:
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
                        yield return Caption.RuntimeDefinedParameter;
                        yield return IsHeader.RuntimeDefinedParameter;
                        break;
                }
            }
        }
    }
}
