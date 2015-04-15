using System;
using System.Linq;

namespace CBreeze.NextGen
{
	public class MultiLanguageProperty : ReferenceProperty<MultiLanguageValue>
	{
		internal MultiLanguageProperty(string name)
			: base(name)
		{
		}

		public override bool HasValue
		{
			get
			{
				return Value.Any();
			}
		}
	}
}

