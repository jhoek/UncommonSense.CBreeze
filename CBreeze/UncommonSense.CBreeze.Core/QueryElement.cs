using System.Linq;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public abstract class QueryElement : KeyedItem<int>, IHasName, IHasProperties, INode
    {
        public QueryElement(int id, string name, int? indentationLevel)
        {
            ID = id;
            IndentationLevel = indentationLevel;
            Name = name;
        }

        public abstract QueryElementType Type { get; }
        public string Name { get; protected set; }
        public int? IndentationLevel { get; protected set; }
        public QueryElements Container { get; internal set; }
        public string GetName() { return Name; }
        public abstract Properties AllProperties { get; }
        public int Index => Container.IndexOf(this);

        public IEnumerable<QueryElement> Descendants => Container.Skip(Index + 1).TakeWhile(e => e.IndentationLevel.GetValueOrDefault(0) > IndentationLevel.GetValueOrDefault(0));

        public IEnumerable<QueryElement> Children => Descendants.Where(e => e.IndentationLevel.GetValueOrDefault(0) == IndentationLevel.GetValueOrDefault(0) + 1);

        public INode ParentNode => Container;

        public abstract IEnumerable<INode> ChildNodes { get; }

        public T AddChildNode<T>(T child, Position position) where T : QueryElement
        {
            switch (position)
            {
                case Position.FirstWithinContainer:
                    Container.Insert(Index + 1, child);
                    break;
                case Position.LastWithinContainer:
                    var descendantElements = Descendants;
                    var lastIndex = descendantElements.Any() ? descendantElements.Last().Index : Index;
                    Container.Insert(lastIndex + 1, child);
                    break;
            }

            return child;
        }
    }
}
