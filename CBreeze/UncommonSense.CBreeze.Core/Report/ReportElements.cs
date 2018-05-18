using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Report
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

        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;

        public override void ValidateName(ReportElement item)
        {
            if (item is ColumnReportElement)
                TestNameNotNullOrEmpty(item);

            TestNameUnique(item);
        }

        protected override void InsertItem(int index, ReportElement item)
        {
            base.InsertItem(index, item);
            item.Container = this;
        }

        protected override void RemoveItem(int index)
        {
            this.ElementAt(index).Container = null;
            base.RemoveItem(index);
        }
    }
}