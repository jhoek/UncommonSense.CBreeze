using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class ReportElements : IntegerKeyedAndNamedContainer<ReportElement>, INode
    {
        internal ReportElements(Report report)
        {
            Report = report;
        }

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();
        public INode ParentNode => Report;

        public Report Report
        {
            get; protected set;
        }

        protected override bool UseAlternativeRange => (Range ?? DefaultRange).Contains(Report.ID);

        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;

        public override void ValidateName(ReportElement item)
        {
            if (item is ColumnReportElement)
                TestNameNotNullOrEmpty(item);

            TestNameUnique(item);
        }
    }
}