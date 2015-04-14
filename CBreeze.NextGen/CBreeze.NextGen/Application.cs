using System.Collections.Generic;
using System.Linq;

namespace CBreeze.NextGen
{
	public class Application : Node
	{
		public Application(params Object[] objects)
		{
			Tables = new Tables(this, objects.OfType<Table>().ToArray());
			Pages = new Pages(this, objects.OfType<Page>().ToArray());
			Reports = new Reports(this, objects.OfType<Report>().ToArray());
			Codeunits = new Codeunits(this, objects.OfType<Codeunit>().ToArray());
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
	}
}

