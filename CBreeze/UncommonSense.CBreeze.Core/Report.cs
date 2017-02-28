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
            Properties = new ReportProperties(this);
            Elements = new ReportElements(this);
            RequestPage = new ReportRequestPage(this);
            Labels = new ReportLabels(this);
            Code = new Code(this);
            RdlData = new RdlData(this);
#if NAV2015
            WordLayout = new WordLayout(this);
#endif
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.Report;
            }
        }

        public Reports Container { get; internal set; }

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

        public override INode ParentNode => Container;

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return Elements ;
                yield return RequestPage ;
                yield return Labels ;
                yield return Code ;
                yield return RdlData ;
#if NAV2015
                yield return WordLayout ;
#endif
            }
        }
    }
}
