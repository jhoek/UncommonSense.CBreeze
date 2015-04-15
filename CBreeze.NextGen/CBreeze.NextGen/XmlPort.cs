using System;

namespace CBreeze.NextGen
{
	public class XmlPort : Object, IEquatable<XmlPort>
	{
		public XmlPort(int id, string name) :
			base(id, name)
		{
		}

		public override ObjectType Type
		{
			get
			{
				return ObjectType.XmlPort;
			}
		}

		public override System.Collections.Generic.IEnumerable<INode> ChildNodes
		{
			get
			{
				yield break; // FIXME
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

