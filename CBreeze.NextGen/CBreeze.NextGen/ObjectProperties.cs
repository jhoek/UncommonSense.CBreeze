using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class ObjectProperties : Properties
	{
		private NullableDateTimeProperty dateTime = new NullableDateTimeProperty("DateTime");
		private NullableBoolProperty modified = new NullableBoolProperty("Modified");
		private StringProperty versionList = new StringProperty("VersionList");

		internal ObjectProperties(Node parentNode)
			: base(parentNode)
		{
		}

		public override string ToString()
		{
			return "ObjectProperties";
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

		public override IEnumerable<INode> ChildNodes
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

