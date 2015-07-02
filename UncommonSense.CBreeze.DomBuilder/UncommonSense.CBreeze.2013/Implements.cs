using System;
using UncommonSense.CBreeze.ObjectModelBuilder;

namespace UncommonSense.CBreeze
{
	public static partial class ExtensionMethods
	{
		public static Item Implements(this Item item, string interfaceName)
		{
			item.ImplementedInterfaces.Add(interfaceName);
			return item;
		}
	}
}

