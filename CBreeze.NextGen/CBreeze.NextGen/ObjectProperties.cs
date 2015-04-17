using System;
using System.Collections.Generic;
using System.Linq;

namespace CBreeze.NextGen
{
	public class ObjectProperties : IProperties, INode
	{
		private NullableDateTimeProperty dateTime = new NullableDateTimeProperty("DateTime");
		private NullableBoolProperty modified = new NullableBoolProperty("Modified");
		private StringProperty versionList = new StringProperty("VersionList");

		internal ObjectProperties(Node parentNode)
		{
			ParentNode = parentNode;
		}

		public override string ToString()
		{
			return "ObjectProperties";
		}

		public Node ParentNode
		{
			get;
			internal set;
		}

		public IEnumerator<Property> GetEnumerator()
		{
			return ChildNodes.Cast<Property>().GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return ChildNodes.Cast<Property>().GetEnumerator();
		}

		public DateTime? DateTime
		{
			get
			{
				return this.dateTime.Value;
			}
			set
			{
				this.dateTime.Value = value;
			}
		}

		public bool? Modified
		{
			get
			{
				return this.modified.Value;
			}
			set
			{
				this.modified.Value = value;
			}
		}

		public string VersionList
		{
			get
			{
				return this.versionList.Value;
			}
			set
			{
				this.versionList.Value = value;
			}
		}

		public IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return dateTime;
				yield return modified;
				yield return versionList;
			}
		}
	}
}

