using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class ReportLabelProperties : Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");

        internal ReportLabelProperties()
        {
            innerList.Add(captionML);
            innerList.Add(description);
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
    }
}
