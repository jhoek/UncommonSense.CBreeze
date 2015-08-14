using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class XmlPortRequestPage
    {
        private PageControls controls = new PageControls();
        private XmlPortRequestPageProperties properties = new XmlPortRequestPageProperties();

        internal XmlPortRequestPage()
        {
        }

        public PageControls Controls
        {
            get
            {
                return this.controls;
            }
        }

        public XmlPortRequestPageProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
