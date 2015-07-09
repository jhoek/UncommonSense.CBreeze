using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
	public abstract class EntityType
	{
		public ApplicationDesign ApplicationDesign
		{
			get;
            internal set;
		}
	}
}
