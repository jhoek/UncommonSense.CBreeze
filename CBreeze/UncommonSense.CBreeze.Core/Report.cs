using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class Report : Object, IHasCode
    {
        public Report(int id, string name)
            : base(id, name)
        {
            Properties = new ReportProperties();
            Elements = new ReportElements();
            RequestPage = new ReportRequestPage(this);
            Labels = new ReportLabels();
            Code = new Code(this);
            RdlData = new RdlData();
#if NAV2015
            WordLayout = new WordLayout();
#endif
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.Report;
            }
        }

        public ReportProperties Properties
        {
            get;
            protected set;
        }

        public ReportElements Elements
        {
            get;
            protected set;
        }

        public ReportRequestPage RequestPage
        {
            get;
            protected set;
        }

        public ReportLabels Labels
        {
            get;
            protected set;
        }

        public Code Code
        {
            get;
            protected set;
        }

        public RdlData RdlData
        {
            get;
            protected set;
        }

#if NAV2015
        public WordLayout WordLayout
        {
            get;
            protected set;
        }
#endif

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }
    }
}
