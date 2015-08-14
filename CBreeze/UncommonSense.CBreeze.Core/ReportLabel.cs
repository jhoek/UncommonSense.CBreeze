using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class ReportLabel
    {
        private Int32 id;
        private String name;
        private ReportLabelProperties properties = new ReportLabelProperties();

        internal ReportLabel(Int32 id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public Int32 ID
        {
            get
            {
                return this.id;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
        }

        public ReportLabelProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
