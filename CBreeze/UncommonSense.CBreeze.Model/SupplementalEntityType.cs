using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Model
{
	public class SupplementalEntityType : EntityType, ISubsidiaryTo
	{
		public SupplementalEntityType(string name, string pluralName) 
		{
			Name = name;
			PluralName = pluralName;
            DescriptionStyle = DescriptionStyle.Description;
            DescriptionLength = DescriptionLength.Normal;
		}

		public string Name
		{
			get;
            internal set;
		}

		public string PluralName
		{
			get;
            internal set;
		}

		public DescriptionStyle DescriptionStyle
		{
			get;
             set;
		}

        public DescriptionLength DescriptionLength
        {
            get;
            set;
        }
	}
}
