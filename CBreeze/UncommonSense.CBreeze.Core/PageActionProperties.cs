using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class PageActionProperties : Properties
    {
#if NAV2015
        private AccessByPermissionProperty accessByPermission = new AccessByPermissionProperty("AccessByPermission");
#endif
#if NAV2017
        private TagListProperty applicationArea = new TagListProperty("ApplicationArea");
#endif
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty ellipsis = new NullableBooleanProperty("Ellipsis");
        private StringProperty enabled = new StringProperty("Enabled");
#if NAV2017
        private GestureProperty gesture = new GestureProperty("Gesture");
#endif
        private StringProperty image = new StringProperty("Image");
        private NullableBooleanProperty inFooterBar = new NullableBooleanProperty("InFooterBar");
        private StringProperty name = new StringProperty("Name");
        private TriggerProperty onAction = new TriggerProperty("OnAction");
        private NullableBooleanProperty promoted = new NullableBooleanProperty("Promoted");
        private PromotedCategoryProperty promotedCategory = new PromotedCategoryProperty("PromotedCategory");
        private NullableBooleanProperty promotedIsBig = new NullableBooleanProperty("PromotedIsBig");
#if NAV2017
        private NullableBooleanProperty promotedOnly = new NullableBooleanProperty("PromotedOnly");
#endif
        private RunObjectProperty runObject = new RunObjectProperty("RunObject");
        private RunObjectLinkProperty runPageLink = new RunObjectLinkProperty("RunPageLink");
        private RunPageModeProperty runPageMode = new RunPageModeProperty("RunPageMode");
        private NullableBooleanProperty runPageOnRec = new NullableBooleanProperty("RunPageOnRec");
        private TableViewProperty runPageView = new TableViewProperty("RunPageView");
#if NAV2015
        private PageActionScopeProperty scope = new PageActionScopeProperty("Scope");
#endif
        private StringProperty shortCutKey = new StringProperty("ShortCutKey");
        private MultiLanguageProperty toolTipML = new MultiLanguageProperty("ToolTipML");
        private StringProperty visible = new StringProperty("Visible");

        internal PageActionProperties(PageAction pageAction)
        {
            PageAction = pageAction;

            innerList.Add(name);
#if NAV2015
            innerList.Add(accessByPermission);
#endif
            innerList.Add(shortCutKey);
            innerList.Add(ellipsis);
            innerList.Add(captionML);
            innerList.Add(toolTipML);
#if NAV2017
            innerList.Add(applicationArea);
#endif
            innerList.Add(description);
            innerList.Add(runObject);
            innerList.Add(runPageOnRec);
            innerList.Add(runPageView);
            innerList.Add(runPageLink);
            innerList.Add(promoted);
            innerList.Add(visible);
            innerList.Add(enabled);
            innerList.Add(inFooterBar);
            innerList.Add(promotedIsBig);
            innerList.Add(image);
            innerList.Add(promotedCategory);
#if NAV2017
            innerList.Add(promotedOnly);
#endif
            innerList.Add(runPageMode);
#if NAV2015
            innerList.Add(scope);
#endif
            innerList.Add(onAction);
#if NAV2017
            innerList.Add(gesture);
#endif
        }

        public PageAction PageAction { get; protected set; }

        public override INode ParentNode => PageAction;

#if NAV2015
        public AccessByPermission AccessByPermission
        {
            get
            {
                return this.accessByPermission.Value;
            }
        }
#endif

#if NAV2017
        public TagList ApplicationArea => applicationArea.Value;
#endif

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public string Description
        {
            get
            {
                return this.description.Value;
            }
            set
            {
                this.description.Value = value;
            }
        }

        public bool? Ellipsis
        {
            get
            {
                return this.ellipsis.Value;
            }
            set
            {
                this.ellipsis.Value = value;
            }
        }

        public string Enabled
        {
            get
            {
                return this.enabled.Value;
            }
            set
            {
                this.enabled.Value = value;
            }
        }

#if NAV2017
        public Gesture? Gesture
        {
            get => gesture.Value;
            set => gesture.Value = value;
        }
#endif

        public string Image
        {
            get
            {
                return this.image.Value;
            }
            set
            {
                this.image.Value = value;
            }
        }

        public bool? InFooterBar
        {
            get
            {
                return this.inFooterBar.Value;
            }
            set
            {
                this.inFooterBar.Value = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name.Value;
            }
            set
            {
                this.name.Value = value;
            }
        }

        public Trigger OnAction
        {
            get
            {
                return this.onAction.Value;
            }
        }

        public bool? Promoted
        {
            get
            {
                return this.promoted.Value;
            }
            set
            {
                this.promoted.Value = value;
            }
        }

        public PromotedCategory? PromotedCategory
        {
            get
            {
                return this.promotedCategory.Value;
            }
            set
            {
                this.promotedCategory.Value = value;
            }
        }

        public bool? PromotedIsBig
        {
            get
            {
                return this.promotedIsBig.Value;
            }
            set
            {
                this.promotedIsBig.Value = value;
            }
        }

#if NAV2017
        public bool? PromotedOnly
        {
            get => promotedOnly.Value;
            set => promotedOnly.Value = value;
        }
#endif

        public RunObject RunObject
        {
            get
            {
                return this.runObject.Value;
            }
        }

        public RunObjectLink RunPageLink
        {
            get
            {
                return this.runPageLink.Value;
            }
        }

        public RunPageMode? RunPageMode
        {
            get
            {
                return this.runPageMode.Value;
            }
            set
            {
                this.runPageMode.Value = value;
            }
        }

        public bool? RunPageOnRec
        {
            get
            {
                return this.runPageOnRec.Value;
            }
            set
            {
                this.runPageOnRec.Value = value;
            }
        }

        public TableView RunPageView
        {
            get
            {
                return this.runPageView.Value;
            }
        }

#if NAV2015
        public PageActionScope? Scope
        {
            get
            {
                return this.scope.Value;
            }
            set
            {
                this.scope.Value = value;
            }
        }
#endif

        public string ShortCutKey
        {
            get
            {
                return this.shortCutKey.Value;
            }
            set
            {
                this.shortCutKey.Value = value;
            }
        }

        public MultiLanguageValue ToolTipML
        {
            get
            {
                return this.toolTipML.Value;
            }
        }

        public string Visible
        {
            get
            {
                return this.visible.Value;
            }
            set
            {
                this.visible.Value = value;
            }
        }
    }
}
