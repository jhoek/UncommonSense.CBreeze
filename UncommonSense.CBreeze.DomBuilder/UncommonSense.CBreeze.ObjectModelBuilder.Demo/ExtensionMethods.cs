using System;

namespace UncommonSense.CBreeze.ObjectModelBuilder.Demo
{
	public static class ExtensionMethods
	{
		public static Item MakeAbstract(this Item item)
		{
			item.Abstract = true;
			return item;
		}
	}
}

