using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
		public class Application
	{
		public Application()
		{
			Tables = new Tables();
			Pages = new Pages();
			Reports = new Reports();
			XmlPorts = new XmlPorts();
			Codeunits = new Codeunits();
			Queries = new Queries();
			MenuSuites = new MenuSuites();
		}

		public Tables Tables
		{
			get;
			protected set;
		}

		public Pages Pages
		{
			get;
			protected set;
		}

		public Reports Reports
		{
			get;
			protected set;
		}

		public XmlPorts XmlPorts
		{
			get;
			protected set;
		}

		public Codeunits Codeunits
		{
			get;
			protected set;
		}

		public Queries Queries
		{
			get;
			protected set;
		}

		public MenuSuites MenuSuites
		{
			get;
			protected set;
		}

        public IEnumerable<Object> Objects
        {
            get
            {
                return
                    Tables
                    .AsEnumerable<Object>()
                    .Concat(Pages.AsEnumerable<Object>())
                    .Concat(Reports.AsEnumerable<Object>())
                    .Concat(XmlPorts.AsEnumerable<Object>())
                    .Concat(Codeunits.AsEnumerable<Object>())
                    .Concat(Queries.AsEnumerable<Object>())
                    .Concat(MenuSuites.AsEnumerable<Object>());
            }
        }
	}
}
