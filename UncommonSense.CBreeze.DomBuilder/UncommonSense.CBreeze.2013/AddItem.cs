using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UncommonSense.CBreeze.ObjectModelBuilder;

namespace UncommonSense.CBreeze
{
	public static partial class ExtensionMethods
	{
		public static Item AddItem(this ObjectModel objectModel, string name, string baseTypeName = null, bool @abstract = false, bool createContainer = false, string containerName = null)
		{
			var item = new Item(name);
			item.BaseTypeName = baseTypeName;
			item.Abstract = @abstract;

			if (createContainer)
			{
				objectModel.AddContainer(name, containerName);
			}

			if (@abstract)
			{
				objectModel.AddEnum(string.Format("{0}Type", name));
			}

			if (!string.IsNullOrEmpty(baseTypeName))
			{
				var enumeration = objectModel.Elements.OfType<Enumeration>().First(e => e.Name == string.Format("{0}Type", baseTypeName));
				enumeration.Values.Add(Regex.Replace(name, baseTypeName + "$", ""));
			}

			return objectModel.Elements.Add(item);
		}
	}
}
