using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder
{
	public class Dom : Node
	{
		private string @namespace;

		public Dom(string @namespace, params Node[] childNodes)
		{
			this.@namespace = @namespace;
			this.ChildNodes.AddRange(Dom, this, childNodes);
		}

        public override string Name
        {
            get
            {
                return Namespace;
            }
        }

		public string Namespace
		{
			get
			{
				return this.@namespace;
			}
		}
	}
}
