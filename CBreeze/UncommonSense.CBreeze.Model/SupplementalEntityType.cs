using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
	public class SupplementalEntityType : EntityType, ISubsidiaryTo
	{
		private string name;
		private string pluralName;
		private DescriptionStyle descriptionStyle = DescriptionStyle.Description;
		private DescriptionLength descriptionLength = DescriptionLength.Normal;

		internal SupplementalEntityType(ApplicationDesign applicationDesign, string name, string pluralName) : base(applicationDesign)
		{
			this.name = name;
			this.pluralName = pluralName;
		}

		public string Name
		{
			get
			{
				return this.name;
			}
		}

		public string PluralName
		{
			get
			{
				return this.pluralName;
			}
		}

		public DescriptionStyle DescriptionStyle
		{
			get
			{
				return this.descriptionStyle;
			}
			set
			{
				this.descriptionStyle = value;
			}
		}

		public DescriptionLength DescriptionLength
		{
			get
			{
				return descriptionLength;
			}
			set
			{
				descriptionLength = value;
			}
		}
	}
}
