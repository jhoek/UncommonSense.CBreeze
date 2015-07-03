using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class Report: Object, IEquatable<Report>
	{
		public Report(int id, string name)
			: base(id, name)
		{
		}

		public override ObjectType Type
		{
			get
			{
				return ObjectType.Report;
			}
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				foreach (var childNode in ChildNodes)
				{
					yield return childNode;
				}
			}
		}

		public bool Equals(Report other)
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

