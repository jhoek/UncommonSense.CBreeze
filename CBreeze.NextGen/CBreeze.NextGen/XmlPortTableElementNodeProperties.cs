using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
	public class XmlPortTableElementNodeProperties : Properties
	{
		private NullableBoolProperty autoReplace = new NullableBoolProperty("AutoReplace");
		private NullableBoolProperty autoSave = new NullableBoolProperty("AutoSave");
		private NullableBoolProperty autoUpdate = new NullableBoolProperty("AutoUpdate");

		internal XmlPortTableElementNodeProperties(Node parentNode)
			: base(parentNode)
		{
		}

		public bool? AutoReplace
		{
			get
			{
				return this.autoReplace.Value;
			}
			set
			{
				this.autoReplace.Value = value;
			}
		}

		public bool? AutoSave
		{
			get
			{
				return this.autoSave.Value;
			}
			set
			{
				this.autoSave.Value = value;
			}
		}

		public bool? AutoUpdate
		{
			get
			{
				return this.autoUpdate.Value;
			}
			set
			{
				this.autoUpdate.Value = value;
			}
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return autoReplace;
				yield return autoSave;
				yield return autoUpdate;
			}
		}
	}
}
