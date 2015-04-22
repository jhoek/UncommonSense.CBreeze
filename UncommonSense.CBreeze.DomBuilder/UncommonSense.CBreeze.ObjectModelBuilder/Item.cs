using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
	public class Item : ObjectModelElement
	{
		public Item(string name, params Attribute[] attributes)
			: base(name)
		{
			Attributes = new Attributes(this);

			Attributes.AddRange(attributes);
		}

		public bool Abstract
		{
			get;
			set;
		}

		public Attributes Attributes
		{
			get;
			internal set;
		}

		public Item BaseType
		{
			get
			{
				return ObjectModel.Elements.OfType<Item>().FirstOrDefault(i => i.Name == BaseTypeName);
			}
		}

		public string BaseTypeName
		{
			get;
			set;
		}
	}
}
