using System.Collections.Generic;
using System.Linq;

namespace CBreeze.NextGen
{
	public class Application : Node
	{
		public Application()
		{
			Tables = new Tables(this);
			Pages = new Pages(this);
			Reports = new Reports(this);
			Codeunits = new Codeunits(this);
			Queries = new Queries(this);
			XmlPorts = new XmlPorts(this);
			// FIXME: MenuSuites = new MenuSuites(this);
		}

		public override string ToString()
		{
			return "Application";
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return Tables;
				yield return Pages;
				yield return Reports;
				yield return Codeunits;
                yield return Queries;
				yield return XmlPorts;
			}
		}

		public Tables Tables
		{
			get;
			internal set;
		}

		public Pages Pages
		{
			get;
			internal set;
		}

		public Reports Reports
		{
			get;
			internal set;
		}

		public Codeunits Codeunits
		{
			get;
			internal set;
		}

        public Queries Queries
        {
            get;
            internal set;
        }

		public XmlPorts XmlPorts
		{
			get;
			internal set;
		}
	}
}

