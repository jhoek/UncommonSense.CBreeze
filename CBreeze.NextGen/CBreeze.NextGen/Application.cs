using System.Collections.Generic;

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
			MenuSuites = new MenuSuites(this);
		}

		public override string ToString()
		{
			return "Application";
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

		public MenuSuites MenuSuites
		{
			get;
			internal set;
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				foreach(var childNode in base.ChildNodes)
				{
					yield return childNode;
				}

				yield return Tables;
				yield return Pages;
				yield return Reports;
				yield return Codeunits;
				yield return Queries;
				yield return XmlPorts;
				yield return MenuSuites;
			}
		}
	}
}
