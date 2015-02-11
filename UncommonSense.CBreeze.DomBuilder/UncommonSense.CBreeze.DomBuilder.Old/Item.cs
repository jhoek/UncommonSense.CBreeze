using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder
{
	public class Item : Node
	{
		private string keyAttributeName;
		private bool autoCreateContainer;
		private List<Attribute> attributes = new List<Attribute>();
		private List<string> uniqueAttributeNames = new List<string>();
		private List<Property> properties = new List<Property>();

		public bool AutoCreateContainer
		{
			get
			{
				return this.autoCreateContainer;
			}
			set
			{
				this.autoCreateContainer = value;
			}
		}

		public bool Derived
		{
			get
			{
				return !string.IsNullOrEmpty(this.BaseItemName);
			}
		}


		public Item BaseItem
		{
			get
			{
				if (string.IsNullOrEmpty(BaseItemName)) return null;

				return Dom.Nodes.OfType<Item>().FirstOrDefault(i => i.Name == BaseItemName);
			}
		}

		public IEnumerable<Attribute> ChildNodes
		{
			get
			{
				return this.childNodes;
			}
		}

		public IEnumerable<Attribute> Attributes // "OwnAttributes"
		{
			get
			{
				return this.attributes;
			}
		}

		public IEnumerable<Attribute> InheritedAttributes
		{
			get
			{
				var baseItem = BaseItem;

				while (baseItem != null) {
					foreach (var attribute in baseItem.Attributes) {
						yield return attribute;
					}

					baseItem = baseItem.BaseItem;
				}
			}
		}

		public IEnumerable<Attribute> AllAttributes
		{
			get
			{
				return Attributes.Concat(InheritedAttributes);
			}
		}

		public string KeyAttributeName
		{
			get
			{
				return this.keyAttributeName;
			}
			set
			{
				this.keyAttributeName = value;
			}
		}


	}
}
