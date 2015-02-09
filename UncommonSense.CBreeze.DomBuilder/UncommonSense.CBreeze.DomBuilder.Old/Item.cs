using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder
{
	public class Item : Node
	{
		private string name;
		private string baseItemName;
		private bool @abstract;
		private string keyAttributeName;
		private bool autoCreateContainer;
		private List<Attribute> attributes = new List<Attribute>();
		private List<Attribute> childNodes = new List<Attribute>();
		private List<string> uniqueAttributeNames = new List<string>();
		private List<Property> properties = new List<Property>();

		public Item(string name)
		{
			this.name = name;
		}

		public Attribute AddAttribute(Attribute attribute)
		{
			attribute.Item = this;
			this.attributes.Add(attribute);
			return attribute;
		}

		public Attribute AddChildNode(Attribute attribute)
		{
			attribute.Item = this;
			this.childNodes.Add(attribute);
			return attribute;
		}

		public void AddUniqueAttributeName(string uniqueAttributeName)
		{
			uniqueAttributeNames.Add(uniqueAttributeName);
		}

		public Property AddProperty(Property property)
		{
			property.Item = this;
			this.properties.Add(property);
			return property;
		}

		public override string Name
		{
			get
			{
				return this.name;
			}
		}

		public string BaseItemName
		{
			get
			{
				return this.baseItemName;
			}
			set
			{
				this.baseItemName = value;
			}
		}

		public bool Abstract
		{
			get
			{
				return this.@abstract;
			}
			set
			{
				this.@abstract = value;
			}
		}

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

		public IEnumerable<string> UniqueAttributeNames
		{
			get
			{
				return this.uniqueAttributeNames;
			}
		}

		public IEnumerable<Property> Properties
		{
			get
			{
				return this.properties;
			}
		}
	}
}
