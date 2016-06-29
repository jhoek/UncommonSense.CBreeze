using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public abstract class XmlPortNode : KeyedItem<Guid>, IHasProperties
    {
        internal XmlPortNode(Guid id, string nodeName, int? indentationLevel)
        {
            ID = id;
            IndentationLevel = indentationLevel;
            NodeName = nodeName;
        }

        public abstract XmlPortNodeAndSourceType Type
        {
            get;
        }

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
            protected set;
        }

        public abstract Properties AllProperties
        {
            get;
        }

        public IEnumerable<XmlPortNode> DescendantNodes
        {
            get
            {
                return Container.Skip(Index + 1).TakeWhile(n => n.IndentationLevel > IndentationLevel);
            }
        }

        public  T AddChildNode<T>(T child, Position position) where T : XmlPortNode
        {
            switch (position)
            {
                case Position.FirstWithinContainer:
                    Container.Insert(Index + 1, child);
                    break;
                case Position.LastWithinContainer:
                    var childNodes = DescendantNodes;
                    var lastINdex = childNodes.Any() ? childNodes.Last().Index : Index;
                    Container.Insert(lastINdex + 1, child);
                    break;
            }

            return child;
        }
    }
}
