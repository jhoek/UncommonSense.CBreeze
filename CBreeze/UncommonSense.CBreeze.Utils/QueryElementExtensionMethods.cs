using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class QueryElementExtensionMethods
    {
        public static IEnumerable<QueryElement> GetDescendantElements(this QueryElement parent)
        {
            var elements = parent.Container;

            return elements.Skip(parent.Index() + 1).TakeWhile(e => e.IndentationLevel > parent.IndentationLevel);
        }

        public static int Index(this QueryElement element)
        {
            return element.Container.IndexOf(element);
        }

        public static T AddChildNode<T>(this QueryElement parent, T child, Position position) where T : QueryElement
        {
            var elements = parent.Container;

            switch (position)
            {
                case Position.FirstWithinContainer:
                    elements.Insert(parent.Index() + 1, child);
                    break;
                case Position.LastWithinContainer:
                    var descendantElements = parent.GetDescendantElements();
                    var lastIndex = descendantElements.Any() ? descendantElements.Last().Index() : parent.Index();
                    elements.Insert(lastIndex + 1, child);
                    break;
            }

            return child;
        }
    }
}
