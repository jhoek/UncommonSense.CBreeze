using System;

namespace CBreeze.NextGen
{
	public class TriggerProperty : ReferenceProperty<Trigger>
	{
		internal TriggerProperty(string name) : base(name)
		{
		}

		public override bool HasValue
		{
			get
			{
				return false; // FIXME
			}
		}
	}
}

