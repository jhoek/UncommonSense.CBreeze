using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
	public class Item : ObjectModelElement
	{
		public Item(string name, params Attribute[] attributes) : this(name, null, attributes)
		{
		}

		public Item(string name, string baseTypeName, params Attribute[] attributes) : base(name)
		{
			BaseTypeName = baseTypeName;
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

        public IEnumerable<Attribute> InheritedAttributes
        {
            get
            {
                if (BaseType != null)
                {
                    foreach (var attribute in BaseType.AllAttributes)
                    {
                        yield return attribute;
                    }
                }
            }
        }

        public IEnumerable<Attribute> AllAttributes
        {
            get
            {
                foreach (var attribute in InheritedAttributes)
                {
                    yield return attribute;
                }

                foreach (var attribute in Attributes)
                {
                    yield return attribute;
                }
            }
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
