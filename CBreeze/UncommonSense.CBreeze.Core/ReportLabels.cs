using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class ReportLabels : IntegerKeyedAndNamedContainer<ReportLabel>, INode
    {
        internal ReportLabels(Report report)
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

        public override void ValidateName(ReportLabel item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }

        protected override void InsertItem(int index, ReportLabel item)
        {
            base.InsertItem(index, item);
            item.Container = this;
        }

        protected override void RemoveItem(int index)
        {
            this[index].Container = null;
            base.RemoveItem(index);
        }
    }
}