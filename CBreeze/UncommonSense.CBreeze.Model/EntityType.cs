using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
	public abstract class EntityType
	{
		private ApplicationDesign applicationDesign;

		internal EntityType(ApplicationDesign applicationDesign)
		{
			this.applicationDesign = applicationDesign;
		}

		public ApplicationDesign ApplicationDesign
		{
			get
			{
				return applicationDesign;
			}
		}
	}
}
