using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class Application : INode
    {
        public Application(params Object[] objects)
        {
            Tables = new Tables(this, objects.OfType<Table>());
            Pages = new Pages(this, objects.OfType<Page>());
            Reports = new Reports(this, objects.OfType<Report>());
            XmlPorts = new XmlPorts(this, objects.OfType<XmlPort>());
            Codeunits = new Codeunits(this, objects.OfType<Codeunit>());
            Queries = new Queries(this, objects.OfType<Query>());
            MenuSuites = new MenuSuites(this, objects.OfType<MenuSuite>());
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

        public IEnumerable<int> IDRange { get; set; }
        public IEnumerable<int> UIDRange { get; set; }

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

        public INode ParentNode => null;

        IEnumerable<INode> INode.ChildNodes
        {
            get
            {
                yield return Tables;
                yield return Pages;
                yield return Reports;
                yield return XmlPorts;
                yield return Codeunits;
                yield return Queries;
                yield return MenuSuites;
            }
        }
    }
}
