using System;
using System.Linq;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class CodeTableFieldProperties : Properties
	{
		private ReferenceProperty<MultiLanguageValue> captionML = new ReferenceProperty<MultiLanguageValue>("CaptionML");
		private ValueProperty<bool?> notBlank = new ValueProperty<bool?>("NotBlank");

		internal CodeTableFieldProperties(Node parentNode)
			: base(parentNode)
		{
		}

		public override string ToString()
		{
			return "Properties";
		}

		public MultiLanguageValue CaptionML
		{
			get
			{
				return this.captionML.Value;
			}
		}

		public bool? NotBlank
		{
			get
			{
				return this.notBlank.Value;
			}
			set
			{
				this.notBlank.Value = value;
			}
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return captionML;
				yield return notBlank;
			}
		}
	}
}

