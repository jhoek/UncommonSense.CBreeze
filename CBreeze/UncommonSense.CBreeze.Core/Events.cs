using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UncommonSense.CBreeze.Core
{
    // Note: Events are not an IntegerKeyedAndNamedContainer for the following reasons:
    // - The ID consists of a combination of the Source ID and the (event) ID;
    // - IDs are not assigned from a range (ID is a well-known event ID; Source ID is an existing variable ID);
    public class Events : KeyedCollection<Tuple<int, int>, Event>, INode
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

        public new Event Add(Event @event)
        {
            base.Add(@event);
            return @event;
        }

        public void AddRange(IEnumerable<Event> events)
        {
            foreach (var @event in events)
            {
                Add(@event);
            }
        }

        protected override void InsertItem(int index, Event item)
        {
            ValidateName(item);

            base.InsertItem(index, item);
            item.Container = this;
        }

        protected override void RemoveItem(int index)
        {
            this[index].Container = null;
            base.RemoveItem(index);
        }

        public virtual void ValidateName(Event item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }

        protected virtual void TestNameNotNullOrEmpty(Event item)
        {
            if (string.IsNullOrEmpty(item.Name))
                throw new ArgumentOutOfRangeException("Collection items must have a name.");
            if (string.IsNullOrEmpty(item.SourceName))
                throw new ArgumentOutOfRangeException("Collection items must have a source name.");
        }

        protected virtual void TestNameUnique(Event item)
        {
            var newName = GetNamesForItem(item);

            var existingNames = this
                    .Where(e => !string.IsNullOrEmpty(e.SourceName))
                    .Where(e => !string.IsNullOrEmpty(e.Name))
                    .Select(e => GetNamesForItem(e));

            if (existingNames.Any(n => Tuple.Equals(n, newName)))
                throw new ArgumentOutOfRangeException("Collection item names must be unique.");
        }

        protected Tuple<string, string> GetNamesForItem(Event item) => new Tuple<string, string>(item.SourceName, item.Name);

        protected override Tuple<int, int> GetKeyForItem(Event item) => new Tuple<int, int>(item.SourceID, item.ID);
    }
}
