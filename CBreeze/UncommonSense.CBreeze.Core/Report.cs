using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class Report : Object
    {
        private Code codes = new Code();
        private ReportElements elements = new ReportElements();
        private ReportLabels labels = new ReportLabels();
        private ReportProperties properties = new ReportProperties();
        private RdlData rdlData = new RdlData();
        private ReportRequestPage requestPage = new ReportRequestPage();

        internal Report(Int32 id, String name) : base(id, name)
        {
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.Report;
            }
        }

        public Code Code
        {
            get
            {
                return this.codes;
            }
        }

        public ReportElements Elements
        {
            get
            {
                return this.elements;
            }
        }

        public ReportLabels Labels
        {
            get
            {
                return this.labels;
            }
        }

        public ReportProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

        public RdlData RdlData
        {
            get
            {
                return this.rdlData;
            }
        }

        public ReportRequestPage RequestPage
        {
            get
            {
                return this.requestPage;
            }
        }

    }
}
