using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.ObjectModelBuilder;

namespace UncommonSense.CBreeze
{
	public static partial class ExtensionMethods
	{
		public static PropertyCollection AddProperty(this PropertyCollection propertyCollection, string typeName, string name = null)
		{
			var property = new Property(name ?? typeName, typeName);
			propertyCollection.Add(property);

			return propertyCollection;
		}
	}
}
