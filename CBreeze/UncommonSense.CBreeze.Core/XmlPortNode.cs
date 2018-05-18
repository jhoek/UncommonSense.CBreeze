using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public abstract class XmlPortNode : KeyedItem<Guid>, IHasProperties, INode
    {
        internal XmlPortNode(string nodeName, int? indentationLevel, Guid id)
        {
            ID = (id == Guid.Empty ? Guid.NewGuid() : id);
            IndentationLevel = indentationLevel;
            NodeName = nodeName;
        }

        public abstract XmlPortNodeType NodeType { get; }
        public abstract XmlPortSourceType SourceType { get; }
        public abstract XmlPortNodeAndSourceType Type { get; }

        public string NodeName
        {
            get;
            protected set;
        }

        public XmlPortNodes Container
        {
            get;
            internal set;
        }

        public int Index
        {
            get
            {
                return Container.IndexOf(this);
            }
        }

        public int? IndentationLevel
        {
            get;
            set;
        }

        public abstract Properties AllProperties
        {
            get;
        }

        public IEnumerable<XmlPortNode> Descendants => 
            Container.Skip(Index + 1).TakeWhile(n => n.IndentationLevel.GetValueOrDefault(0) > IndentationLevel.GetValueOrDefault(0));

        public IEnumerable<XmlPortNode> Children => 
            Descendants.Where(c => c.IndentationLevel.GetValueOrDefault(0) == IndentationLevel.GetValueOrDefault(0) + 1);

        public INode ParentNode => Container;

        public abstract IEnumerable<INode> ChildNodes
        {
            get;
        }

        public T AddChildNode<T>(T child, Position position) where T : XmlPortNode
        {
            switch (position)
            {
                case Position.FirstWithinContainer:
                    Container.Insert(Index + 1, child);
                    break;

                case Position.LastWithinContainer:
                    var lastIndex = Descendants.Any() ? Descendants.Last().Index : Index;
                    Container.Insert(lastIndex + 1, child);
                    break;
            }

            return child;
        }
    }
}