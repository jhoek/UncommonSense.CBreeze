using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class PageActionGroupProperties : Properties
    {
        private ActionContainerTypeProperty actionContainerType = new ActionContainerTypeProperty("ActionContainerType");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private StringProperty enabled = new StringProperty("Enabled");
        private StringProperty image = new StringProperty("Image");
        private StringProperty name = new StringProperty("Name");
#if NAV2016
        private MultiLanguageProperty toolTipML = new MultiLanguageProperty("ToolTipML");
#endif
        private StringProperty visible = new StringProperty("Visible");

        internal PageActionGroupProperties(PageActionGroup pageActionGroup)
        {
            PageActionGroup = pageActionGroup;

            innerList.Add(name);
            innerList.Add(captionML);
#if NAV2016
            innerList.Add(toolTipML);
#endif
            innerList.Add(description);
            innerList.Add(visible);
            innerList.Add(enabled);
            innerList.Add(actionContainerType);
            innerList.Add(image);
        }

        public PageActionGroup PageActionGroup { get; protected set; }

        public override INode ParentNode => PageActionGroup;

        // See also: http://www.uncommonsense.nl/zen/?p=29
        public ActionContainerType? ActionContainerType
        {
            get
            {
                return this.actionContainerType.Value;
            }
            set
            {
                this.actionContainerType.Value = value;
            }
        }

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

#if NAV2016
        public MultiLanguageValue ToolTipML
        {
            get
            {
                return this.toolTipML.Value;
            }
        }
#endif

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
