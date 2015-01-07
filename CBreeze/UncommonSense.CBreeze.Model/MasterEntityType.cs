using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
	public class MasterEntityType : EntityType, ISubsidiaryTo
	{
		private string name;
        private SetupEntityType setupEntityType;
		private DescriptionStyle descriptionStyle = DescriptionStyle.Description;
		private bool hasDescription2Field = true;
		private bool hasSearchDescriptionField = true;
		private bool hasLastDateModifiedField = true;
		private bool hasStatisticsPage = true;

		internal MasterEntityType(ApplicationDesign applicationDesign, string name, SetupEntityType setupEntityType) : base(applicationDesign)
		{
			this.name = name;
            this.setupEntityType = setupEntityType;
		}

		public string Name
		{
			get
			{
				return this.name;
			}
		}

        public SetupEntityType SetupEntityType
        {
            get
            {
                return this.setupEntityType;
            }
        }

		public DescriptionStyle DescriptionStyle
		{
			get
			{
				return descriptionStyle;
			}
			set
			{
				descriptionStyle = value;
			}
		}

		public bool HasDescription2Field
		{
			get
			{
				return hasDescription2Field;
			}
			set
			{
				hasDescription2Field = value;
			}
		}

		public bool HasSearchDescriptionField
		{
			get
			{
				return hasSearchDescriptionField;
			}
			set
			{
				hasSearchDescriptionField = value;
			}
		}

		public bool HasDateLastModifiedField
		{
			get
			{
				return hasLastDateModifiedField;
			}
			set
			{
				hasLastDateModifiedField = value;
			}
		}

		public bool HasStatisticsPage
		{
			get
			{
				return hasStatisticsPage;
			}
			set
			{
				hasStatisticsPage = value;
			}
		}
	}
}
