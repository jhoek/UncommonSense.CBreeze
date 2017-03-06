using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class Reports : IntegerKeyedAndNamedContainer<Report>, INode
    {
        internal Reports(Application application, IEnumerable<Report> reports)
        {
            Application = application;
            AddRange(reports);
        }

        public Application Application { get; protected set; }
        public IEnumerable<INode> ChildNodes => this.Cast<INode>();
        public INode ParentNode => Application;
        protected override IEnumerable<int> DefaultRange => DefaultRanges.ID;
        protected override bool UseAlternativeRange => false;

        public override void ValidateName(Report item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }

        protected override void InsertItem(int index, Report item)
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