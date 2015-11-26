using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class XmlPortNodeExtensionMethods
    {
        public static IEnumerable<XmlPortNode> GetDescendantNodes(this XmlPortNode parent)
        {
            var nodes = parent.Container;

            return nodes.Skip(parent.Index() + 1).TakeWhile(n => n.IndentationLevel > parent.IndentationLevel);
        }

        public static int Index(this XmlPortNode node)
        {
            return node.Container.IndexOf(node);
        }

        public static T AddChildNode<T>(this XmlPortNode parent, T child, Position position) where T : XmlPortNode
        {
            var nodes = parent.Container;

            switch (position)
            {
                case Position.FirstWithinContainer:
                    nodes.Insert(parent.Index() + 1, child);
                    break;
                case Position.LastWithinContainer:
                    var childNodes = parent.GetDescendantNodes();
                    var lastINdex = childNodes.Any() ? childNodes.Last().Index() : parent.Index();
                    nodes.Insert(lastINdex + 1, child);
                    break;
            }

            return child;
        }
    }
}
