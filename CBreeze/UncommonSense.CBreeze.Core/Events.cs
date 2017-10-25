using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UncommonSense.CBreeze.Core
{
        public class Events : IntegerKeyedAndNamedContainer<Event>, INode
    {
        internal Events(Code code)
        {
            Code = code;
        }

        public Code Code
        {
            get;
            protected set;
        }

        public INode ParentNode => Code;

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;

        protected override void InsertItem(int index, Event item)
        {
            base.InsertItem(index, item);
            item.Container = this;
        }

        protected override void RemoveItem(int index)
        {
            this[index].Container = null;
            base.RemoveItem(index);
        }

        public override void ValidateName(Event item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }

        protected override void TestNameNotNullOrEmpty(Event item)
        {
            if (string.IsNullOrEmpty(item.Name))
                throw new ArgumentOutOfRangeException("Collection items must have a name.");
            if (string.IsNullOrEmpty(item.SourceName))
                throw new ArgumentOutOfRangeException("Collection items must have a source name.");
        }

        protected override void TestNameUnique(Event item)
        {
            var newName = $"{item.SourceName}::{item.Name}";

            var existingNames = this
                    .Where(e => !string.IsNullOrEmpty(e.SourceName))
                    .Where(e => !string.IsNullOrEmpty(e.Name))
                    .Select(e => $"{e.SourceName}::{e.Name}");

            if (existingNames.Any(n => n.Equals(newName, StringComparison.InvariantCultureIgnoreCase)))
                throw new ArgumentOutOfRangeException("Collection item names must be unique.");
        }
    }
}
