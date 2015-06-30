using System;
using UncommonSense.CBreeze.ObjectModelBuilder;
using UncommonSense.CBreeze.ObjectModelWriter;

namespace UncommonSense.CBreeze
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			new ObjectModel(
				"UncommonSense.CBreeze.70.Core",
				new Item(
					"Application",
					new ChildNode("Tables"),
					new ChildNode("Pages")
				)
			).WriteToFolder(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
		}
	}
}
