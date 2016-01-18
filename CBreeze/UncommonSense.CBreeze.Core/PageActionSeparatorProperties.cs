using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class PageActionSeparatorProperties : Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private NullableBooleanProperty isHeader = new NullableBooleanProperty("IsHeader");

        internal PageActionSeparatorProperties()
        {
            innerList.Add(captionML);
            innerList.Add(isHeader);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public bool? IsHeader
        {
            get
            {
                return this.isHeader.Value;
            }
            set
            {
                this.isHeader.Value = value;
            }
        }
    }
}
