using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
	public class SetupEntityType : EntityType
	{
		public SetupEntityType(string name)
		{
			Name = name;
		}

		public string Name
		{
			get;
            internal set;
		}
	}
}
