using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class Codeunit : Object, IEquatable<Codeunit>
	{
		public Codeunit(int id, string name)
			: base(id, name)
		{
			Properties = new CodeunitProperties(this);
			Code = new Code(this);
		}

		public override ObjectType Type
		{
			get
			{
				return ObjectType.Codeunit;
			}
		}

		public CodeunitProperties Properties
		{
			get;
			internal set;
		}

		public Code Code
		{
			get;
			internal set;
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				foreach (var childNode in base.ChildNodes)
				{
					yield return childNode;
				}

				yield return Properties;
				yield return Code;
			}
		}

		public bool Equals(Codeunit other)
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

