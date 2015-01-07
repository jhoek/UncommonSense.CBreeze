using System;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.DomBuilder
{
	public class Nodes : IEnumerable<Node>
	{
		private List<Node> innerList = new List<Node>();

		internal void Add(Dom dom, Node parentNode, Node node)
		{
			node.Dom = dom;
            node.ParentNode = parentNode;
			innerList.Add(node);
		}

		internal void AddRange(Dom dom, Node parentNode, Node[] nodes)
		{
			foreach (var node in nodes) {
				Add(dom, parentNode, node);
			}
		}

		public IEnumerator<Node> GetEnumerator()
		{
			return innerList.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return innerList.GetEnumerator();
		}
	}
}

