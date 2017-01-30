using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezePageAction")]
    [OutputType(typeof(PageAction))]
    public class NewCBreezePageAction : NewCBreezePageActionBase
    {
        [Parameter(Position=1)]
        public string Caption
        {
            get; set;
        }

        [Parameter()]
        public string Description
        {
            get; set;
        }

        [Parameter()]
        public bool? Ellipsis
        {
            get; set;
        }

        [Parameter()]
        public string Enabled
        {
            get; set;
        }

        [Parameter(Position=2)]
        public string Image
        {
            get; set;
        }

        [Parameter()]
        public bool? InFooterBar
        {
            get; set;
        }

        [Parameter()]
        public string Name
        {
            get; set;
        }

        [Parameter()]
        public bool? Promoted
        {
            get; set;
        }

        [Parameter()]
        public PromotedCategory? PromotedCategory
        {
            get; set;
        }

        [Parameter()]
        public bool? PromotedIsBig
        {
            get; set;
        }

        [Parameter()]
        public RunObjectType? RunObjectType
        {
            get; set;
        }

        [Parameter()]
        public int? RunObjectID
        {
            get; set;
        }

        [Parameter()]
        public RunPageMode? RunPageMode
        {
            get; set;
        }

        [Parameter()]
        public bool? RunPageOnRec
        {
            get; set;
        }

        [Parameter()]
        public string RunPageViewKey
        {
            get; set;
        }

        [Parameter()]
        public Order? RunPageViewOrder
        {
            get; set;
        }

#if NAV2015
        [Parameter()]
        public PageActionScope? Scope
        {
            get; set;
        }
#endif

        [Parameter()]
        public string ShortcutKey
        {
            get; set;
        }

        [Parameter()]
        public string Visible
        {
            get; set;
        }

        protected PageAction CreatePageAction()
        {
            var pageAction = new PageAction(GetID(), GetIndentation());
            pageAction.Properties.CaptionML.Set("ENU", Caption);
            pageAction.Properties.Description = Description;
            pageAction.Properties.Ellipsis = Ellipsis;
            pageAction.Properties.Enabled = Enabled;
            pageAction.Properties.Image = Image;
            pageAction.Properties.InFooterBar = InFooterBar;
            pageAction.Properties.Name = Name;
            pageAction.Properties.Promoted = Promoted;
            pageAction.Properties.PromotedCategory = PromotedCategory;
            pageAction.Properties.PromotedIsBig = PromotedIsBig;
            pageAction.Properties.RunObject.Type = RunObjectType;
            pageAction.Properties.RunObject.ID = RunObjectID;
            pageAction.Properties.RunPageMode = RunPageMode;
            pageAction.Properties.RunPageOnRec = RunPageOnRec;
            pageAction.Properties.RunPageView.Key = RunPageViewKey;
            pageAction.Properties.RunPageView.Order = RunPageViewOrder;
#if NAV2015
            pageAction.Properties.Scope = Scope;
#endif
            pageAction.Properties.ShortCutKey = ShortcutKey;
            pageAction.Properties.Visible = Visible;

            return pageAction;
        }

        protected override void ProcessRecord()
        {
            WriteObject(CreatePageAction());
        }
    }
}
