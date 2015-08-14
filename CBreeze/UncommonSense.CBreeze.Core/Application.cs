using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class Application
    {
        private Tables tables = new Tables();
        private Pages pages = new Pages();
        private Reports reports = new Reports();
        private XmlPorts xmlPorts = new XmlPorts();
        private Codeunits codeunits = new Codeunits();
        private Queries queries = new Queries();
        private MenuSuites menuSuites = new MenuSuites();

        public Tables Tables
        {
            get
            {
                return this.tables;
            }
        }

        public Pages Pages
        {
            get
            {
                return this.pages;
            }
        }

        public Reports Reports
        {
            get
            {
                return this.reports;
            }
        }

        public XmlPorts XmlPorts
        {
            get
            {
                return this.xmlPorts;
            }
        }

        public Codeunits Codeunits
        {
            get
            {
                return this.codeunits;
            }
        }

        public Queries Queries
        {
            get
            {
                return this.queries;
            }
        }

        public MenuSuites MenuSuites
        {
            get
            {
                return this.menuSuites;
            }
        }

    }
}
