using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
	public class XmlPortTextElementNodeProperties : Properties
	{
		private MaxOccursProperty maxOccurs = new MaxOccursProperty("MaxOccurs");
		private NullableValueProperty<MinOccurs> minOccurs = new NullableValueProperty<MinOccurs>("MinOccurs");


		internal XmlPortTextElementNodeProperties(Node parentNode)
			: base(parentNode)
		{
		}

		public MaxOccurs? MaxOccurs
		{
			get
			{
				return this.maxOccurs.Value;
			}
			set
			{
				this.maxOccurs.Value = value;
			}
		}

		public MinOccurs? MinOccurs
		{
			get
			{
				return this.minOccurs.Value;
			}
			set
			{
				this.minOccurs.Value = value;
			}
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return maxOccurs;
			}
		}
	}
}
