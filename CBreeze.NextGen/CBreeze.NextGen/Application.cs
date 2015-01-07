using System.Collections.Generic;

namespace CBreeze.NextGen
{
    public class Application : Node
    {
        private Tables tables;
        private Pages pages;
        private Reports reports;

        public Application()
        {
            this.tables = new Tables(this);
            this.pages = new Pages(this);
            this.reports = new Reports(this);
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
            }
        }

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
    }
}

