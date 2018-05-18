using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class PageActionContainerProperties : Properties
    {
        private PageActionContainerTypeProperty actionContainerType = new PageActionContainerTypeProperty("ActionContainerType");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
#if NAV2016
        private MultiLanguageProperty tooltipML = new MultiLanguageProperty("ToolTipML");
#endif
        private StringProperty description = new StringProperty("Description");
        private StringProperty name = new StringProperty("Name");

        internal PageActionContainerProperties(PageActionContainer pageActionContainer)
        {
            PageActionContainer = pageActionContainer;

            innerList.Add(name);
            innerList.Add(captionML);
#if NAV2016
            innerList.Add(tooltipML);
#endif
            innerList.Add(description);
            innerList.Add(actionContainerType);
        }

        public PageActionContainer PageActionContainer { get; protected set; }

        public override INode ParentNode => PageActionContainer;

        public PageActionContainerType? ActionContainerType
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
                return this.tooltipML.Value;
            }
        }
#endif
    }
}
