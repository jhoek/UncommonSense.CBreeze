using System;

namespace CBreeze.NextGen
{
	public class XmlPort : Object, IEquatable<XmlPort>
	{
		public XmlPort(int id, string name)
			: base(id, name)
		{
			Properties = new XmlPortProperties(this);
			Nodes = new XmlPortNodes(this);
			Code = new Code(this);
		}

		public override ObjectType Type
		{
			get
			{
				return ObjectType.XmlPort;
			}
		}

		public XmlPortProperties Properties
		{
			get;
			internal set;
		}

		public XmlPortNodes Nodes
		{
			get;
			internal set;
		}

		public Code Code
		{
			get;
			internal set;
		}

		public override System.Collections.Generic.IEnumerable<INode> ChildNodes
		{
			get
			{
				foreach (var childNode in base.ChildNodes)
				{
					yield return childNode;
				}

				yield return Properties;
				yield return Nodes;
				yield return Code;
			}
		}

		public bool Equals(XmlPort other)
		{
			if (other == null)
				return false;

			if (other.ID == ID)
				return true;

			if (other.Name == Name)
				return true;

			return false;
		}
	}
}

