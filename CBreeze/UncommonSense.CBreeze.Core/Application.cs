using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class Application
    {
        public Application(params Object[] objects) 
        {
            Tables = new Tables(objects.OfType<Table>());
            Pages = new Pages(objects.OfType<Page>());
            Reports = new Reports(objects.OfType<Report>());
            XmlPorts = new XmlPorts(objects.OfType<XmlPort>());
            Codeunits = new Codeunits(objects.OfType<Codeunit>());
            Queries = new Queries(objects.OfType<Query>());
            MenuSuites = new MenuSuites(objects.OfType<MenuSuite>());
        }

        public void Clear()
        {
            Tables.Clear();
            Pages.Clear();
            Reports.Clear();
            XmlPorts.Clear();
            Codeunits.Clear();
            Queries.Clear();
            MenuSuites.Clear();
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
