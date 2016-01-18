using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class TableFieldGroupProperties : Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");

        internal TableFieldGroupProperties()
        {
            innerList.Add(captionML);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }
    }
}
