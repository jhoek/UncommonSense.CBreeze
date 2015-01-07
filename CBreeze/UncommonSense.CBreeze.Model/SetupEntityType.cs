using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
	public class SetupEntityType : EntityType
	{
		private string name;

		public SetupEntityType(ApplicationDesign applicationDesign, string name) : base(applicationDesign)
		{
			this.name = name;
		}

		public string Name
		{
			get
			{
				return this.name;
			}
		}
	}
}
