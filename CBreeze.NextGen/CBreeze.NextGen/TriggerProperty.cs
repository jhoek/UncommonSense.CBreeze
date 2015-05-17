using System;
using System.Linq;

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
                return (Value.Variables.Any()); // FIXME
			}
		}

        public override System.Collections.Generic.IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Value.Variables;
            }
        }
	}
}

