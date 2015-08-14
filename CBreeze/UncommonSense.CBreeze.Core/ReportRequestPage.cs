using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class ReportRequestPage
    {
        private PageControls controls = new PageControls();
        private ReportRequestPageProperties properties = new ReportRequestPageProperties();

        internal ReportRequestPage()
        {
        }

        public PageControls Controls
        {
            get
            {
                return this.controls;
            }
        }

        public ReportRequestPageProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
