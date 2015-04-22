using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
	public class Item : ObjectModelElement
	{
		public Item(string name)
			: base(name)
		{
			Attributes = new Dictionary<string, string>(); // name, type
		}

		public bool Abstract
		{
			get;
			set;
		}

		public Dictionary<string, string> Attributes
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
